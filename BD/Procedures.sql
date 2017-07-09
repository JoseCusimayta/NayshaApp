-------------------Insertar----------------------
create Procedure InsertarPrendas
@Codigo char (6),
@Prenda varchar (20),
@Color varchar (20),
@Talla varchar (8),
@PxMayor numeric(7,2),
@PxMenor numeric(7,2),
@Estado varchar (11),
@Orden int
as
insert into Prendas values (
@Codigo,
@Prenda,
@Color,
@Talla,
@PxMayor,
@PxMenor,
@Estado,
@Orden)
go

create Procedure InsertarTiendas
@Codigo char (6),
@Tienda varchar(20),
@Vendedor varchar(20),
@Fecha_Inicio date,
@Fecha_Cierre date,
@Alquiler numeric (7,2),
@Estado varchar (11),
@Orden int
as
insert into Tiendas values (
@Codigo,
@Tienda,
@Vendedor,
@Fecha_Inicio,
@Fecha_Cierre,
@Alquiler,
@Estado,
@Orden)
go

create Procedure InsertarEntradasSalidas
@Boleta char (13),
@Salida char(20),
@Ingreso char(20),
@Prenda char(20),
@CodigoPrenda char(6),
@Cantidad int,
@Fecha date,
@Estado char(11),
@Orden int
as
insert into EntradasSalidas values (
@Boleta,
@Salida,
@Ingreso,
@Prenda,
@CodigoPrenda,
@Cantidad,
@Fecha,
'Ingresado',
@Orden)
go

create Procedure InsertarVentas
@Boleta varchar (13),
@Tienda varchar (20),
@Prenda varchar (20),
@Tipo varchar (9),
@Cantidad int,
@Precio numeric(6,2),
@Total numeric(6,2),
@Fecha date,
@Orden int
as
insert into Ventas Values (
@Boleta,
@Tienda,
@Prenda,
@Tipo,
@Cantidad,
@Precio,
@Total,
@Fecha,
'Ingresado',
@Orden)
go

create procedure GuardarReporte
@Codigo int,
@Tienda varchar (20),
@Prenda varchar (20),
@FechaInicio date,
@FechaFinal date,
@StockInicial int,
@StockIngreso int,
@StockSalida int,
@StockVentas int,
@StockReal int,
@Variacion int,
@Disponible varchar(8)
 as
 insert into HistorialStock (Tienda, Prenda, FechaInicio, FechaFinal, StockInicial, StockIngreso,StockSalida, StockVentas,StockReal, Variacion, Disponible) values (@Tienda, @Prenda,@FechaInicio, @FechaFinal, @StockInicial, @StockIngreso,@StockSalida, @StockVentas,@StockReal, @Variacion, @Disponible)
 update StocK set StockInicial=0,StockIngreso=0,StockSalida=0,StockVentas=0,StockReal=0, Disponible='Completo' where Codigo=@Codigo
 go


 create procedure InsertarRelacionStock
 @Tienda varchar (20)
 as
 insert into RelacionStock(Tienda) values (@Tienda)
 go
 

create procedure InsertarPersonal
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
@Total numeric(8,2)
as
insert into DatosPersonal values
(
@Nombres,
@Apellidos,
@DNI,
@NumeroFijo,
@Direccion,
@NumeroCelular,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones,
@Estado,
@Tienda,
@Salario,
@Seguro,
@Descuento,
@Total
)
go

create procedure InsertarAdministrativo
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
@Total numeric(8,2)
as
insert into PersonalAdministrativo values
(
@Nombres,
@Apellidos,
@DNI,
@NumeroFijo,
@Direccion,
@NumeroCelular,
@Referencia,
@FechaInicio,
@FechaFinal,
@FechaVacaciones,
@Estado,
@Cargo,
@Salario,
@Seguro,
@Descuento,
@Total
)
go

create procedure InsertarCalculoPrendas
@Codigo int,
@MetrosTela numeric(8,2),
@PrecioTela numeric(8,2),
@SubTtotalTela numeric(8,2),
@MetrosAplicacion numeric(8,2),
@PrecioAplicacion numeric(8,2),
@SubTotalAplicaciones numeric(8,2),
@CantidadDecoracion numeric(8,2),
@PrecioDecoracion numeric(8,2),
@SubTotalDecoracion numeric(8,2),
@PrecioServicio numeric(8,2),
@TransporteServicio numeric(8,2),
@ManoObraServicio numeric(8,2),
@PersonalTiendaServicio numeric(8,2),
@GananciaServicio numeric(8,2),
@SubTotalServicio numeric(8,2),
@CostoIGV numeric(15,2),
@CostoTotal numeric(15,2),
@Fecha date,
@NuevoOrden int
as
insert into HistorialCalculoPrendas values
(
@Codigo,
@MetrosTela,
@PrecioTela,
@SubTtotalTela,
@MetrosAplicacion,
@PrecioAplicacion,
@SubTotalAplicaciones,
@CantidadDecoracion,
@PrecioDecoracion,
@SubTotalDecoracion,
@PrecioServicio,
@TransporteServicio,
@ManoObraServicio,
@PersonalTiendaServicio,
@GananciaServicio,
@SubTotalServicio,
@CostoIGV,
@CostoTotal,
@Fecha,
'Ingresado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Ingresado',
@NuevoOrden,
null
)
go

