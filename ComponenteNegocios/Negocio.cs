using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponenteDatos;
using System.Data;

namespace ComponenteNegocios
{
    public class Negocio
    {
        Datos cd = new Datos();

        #region Base de Datos
        // Base De Datos
        public Boolean BaseDeDatos()
        {
            return cd.BaseDeDatos();
        }

        public DataTable SelectDataTable(string query)
        {
            return cd.SelectDataTable(query);
        }

        public String ObtenerDatos(String query)
        {
            return cd.selectstring(query);
        }
        public Int32 Contar(String tabla, String Condicion)
        {
            Int32 Conteo;
            object top = cd.Contar("select count(*) from " + tabla + " where " + Condicion);
            if (top != null)
            {
                Conteo = Convert.ToInt32(top.ToString());
            }
            else
            {
                Conteo = 0;
            }
            return Conteo;
        }
        public List<String> Listas(String query)
        {
            return cd.Listas(query);
        }
        public List<int> ListasEnteros(String query)
        {
            return cd.ListasEnteros(query);
        }

        public String NuevoCodigo(String Tabla)
        {
            Int32 Orden;
            object top = cd.Contar("select top (1) Codigo from " + Tabla + " order by Codigo desc");
            if (top != null)
            {
                Orden = Convert.ToInt32(top.ToString()) + 1;
            }
            else
            {
                Orden = 1;
            }
            return Orden.ToString();
        }

        public Int32 NuevoOrden(String Tabla)
        {
            Int32 Orden;
            object top = cd.Contar("select top (1) Orden from " + Tabla + " order by Orden desc");
            if (top != null)
            {
                Orden = Convert.ToInt32(top.ToString()) + 1;
            }
            else
            {
                Orden = 1;
            }
            return Orden;
        }
        public String Orden(String Tabla, String Codigo)
        {
            String Orden;
            object top = cd.Contar("select Orden from " + Tabla + " where Codigo='" + Codigo + "'");
            if (top != null)
            {
                Orden = top.ToString();
            }
            else
            {
                Orden = "Error";
            }
            return Orden;
        }
        
        public bool Comprobar(String query)
        {
            return cd.executecommand(query);
        }

        public bool GuardarBD(string localizacion)
        {
            return cd.GuardarBD(localizacion);
        }
        public String RestaurarBD(string localizacion)
        {
            
            return cd.RestaurarBD(localizacion);
        }
        #endregion

        #region Guardar

