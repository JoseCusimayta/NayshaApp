-------------------Insertar----------------------

create Trigger InsertarHistorialPrendas on Prendas after insert
as
begin
declare 
@Codigo char (6),
@Prenda varchar (20),
@Color varchar (20),
@Talla varchar (8),
@PxMayor numeric(7,2),
@PxMenor numeric(7,2),
@Estado varchar (11),
@NuevoOrden int
set @Codigo=(select Codigo from inserted)
set @Prenda=(select Prenda from inserted)
set @Color=(select Color from inserted)
set @Talla=(select Talla from inserted)
set @PxMayor=(select PxMayor from inserted)
set @PxMenor=(select PxMenor from inserted)
set @Estado=(select Estado from inserted)
set @NuevoOrden=(select Orden from inserted)
insert into HistorialPrendas
(
Codigo,
Prenda,
Color,
Talla,
PxMayor,
PxMenor,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Prenda,
@Color,
@Talla,
@PxMayor,
@PxMenor,
@Estado,
'Ingresado',
@NuevoOrden,
null
)
end
go

create Trigger InsertarHistorialTiendas on Tiendas after insert
as
begin
declare 
@Codigo char (6),
@Tienda varchar(20),
@Vendedor varchar(20),
@Fecha_Inicio date,
@Fecha_Cierre date,
@Alquiler numeric (7,2),
@Estado varchar (11),
@NuevoOrden int
set @Codigo=(select Codigo from inserted)
set @Tienda=(select Tienda from inserted)
set @Vendedor=(select Vendedor from inserted)
set @Fecha_Inicio=(select Fecha_Inicio from inserted)
set @Fecha_Cierre=(select Fecha_Cierre from inserted)
set @Alquiler=(select Alquiler from inserted)
set @Estado=(select Estado from inserted)
set @NuevoOrden=(select Orden from inserted)
insert into HistorialTiendas
(
Codigo,
Tienda,
Vendedor,
Fecha_Inicio,
Fecha_Cierre,
Alquiler,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Tienda,
@Vendedor,
@Fecha_Inicio,
@Fecha_Cierre,
@Alquiler,
@Estado,
'Ingresado',
@NuevoOrden,
null
)
end
go