create procedure InsertarCalculoGastos
@Codigo int,
@Tienda varchar(30),
@Fecha date,
@GastosTiendas numeric(8,2),
@PagosPersonal numeric(8,2),
@PagosTaller numeric(8,2),
@PagosTienda numeric(8,2),
@GastosTelas numeric(8,2),
@GastosHijos numeric(8,2),
@GastosAccesorios numeric(8,2),
@GastosPlanchado numeric(8,2),
@Monto numeric(8,2),
@GastosPagos numeric(8,2),
@GastosMateria numeric(8,2),
@Total numeric(8,2),
@NuevoOrden int
as
insert into HistorialCalculoGastos values
(
@Codigo,
@Tienda,
@Fecha,
@GastosTiendas,
@PagosPersonal,
@PagosTaller,
@PagosTienda,
@GastosTelas,
@GastosHijos,
@GastosAccesorios,
@GastosPlanchado,
@Monto,
@GastosPagos,
@GastosMateria,
@Total,
'Ingresado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Ingresado',
@NuevoOrden,
null
)
go
-------------------Insertar----------------------
-------------------Actualizar----------------------

create Procedure ActualizarPrendas
@Codigo char (6),
@Prenda varchar (20),
@Color varchar (20),
@Talla varchar (8),
@PxMayor numeric(7,2),
@PxMenor numeric(7,2),
@Estado varchar (11),
@Orden int
as
update Prendas 
set 
Prenda=@Prenda,
Color=@Color,
Talla=@Talla,
PxMayor=@PxMayor,
PxMenor=@PxMenor,
Estado=@Estado,
Orden=@Orden
where 
Codigo=@Codigo
go

create Procedure ActualizarTiendas
@Codigo char (6),
@Tienda varchar(20),
@Vendedor varchar(20),
@Fecha_Inicio date,
@Fecha_Cierre date,
@Alquiler numeric (7,2),
@Estado varchar (11),
@Orden int
as
update Tiendas
set
Tienda=@Tienda,
Vendedor=@Vendedor,
Fecha_Inicio=@Fecha_Inicio,
Fecha_Cierre=@Fecha_Cierre,
Alquiler=@Alquiler,
Estado=@Estado,
Orden=@Orden
where 
Codigo=@Codigo
go

create Procedure ActualizarEntradasSalidas
@Boleta char (13),
@Salida char(20),
@Ingreso char(20),
@Prenda char(20),
@CodigoPrenda char(6),
@Cantidad int,
@Fecha date,
@Estado char(11),
@Orden int,
@OrdenAnterior int
as
update EntradasSalidas set
Boleta=@Boleta,
Salida=@Salida,
Ingreso=@Ingreso,
Prenda=@Prenda,
CodigoPrenda=@CodigoPrenda,
Cantidad=@Cantidad,
Fecha=@Fecha,
Estado=@Estado,
Orden=@Orden
where Orden=@OrdenAnterior
go

create Procedure ActualizarVentas
@Boleta varchar (13),
@Tienda varchar (20),
@Prenda varchar (20),
@Tipo varchar (9),
@Cantidad int,
@Precio numeric(6,2),
@Total numeric(6,2),
@Fecha date,
@Orden int,
@OrdenAnterior int
as
update Ventas set
Boleta=@Boleta,
Tienda=@Tienda,
Prenda=@Prenda,
Tipo=@Tipo,
Cantidad=@Cantidad,
Precio=@Precio,
Total=@Total,
Fecha=@Fecha,
Estado='Actualizado',
Orden=@Orden
where Orden=@OrdenAnterior
go	

