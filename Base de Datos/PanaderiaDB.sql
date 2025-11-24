create database panaderia;
use panaderia;

create table Usuarios (
    userID int primary key auto_increment,
    user varchar(20) unique not null,
    nombre varchar(50) not null,
    apellidos varchar(50) not null,
    email varchar(100),
    telefono varchar(10) not null,
    password varchar(255),
    fechaNacimiento date not null,
    fechaCreacion datetime default current_timestamp,
    rol enum('Administrador', 'Empleado') not null
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
    importe decimal(10,2),
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

insert into usuarios(user, nombre, apellidos, email, telefono, password, fechaNacimiento, rol)
values('Admin1', 'Alan', 'Fonseca', 'yalan@gmail.com', '4451234567', sha2('admin', 256), '2005-12-30', 1);

select * from usuarios;

/*
delimiter $$
-- 1. Trigger para insertar (No hay valor anterior, solo nuevo)
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
        concat('ID:', new.clave, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio), 
        user()
    );
end $$
delimiter ;


delimiter $$
-- 2. Trigger para actualizar (Hay valor anterior y nuevo)
create trigger trUpdateProducto
after update on Productos
for each row
begin
    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(), 'UPDATE', 
        concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio), 
        concat('ID:', new.ProductoID, ' | ', new.nombre, ' | Stock:', new.stock, ' | $', new.precio));
end $$
delimiter ;



delimiter $$
-- 3. Trigger para eliminar (Solo hay valor anterior)
create trigger trBorrarProducto
after delete on Productos
for each row
begin
    insert into AuditoriaProductos (fecha, hora, tipoCambio, valorAnterior, valorNuevo, usuario)
    values (curdate(), curtime(), 'DELETE', concat('ID:', old.ProductoID, ' | ', old.nombre, ' | Stock:', old.stock, ' | $', old.precio),'Eliminado');
end $$
delimiter ;


delimiter $$
-- crear Empleado
create procedure spCrearEmp(in usu varchar(20), nom varchar(50), in ape varchar(50), in emaill varchar(100), in tel int , in pass varchar(255), in feNac datetime, in roll varchar(20))
begin
    insert into Usuarios (user, nombre, apellidos, email, telefono, password, fechaNacimiento, rol)
    values (usu, nombre, apellidos, emaill, tel, sha2(pass, 256), fecNac, roll);
end $$
delimiter ;



delimiter $$
create procedure spLeerEmp()
begin
    select * from Usuarios;
end $$
delimiter ;



delimiter $$
-- Aactualizar Empleado
create procedure spActualizarEmp(in uID int, in us varchar(20), in nom varchar(50), in ape varchar(50), in roll varchar(20))
begin
    update Usuarios 
    set usuario = us, nombre = nom, apellidos = ape, rol = roll
    where usuarioID = uID;
end $$
delimiter ;



delimiter $$
-- Eliminar Empleado
create procedure spEliminarEmp(in uID int)
begin
    delete from Usuarios where usuarioID = uID;
end $$
delimiter ;
*/