create Trigger InsertarHistorialEntradasSalidas on EntradasSalidas after insert
as
begin
declare 
@Codigo int,
@Boleta char (13),
@Salida char(20),
@Ingreso char(20),
@Prenda char(20),
@CodigoPrenda char(6),
@Cantidad int,
@Fecha date,
@Estado char(11),
@Accion varchar (11), 
@NuevoOrden int
set @Codigo=(select Codigo from inserted)
set @Boleta=(select Boleta from inserted)
set @Salida=(select Salida from inserted)
set @Ingreso=(select Ingreso from inserted)
set @Prenda=(select Prenda from inserted)
set @CodigoPrenda=(select CodigoPrenda from inserted)
set @Cantidad=(select Cantidad from inserted)
set @Fecha=(select Fecha from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden=(Select Codigo from inserted)
insert into HistorialEntradasSalidas
(
Codigo,
Boleta,
Salida,
Ingreso,
Prenda,
CodigoPrenda,
Cantidad,
Fecha,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Boleta,
@Salida,
@Ingreso,
@Prenda,
@CodigoPrenda,
@Cantidad,
@Fecha,
@Estado,
@Accion,
@NuevoOrden,
null
)
end
go

create Trigger InsertarHistorialVentas on Ventas after insert
as
begin
declare 
@Codigo int,
@Boleta varchar (13),
@Tienda varchar (20),
@Prenda varchar (20),
@Tipo varchar (9),
@Cantidad int,
@Precio numeric(6,2),
@Total numeric(6,2),
@Fecha date,
@Estado varchar (11),
@Accion varchar (11), 
@NuevoOrden int
set @Codigo=(select Codigo from inserted)
set @Boleta=(select Boleta from inserted)
set @Tienda=(select Tienda from inserted)
set @Prenda=(select Prenda from inserted)
set @Tipo=(select Tipo from inserted)
set @Cantidad=(select Cantidad from inserted)
set @Precio=(select Precio from inserted)
set @Total=(select Total from inserted)
set @Fecha=(select Fecha from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden=(select Codigo from inserted)
insert into HistorialVentas
(
Codigo,
Boleta,
Tienda,
Prenda,
Tipo,
Cantidad,
Precio,
Total,
Fecha,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Boleta,
@Tienda,
@Prenda,
@Tipo,
@Cantidad,
@Precio,
@Total,
@Fecha,
@Estado,
'Ingresado',
@NuevoOrden,
null
)
end
go

create trigger InsertarStock on EntradasSalidas after insert
as
begin
declare
@Ingreso varchar (20),
@Salida varchar (20),
@Prenda varchar (20),
@Fecha date,
@StockIngreso int,
@StockSalida int
set @Ingreso = (select Ingreso from inserted)
set @Salida = (select Salida from inserted)
set @Prenda = (select Prenda from inserted)
set @Fecha = (select Fecha from inserted)
set @StockIngreso = (select Cantidad from inserted)
set @StockSalida = (select Cantidad from inserted)
if(
(select count(*) from Stock where Tienda=@Ingreso and Prenda=@Prenda)
=0
) begin 
insert into Stock values (@Ingreso,@Prenda,@Fecha,0,@StockIngreso,0,0,0,0,'Completo')
end else begin
update Stock set StockIngreso += @StockIngreso where Tienda=@Ingreso and Prenda=@Prenda
update Stock set Fecha =@Fecha where Tienda=@Ingreso and Prenda=@Prenda
end
if(
(select count(*) from stock where  Tienda=@Salida and Prenda=@Prenda)
=0
) begin
insert into Stock values (@Salida,@Prenda,@Fecha,0,0,@StockSalida,0,0,0,'Completo')
end else begin
update Stock set StockSalida += @StockSalida where Tienda=@Salida and Prenda=@Prenda
update Stock set Fecha =@Fecha where Tienda=@Salida and Prenda=@Prenda
end
end
go

create trigger InsertarStock2 on Ventas after insert
as
begin
declare
@Tienda varchar (20),
@Prenda varchar (20),
@Fecha date,
@StockVentas int
set @Tienda = (select Tienda from inserted)
set @Prenda = (select Prenda from inserted)
set @Fecha = (select Fecha from inserted)
set @StockVentas = (select Cantidad from inserted)
if(
(select count(*) from Stock where Tienda=@Tienda and Prenda=@Prenda)
=0
) begin
insert into Stock values (@Tienda,@Prenda,@Fecha,0,0,0,@StockVentas,0,0,'Completo')
end
else begin
update Stock set StockVentas +=@StockVentas where Tienda=@Tienda and Prenda=@Prenda
update Stock set Fecha =@Fecha where Tienda=@Tienda and Prenda=@Prenda
end
end
go

create trigger InsertarHistorialDatosPersonal on DatosPersonal after insert
as
begin
declare
@Orden int,
@Nombres varchar (50),
@Apellidos varchar (50),
@DNI varchar(8),
@NumeroFijo varchar (7),
@Direccion varchar(50),
@NumeroCelular varchar (9),
@Referencia varchar(50),
@FechaInicio date,
@FechaFinal date,
@FechaVacaciones date,
@Estado varchar(11),
@Tienda varchar(20),
@Salario numeric(8,2),
@Seguro varchar(20),
@Descuento numeric(8,2),
@Total numeric(8,2),
@Accion varchar (11), 
@NuevoOrden int
set @Orden=(select Orden from inserted)
set @Nombres =(select Nombres from inserted)
set @Apellidos=(select Apellidos from inserted)
set @DNI =(select DNI from inserted)
set @NumeroFijo =(select NumeroFijo from inserted)
set @Direccion=(select Direccion from inserted)
set @NumeroCelular =(select NumeroCelular from inserted)
set @Referencia =(select Referencia from inserted)
set @FechaInicio =(select FechaInicio from inserted)
set @FechaFinal =(select FechaFinal from inserted)
set @FechaVacaciones =(select FechaVacaciones from inserted)
set @Estado =(select Estado from inserted)
set @Tienda=(select Tienda from inserted)
set @Salario =(select Sueldo from inserted)
set @Seguro=(select Seguro from inserted)
set @Descuento =(select Descuento from inserted)
set @Total=(select Total from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden =(select Orden from inserted)
insert into HistorialDatosPersonal
(
Orden ,
Nombres ,
Apellidos ,
DNI ,
NumeroFijo ,
Direccion ,
NumeroCelular ,
Referencia,
FechaInicio,
FechaFinal,
FechaVacaciones ,
Estado,
Tienda ,
Sueldo ,
Seguro ,
Descuento ,
Total ,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Orden ,
@Nombres ,
@Apellidos ,
@DNI ,
@NumeroFijo ,
@Direccion ,
@NumeroCelular ,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones ,
@Estado,
@Tienda ,
@Salario ,
@Seguro ,
@Descuento ,
@Total ,
@Accion,
@NuevoOrden,
null
)
end
go

create trigger InsertarHistorialAdministrativo on PersonalAdministrativo after insert
as
begin
declare
@Orden int,
@Nombres varchar (50),
@Apellidos varchar (50),
@DNI varchar(8),
@NumeroFijo varchar (7),
@Direccion varchar(50),
@NumeroCelular varchar (9),
@Referencia varchar(50),
@FechaInicio date,
@FechaFinal date,
@FechaVacaciones date,
@Estado varchar(11),
@Cargo varchar(30),
@Salario numeric(8,2),
@Seguro varchar(20),
@Descuento numeric(8,2),
@Total numeric(8,2),
@Accion varchar (11), 
@NuevoOrden int
set @Orden=(select Orden from inserted)
set @Nombres =(select Nombres from inserted)
set @Apellidos=(select Apellidos from inserted)
set @DNI =(select DNI from inserted)
set @NumeroFijo =(select NumeroFijo from inserted)
set @Direccion=(select Direccion from inserted)
set @NumeroCelular =(select NumeroCelular from inserted)
set @Referencia =(select Referencia from inserted)
set @FechaInicio =(select FechaInicio from inserted)
set @FechaFinal =(select FechaFinal from inserted)
set @FechaVacaciones =(select FechaVacaciones from inserted)
set @Estado =(select Estado from inserted)
set @Cargo=(select Cargo from inserted)
set @Salario =(select Sueldo from inserted)
set @Seguro=(select Seguro from inserted)
set @Descuento =(select Descuento from inserted)
set @Total=(select Total from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden =(select Orden from inserted)
insert into HistorialPersonalAdministrativo
(
Orden ,
Nombres ,
Apellidos ,
DNI ,
NumeroFijo ,
Direccion ,
NumeroCelular ,
Referencia,
FechaInicio,
FechaFinal,
FechaVacaciones ,
Estado,
Cargo ,
Sueldo ,
Seguro ,
Descuento ,
Total ,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Orden ,
@Nombres ,
@Apellidos ,
@DNI ,
@NumeroFijo ,
@Direccion ,
@NumeroCelular ,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones ,
@Estado,
@Cargo ,
@Salario ,
@Seguro ,
@Descuento ,
@Total ,
@Accion,
@NuevoOrden,
null
)
end
go

create trigger InsertarHistorialCalculoPrendas on HistorialCalculoPrendas after insert
as
begin
declare
@Codigo int,
@SubTtotalTela numeric(8,2),
@SubTotalAplicaciones numeric(8,2),
@SubTotalDecoracion numeric(8,2),
@SubTotalServicio numeric(8,2),
@CostoIGV numeric(15,2),
@CostoTotal numeric(15,2),
@Fecha date,
@Estado varchar(11),
@Orden int
set @Codigo=(select Codigo from inserted)
set @SubTtotalTela=(select SubTotalTela from inserted)
set @SubTotalAplicaciones =(select SubTotalAplicaciones from inserted)
set @SubTotalDecoracion=(select SubTotalDecoracion from inserted)
set @SubTotalServicio =(select SubTotalServicio from inserted)
set @CostoIGV =(select CostoIGV from inserted)
set @CostoTotal=(select CostoTotal from inserted)
set @Fecha =(select Fecha from inserted)
set @Estado =(select Estado from inserted)
set @Orden=(select NuevoOrden from inserted)
if(@Estado='Ingresado')
begin
insert into CalculoPrendas values (
@SubTtotalTela, 
@SubTotalAplicaciones, 
@SubTotalDecoracion,
@SubTotalServicio,
@CostoIGV,
@CostoTotal,
@Fecha,
@Estado,
@Orden)
end else begin
update CalculoPrendas set 
SubTotalTela = @SubTtotalTela, 
SubTotalAplicaciones =@SubTotalAplicaciones, 
SubTotalDecoracion=@SubTotalDecoracion,
SubTotalServicio=@SubTotalServicio,
CostoIGV=@CostoIGV,
CostoTotal=@CostoTotal,
Fecha=@Fecha,
Estado=@Estado,
Orden=@Orden
where Codigo=@Codigo
end
end
go


create trigger InsertarHistorialCalculoGastos on HistorialCalculoGastos after insert
as
begin
declare
@Codigo int,
@Tienda varchar(30),
@Fecha date,
@Monto numeric(8,2),
@GastosPagos numeric(8,2),
@GastosMateria numeric(8,2),
@Total numeric(8,2),
@Estado varchar(11),
@Orden int
set @Codigo=(select Codigo from inserted)
set @Tienda =(select Tienda from inserted)
set @Fecha=(select Fecha from inserted)
set @Monto =(select Monto from inserted)
set @GastosPagos =(select GastosPagos from inserted)
set @GastosMateria=(select GastosMateria from inserted)
set @Total =(select Total from inserted)
set @Estado =(select Estado from inserted)
set @Orden=(select NuevoOrden from inserted)
if(@Estado='Ingresado')
begin
insert into CalculoGastos values (
@Tienda,
@Fecha,
@Monto,
@GastosPagos,
@GastosMateria,
@Total,
@Estado,
@Orden)
end else begin
update CalculoGastos set 
Tienda=@Tienda,
Fecha=@Fecha,
Monto=@Monto,
GastosPagos=@GastosPagos,
GastosMateria=@GastosMateria,
Total=@Total,
Estado=@Estado,
Orden=@Orden
where Codigo=@Codigo
end
end
go

create trigger InsertarHistorialConexiones on Conexiones after insert
as
begin
declare
@Usuario varchar (10),
@MAC varchar(20),
@estado varchar(1)
set @Usuario=(select Usuario from Conexiones)
set @MAC=(select MAC from Conexiones)
set @estado=(select estado from Conexiones)
if(@estado='1')
begin
insert into HistorialConexiones (Usuario, MAC, Accion) values (@Usuario, @MAC, 'Ingreso')
end else begin
insert into HistorialConexiones (Usuario, MAC, Accion) values (@Usuario, @MAC, 'salida')
end
end
go

-------------------Insertar----------------------
-------------------Actualizar----------------------

create Trigger ActualizarHistorialPrendas on Prendas after update
as
begin
declare 
@Codigo char (6),
@Prenda varchar (20),
@Color varchar (20),
@Talla varchar (8),
@PxMayor numeric(7,2),
@PxMenor numeric(7,2),
@Estado varchar (11),
@Accion varchar (11),
@NuevoOrden int,
@AntiguoOrden int
set @Codigo=(select Codigo from inserted)
set @Prenda=(select Prenda from inserted)
set @Color=(select Color from inserted)
set @Talla=(select Talla from inserted)
set @PxMayor=(select PxMayor from inserted)
set @PxMenor=(select PxMenor from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else
set @Accion='Actualizado'
set @NuevoOrden=(select Orden from inserted)
set @AntiguoOrden=(select Orden from deleted)
insert into HistorialPrendas
(
Codigo,
Prenda,
Color,
Talla,
PxMayor,
PxMenor,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Prenda,
@Color,
@Talla,
@PxMayor,
@PxMenor,
@Estado,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create Trigger ActualizarHistorialTiendas on Tiendas after update
as
begin
declare 
@Codigo char (6),
@Tienda varchar(20),
@Vendedor varchar(20),
@Fecha_Inicio date,
@Fecha_Cierre date,
@Alquiler numeric (7,2),
@Estado varchar (11),
@Accion varchar (11),
@NuevoOrden int,
@AntiguoOrden int
set @Codigo=(select Codigo from inserted)
set @Tienda=(select Tienda from inserted)
set @Vendedor=(select Vendedor from inserted)
set @Fecha_Inicio=(select Fecha_Inicio from inserted)
set @Fecha_Cierre=(select Fecha_Cierre from inserted)
set @Alquiler=(select Alquiler from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if(@Estado='En Espera')
set @Accion='En Espera'
else if(@Estado='Cerrado')
set @Accion='Cerrado'
else
set @Accion='Actualizado'
set @NuevoOrden=(select Orden from inserted)
set @AntiguoOrden=(select Orden from deleted)
insert into HistorialTiendas
(
Codigo,
Tienda,
Vendedor,
Fecha_Inicio,
Fecha_Cierre,
Alquiler,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Tienda,
@Vendedor,
@Fecha_Inicio,
@Fecha_Cierre,
@Alquiler,
@Estado,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create Trigger ActualizarHistorialEntradasSalidas on EntradasSalidas after update
as
begin
declare 
@Codigo int,
@Boleta char (13),
@Salida char(20),
@Ingreso char(20),
@Prenda char(20),
@CodigoPrenda char(6),
@Cantidad int,
@Fecha date,
@Estado char(11),
@Accion varchar (11),
@NuevoOrden int,
@AntiguoOrden int
set @Codigo=(select Codigo from inserted)
set @Boleta=(select Boleta from inserted)
set @Salida=(select Salida from inserted)
set @Ingreso=(select Ingreso from inserted)
set @Prenda=(select Prenda from inserted)
set @CodigoPrenda=(select CodigoPrenda from inserted)
set @Cantidad=(select Cantidad from inserted)
set @Fecha=(select Fecha from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden=(select Orden from inserted)
set @AntiguoOrden=(select Orden from deleted)
insert into HistorialEntradasSalidas
(
Codigo,
Boleta,
Salida,
Ingreso,
Prenda,
CodigoPrenda,
Cantidad,
Fecha,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Boleta,
@Salida,
@Ingreso,
@Prenda,
@CodigoPrenda,
@Cantidad,
@Fecha,
@Estado,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create Trigger ActualizarHistorialVentas on Ventas after update
as
begin
declare 
@Codigo int,
@Boleta varchar (13),
@Tienda varchar (20),
@Prenda varchar (20),
@Tipo varchar (9),
@Cantidad int,
@Precio numeric(6,2),
@Total numeric(6,2),
@Fecha date,
@Estado varchar (11),
@Accion varchar (11),
@NuevoOrden int,
@AntiguoOrden int
set @Codigo=(select Codigo from inserted)
set @Boleta=(select Boleta from inserted)
set @Fecha=(select Fecha from inserted)
set @Tienda=(select Tienda from inserted)
set @Prenda=(select Prenda from inserted)
set @Tipo=(select Tipo from inserted)
set @Cantidad=(select Cantidad from inserted)
set @Precio=(select Precio from inserted)
set @Total=(select Total from inserted)
set @Fecha=(select Fecha from inserted)
set @Estado=(select Estado from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden=(select Orden from inserted)
set @AntiguoOrden=(select Orden from deleted)
insert into HistorialVentas
(
Codigo,
Boleta,
Tienda,
Prenda,
Tipo,
Cantidad,
Precio,
Total,
Fecha,
Estado,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Codigo,
@Boleta,
@Tienda,
@Prenda,
@Tipo,
@Cantidad,
@Precio,
@Total,
@Fecha,
@Estado,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create trigger ActualizarHistorialDatosPersonal on DatosPersonal after update
as
begin
declare
@Orden int,
@Nombres varchar (50),
@Apellidos varchar (50),
@DNI varchar(8),
@NumeroFijo varchar (7),
@Direccion varchar(50),
@NumeroCelular varchar (9),
@Referencia varchar(50),
@FechaInicio date,
@FechaFinal date,
@FechaVacaciones date,
@Estado varchar(11),
@Tienda varchar(20),
@Salario numeric(8,2),
@Seguro varchar(20),
@Descuento numeric(8,2),
@Total numeric(8,2),
@Accion varchar (11), 
@NuevoOrden int,
@AntiguoOrden int
set @Orden=(select Orden from inserted)
set @Nombres =(select Nombres from inserted)
set @Apellidos=(select Apellidos from inserted)
set @DNI =(select DNI from inserted)
set @NumeroFijo =(select NumeroFijo from inserted)
set @Direccion=(select Direccion from inserted)
set @NumeroCelular =(select NumeroCelular from inserted)
set @Referencia =(select Referencia from inserted)
set @FechaInicio =(select FechaInicio from inserted)
set @FechaFinal =(select FechaFinal from inserted)
set @FechaVacaciones =(select FechaVacaciones from inserted)
set @Estado =(select Estado from inserted)
set @Tienda=(select Tienda from inserted)
set @Salario =(select Sueldo from inserted)
set @Seguro=(select Seguro from inserted)
set @Descuento =(select Descuento from inserted)
set @Total=(select Total from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden =(select Orden from inserted)
set @AntiguoOrden =(select Orden from deleted)
insert into HistorialDatosPersonal
(
Orden ,
Nombres ,
Apellidos ,
DNI ,
NumeroFijo ,
Direccion ,
NumeroCelular ,
Referencia,
FechaInicio,
FechaFinal,
FechaVacaciones ,
Estado,
Tienda ,
Sueldo ,
Seguro ,
Descuento ,
Total ,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Orden ,
@Nombres ,
@Apellidos ,
@DNI ,
@NumeroFijo ,
@Direccion ,
@NumeroCelular ,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones ,
@Estado,
@Tienda ,
@Salario ,
@Seguro ,
@Descuento ,
@Total ,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create trigger ActualizarHistorialAdministrativo on PersonalAdministrativo after update
as
begin
declare
@Orden int,
@Nombres varchar (50),
@Apellidos varchar (50),
@DNI varchar(8),
@NumeroFijo varchar (7),
@Direccion varchar(50),
@NumeroCelular varchar (9),
@Referencia varchar(50),
@FechaInicio date,
@FechaFinal date,
@FechaVacaciones date,
@Estado varchar(11),
@Cargo varchar(30),
@Salario numeric(8,2),
@Seguro varchar(20),
@Descuento numeric(8,2),
@Total numeric(8,2),
@Accion varchar (11), 
@NuevoOrden int,
@AntiguoOrden int
set @Orden=(select Orden from inserted)
set @Nombres =(select Nombres from inserted)
set @Apellidos=(select Apellidos from inserted)
set @DNI =(select DNI from inserted)
set @NumeroFijo =(select NumeroFijo from inserted)
set @Direccion=(select Direccion from inserted)
set @NumeroCelular =(select NumeroCelular from inserted)
set @Referencia =(select Referencia from inserted)
set @FechaInicio =(select FechaInicio from inserted)
set @FechaFinal =(select FechaFinal from inserted)
set @FechaVacaciones =(select FechaVacaciones from inserted)
set @Estado =(select Estado from inserted)
set @Cargo=(select Cargo from inserted)
set @Salario =(select Sueldo from inserted)
set @Seguro=(select Seguro from inserted)
set @Descuento =(select Descuento from inserted)
set @Total=(select Total from inserted)
if(@Estado='Anulado')
set @Accion='Anulado'
else if (@Estado='Actualizado')
set @Accion='Actualizado'
else
set @Accion='Ingresado'
set @NuevoOrden =(select Orden from inserted)
set @AntiguoOrden =(select Orden from deleted)
insert into HistorialPersonalAdministrativo
(
Orden ,
Nombres ,
Apellidos ,
DNI ,
NumeroFijo ,
Direccion ,
NumeroCelular ,
Referencia,
FechaInicio,
FechaFinal,
FechaVacaciones ,
Estado,
Cargo ,
Sueldo ,
Seguro ,
Descuento ,
Total ,
Accion,
NuevoOrden,
AntiguoOrden
)
values
(
@Orden ,
@Nombres ,
@Apellidos ,
@DNI ,
@NumeroFijo ,
@Direccion ,
@NumeroCelular ,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones ,
@Estado,
@Cargo ,
@Salario ,
@Seguro ,
@Descuento ,
@Total ,
@Accion,
@NuevoOrden,
@AntiguoOrden
)
end
go

create trigger ActualizarrHistorialConexiones on Conexiones after update
as
begin
declare
@Usuario varchar (10),
@MAC varchar(20),
@estado varchar(1)
set @Usuario=(select Usuario from inserted)
set @MAC=(select MAC from inserted)
set @estado=(select estado from inserted)
if(@estado='1')
begin
insert into HistorialConexiones (Usuario, MAC, Accion) values (@Usuario, @MAC, 'Ingreso')
end else begin
insert into HistorialConexiones (Usuario, MAC, Accion) values (@Usuario, @MAC, 'salida')
end
end
go

-------------------Actualizar----------------------
