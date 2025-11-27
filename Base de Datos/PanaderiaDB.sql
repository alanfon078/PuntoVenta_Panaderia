create database if not exists panaderia;
use panaderia;

-- 1. Tablas
create table Usuarios (
    userID int primary key auto_increment,
    user varchar(20) unique not null,
    nombre varchar(50) not null,
    apellidos varchar(50) not null,
    email varchar(100) unique,
    telefono varchar(15) not null unique, 
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
    usuario varchar(50) -- Aquí guardaremos el usuario de la App, no el 'root'
);

-- 2. Insert inicial
INSERT INTO Usuarios (user, nombre, apellidos, email, telefono, password, fechaNacimiento, rol)
VALUES ('Admin', 'Yael', 'Ruiz', 'yalan@gmail.com', '1234567890', SHA2('admin', 256), '2005-12-30', 'Admin');

-- 3. SP Login
delimiter $$
create procedure spLogin(in us varchar(20), in pas varchar(255))
begin
    select * from Usuarios u 
    where u.user = us and u.password = sha2(pas, 256);
end $$
delimiter ;

-- 4. Triggers
-- El trigger buscará una variable definida desde C#

delimiter $$
-- Insert
create trigger trInsertProducto
after insert on Productos
for each row
begin
    -- Usar COALESCE para leer la variable de sesión
    declare appUser varchar(50);
    set appUser = COALESCE(@UsuarioActual, 'Sistema/Root');

    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (
        curdate(), 
        curtime(), 
        'INSERT', 
        'N/A', 
        concat('ID:', new.ProductoID, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio),
        appUser
    );
end $$

-- Update
create trigger trUpdateProducto
after update on Productos
for each row
begin
    declare appUser varchar(50);
    set appUser = COALESCE(@UsuarioActual, 'Sistema/Root');

    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(), 'UPDATE', 
        concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio), 
        concat('ID:', new.ProductoID, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio),
        appUser);
end $$

-- Delete
create trigger trBorrarProducto
after delete on Productos
for each row
begin
    declare appUser varchar(50);
    set appUser = COALESCE(@UsuarioActual, 'Sistema/Root');

    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(),
    'DELETE', concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio),'Eliminado',
    appUser);
end $$
delimiter ;

-- 5. SP CRUD Empleados

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
end $$

create procedure spLeerEmp()
begin
    select * from Usuarios;
end $$

create procedure spActualizarEmp(
    in uID int, 
    in us varchar(20), 
    in nom varchar(50), 
    in ape varchar(50), 
    in roll varchar(20)
)
begin
    update Usuarios 
    set user = us, nombre = nom, apellidos = ape, rol = roll
    where userID = uID;
end $$

create procedure spEliminarEmp(in uID int)
begin
    delete from Usuarios where userID = uID; 
end $$
delimiter ;