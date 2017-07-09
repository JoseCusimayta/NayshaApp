create table Prendas
(
Codigo char (6) primary key,
Prenda varchar (20),
Color varchar (20),
Talla varchar (8),
PxMayor numeric(7,2),
PxMenor numeric(7,2),
Estado varchar (11),
Orden int
)
go

create table HistorialPrendas
(
Historial int identity (1,1) primary key,
Codigo char (6),
Prenda varchar (20),
Color varchar (20),
Talla varchar (8),
PxMayor numeric(7,2),
PxMenor numeric(7,2),
Estado varchar (11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)
go

create table Tiendas
(
Codigo char (6) primary key,
Tienda varchar(50),
Vendedor varchar(20),
Fecha_Inicio date,
Fecha_Cierre date,
Alquiler numeric (7,2),
Estado varchar (11),
Orden int
)
go

create table HistorialTiendas
(
Historial int identity (1,1) primary key,
Codigo char (6),
Tienda varchar(20),
Vendedor varchar(20),
Fecha_Inicio date,
Fecha_Cierre date,
Alquiler numeric (7,2),
Estado varchar (11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)
go

create table EntradasSalidas
(
Codigo int identity (1,1) primary key,
Boleta char (13),
Salida char(20),
Ingreso char(20),
Prenda char(20),
CodigoPrenda char(6),
Cantidad int,
Fecha date,
Estado char(11),
Orden int
)
go

create table HistorialEntradasSalidas
(
Historial int identity (1,1) primary key,
Codigo int,
Boleta char (13),
Salida char(20),
Ingreso char(20),
Prenda char(20),
CodigoPrenda char(6),
Cantidad int,
Fecha date,
Estado char(11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)
go

create table Ventas
(
Codigo int identity (1,1) primary key,
Boleta varchar (13),
Tienda varchar (20),
Prenda varchar (20),
Tipo varchar (9),
Cantidad int,
Precio numeric(6,2),
Total numeric(6,2),
Fecha date,
Estado varchar (11),
Orden int
)
go

create table HistorialVentas
(
Historial int identity (1,1) primary key,
Codigo int,
Boleta varchar (13),
Tienda varchar (20),
Prenda varchar (20),
Tipo varchar (9),
Cantidad int,
Precio numeric(6,2),
Total numeric(6,2),
Fecha date,
Estado varchar (11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)
go

create table Stock
(
Codigo int identity (1,1) primary key,
Tienda varchar (20),
Prenda varchar (20),
Fecha date,
StockInicial int,
StockIngreso int,
StockSalida int,
StockVentas int,
StockReal int,
Variacion int,
Disponible varchar(8)
)
go

create table HistorialStock
(Codigo int identity (1,1) primary key,
Tienda varchar (20),
Prenda varchar (20),
FechaInicio date,
FechaFinal date,
StockInicial int,
StockIngreso int,
StockSalida int,
StockVentas int,
StockReal int,
Variacion int,
Disponible varchar(8),
FechaInv Date default (getdate()),
Hora Time default (CONVERT(VARCHAR, getdate(), 108)),
)
go

create table RelacionStock
(
Codigo int identity (1,1) primary key,
Tienda varchar (20),
Fecha Date default (getdate()),
Hora Time default (CONVERT(VARCHAR, getdate(), 108)),
)
go

create table DatosPersonal
(
Orden int identity (1,1) primary key,
Nombres varchar (50),
Apellidos varchar (50),
DNI varchar(8),
NumeroFijo varchar (7),
Direccion varchar(50),
NumeroCelular varchar (9),
Referencia varchar(50),
FechaInicio date,
FechaFinal date,
FechaVacaciones date,
Estado varchar(11),
Tienda varchar(20),
Sueldo  numeric(8,2),
Seguro varchar(20),
Descuento  numeric(8,2),
Total  numeric(8,2),
)

create table HistorialDatosPersonal
(
Codigo int identity (1,1) primary key,
Orden int,
Nombres varchar (50),
Apellidos varchar (50),
DNI varchar(8),
NumeroFijo varchar (7),
Direccion varchar(50),
NumeroCelular varchar (9),
Referencia varchar(50),
FechaInicio date,
FechaFinal date,
FechaVacaciones date,
Estado varchar(11),
Tienda varchar(20),
Sueldo  numeric(8,2),
Seguro varchar(20),
Descuento  numeric(8,2),
Total  numeric(8,2),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)


create table PersonalAdministrativo
(
Orden int identity (1,1) primary key,
Nombres varchar (50),
Apellidos varchar (50),
DNI varchar(8),
NumeroFijo varchar (7),
Direccion varchar(50),
NumeroCelular varchar (9),
Referencia varchar(50),
FechaInicio date,
FechaFinal date,
FechaVacaciones date,
Estado varchar(11),
Cargo varchar(30),
Sueldo numeric(8,2),
Seguro varchar(20),
Descuento numeric(8,2),
Total numeric(8,2),
)

create table HistorialPersonalAdministrativo
(
Codigo int identity (1,1) primary key,
Orden int,
Nombres varchar (50),
Apellidos varchar (50),
DNI varchar(8),
NumeroFijo varchar (7),
Direccion varchar(50),
NumeroCelular varchar (9),
Referencia varchar(50),
FechaInicio date,
FechaFinal date,
FechaVacaciones date,
Estado varchar(11),
Cargo varchar(30),
Sueldo numeric(8,2),
Seguro varchar(20),
Descuento numeric(8,2),
Total numeric(8,2),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)

create table CalculoPrendas
(
Codigo int identity (1,1) primary key,
SubTotalTela numeric(8,2),
SubTotalAplicaciones numeric(8,2),
SubTotalDecoracion numeric(8,2),
SubTotalServicio numeric(8,2),
CostoIGV numeric(15,2),
CostoTotal numeric(15,2),
Fecha date,
Estado varchar(11),
Orden int
)

create table HistorialCalculoPrendas
(
Historial int identity (1,1) primary key,
Codigo int,
MetrosTela numeric(8,2),
PrecioTela numeric(8,2),
SubTotalTela numeric(8,2),
MetrosAplicacion numeric(8,2),
PrecioAplicacion numeric(8,2),
SubTotalAplicaciones numeric(8,2),
CantidadDecoracion numeric(8,2),
PrecioDecoracion numeric(8,2),
SubTotalDecoracion numeric(8,2),
PrecioServicio numeric(8,2),
TransporteServicio numeric(8,2),
ManoObraServicio numeric(8,2),
PersonalTiendaServicio numeric(8,2),
GananciaServicio numeric(8,2),
SubTotalServicio numeric(8,2),
CostoIGV numeric(15,2),
CostoTotal numeric(15,2),
Fecha date,
Estado varchar(11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)

create table CalculoGastos
(
Codigo int identity (1,1) primary key,
Tienda varchar(30),
Fecha date,
Monto numeric(8,2),
GastosPagos numeric(8,2),
GastosMateria numeric(8,2),
Total numeric(8,2),
Estado varchar(11),
Orden int 
)

create table HistorialCalculoGastos
(
Historial int identity (1,1) primary key,
Codigo int,
Tienda varchar(30),
Fecha date,
GastosTienda numeric(8,2),
PagosPersonal numeric(8,2),
PagosTaller numeric(8,2),
PagosTienda numeric(8,2),
GastosTelas numeric(8,2),
GastosHijos numeric(8,2),
GastosAccesorios numeric(8,2),
GastosPlanchado numeric(8,2),
Monto numeric(8,2),
GastosPagos numeric(8,2),
GastosMateria numeric(8,2),
Total numeric(8,2),
Estado varchar(11),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar (11),
NuevoOrden int,
AntiguoOrden int
)


create table Usuarios
(
Usuario varchar (10) primary key,
Clave varchar (10),
Tipo varchar (10),
Nombre varchar(40),
Apellidos varchar(40),
edad varchar (2),
genero varchar(10),
estado varchar(1)
)
create table Conexiones
(
IDConexion Int Identity (1,1) Primary Key,
Usuario varchar (10),
MAC varchar(20),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
estado varchar(1)
)

create table HistorialConexiones
(
IDHConexion Int Identity (1,1) Primary Key,
Usuario varchar (10),
MAC varchar(20),
FechaSistema Date default (getdate()),
HoraSistema Time default (CONVERT(VARCHAR, getdate(), 108)),
Accion varchar(7)
)
create table Tipo
(
Tipo varchar(10) primary key,
Permisos varchar(1)
)