create procedure ActualizarStock
@StockReal int,
@Codigo int
as
begin
update StocK set
StockReal=@StockReal,
Variacion=@StockReal-(StockIngreso-StockSalida-StockVentas)
 where Codigo=@Codigo
 if ((select Variacion from StocK where Codigo=@Codigo)>0) begin
 update StocK set
 disponible='Sobra' where Codigo=@Codigo
 end else if ((select Variacion from StocK where Codigo=@Codigo)<0) begin
  update StocK set
 disponible='Falta' where Codigo=@Codigo
 end else begin
   update StocK set
 disponible='Completo' where Codigo=@Codigo
 end
 end
 go
 
create procedure ActualizarPersonal
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
@Total numeric(8,2)
as
update DatosPersonal set
Nombres=@Nombres,
Apellidos=@Apellidos,
DNI=@DNI,
NumeroFijo=@NumeroFijo,
Direccion=@Direccion,
NumeroCelular=@NumeroCelular,
Referencia=@Referencia,
FechaInicio=@FechaInicio,
FechaFinal=@FechaFinal,
FechaVacaciones = @FechaVacaciones,
Estado=@Estado,
Tienda=@Tienda,
Sueldo=@Salario,
Seguro=@Seguro,
Descuento=@Descuento,
Total=@Total
where 
Orden=@Orden
go

create procedure ActualizarAdministrativo
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
@Total numeric(8,2)
as
update PersonalAdministrativo set
Nombres=@Nombres,
Apellidos=@Apellidos,
DNI=@DNI,
NumeroFijo=@NumeroFijo,
Direccion=@Direccion,
NumeroCelular=@NumeroCelular,
Referencia=@Referencia,
FechaInicio=@FechaInicio,
FechaFinal=@FechaFinal,
FechaVacaciones = @FechaVacaciones,
Estado=@Estado,
Cargo=@Cargo,
Sueldo=@Salario,
Seguro=@Seguro,
Descuento=@Descuento,
Total=@Total
where 
Orden=@Orden
go

create procedure ActualizarCalculoPrendas
@Codigo int,
@MetrosTela numeric(8,2),
@PrecioTela numeric(8,2),
@SubTtotalTela numeric(8,2),
@MetrosAplicacion numeric(8,2),
@PrecioAplicacion numeric(8,2),
@SubTotalAplicaciones numeric(8,2),
@CantidadDecoracion numeric(8,2),
@PrecioDecoracion numeric(8,2),
@SubTotalDecoracion numeric(8,2),
@PrecioServicio numeric(8,2),
@TransporteServicio numeric(8,2),
@ManoObraServicio numeric(8,2),
@PersonalTiendaServicio numeric(8,2),
@GananciaServicio numeric(8,2),
@SubTotalServicio numeric(8,2),
@CostoIGV numeric(15,2),
@CostoTotal numeric(15,2),
@Fecha date,
@NuevoOrden int,
@AntiguoOrden int
as
insert into HistorialCalculoPrendas values
(
@Codigo,
@MetrosTela,
@PrecioTela,
@SubTtotalTela,
@MetrosAplicacion,
@PrecioAplicacion,
@SubTotalAplicaciones,
@CantidadDecoracion,
@PrecioDecoracion,
@SubTotalDecoracion,
@PrecioServicio,
@TransporteServicio,
@ManoObraServicio,
@PersonalTiendaServicio,
@GananciaServicio,
@SubTotalServicio,
@CostoIGV,
@CostoTotal,
@Fecha,
'Actualizado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Actualizado',
@NuevoOrden,
@AntiguoOrden
)
go


create procedure ActualizarCalculoGastos
@Codigo int,
@Tienda varchar(30),
@Fecha date,
@GastosTiendas numeric(8,2),
@PagosPersonal numeric(8,2),
@PagosTaller numeric(8,2),
@PagosTienda numeric(8,2),
@GastosTelas numeric(8,2),
@GastosHijos numeric(8,2),
@GastosAccesorios numeric(8,2),
@GastosPlanchado numeric(8,2),
@Monto numeric(8,2),
@GastosPagos numeric(8,2),
@GastosMateria numeric(8,2),
@Total numeric(8,2),
@NuevoOrden int,
@AntiguoOrden int
as
insert into HistorialCalculoGastos values
(
@Codigo,
@Tienda,
@Fecha,
@GastosTiendas,
@PagosPersonal,
@PagosTaller,
@PagosTienda,
@GastosTelas,
@GastosHijos,
@GastosAccesorios,
@GastosPlanchado,
@Monto,
@GastosPagos,
@GastosMateria,
@Total,
'Actualizado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Actualizado',
@NuevoOrden,
@AntiguoOrden
)
go
-------------------Actualizar----------------------
-------------------Eliminar----------------------

create Procedure EliminarPrendas
@Codigo char(6)
as
update Prendas set Estado='Anulado' where Codigo=@Codigo
go

