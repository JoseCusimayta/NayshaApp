using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace ComponenteDatos
{
    public class Datos
    {
        public string connection = string.Empty;
        public SqlConnection connect;
        public SqlCommand command;
        public SqlDataAdapter da;
        public DataTable dt;
        public DataSet ds;
        String DataSource = "YIWO\\SQLEXPRESS";
        String DBNAME = "BDNaysha";
        String Clave = "kc34jopz";
        //String DataSource = "DESKTOP-GB6BGBL";
        //String DBNAME = "BDNaysha";
        String Usuario = "Druisor";
        //String Clave = "Jhan1984";
        //String DataSource = "Yiwo";
        //String DBNAME = "BDNaysha";
        //String Usuario = "Yiwo";
        //String Clave = "kc34jopz";

        #region Base de Datos
        //Base de datos
        public Boolean BaseDeDatos()
        {
            Boolean valor;
            try
            {
                connect = new SqlConnection("Data Source=" + DataSource + ";Initial Catalog=" + DBNAME + ";User ID="+Usuario+";Password=" + Clave);
                connect.Open();
                valor = true;
            }
            catch
            {
                valor = false;
            }
            return valor;
        }
        private SqlConnection connecttodb()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.ConnectionString = connection;
                    connect.Open();
                }
                catch
                {
                    connect = null;
                }
            }
            return connect;
        }

        public List<String> Listas(String query)
        {
            List<String> columnData = new List<String>();
            using (SqlCommand command = new SqlCommand(query, connect))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columnData.Add(reader.GetString(0));
                    }
                }
            }
            return columnData;
        }
        public List<Int32> ListasEnteros(String query)
        {
            List<Int32> columnData = new List<Int32>();
            using (SqlCommand command = new SqlCommand(query, connect))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columnData.Add(reader.GetInt32(0));
                    }
                }
            }
            return columnData;
        }
        private void closeconnection()
        {
            if (connect.State != ConnectionState.Closed)
                connect.Close();
        }
        public string selectstring(string query)
        {
            string cadena = string.Empty;
            try
            {
                connecttodb();
                command = new SqlCommand(query, connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
            }
            return cadena;
        }

        public bool executecommand(string query)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }

        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                connecttodb();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }

        public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                command = new SqlCommand(namestoreprocedure, connect);//
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch
            {
                dt = null;
            }
            finally
            {
            }
            return dt;
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            finally
            {
            }
            return dt;
        }

        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();
            try
            {
                connecttodb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(ds, table);
            }
            catch
            {
                ds = null;
            }
            finally
            {
            }
            return ds;
        }
        public object Contar(String query)
        {
            object count;
            SqlConnection conDatabase;
            SqlCommand com;
            try
            {
                conDatabase = connecttodb();
                com = new SqlCommand(query, conDatabase);
                count = com.ExecuteScalar();
            }
            catch
            {
                count = null;
            }
            finally
            {
            }
            return count;
        }
        public String RestaurarBD(String Localizacion)
        {
            String sql, mensaje;
            try
            {
                connect = new SqlConnection("Data Source=" + DataSource + ";User ID=" + Usuario + ";Password=" + Clave);
                connect.Open();
                try
                {
                    sql = "ALTER DATABASE " + DBNAME + " SET SINGLE_USER with ROLLBACK IMMEDIATE;";
                    command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    sql = null;
                }
                sql = "Restore Database " + DBNAME + " FROM Disk = '" + Localizacion + "' WITH REPLACE";
                command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                connect.Close();
                connect.Dispose();
                mensaje = "Base de Datos Naysha Restaurada correctamente";
            }
            catch(Exception e)
            {
                mensaje=e.Message;
            }
            return mensaje;
        }
        public bool GuardarBD(String Localizacion)
        {
            string sql;
            try
            {
                connect = new SqlConnection("Data Source=" + DataSource + ";User ID=" + Usuario + ";Password=" + Clave);
                connect.Open();
                sql = "BACKUP DATABASE " + DBNAME + " TO DISK='" + Localizacion + "\\" + DBNAME + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                connect.Close();
                connect.Dispose();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        #endregion

        #region Insertar
        public bool InsertarPrendas(String Codigo, String Prenda, String Color, String Talla, String PxMayor, String PxMenor, String Estado, Int32 Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@Color", SqlDbType.VarChar, 20).Value = Color;
                command.Parameters.Add("@Talla", SqlDbType.VarChar, 8).Value = Talla;
                command.Parameters.Add("@PxMayor", SqlDbType.VarChar, 8).Value = PxMayor;
                command.Parameters.Add("@PxMenor", SqlDbType.VarChar, 8).Value = PxMenor;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 10).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarTiendas(String Codigo, String Tienda, String Vendedor, String Fecha_Inicio, String Fecha_Cierre, String Alquiler, String Estado, int Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarTiendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Vendedor", SqlDbType.VarChar, 20).Value = Vendedor;
                command.Parameters.Add("@Fecha_Inicio", SqlDbType.Date).Value = Fecha_Inicio;
                command.Parameters.Add("@Fecha_Cierre", SqlDbType.Date).Value = Fecha_Cierre;
                command.Parameters.Add("@Alquiler", SqlDbType.VarChar, 10).Value = Alquiler;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarEntradasSalidas(String Boleta, String Salida, String Ingreso, String Prenda, String CodigoPrenda, String Cantidad, DateTime Fecha, String Estado, String Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarEntradasSalidas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Boleta", SqlDbType.VarChar, 13).Value = Boleta;
                command.Parameters.Add("@Salida", SqlDbType.VarChar, 20).Value = Salida;
                command.Parameters.Add("@Ingreso", SqlDbType.VarChar, 20).Value = Ingreso;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@CodigoPrenda", SqlDbType.VarChar, 6).Value = CodigoPrenda;
                command.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarVentas(String Boleta, String Tienda, String Prenda, String Tipo, String Cantidad, String Precio, String Total, DateTime Fecha, String Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarVentas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Boleta", SqlDbType.VarChar, 13).Value = Boleta;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@Tipo", SqlDbType.VarChar, 9).Value = Tipo;
                command.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Precio;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool GuardarReporte(Int32 Codigo, String Tienda, String Prenda, String FechaInicio, String FechaFinal, Int32 StockInicial, Int32 StockIngreso, Int32 StockSalida, Int32 StockVentas, Int32 StockReal, Int32 Variacion, String Disponible)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("GuardarReporte", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = FechaInicio;
                command.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal;
                command.Parameters.Add("@StockInicial", SqlDbType.Int).Value = StockInicial;
                command.Parameters.Add("@StockIngreso", SqlDbType.Int).Value = StockIngreso;
                command.Parameters.Add("@StockSalida", SqlDbType.Int).Value = StockSalida;
                command.Parameters.Add("@StockVentas", SqlDbType.Int).Value = StockVentas;
                command.Parameters.Add("@StockReal", SqlDbType.Int).Value = StockReal;
                command.Parameters.Add("@Variacion", SqlDbType.Int).Value = Variacion;
                command.Parameters.Add("@Disponible", SqlDbType.VarChar, 8).Value = Disponible;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool GuardarRelacion(String Tienda)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarRelacionStock", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarPersonal(String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarPersonal", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                command.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = DNI;
                command.Parameters.Add("@NumeroFijo", SqlDbType.VarChar, 7).Value = NumeroFijo;
                command.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                command.Parameters.Add("@NumeroCelular", SqlDbType.VarChar, 9).Value = NumeroCelular;
                command.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = Referencia;
                command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = FechaInicio;
                command.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal;
                command.Parameters.Add("@FechaVacaciones", SqlDbType.Date).Value = FechaVacaciones;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Salario", SqlDbType.Decimal).Value = Salario;
                command.Parameters.Add("@Seguro", SqlDbType.VarChar, 20).Value = Seguro;
                command.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Descuento;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarAdministrativo(String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarAdministrativo", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                command.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = DNI;
                command.Parameters.Add("@NumeroFijo", SqlDbType.VarChar, 7).Value = NumeroFijo;
                command.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                command.Parameters.Add("@NumeroCelular", SqlDbType.VarChar, 9).Value = NumeroCelular;
                command.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = Referencia;
                command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = FechaInicio;
                command.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal;
                command.Parameters.Add("@FechaVacaciones", SqlDbType.Date).Value = FechaVacaciones;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Cargo", SqlDbType.VarChar, 30).Value = Tienda;
                command.Parameters.Add("@Salario", SqlDbType.Decimal).Value = Salario;
                command.Parameters.Add("@Seguro", SqlDbType.VarChar, 20).Value = Seguro;
                command.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Descuento;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarCalculoPrendas(String Codigo, String MetrosTela, String PrecioTela, String SubTtotalTela, String MetrosAplicacion, String PrecioAplicacion, String SubTotalAplicaciones, String CantidadDecoracion, String PrecioDecoracion, String SubTotalDecoracion, String PrecioServicio, String TransporteServicio, String ManoObraServicio, String PersonalTiendaServicio, String GananciaServicio, String SubTotalServicio, String CostoIGV, String CostoTotal, DateTime Fecha, String NuevoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarCalculoPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Decimal).Value = Codigo;
                command.Parameters.Add("@MetrosTela", SqlDbType.Decimal).Value = MetrosTela;
                command.Parameters.Add("@PrecioTela", SqlDbType.Decimal).Value = PrecioTela;
                command.Parameters.Add("@SubTtotalTela", SqlDbType.Decimal).Value = SubTtotalTela;
                command.Parameters.Add("@MetrosAplicacion", SqlDbType.Decimal).Value = MetrosAplicacion;
                command.Parameters.Add("@PrecioAplicacion", SqlDbType.Decimal).Value = PrecioAplicacion;
                command.Parameters.Add("@SubTotalAplicaciones", SqlDbType.Decimal).Value = SubTotalAplicaciones;
                command.Parameters.Add("@CantidadDecoracion", SqlDbType.Decimal).Value = CantidadDecoracion;
                command.Parameters.Add("@PrecioDecoracion", SqlDbType.Decimal).Value = PrecioDecoracion;
                command.Parameters.Add("@SubTotalDecoracion", SqlDbType.Decimal).Value = SubTotalDecoracion;
                command.Parameters.Add("@PrecioServicio", SqlDbType.Decimal).Value = PrecioServicio;
                command.Parameters.Add("@TransporteServicio", SqlDbType.Decimal).Value = TransporteServicio;
                command.Parameters.Add("@ManoObraServicio", SqlDbType.Decimal).Value = ManoObraServicio;
                command.Parameters.Add("@PersonalTiendaServicio", SqlDbType.Decimal).Value = PersonalTiendaServicio;
                command.Parameters.Add("@GananciaServicio", SqlDbType.Decimal).Value = GananciaServicio;
                command.Parameters.Add("@SubTotalServicio", SqlDbType.Decimal).Value = SubTotalServicio;
                command.Parameters.Add("@CostoIGV", SqlDbType.Decimal).Value = CostoIGV;
                command.Parameters.Add("@CostoTotal", SqlDbType.Decimal).Value = CostoTotal;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool InsertarCalculoGastos(String Codigo, String Tienda, DateTime Fecha, String GastosTiendas, String PagosPersonal, String PagosTaller, String PagosTienda, String GastosTelas, String GastosHijos, String GastosAccesorios, String GastosPlanchado, String Monto, String GastosPagos, String GastosMateria, String Total, String NuevoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarCalculoGastos", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 30).Value = Tienda;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@GastosTiendas", SqlDbType.Decimal).Value = GastosTiendas;
                command.Parameters.Add("@PagosPersonal", SqlDbType.Decimal).Value = PagosPersonal;
                command.Parameters.Add("@PagosTaller", SqlDbType.Decimal).Value = PagosTaller;
                command.Parameters.Add("@PagosTienda", SqlDbType.Decimal).Value = PagosTienda;
                command.Parameters.Add("@GastosTelas", SqlDbType.Decimal).Value = GastosTelas;
                command.Parameters.Add("@GastosHijos", SqlDbType.Decimal).Value = GastosHijos;
                command.Parameters.Add("@GastosAccesorios", SqlDbType.Decimal).Value = GastosAccesorios;
                command.Parameters.Add("@GastosPlanchado", SqlDbType.Decimal).Value = GastosPlanchado;
                command.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto;
                command.Parameters.Add("@GastosPagos", SqlDbType.Decimal).Value = GastosPagos;
                command.Parameters.Add("@GastosMateria", SqlDbType.Decimal).Value = GastosMateria;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }

        #endregion

        #region Actualizar
        public bool ActualizarPrendas(String Codigo, String Prenda, String Color, String Talla, String PxMayor, String PxMenor, String Estado, Int32 Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@Color", SqlDbType.VarChar, 20).Value = Color;
                command.Parameters.Add("@Talla", SqlDbType.VarChar, 8).Value = Talla;
                command.Parameters.Add("@PxMayor", SqlDbType.VarChar, 8).Value = PxMayor;
                command.Parameters.Add("@PxMenor", SqlDbType.VarChar, 8).Value = PxMenor;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 10).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarTiendas(String Codigo, String Tienda, String Vendedor, String Fecha_Inicio, String Fecha_Cierre, String Alquiler, String Estado, int Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarTiendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Vendedor", SqlDbType.VarChar, 20).Value = Vendedor;
                command.Parameters.Add("@Fecha_Inicio", SqlDbType.Date).Value = Fecha_Inicio;
                command.Parameters.Add("@Fecha_Cierre", SqlDbType.Date).Value = Fecha_Cierre;
                command.Parameters.Add("@Alquiler", SqlDbType.VarChar, 10).Value = Alquiler;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarEntradasSalidas(String Boleta, String Salida, String Ingreso, String Prenda, String CodigoPrenda, String Cantidad, DateTime Fecha, String Estado, String Orden, String OrdenAnterior)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarEntradasSalidas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Boleta", SqlDbType.VarChar, 13).Value = Boleta;
                command.Parameters.Add("@Salida", SqlDbType.VarChar, 20).Value = Salida;
                command.Parameters.Add("@Ingreso", SqlDbType.VarChar, 20).Value = Ingreso;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@CodigoPrenda", SqlDbType.VarChar, 6).Value = CodigoPrenda;
                command.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.Parameters.Add("@OrdenAnterior", SqlDbType.Int).Value = OrdenAnterior;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarVentas(String Boleta, String Tienda, String Prenda, String Tipo, String Cantidad, String Precio, String Total, DateTime Fecha, String Orden, String OrdenAnterior)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarVentas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Boleta", SqlDbType.VarChar, 13).Value = Boleta;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Prenda", SqlDbType.VarChar, 20).Value = Prenda;
                command.Parameters.Add("@Tipo", SqlDbType.VarChar, 9).Value = Tipo;
                command.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Precio;
                command.Parameters.Add("@Total", SqlDbType.VarChar, 7).Value = Total;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.Parameters.Add("@OrdenAnterior", SqlDbType.Int).Value = OrdenAnterior;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarStock(int StockReal, int Codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarStock", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@StockReal", SqlDbType.Int).Value = StockReal;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarPersonal(String Codigo, String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarPersonal", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                command.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = DNI;
                command.Parameters.Add("@NumeroFijo", SqlDbType.VarChar, 7).Value = NumeroFijo;
                command.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                command.Parameters.Add("@NumeroCelular", SqlDbType.VarChar, 9).Value = NumeroCelular;
                command.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = Referencia;
                command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = FechaInicio;
                command.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal;
                command.Parameters.Add("@FechaVacaciones", SqlDbType.Date).Value = FechaVacaciones;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 20).Value = Tienda;
                command.Parameters.Add("@Salario", SqlDbType.Decimal).Value = Salario;
                command.Parameters.Add("@Seguro", SqlDbType.VarChar, 20).Value = Seguro;
                command.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Descuento;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarAdministrativo(String Codigo, String Nombres, String Apellidos, String DNI, String NumeroFijo, String Direccion, String NumeroCelular, String Referencia, DateTime FechaInicio, DateTime FechaFinal, DateTime FechaVacaciones, String Estado, String Tienda, String Salario, String Seguro, String Descuento, String Total)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarAdministrativo", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Nombres;
                command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 50).Value = Apellidos;
                command.Parameters.Add("@DNI", SqlDbType.VarChar, 8).Value = DNI;
                command.Parameters.Add("@NumeroFijo", SqlDbType.VarChar, 7).Value = NumeroFijo;
                command.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = Direccion;
                command.Parameters.Add("@NumeroCelular", SqlDbType.VarChar, 9).Value = NumeroCelular;
                command.Parameters.Add("@Referencia", SqlDbType.VarChar, 50).Value = Referencia;
                command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = FechaInicio;
                command.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal;
                command.Parameters.Add("@FechaVacaciones", SqlDbType.Date).Value = FechaVacaciones;
                command.Parameters.Add("@Estado", SqlDbType.VarChar, 11).Value = Estado;
                command.Parameters.Add("@Cargo", SqlDbType.VarChar, 30).Value = Tienda;
                command.Parameters.Add("@Salario", SqlDbType.Decimal).Value = Salario;
                command.Parameters.Add("@Seguro", SqlDbType.VarChar, 20).Value = Seguro;
                command.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = Descuento;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarCalculoPrendas(String Codigo, String MetrosTela, String PrecioTela, String SubTtotalTela, String MetrosAplicacion, String PrecioAplicacion, String SubTotalAplicaciones, String CantidadDecoracion, String PrecioDecoracion, String SubTotalDecoracion, String PrecioServicio, String TransporteServicio, String ManoObraServicio, String PersonalTiendaServicio, String GananciaServicio, String SubTotalServicio, String CostoIGV, String CostoTotal, DateTime Fecha, String NuevoOrden, String AntiguoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarCalculoPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Decimal).Value = Codigo;
                command.Parameters.Add("@MetrosTela", SqlDbType.Decimal).Value = MetrosTela;
                command.Parameters.Add("@PrecioTela", SqlDbType.Decimal).Value = PrecioTela;
                command.Parameters.Add("@SubTtotalTela", SqlDbType.Decimal).Value = SubTtotalTela;
                command.Parameters.Add("@MetrosAplicacion", SqlDbType.Decimal).Value = MetrosAplicacion;
                command.Parameters.Add("@PrecioAplicacion", SqlDbType.Decimal).Value = PrecioAplicacion;
                command.Parameters.Add("@SubTotalAplicaciones", SqlDbType.Decimal).Value = SubTotalAplicaciones;
                command.Parameters.Add("@CantidadDecoracion", SqlDbType.Decimal).Value = CantidadDecoracion;
                command.Parameters.Add("@PrecioDecoracion", SqlDbType.Decimal).Value = PrecioDecoracion;
                command.Parameters.Add("@SubTotalDecoracion", SqlDbType.Decimal).Value = SubTotalDecoracion;
                command.Parameters.Add("@PrecioServicio", SqlDbType.Decimal).Value = PrecioServicio;
                command.Parameters.Add("@TransporteServicio", SqlDbType.Decimal).Value = TransporteServicio;
                command.Parameters.Add("@ManoObraServicio", SqlDbType.Decimal).Value = ManoObraServicio;
                command.Parameters.Add("@PersonalTiendaServicio", SqlDbType.Decimal).Value = PersonalTiendaServicio;
                command.Parameters.Add("@GananciaServicio", SqlDbType.Decimal).Value = GananciaServicio;
                command.Parameters.Add("@SubTotalServicio", SqlDbType.Decimal).Value = SubTotalServicio;
                command.Parameters.Add("@CostoIGV", SqlDbType.Decimal).Value = CostoIGV;
                command.Parameters.Add("@CostoTotal", SqlDbType.Decimal).Value = CostoTotal;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.Parameters.Add("@AntiguoOrden", SqlDbType.Int).Value = AntiguoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarCalculoGastos(String Codigo, String Tienda, DateTime Fecha, String GastosTela, String PagosPersonal, String PagosTaller, String PagosTienda, String GastosTelas, String GastosHijos, String GastosAccesorios, String GastosPlanchado, String Monto, String GastosPagos, String GastosMateria, String Total,  String NuevoOrden, String AntiguoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarCalculoGastos", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 30).Value = Tienda;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@GastosTiendas", SqlDbType.Decimal).Value = GastosTela;
                command.Parameters.Add("@PagosPersonal", SqlDbType.Decimal).Value = PagosPersonal;
                command.Parameters.Add("@PagosTaller", SqlDbType.Decimal).Value = PagosTaller;
                command.Parameters.Add("@PagosTienda", SqlDbType.Decimal).Value = PagosTienda;
                command.Parameters.Add("@GastosTelas", SqlDbType.Decimal).Value = GastosTelas;
                command.Parameters.Add("@GastosHijos", SqlDbType.Decimal).Value = GastosHijos;
                command.Parameters.Add("@GastosAccesorios", SqlDbType.Decimal).Value = GastosAccesorios;
                command.Parameters.Add("@GastosPlanchado", SqlDbType.Decimal).Value = GastosPlanchado;
                command.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto;
                command.Parameters.Add("@GastosPagos", SqlDbType.Decimal).Value = GastosPagos;
                command.Parameters.Add("@GastosMateria", SqlDbType.Decimal).Value = GastosMateria;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.Parameters.Add("@AntiguoOrden", SqlDbType.Int).Value = AntiguoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }

        #endregion

        #region Eliminar
        public bool EliminarPrendas(String Codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarTiendas(String Codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarTiendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.VarChar, 6).Value = Codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarEntradasSalidas(String Orden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarEntradasSalidas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarVentas(String Codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarVentas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarPersonal(String codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarPersonal", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarAdministrativo(String codigo)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarAdministrativo", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Orden", SqlDbType.Int).Value = codigo;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarCalculoPrendas(String Codigo, String MetrosTela, String PrecioTela, String SubTtotalTela, String MetrosAplicacion, String PrecioAplicacion, String SubTotalAplicaciones, String CantidadDecoracion, String PrecioDecoracion, String SubTotalDecoracion, String PrecioServicio, String TransporteServicio, String ManoObraServicio, String PersonalTiendaServicio, String GananciaServicio, String SubTotalServicio, String CostoIGV, String CostoTotal, DateTime Fecha, String NuevoOrden, String AntiguoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarCalculoPrendas", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Decimal).Value = Codigo;
                command.Parameters.Add("@MetrosTela", SqlDbType.Decimal).Value = MetrosTela;
                command.Parameters.Add("@PrecioTela", SqlDbType.Decimal).Value = PrecioTela;
                command.Parameters.Add("@SubTtotalTela", SqlDbType.Decimal).Value = SubTtotalTela;
                command.Parameters.Add("@MetrosAplicacion", SqlDbType.Decimal).Value = MetrosAplicacion;
                command.Parameters.Add("@PrecioAplicacion", SqlDbType.Decimal).Value = PrecioAplicacion;
                command.Parameters.Add("@SubTotalAplicaciones", SqlDbType.Decimal).Value = SubTotalAplicaciones;
                command.Parameters.Add("@CantidadDecoracion", SqlDbType.Decimal).Value = CantidadDecoracion;
                command.Parameters.Add("@PrecioDecoracion", SqlDbType.Decimal).Value = PrecioDecoracion;
                command.Parameters.Add("@SubTotalDecoracion", SqlDbType.Decimal).Value = SubTotalDecoracion;
                command.Parameters.Add("@PrecioServicio", SqlDbType.Decimal).Value = PrecioServicio;
                command.Parameters.Add("@TransporteServicio", SqlDbType.Decimal).Value = TransporteServicio;
                command.Parameters.Add("@ManoObraServicio", SqlDbType.Decimal).Value = ManoObraServicio;
                command.Parameters.Add("@PersonalTiendaServicio", SqlDbType.Decimal).Value = PersonalTiendaServicio;
                command.Parameters.Add("@GananciaServicio", SqlDbType.Decimal).Value = GananciaServicio;
                command.Parameters.Add("@SubTotalServicio", SqlDbType.Decimal).Value = SubTotalServicio;
                command.Parameters.Add("@CostoIGV", SqlDbType.Decimal).Value = CostoIGV;
                command.Parameters.Add("@CostoTotal", SqlDbType.Decimal).Value = CostoTotal;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.Parameters.Add("@AntiguoOrden", SqlDbType.Int).Value = AntiguoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool EliminarCalculoGastos(String Codigo, String Tienda, DateTime Fecha, String GastosTiendas, String PagosPersonal, String PagosTaller, String PagosTienda, String GastosTelas, String GastosHijos, String GastosAccesorios, String GastosPlanchado, String Monto, String GastosPagos, String GastosMateria, String Total, String NuevoOrden, String AntiguoOrden)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("EliminarCalculoGastos", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                command.Parameters.Add("@Tienda", SqlDbType.VarChar, 30).Value = Tienda;
                command.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
                command.Parameters.Add("@GastosTiendas", SqlDbType.Decimal).Value = GastosTiendas;
                command.Parameters.Add("@PagosPersonal", SqlDbType.Decimal).Value = PagosPersonal;
                command.Parameters.Add("@PagosTaller", SqlDbType.Decimal).Value = PagosTaller;
                command.Parameters.Add("@PagosTienda", SqlDbType.Decimal).Value = PagosTienda;
                command.Parameters.Add("@GastosTelas", SqlDbType.Decimal).Value = GastosTelas;
                command.Parameters.Add("@GastosHijos", SqlDbType.Decimal).Value = GastosHijos;
                command.Parameters.Add("@GastosAccesorios", SqlDbType.Decimal).Value = GastosAccesorios;
                command.Parameters.Add("@GastosPlanchado", SqlDbType.Decimal).Value = GastosPlanchado;
                command.Parameters.Add("@Monto", SqlDbType.Decimal).Value = Monto;
                command.Parameters.Add("@GastosPagos", SqlDbType.Decimal).Value = GastosPagos;
                command.Parameters.Add("@GastosMateria", SqlDbType.Decimal).Value = GastosMateria;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                command.Parameters.Add("@NuevoOrden", SqlDbType.Int).Value = NuevoOrden;
                command.Parameters.Add("@AntiguoOrden", SqlDbType.Int).Value = AntiguoOrden;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }


        #endregion

        #region Usuario

        public bool InsertarUsuarios(String Usuario, String Clave, String Tipo, String Nombre, String Apellido, String Eddad, String Genero)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand("InsertarUsuarios", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 10).Value = Usuario;
                command.Parameters.Add("@Clave", SqlDbType.VarChar, 10).Value = Clave;
                command.Parameters.Add("@Tipo", SqlDbType.VarChar, 10).Value = Tipo;
                command.Parameters.Add("@Nombre", SqlDbType.VarChar, 40).Value = Nombre;
                command.Parameters.Add("@Apellidos", SqlDbType.VarChar, 40).Value = Apellido;
                command.Parameters.Add("@edad", SqlDbType.VarChar, 2).Value = Eddad;
                command.Parameters.Add("@genero", SqlDbType.VarChar, 10).Value = Genero;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }        
        
        public String VerificarUsuario(String Usuario, String Clave)
        {
            string cadena = string.Empty;
            try
            {
                connecttodb();
                command = new SqlCommand("select count(*) from Usuarios WHERE Usuario = '" + Usuario + "' And Clave = '" + Clave + "' and estado= 1", connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
            }
            return cadena;
        }

        public String VerificarConexion(String Usuario)
        {
            String MAC = getMacAddress();
            string cadena = string.Empty;
            try
            {
                connecttodb();
                command = new SqlCommand("select count(*) from Conexiones where Usuario='" + Usuario + "' and MAC='"+ MAC+"'", connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
            }
            return cadena;
        }

        public String ObtenerUsuario()
        {
            String MAC = getMacAddress();
            string cadena = string.Empty;
            try
            {
                connecttodb();
                command = new SqlCommand("select Usuario from Conexiones WHERE estado='1' and MAC='" + MAC + "'", connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
            }
            return cadena;
        }
               
        public bool RegistrarConexion(String Usuario)
        {
            bool exito;
            String MAC = getMacAddress();
            try
            {
                connecttodb();
                command = new SqlCommand("RegistrarConexion", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 10).Value = Usuario;
                command.Parameters.Add("@MAC", SqlDbType.VarChar, 20).Value = MAC;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool ActualizarConexion(String Usuario)
        {
            bool exito;
            String MAC = getMacAddress();
            try
            {
                connecttodb();
                command = new SqlCommand("ActualizarConexion", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 10).Value = Usuario;
                command.Parameters.Add("@MAC", SqlDbType.VarChar, 20).Value = MAC;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public bool TerminarConexion(String Usuario)
        {
            bool exito;
            String MAC = getMacAddress();
            try
            {
                connecttodb();
                command = new SqlCommand("TerminarConexion", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 10).Value = Usuario;
                command.Parameters.Add("@MAC", SqlDbType.VarChar, 20).Value = MAC;
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
            }
            return exito;
        }
        public String getMacAddress()
        {
            String MACAddress;
            try
            {
                MACAddress = GetMacAddress().ToString();
            }
            catch
            {
                try
                {
                    MACAddress = GetMACAddress1().ToString();
                }
                catch
                {
                    try
                    {
                        MACAddress = GetMACAddress2().ToString();
                    }
                    catch
                    {
                        MACAddress = "Maquina Invalida";
                    }
                }
            }
            return MACAddress;

        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
        public string GetMACAddress1()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }


        #endregion

    }
}