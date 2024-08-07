USE DB_Talleres

CREATE TABLE cargos (
id_cargo int PRIMARY KEY IDENTITY,
nombre_cargo varchar(20) not null
)
INSERT INTO cargos(nombre_cargo) VALUES ('Administrador'), ('Operador')

CREATE TABLE Usuarios(
id_usuario int PRIMARY KEY IDENTITY,
nombre varchar(20) not null,
apellido varchar(20) not null,
codigo nchar(6) not null UNIQUE,
contrase�a varchar(100),
id_cargo int FOREIGN KEY REFERENCES cargos(id_cargo) ON UPDATE CASCADE ON DELETE CASCADE
)

INSERT INTO Usuarios(nombre,apellido,codigo,contrase�a,id_cargo)
VALUES('Rodrigo','Vides','VN1917','aefd843245aacf390df832f2d491dc0c199d20aef0cf53572ed106ff5082dd8e',1)

--DROP TABLE Proveedores
--CREATE TABLE Proveedores(
--id_proveedor int PRIMARY KEY IDENTITY,
--nombre_proveedor varchar(50) not null,
--codigo_proveedor nchar(6) not null,
--descripcion varchar(200) not null,
--correo varchar(50) not null,
--telefono  varchar(8) not null
--)

CREATE TABLE Gas(
id int PRIMARY KEY IDENTITY,
nombre varchar(20)
)

INSERT INTO Gas(nombre) VALUES ('Diesel'),('Gasolina')

CREATE TABLE Clientes(
id int PRIMARY KEY IDENTITY,
nombre varchar(75),
telefono varchar(9) UNIQUE
)

CREATE TABLE Documentos(
id int PRIMARY KEY IDENTITY,
llave bit not null,
tarjeta bit not null,
poliza bit not null,
alarma bit not null
)

CREATE TABLE Condiciones(
id int PRIMARY KEY IDENTITY,
radio bit not null,
mascara_radio bit not null,
perilla_cal bit not null,
aire_ac bit not null,
cont_alar bit not null,
pito bit not null,
esp_int bit not null,
esp_ext bit not null,
antena bit not null,
tapa_llanta bit not null,
emblema_lat bit not null,
emblema_post bit not null,
gato bit not null,
llave_rueda bit not null,
herramientas bit not null,
kit_carretera bit not null,
tapa_gas bit not null,
encendedor bit not null,
tapa_liq_frenos bit not null,
tapa_fusibles bit not null,
alfombras bit not null,
llanta_emergencia bit not null,
copa_llantas bit not null,
cable_corriente bit not null,
)

CREATE TABLE Vehiculos(
id int PRIMARY KEY IDENTITY,
placa nchar(9) not null UNIQUE,
modelo varchar(50) not null,
marca varchar(50) not null,
color varchar(25) not null,
a�o int not null,
tipo varchar(20) not null,
id_gas int FOREIGN KEY REFERENCES Gas(id),
id_cliente int FOREIGN KEY REFERENCES Clientes(id),
id_docs int FOREIGN KEY REFERENCES Documentos(id),
id_con int FOREIGN KEY REFERENCES Condiciones(id),
)
CREATE TABLE ListaServicios(
id int IDENTITY PRIMARY KEY,
nombre varchar(100) not null 
)
--El estado 1 es activo 0 es finalizado
--Anulado 1 es anulado y 0 es no anulado
CREATE TABLE Servicios(
id int IDENTITY PRIMARY KEY,
id_vehiculo int FOREIGN KEY REFERENCES Vehiculos(id),
id_servicio int FOREIGN KEY REFERENCES ListaServicios(id),
gas_recibido varchar(3) not null,
estado bit not null,
anulado bit not null,
fecha_in varchar(10) not null,
km_in int,
mil_in int,
fecha_out varchar(10),
km_out int,
mil_out int,
pintura nvarchar(MAX) not null,
receptor varchar(75) not null,
mecanico varchar(75) not null,
encargado_vehi varchar(75),
cargo_en varchar(50),
comentarios varchar(500) 
)

CREATE TABLE Categorias(
id int PRIMARY KEY IDENTITY,
nombre varchar(75) not null
)

CREATE TABLE Marcas(
id int PRIMARY KEY IDENTITY,
nombre varchar(75) not null
)
INSERT INTO Marcas(nombre) VALUES('Sin Marca')

CREATE TABLE Productos(
id int PRIMARY KEY IDENTITY,
codigo varchar(20),
cantidad smallint not null,
medida varchar(50),
biscosidad varchar(30),
precio_venta decimal(5,2) not null,
modelo_vehiculo varchar(50),
id_marca int FOREIGN KEY REFERENCES Marcas(id) default 1,
id_categoria int FOREIGN KEY REFERENCES Categorias(id),
nombre varchar(75)
)

CREATE TABLE Venta(
id_venta int PRIMARY KEY IDENTITY,
id_usuario int FOREIGN KEY REFERENCES usuarios(id_usuario),
tipo_doc varchar(50) not null,
numero_doc int not null,
id_cliente int FOREIGN KEY REFERENCES Clientes(id),
monto_total decimal(5,2) not null,
monto_cambio decimal(5,2),
descuento int,
descripcion varchar(250),
fecha_registro datetime default getdate()
)

CREATE TABLE Detalle_Venta(
id_detalle int PRIMARY KEY IDENTITY,
id_venta int FOREIGN KEY REFERENCES Venta(id_venta),
id_producto int FOREIGN KEY REFERENCES Productos(id),
precio_venta decimal(5,2) not null,
tipo_pago varchar(25) not null,
cantidad int not null,
subtotal decimal(5,2) not null,
fecha_registro datetime default getdate()
)
--DROP TABLE Detalle_Compra
--DROP TABLE Compra
--CREATE TABLE Compra(
--id_compra int PRIMARY KEY IDENTITY,
--id_usuario int FOREIGN KEY REFERENCES Usuarios(id_usuario),
--id_proveedor int FOREIGN KEY REFERENCES Proveedores(id_proveedor),
--tipo_doc varchar(50) not null,
--numero_doc int not null,
--monto_tot decimal(5,2) not null,
--fecha_compra datetime default getdate()
--)

--CREATE TABLE Detalle_Compra(
--id_detalle_compra int PRIMARY KEY IDENTITY,
--id_compra int FOREIGN KEY REFERENCES compra(id_compra),
--id_producto int FOREIGN KEY REFERENCES Productos(id),
--precio_compra decimal(5,2) not null,
--precio_venta decimal(5,2),
--total decimal(5,2) not null,
--metodo_pago varchar(25) not null,
--fecha_compra datetime default getdate()
--)

--CREATE TABLE Contabilidad(
--id int PRIMARY KEY IDENTITY,
--tipo_trans varchar(50) not null,
--concepto varchar(75) not null,
--monto decimal(5,2) not null,
--tipo_pago varchar(25) not null,
--balance decimal(11,2) not null
--)