create Procedure EliminarTiendas
@Codigo char(6)
as
update Tiendas set Estado='Cerrado' where Codigo=@Codigo
go

create Procedure EliminarEntradasSalidas
@Orden int
as
update EntradasSalidas set Estado='Anulado' where Orden=@Orden
go

create Procedure EliminarVentas
@Orden int
as
update Ventas set Estado='Anulado' where Orden=@Orden
go

create procedure EliminarPersonal 
@Orden int
as
update DatosPersonal set
Estado='Anulado'
where
@Orden=Orden
go

create procedure EliminarAdministrativo
@Orden int
as
update PersonalAdministrativo set
Estado='Anulado'
where
@Orden=Orden
go

create procedure EliminarCalculoPrendas
@Codigo int,
@MetrosTela numeric(8,2),
@PrecioTela numeric(8,2),
@SubTtotalTela numeric(8,2),
@MetrosAplicacion numeric(8,2),
@PrecioAplicacion numeric(8,2),
@SubTotalAplicaciones numeric(8,2),
@CantidadDecoracion numeric(8,2),
@PrecioDecoracion numeric(8,2),
@SubTotalDecoracion numeric(8,2),
@PrecioServicio numeric(8,2),
@TransporteServicio numeric(8,2),
@ManoObraServicio numeric(8,2),
@PersonalTiendaServicio numeric(8,2),
@GananciaServicio numeric(8,2),
@SubTotalServicio numeric(8,2),
@CostoIGV numeric(15,2),
@CostoTotal numeric(15,2),
@Fecha date,
@NuevoOrden int,
@AntiguoOrden int
as
insert into HistorialCalculoPrendas values
(
@Codigo,
@MetrosTela,
@PrecioTela,
@SubTtotalTela,
@MetrosAplicacion,
@PrecioAplicacion,
@SubTotalAplicaciones,
@CantidadDecoracion,
@PrecioDecoracion,
@SubTotalDecoracion,
@PrecioServicio,
@TransporteServicio,
@ManoObraServicio,
@PersonalTiendaServicio,
@GananciaServicio,
@SubTotalServicio,
@CostoIGV,
@CostoTotal,
@Fecha,
'Anulado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Anulado',
@NuevoOrden,
@AntiguoOrden
)
go


create procedure EliminarCalculoGastos
@Codigo int,
@Tienda varchar(30),
@Fecha date,
@GastosTiendas numeric(8,2),
@PagosPersonal numeric(8,2),
@PagosTaller numeric(8,2),
@PagosTienda numeric(8,2),
@GastosTelas numeric(8,2),
@GastosHijos numeric(8,2),
@GastosAccesorios numeric(8,2),
@GastosPlanchado numeric(8,2),
@Monto numeric(8,2),
@GastosPagos numeric(8,2),
@GastosMateria numeric(8,2),
@Total numeric(8,2),
@NuevoOrden int,
@AntiguoOrden int
as
insert into HistorialCalculoGastos values
(
@Codigo,
@Tienda,
@Fecha,
@GastosTiendas,
@PagosPersonal,
@PagosTaller,
@PagosTienda,
@GastosTelas,
@GastosHijos,
@GastosAccesorios,
@GastosPlanchado,
@Monto,
@GastosPagos,
@GastosMateria,
@Total,
'Anulado',
(getdate()),
(CONVERT(VARCHAR, getdate(), 108)),
'Anulado',
@NuevoOrden,
@AntiguoOrden
)
go
-------------------Eliminar----------------------


------------------Miscelaneos--------------------
create Procedure Ingresar
( 
@Usuario VarChar(10), 
@Clave varChar(10), 
@OutRes int OUTPUT 
)
AS
set
@OutRes = (SELECT count(*) FROM Usuarios WHERE Usuario = @Usuario And Clave = @Clave and estado= 1)
select case @OutRes
when 1 then 1
else
0
end



create Procedure RegistrarConexion

@Usuario varchar (10),
@MAC varchar(20)
as
insert into Conexiones (Usuario, MAC,estado) values (
@Usuario,
@MAC,
1
)

create procedure ActualizarConexion
@Usuario varchar (10),
@MAC varchar(20)
as
update Conexiones set Estado='1', FechaSistema=(getdate()), HoraSistema=(CONVERT(VARCHAR, getdate(), 108)) where Usuario= @Usuario and Mac = @MAC
go

create procedure TerminarConexion
@Usuario varchar (10),
@MAC varchar(20)
as
update Conexiones set Estado='0', FechaSistema=(getdate()), HoraSistema=(CONVERT(VARCHAR, getdate(), 108)) where Usuario= @Usuario and Mac = @MAC
go