        public Int32 GuardarPrendas(Int32 modo, String Codigo, String Prenda, String Color, String Talla, String PxMayor, String PxMenor, String Estado, Int32 ordenPrenda)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarPrendas(Codigo, Prenda, Color, Talla, PxMayor, PxMenor, Estado, ordenPrenda))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarPrendas(Codigo, Prenda, Color, Talla, PxMayor, PxMenor, Estado, ordenPrenda))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarTiendas(Int32 modo, String Codigo, String Tienda, String Vendedor, String Fecha_Inicio, String Fecha_Cierre, String Alquiler, String Estado, int Orden)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarTiendas(Codigo, Tienda, Vendedor, Fecha_Inicio, Fecha_Cierre, Alquiler, Estado, Orden))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarTiendas(Codigo, Tienda, Vendedor, Fecha_Inicio, Fecha_Cierre, Alquiler, Estado, Orden))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarEntradasSalidas(Int32 modo, String Boleta, String Salida, String Ingreso, String Prenda, String CodigoPrenda, String Cantidad, DateTime Fecha, String Estado, String Orden, String OrdenAnterior)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarEntradasSalidas(Boleta,Salida,Ingreso,Prenda,CodigoPrenda,Cantidad,Fecha,Estado,Orden))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarEntradasSalidas(Boleta, Salida, Ingreso, Prenda, CodigoPrenda, Cantidad, Fecha, Estado, Orden, OrdenAnterior))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarVentas(Int32 modo,String Boleta, String Tienda, String Prenda, String Tipo, String Cantidad, String Precio, String Total, DateTime Fecha, String Orden, String OrdenAnterior)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarVentas(Boleta, Tienda, Prenda, Tipo, Cantidad, Precio, Total, Fecha, Orden))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarVentas(Boleta, Tienda, Prenda, Tipo, Cantidad, Precio, Total, Fecha, Orden, OrdenAnterior))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 ActualizarStock(int StockReal, int Codigo)
        {
            Int32 Valor;
            if (cd.ActualizarStock(StockReal, Codigo))
                Valor = 0;
            else
                Valor = 1;

            return Valor;
        }

        public Int32 GuardarReporte(Int32 Codigo, String Tienda, String Prenda, String FechaInicio, String FechaFinal, Int32 StockInicial, Int32 StockIngreso, Int32 StockSalida, Int32 StockVentas, Int32 StockReal, Int32 Variacion, String Disponible)
        {
            Int32 Valor;
            if (cd.GuardarReporte(Codigo, Tienda, Prenda, FechaInicio, FechaFinal, StockInicial, StockIngreso, StockSalida, StockVentas, StockReal, Variacion, Disponible))
                Valor = 0;
            else
                Valor = 1;

            return Valor;
        }

        public Int32 GuardarRelacion(String Tienda)
        {
            Int32 Valor;
            if (cd.GuardarRelacion(Tienda))
                Valor = 0;
            else
                Valor = 1;

            return Valor;
        }

        public Int32 GuardarPersonal(Int32 modo, String Codigo, String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarPersonal(Nombres, Apellidos, DNI, NumeroFijo, Direccion, NumeroCelular, Referencia, FechaInicio, FechaFinal, FechaVacaciones, Estado, Tienda, Salario, Seguro, Descuento, Total))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarPersonal(Codigo, Nombres, Apellidos, DNI, NumeroFijo, Direccion, NumeroCelular, Referencia, FechaInicio, FechaFinal, FechaVacaciones, Estado, Tienda, Salario, Seguro, Descuento, Total))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarAdministrativo(Int32 modo, String Codigo, String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarAdministrativo(Nombres, Apellidos, DNI, NumeroFijo, Direccion, NumeroCelular, Referencia, FechaInicio, FechaFinal, FechaVacaciones, Estado, Tienda, Salario, Seguro, Descuento, Total))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarAdministrativo(Codigo, Nombres, Apellidos, DNI, NumeroFijo, Direccion, NumeroCelular, Referencia, FechaInicio, FechaFinal, FechaVacaciones, Estado, Tienda, Salario, Seguro, Descuento, Total))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarCalculoPrendas(Int32 modo, String Codigo, String MetrosTela, String PrecioTela, String SubTtotalTela, String MetrosAplicacion, String PrecioAplicacion, String SubTotalAplicaciones, String CantidadDecoracion, String PrecioDecoracion, String SubTotalDecoracion, String PrecioServicio, String TransporteServicio, String ManoObraServicio, String PersonalTiendaServicio, String GananciaServicio, String SubTotalServicio, String CostoIGV, String CostoTotal, DateTime Fecha, String NuevoOrden, String AntiguoOrden)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarCalculoPrendas(Codigo, MetrosTela, PrecioTela, SubTtotalTela, MetrosAplicacion, PrecioAplicacion, SubTotalAplicaciones, CantidadDecoracion, PrecioDecoracion, SubTotalDecoracion, PrecioServicio, TransporteServicio, ManoObraServicio, PersonalTiendaServicio, GananciaServicio, SubTotalServicio, CostoIGV, CostoTotal, Fecha, NuevoOrden))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarCalculoPrendas(Codigo, MetrosTela, PrecioTela, SubTtotalTela, MetrosAplicacion, PrecioAplicacion, SubTotalAplicaciones, CantidadDecoracion, PrecioDecoracion, SubTotalDecoracion, PrecioServicio, TransporteServicio, ManoObraServicio, PersonalTiendaServicio, GananciaServicio, SubTotalServicio, CostoIGV, CostoTotal, Fecha, NuevoOrden, AntiguoOrden))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }

        public Int32 GuardarCalculoGastos(Int32 modo, String Codigo, String Tienda, DateTime Fecha, String GastosTiendas, String PagosPersonal, String PagosTaller, String PagosTienda, String GastosTelas, String GastosHijos, String GastosAccesorios, String GastosPlanchado, String Monto, String GastosPagos, String GastosMateria, String Total, String NuevoOrden, String AntiguoOrden)
        {
            Int32 Valor;
            if (modo == 1)
            {
                if (cd.InsertarCalculoGastos(Codigo, Tienda, Fecha, GastosTiendas, PagosPersonal, PagosTaller, PagosTienda, GastosTelas, GastosHijos, GastosAccesorios, GastosPlanchado, Monto, GastosPagos, GastosMateria, Total, NuevoOrden))
                    Valor = 1;
                else
                    Valor = 2;
            }
            else if (modo == 2)
            {
                if (cd.ActualizarCalculoGastos(Codigo, Tienda, Fecha, GastosTiendas, PagosPersonal, PagosTaller, PagosTienda, GastosTelas, GastosHijos, GastosAccesorios, GastosPlanchado, Monto, GastosPagos, GastosMateria, Total, NuevoOrden, AntiguoOrden))
                    Valor = 3;
                else
                    Valor = 4;
            }
            else
                Valor = 0;
            return Valor;
        }
        #endregion

        #region Eliminar
        public bool EliminarPrendas(String codigo)
        {
            return cd.EliminarPrendas(codigo);
        }

        public bool EliminarTiendas(String codigo)
        {
            return cd.EliminarTiendas(codigo);

        }

        public bool EliminarEntradasSalidas(String Orden)
        {
            return cd.EliminarEntradasSalidas(Orden);
        }
        public bool EliminarVentas(String Codigo)
        {
            return cd.EliminarVentas(Codigo);
        }
        public bool EliminarPersonal(String Codigo)
        {
            return cd.EliminarPersonal(Codigo);
        }
        public bool EliminarAdministrativo(String Codigo)
        {
            return cd.EliminarAdministrativo(Codigo);
        }
        public bool EliminarCalculoPrendas(String Codigo, String MetrosTela, String PrecioTela, String SubTtotalTela, String MetrosAplicacion, String PrecioAplicacion, String SubTotalAplicaciones, String CantidadDecoracion, String PrecioDecoracion, String SubTotalDecoracion, String PrecioServicio, String TransporteServicio, String ManoObraServicio, String PersonalTiendaServicio, String GananciaServicio, String SubTotalServicio, String CostoIGV, String CostoTotal, DateTime Fecha, String NuevoOrden, String AntiguoOrden)
        {
            return cd.EliminarCalculoPrendas(Codigo, MetrosTela, PrecioTela, SubTtotalTela, MetrosAplicacion, PrecioAplicacion, SubTotalAplicaciones, CantidadDecoracion, PrecioDecoracion, SubTotalDecoracion, PrecioServicio, TransporteServicio, ManoObraServicio, PersonalTiendaServicio, GananciaServicio, SubTotalServicio, CostoIGV, CostoTotal, Fecha,NuevoOrden, AntiguoOrden);
        }
        public bool EliminarCalculoGastos(String Codigo, String Tienda, DateTime Fecha, String GastosTiendas, String PagosPersonal, String PagosTaller, String PagosTienda, String GastosTelas, String GastosHijos, String GastosAccesorios, String GastosPlanchado, String Monto, String GastosPagos, String GastosMateria, String Total, String NuevoOrden, String AntiguoOrden)
        {
            return cd.EliminarCalculoGastos(Codigo, Tienda, Fecha, GastosTiendas, PagosPersonal, PagosTaller, PagosTienda, GastosTelas, GastosHijos, GastosAccesorios, GastosPlanchado, Monto, GastosPagos, GastosMateria, Total, NuevoOrden, AntiguoOrden);
        }
        #endregion

        #region Usuario
        public String VerificarUsuario(String Usuario, String Clave)
        {
            //return cd.VerificarUsuario(Usuario, Clave);
            if (cd.VerificarUsuario(Usuario, Clave) == "1")
            {
                if (cd.VerificarConexion(Usuario) == "1")
                {
                    if (cd.ActualizarConexion(Usuario))
                        return "1";
                    else
                        return "0";
                }
                else
                {
                    if (cd.RegistrarConexion(Usuario))
                        return "1";
                    else
                        return "0";
                }
            }
            else
                return "0";

        }
        public void TerminarConexion()
        {
            String Usuario = ObtenerUsuario();
            try
            {
                cd.TerminarConexion(Usuario);
            }
            catch
            {
                
            }

        }
        public String ObtenerUsuario()
        {
            return cd.ObtenerUsuario();
        }
        public bool InsertarUsuarios(String Usuario, String Clave, String Tipo, String Nombre, String Apellido, String Eddad, String Genero)
        {
            return cd.InsertarUsuarios(Usuario, Clave, Tipo, Nombre, Apellido, Eddad, Genero);
        }

        #endregion
    }
}