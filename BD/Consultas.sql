-------------------------Prendas--------------------------

select Codigo, Prenda, Color, Talla, PxMayor as 'Por Mayor', PxMenor as 'Por Menor', Estado, Orden from prendas
exec InsertarPrendas
truncate table Prendas
-------------------------Prendas--------------------------

-------------------------Historial Prendas--------------------------

select Codigo, Prenda, Color, Talla, PxMayor as 'Por Mayor', PxMenor as 'Por Menor', Estado, FechaSistema as 'Fecha Sistema', HoraSistema as 'Hora Sistema', Accion, NuevoOrden as 'Nuevo Orden', AntiguoOrden as 'Antiguo Orden' from HistorialPrendas 
where
FechaSistema='13/06/2016'
select * from HistorialPrendas
truncate table HistorialPrendas
-------------------------Historial Prendas--------------------------

-------------------------Tiendas--------------------------

select Codigo, Tienda, Vendedor, Fecha_Inicio as 'Fecha Inicio', Fecha_Cierre as 'Fecha Cierre', Alquiler, Estado, Orden from Tiendas
select * from Tiendas where Fecha_Cierre<DATEADD(d,-1,GETDATE()) and Estado='Activo'
select Tienda from Tiendas where Fecha_Cierre<DATEADD(day,15,GETDATE()) and Estado='Activo'
select DATEDIFF(day,GETDATE(),Fecha_Cierre) from Tiendas where Tienda='Tienda1'
truncate table Tiendas

-------------------------Tiendas--------------------------

-------------------------Historial Tiendas--------------------------

select Codigo, Tienda, Vendedor, Fecha_Inicio as 'Fecha Inicio', Fecha_Cierre as 'Fecha Cierre', Alquiler, Estado, FechaSistema as 'Fecha Sistema', HoraSistema as 'Hora Sistema', Accion, NuevoOrden as 'Nuevo Orden', AntiguoOrden as 'Antiguo Orden' from HistorialTiendas
truncate table HistorialTiendas

-------------------------Historial Tiendas--------------------------

-------------------------Entradas y Salidas--------------------------

select * from EntradasSalidas 
select * from EntradasSalidas  where (Ingreso='Tienda2' ) or Ingreso='Tienda2' ) and (Salida='Tienda2' ) or Salida='Tienda2' ) and (Prenda='Prenda3' ) or Prenda='Prenda3' )  and Fecha between '16/06/2016' and '16/06/2016'
select Codigo from EntradasSalidas where Ingreso='Tienda2' and Salida='Tienda1' and Prenda='Prenda2' and Fecha = '2016-06-15'
truncate table EntradasSalidas
select Salida, Ingreso, Prenda, sum(Cantidad) as 'Cantidad', Fecha from EntradasSalidas group by  Salida, Ingreso, Prenda, Fecha
-------------------------Entradas y Salidas--------------------------

-------------------------Historial Entradas y Salidas--------------------------

select * from HistorialEntradasSalidas
 truncate table HistorialEntradasSalidas
 
 select Fecha, Salida as 'Tienda Salida', Ingreso as 'Tienda Ingreso', Prenda as 'Prenda Salida', Cantidad'Cantidad de Prendas' from EntradasSalidas
 
 select ES.Fecha, HoraSistema as 'Hora', ES.Salida as 'Tienda Salida', ES.Ingreso as 'Tienda Ingreso', ES.Prenda as 'Prenda Salida', ES.Cantidad'Cantidad de Prendas' from EntradasSalidas as ES inner join HistorialEntradasSalidas as HES on ES.Codigo=HES.Codigo

-------------------------Historial Entradas y Salidas--------------------------

-------------------------Ventas--------------------------
select * from Ventas
select Tienda, Prenda, sum(cantidad) as 'Cantidad de Prendas', sum(total) as 'Total Ventas' from Ventas where Tienda='Tienda1' group by Tienda,Prenda 
select V.Fecha, HoraSistema, V.Tienda, V.Prenda, V.Cantidad, V.Total from Ventas as V inner join HistorialVentas as HV on V.Codigo=HV.Codigo
-------------------------Ventas--------------------------

-------------------------Historial Ventas--------------------------
select * from HistorialVentas
truncate table HistorialVentas
-------------------------Historial Ventas--------------------------
-------------------------Stock--------------------------
select * from RelacionStock
-------------------------Personal---------------------------
select DATEDIFF(day,GETDATE(),FechaFinal) from DatosPersonal where Orden=1
select Orden from DatosPersonal where FechaFinal<DATEADD(day,15,GETDATE()) and Estado='Activo'
select * from DatosPersonal where FechaFinal<DATEADD(d,-1,GETDATE()) and Estado='Activo'
select DATEDIFF(day,GETDATE(),FechaFinal) from DatosPersonal where DNI=1
select * from DatosPersonal
select DATEDIFF(day,GETDATE(),FechaVacaciones) from DatosPersonal where FechaVacaciones<DATEADD(day,400,GETDATE()) and Estado='Activo'
select cast(DATEDIFF(day,GETDATE(),FechaVacaciones)) as Tiempo from DatosPersonal
select Nombres from DatosPersonal where DATEADD(DAY,0,FechaVacaciones)=DATEADD(day,365,GETDATE()) and Estado='Activo'
-------------------------Personal---------------------------
select * from HistorialCalculoPrendas where Codigo='1'
exec EliminarCalculoGastos 1,'1','1/2/2016','3','4','2','3','4','2','3','4','2','3','4','4',3,1
	select * from CalculoGastos
	select * from HistorialCalculoGastos
-------------------------Truncate----------------------
truncate table Prendas
truncate table HistorialPrendas
truncate table Tiendas
truncate table HistorialTiendas
truncate table EntradasSalidas
truncate table HistorialEntradasSalidas
truncate table Ventas
truncate table HistorialVentas
truncate table Stock
truncate table HistorialStock
truncate table RelacionStock
truncate table DatosPersonal
truncate table HistorialDatosPersonal
truncate table PersonalAdministrativo
truncate table HistorialPersonalAdministrativo
truncate table CalculoPrendas
truncate table HistorialCalculoPrendas
truncate table CalculoGastos
truncate table HistorialCalculoGastos

select * from Prendas
select * from HistorialPrendas
select * from Tiendas
select * from HistorialTiendas
select * from EntradasSalidas
select * from HistorialEntradasSalidas
select * from Ventas
select * from HistorialVentas
select * from Stock
select * from HistorialStock
select * from RelacionStock
select * from DatosPersonal
select * from HistorialDatosPersonal
select * from CalculoPrendas
select * from HistorialCalculoPrendas
select * from CalculoGastos
select * from HistorialCalculoGastos
select * from Usuarios
select * from Conexiones
select * from HistorialConexiones

drop table Prendas
drop table HistorialPrendas
drop table Tiendas
drop table HistorialTiendas
drop table EntradasSalidas
drop table HistorialEntradasSalidas
drop table Ventas
drop table HistorialVentas
drop table Stock
drop table HistorialStock
drop table RelacionStock
drop table DatosPersonal
drop table HistorialDatosPersonal


Alter Database BDNaysha Set SINGLE_USER WITH ROLLBACK immediate 
Restore Database BDNaysha FROM Disk = 'C:\Users\hp1\Desktop\BDNaysha.bak' WITH REPLACE;