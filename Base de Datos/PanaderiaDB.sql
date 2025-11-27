create database if not exists panaderia;
#drop database panaderia;
use panaderia;

-- 1. Tablas
create table Usuarios (
    userID int primary key auto_increment,
    user varchar(20) unique not null,
    nombre varchar(50) not null,
    apellidos varchar(50) not null,
    email varchar(100),
    telefono varchar(15) not null, 
    password varchar(255),
    fechaNacimiento date not null,
    fechaCreacion datetime default current_timestamp,
    rol enum('Admin', 'Empleado') not null
);

create table Productos (
    ProductoID int primary key auto_increment,
    nombre varchar(50) not null, 
    descripcion varchar(100),
    precio decimal(10,2) not null,
    stock int not null,  
    fotoProducto blob
);

create table Ventas (
    ventaID int primary key auto_increment,
    fecha datetime default current_timestamp,
    total decimal(10,2),
    userID int,
    foreign key (userID) references Usuarios(userID)
);

create table DetalleVentas (
    ventaID int,
    productoID int,
    cantidad int not null,
    precioUnitario decimal(10,2) not null, 
    total decimal(10,2),
    primary key (ventaID, productoID),
    foreign key (ventaID) references Ventas(ventaID),
    foreign key (productoID) references Productos(ProductoID)
);

create table AuditoriaProductos (
    id int primary key auto_increment,
    fecha date,
    hora time,
    tipoCambio varchar(20),
    valorAnterior text,     
    valorNuevo text,
    usuario varchar(50)
);

-- 2. Insert inicial (Admin)
insert into usuarios(user, nombre, apellidos, email, telefono, password, fechaNacimiento, rol)
values('Admin1', 'Alan', 'Fonseca', 'yalan@gmail.com', '4451234567', sha2('admin', 256), '2005-12-30', 'Admin');

-- 3. Roles y Permisos
create role if not exists 'Admin', 'Empleado';
grant all privileges on panaderia.* to 'Admin';
grant select, insert on panaderia.* to 'Empleado';

-- 4. SP Login
delimiter $$
create procedure spLogin(in us varchar(20), in pas varchar(255))
begin
    -- Verificar credenciales
    select userID, rol from usuarios u 
    where u.user = us and u.password = sha2(pas, 256);
    
    -- Activar rol 
    set @userquery = CONCAT('SET DEFAULT ROLE ALL TO ''', us, '''@''localhost''');
    prepare stmt1 from @userquery;
    execute stmt1;
    deallocate prepare stmt1;
    

end $$
delimiter ;

-- 5. Triggers 

delimiter $$
-- Insert
create trigger trInsertProducto
after insert on Productos
for each row
begin
    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (
        curdate(), 
        curtime(), 
        'INSERT', 
        'N/A', 
        concat('ID:', new.ProductoID, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio),
        user()
    );
end $$

-- Update
create trigger trUpdateProducto
after update on Productos
for each row
begin
    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(), 'UPDATE', 
        concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio), 
        concat('ID:', new.ProductoID, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio),
        user());
end $$

-- Delete
create trigger trBorrarProducto
after delete on Productos
for each row
begin
    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(),
    'DELETE', concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio),'Eliminado',
    user());
end $$
delimiter ;

-- 6. SP CRUD Empleados 

delimiter $$
create procedure spCrearEmp(
    in usu varchar(20), 
    in nom varchar(50), 
    in ape varchar(50), 
    in emaill varchar(100), 
    in tel varchar(15), 
    in pass varchar(255), 
    in feNac date,     
    in roll varchar(20)
)
begin
    insert into Usuarios (user, nombre, apellidos, email, telefono, password, fechaNacimiento, rol)
    values (usu, nom, ape, emaill, tel, sha2(pass, 256), feNac, roll);
    
    -- Usuario de mysql
    set @userquery = CONCAT('CREATE USER ''', usu, '''@''localhost'' IDENTIFIED BY ''', pass, '''');
    prepare stmt1 from @userquery;
    execute stmt1;
    deallocate prepare stmt1;
    
    -- Rol en mysql 
    if(roll='Admin') then
        set @rolquery = CONCAT('GRANT ''Admin'' TO ''', usu, '''@''localhost''');
    else
        set @rolquery = CONCAT('GRANT ''Empleado'' TO ''', usu, '''@''localhost''');
    end if;
    
    prepare stmt2 from @rolquery;
    execute stmt2;
    deallocate prepare stmt2;
    
    -- Activar rol
    set @defaultrole = CONCAT('SET DEFAULT ROLE ALL TO ''', usu, '''@''localhost''');
    prepare stmt3 from @defaultrole;
    execute stmt3;
    deallocate prepare stmt3;

end $$

create procedure spLeerEmp()
begin
    select * from Usuarios;
end $$

delimiter $$
create procedure spActualizarEmp(
    in uID int, 
    in us varchar(20), 
    in nom varchar(50), 
    in ape varchar(50), 
    in roll varchar(20)
)
begin
    DECLARE oldUser VARCHAR(20);
    SELECT user INTO oldUser FROM Usuarios WHERE userID = uID;

    -- 2. Actualizar la tabla de datos
    update Usuarios 
    set user = us, nombre = nom, apellidos = ape, rol = roll
    where userID = uID;
    
    -- 3. Renombrar el usuario de MySQL (si es que cambio)
    IF oldUser != us THEN
        set @renameQuery = CONCAT('RENAME USER ''', oldUser, '''@''localhost'' TO ''', us, '''@''localhost''');
        prepare stmt1 from @renameQuery;
        execute stmt1;
        deallocate prepare stmt1;
    END IF;
    
    -- 4. Actualizar Roles
    set @revokeQuery = CONCAT('REVOKE ALL PRIVILEGES, GRANT OPTION FROM ''', us, '''@''localhost''');
    prepare stmt2 from @revokeQuery;
    execute stmt2;
    deallocate prepare stmt2;
    
    -- Asignar el nuevo rol
    if(roll='Admin') then
        set @rolquery = CONCAT('GRANT ''Admin'' TO ''', us, '''@''localhost''');
    else
        set @rolquery = CONCAT('GRANT ''Empleado'' TO ''', us, '''@''localhost''');
    end if;
    
    prepare stmt3 from @rolquery;
    execute stmt3;
    deallocate prepare stmt3;
    
    -- Activar rol
    set @defaultrole = CONCAT('SET DEFAULT ROLE ALL TO ''', us, '''@''localhost''');
    prepare stmt4 from @defaultrole;
    execute stmt4;
    deallocate prepare stmt4;

end $$
delimiter ;


delimiter $$
-- Eliminar
create procedure spEliminarEmp(in uID int)
begin
	set @us ='';
    select user into @us from Usuarios where userID = uID;
    
    set @delquery = CONCAT('drop user ''', @us, '''@''localhost''');
    prepare stmt1 from @delquery;
    execute stmt1;
    deallocate prepare stmt1;
    
    delete from Usuarios where userID = uID; 
     
end $$
delimiter ;