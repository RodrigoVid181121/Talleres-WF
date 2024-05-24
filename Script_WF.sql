USE DB_Talleres

CREATE TABLE Gas(
id int PRIMARY KEY IDENTITY,
nombre varchar(20)
)

CREATE TABLE Clientes(
id int PRIMARY KEY IDENTITY,
nombre varchar(75),
direccion varchar(150),
telefono varchar(9)
)

CREATE TABLE Documentos(
id int PRIMARY KEY IDENTITY,
llave bit not null,
tarjeta bit not null,
poliza bit not null,
alarma bit not null
)

CREATE TABLE Vehiculos(
id int PRIMARY KEY IDENTITY,
placa nchar(9) not null,
modelo varchar(50) not null,
marca varchar(50) not null,
color varchar(25) not null,
año tinyint not null,
tipo varchar(20) not null,
id_gas int FOREIGN KEY REFERENCES Gas(id),
id_cliente int FOREIGN KEY REFERENCES Clientes(id),
id_docs int FOREIGN KEY REFERENCES Documentos(id),
receptor varchar(75)
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

CREATE TABLE Servicios(
id int IDENTITY PRIMARY KEY,
id_vehiculo int FOREIGN KEY REFERENCES Vehiculos(id),
id_cliente int FOREIGN KEY REFERENCES Clientes(id),
id_docs int FOREIGN KEY REFERENCES Documentos(id),
gas_recibido varchar(3) not null,
fecha_in date not null,
km_in float,
mil_in float,
fecha_out date not null,
km_out float,
mil_out float,
pintura image not null,
receptor varchar(75) not null,
id_con int FOREIGN KEY REFERENCES Condiciones(id),
comentarios varchar(500) 
)

CREATE TABLE Productos(
id int PRIMARY KEY IDENTITY,
codigo nchar(8) not null,
cantidad smallint not null,
precio_costo decimal(5,2) not null,
precio_venta decimal(5,2) not null,
modelo_vehiculo varchar(50)
)

CREATE TABLE Contabilidad(
id int PRIMARY KEY IDENTITY,
tipo_trans varchar(50) not null,
concepto varchar(75) not null,
monto decimal(5,2) not null,
tipo_pago varchar(25) not null,
balance decimal(11,2) not null
)