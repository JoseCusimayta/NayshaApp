using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponenteNegocios;
using System.Drawing.Printing;

namespace ComponenteVistas
{
    public partial class VistasVentas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas, tablas1, tablas2, tablas3, tablas4, tablas5;
        int modo = 0, contar, anulados, varios = 0, Valor;
        bool fechas=true;
        Double Cantidad, Precio;
        String mensaje, AntiguoOrden = null, Codigo, Boleta, Total, Monto;

        public VistasVentas()
        {
            InitializeComponent();
            if (neg.BaseDeDatos())
            {
                if (Tablas(null))
                    DiseñoTablas();
                ComboBox();
            }
        }

        #region Llenar datos y verificar que existan tablas/datos
        public bool Tablas(String condicion)
        {
            datatablas = neg.SelectDataTable("select * from Ventas " + condicion);
            bool tabla;
            if (datatablas == null)
            {
                tabla = false;
                Error("No hay Datos", "Tablas Vacias");
            }
            else
            {
                dataGridView1.DataSource = datatablas;
                tabla = true;
            }
            return tabla;
        }
        public bool ComboBox()
        {
            tablas1 = neg.SelectDataTable("Select Tienda from Tiendas where Estado <> 'Anulado' and Estado <> 'Cerrado'");
            tablas2 = neg.SelectDataTable("Select Prenda from Prendas where Estado <> 'Anulado'");
            tablas3 = neg.SelectDataTable("Select Tienda from Tiendas where Estado <> 'Anulado' and Estado <> 'Cerrado'");
            tablas4 = neg.SelectDataTable("Select Tienda from Tiendas where Estado <> 'Anulado' and Estado <> 'Cerrado'");
            tablas5 = neg.SelectDataTable("Select Prenda from Prendas where Estado <> 'Anulado'");
            if (tablas1.Rows.Count == 0 || tablas2.Rows.Count == 0 || tablas3.Rows.Count == 0 || tablas4.Rows.Count == 0 || tablas5.Rows.Count == 0)
            {
                Error("No hay Datos de Tiendas o Prendas", "Tiendas y Prendas");
                return false;
            }
            else
            {
                cb_tienda.DataSource = tablas1;
                cb_tienda.DisplayMember = "Tienda";
                cb_prenda.DataSource = tablas2;
                cb_prenda.DisplayMember = "Prenda";
                cb_tienda1.DataSource = tablas3;
                cb_tienda1.DisplayMember = "Tienda";
                cb_tienda2.DataSource = tablas4;
                cb_tienda2.DisplayMember = "Tienda";
                cb_prenda1.DataSource = tablas5;
                cb_prenda1.DisplayMember = "Prenda";
                return true;
            }
        }
        private void Formulario_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from Ventas"))
            {
                Error("No se ha encontrado este componente", "Ventas");
            }
        }
        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }
        #endregion

        #region Diseño del dataGridView

        public void DiseñoTablas()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Estado")
            {
                String valor = e.Value as String;
                if (valor == "Anulado    ")
                {
                    Int32 fila = e.RowIndex;
                    dataGridView1.Rows[fila].DefaultCellStyle.BackColor = Color.LightPink;
                    dataGridView1.Rows[fila].DefaultCellStyle.SelectionBackColor = Color.DeepPink;
                }
            }
        }

        #endregion

        #region Programacion de las celdas

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarcelda(e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarcelda(e);
        }
        public void seleccionarcelda(DataGridViewCellEventArgs e)
        {
            if (modo == 0)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    String[] Separar = row.Cells[1].Value.ToString().Split(' ');
                    tb_serie.Text = Separar[0];
                    tb_secuencial.Text = Separar[2];
                    cb_tienda.Text = row.Cells[2].Value.ToString().Trim();
                    cb_prenda.Text = row.Cells[3].Value.ToString().Trim();
                    cb_tipo.Text = row.Cells[4].Value.ToString().Trim();
                    tb_cantidad.Text = row.Cells[5].Value.ToString();
                    tb_precio.Text = row.Cells[6].Value.ToString();
                    tb_total.Text = row.Cells[7].Value.ToString();
                    dateTimePicker1.Text = row.Cells[8].Value.ToString();
                    AntiguoOrden = row.Cells[10].Value.ToString();
                    tb_orden.Text = row.Cells[10].Value.ToString();
                }
            }
        }

        #endregion       

        #region KeyDown y KeyPress Para Boletas
        private void tb_serie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
            if (Char.IsDigit(e.KeyChar))
            {
                Char Valor = e.KeyChar;
                if (tb_serie.TextLength == 4)
                {
                    tb_secuencial.Enabled = true;
                    tb_secuencial.Text = Valor.ToString();
                    tb_secuencial.Select();
                    tb_secuencial.Select(tb_secuencial.TextLength, 0);
                    tb_serie.Enabled = false;
                }
            }
        }

        private void tb_serie_KeyDown(object sender, KeyEventArgs e)
        {
            SerieKeyDown(e);
        }

        private void tb_secuencial_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }

        private void tb_secuencial_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back && tb_secuencial.Text == String.Empty) || (e.KeyCode == Keys.Delete && tb_secuencial.Text == String.Empty))
            {
                tb_serie.Enabled = true;
                tb_serie.Select();
                tb_serie.Select(tb_serie.TextLength, 0);
            }
        }
        private void tb_secuencial_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back && tb_secuencial.Text == String.Empty) || (e.KeyCode == Keys.Delete && tb_secuencial.Text == String.Empty))
            {
                tb_serie.Enabled = true;
                tb_serie.Select();
                tb_serie.Select(tb_serie.TextLength, 0);
            }
        }
        private void tb_serie1_KeyDown(object sender, KeyEventArgs e)
        {
            SerieKeyDown(e);
        }

        private void tb_serie1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
            if (Char.IsDigit(e.KeyChar))
            {
                Char Valor = e.KeyChar;
                if (tb_serie1.TextLength == 4)
                {
                    tb_secuencial1.Enabled = true;
                    tb_secuencial1.Text = Valor.ToString();
                    tb_secuencial1.Select();
                    tb_secuencial1.Select(tb_secuencial1.TextLength, 0);
                    tb_serie1.Enabled = false;
                }
            }
        }

        private void tb_secuencial1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }

        private void tb_secuencial1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back && tb_secuencial1.Text == String.Empty) || (e.KeyCode == Keys.Delete && tb_secuencial1.Text == String.Empty))
            {
                tb_serie1.Enabled = true;
                tb_serie1.Select();
                tb_serie1.Select(tb_serie1.TextLength, 0);
            }
        }
        private void tb_secuencial1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back && tb_secuencial1.Text == String.Empty) || (e.KeyCode == Keys.Delete && tb_secuencial1.Text == String.Empty))
            {
                tb_serie1.Enabled = true;
                tb_serie1.Select();
                tb_serie1.Select(tb_serie1.TextLength, 0);
            }
        }

        public void SerieKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region CheckBox

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox2.Checked = false;
                if (tb_serie.TextLength == 4)
                {
                    tb_serie.Enabled = false;
                    tb_secuencial.Enabled = true;
                }
                else
                {
                    tb_serie.Enabled = true;
                    tb_secuencial.Enabled = false;
                }
                varios = 0;
            }
            else
            {
                if (tb_serie.TextLength == 4 && tb_secuencial.TextLength == 6)
                {
                    tb_serie.Enabled = false;
                    tb_secuencial.Enabled = false;
                    varios = 1;
                }
                else
                {
                    MessageBox.Show("La boleta debe tener 13 dígitos", "Validación de Boleta");
                    checkBox1.Checked = false;
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                dateTimePicker1.Enabled = true;
                cb_tienda.Enabled = true;
            }
            else
            {
                if (tb_serie.TextLength == 4 && tb_secuencial.TextLength == 6)
                {
                    checkBox1.Checked = true;
                    dateTimePicker1.Enabled = false;
                    cb_tienda.Enabled = false;
                    varios = 2;
                }
                else
                {
                    MessageBox.Show("La boleta debe tener 13 dígitos", "Validación de Boleta");
                    checkBox2.Checked = false;
                }
            }
        }
        public void GuardarConCheckBox()
        {
            modo = 1;
            Tablas(null);
            if (varios == 1)
            {
                dateTimePicker1.Value = DateTime.Now;
                cb_tienda.SelectedIndex = 0;
                cb_prenda.SelectedIndex = 0;
                cb_tipo.SelectedIndex = 0;
                tb_cantidad.Text = "";
                //tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
                tb_total.Text = "";
                tb_serie.Enabled = false;
                tb_secuencial.Enabled = false;
            }
            else if (varios == 2)
            {
                cb_prenda.SelectedIndex = 0;
                cb_tipo.SelectedIndex = 0;
                tb_cantidad.Text = "";
                //tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
                tb_total.Text = "";
                tb_serie.Enabled = false;
                tb_secuencial.Enabled = false;
            }
            tb_orden.Text = neg.NuevoOrden("Ventas").ToString();
        }
        #endregion

        #region Busqueda por ComboBox
        private void cb_prenda_EnabledChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Por Mayor")
                tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
            if (cb_tipo.Text == "Por Menor")
                tb_precio.Text = neg.ObtenerDatos("select PxMenor from Prendas where Prenda='" + cb_prenda.Text + "'");
        }

        private void cb_prenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Por Mayor")
                tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
            if (cb_tipo.Text == "Por Menor")
                tb_precio.Text = neg.ObtenerDatos("select PxMenor from Prendas where Prenda='" + cb_prenda.Text + "'");
        }

        private void cb_tipo_EnabledChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Por Mayor")
                tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
            if (cb_tipo.Text == "Por Menor")
                tb_precio.Text = neg.ObtenerDatos("select PxMenor from Prendas where Prenda='" + cb_prenda.Text + "'");
        }

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Por Mayor")
                tb_precio.Text = neg.ObtenerDatos("select PxMayor from Prendas where Prenda='" + cb_prenda.Text + "'");
            if (cb_tipo.Text == "Por Menor")
                tb_precio.Text = neg.ObtenerDatos("select PxMenor from Prendas where Prenda='" + cb_prenda.Text + "'");
        }
        #endregion

        #region Verificar Ingreso de Teclado
        private void tb_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }
        private void tb_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }

        private void tb_cantidad_TextChanged(object sender, EventArgs e)
        {
            if (tb_cantidad.Text != String.Empty && tb_precio.Text != String.Empty)
            {
                Cantidad = Convert.ToDouble(tb_cantidad.Text);
                Precio = Convert.ToDouble(tb_precio.Text);
                tb_total.Text = (Cantidad * Precio).ToString();
            }
            else
                tb_total.Text = "";
        }

        private void tb_precio_TextChanged(object sender, EventArgs e)
        {
            if (tb_cantidad.Text != String.Empty && tb_precio.Text != String.Empty)
            {
                Cantidad = Convert.ToDouble(tb_cantidad.Text);
                Precio = Convert.ToDouble(tb_precio.Text);
                tb_total.Text = (Cantidad * Precio).ToString();
            }
            else
                tb_total.Text = "";
        }

        #endregion    

        #region Filtros
        private void b_actualizar_Click(object sender, EventArgs e)
        {
            Tablas(null);
        }
        private void b_buscar_Click(object sender, EventArgs e)
        {
            if (tb_secuencial1.TextLength == 6)
                Tablas("where Tienda='" + cb_tienda1.Text + "' and Boleta='" + tb_serie1.Text + " - " + tb_secuencial1.Text + "'");
            else
                MessageBox.Show("La boleta debe tener 13 dígitos", "Validación de Boleta");
        }
        #endregion

        #region Resumen de Ventas
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(fechas==true)
            dateTimePicker3.Value = dateTimePicker2.Value;
        }
        private void dateTimePicker3_Enter(object sender, EventArgs e)
        {
            fechas = false;
        }
        private void b_limpiar_Click(object sender, EventArgs e)
        {
            fechas = true;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void b_calcular_Click(object sender, EventArgs e)
        {
            TimeSpan difference = dateTimePicker3.Value - dateTimePicker2.Value;
            if (difference.Days >= 0)
            {
                Total = neg.ObtenerDatos("select sum(Cantidad) from Ventas where Tienda='" + cb_tienda2.Text + "' and Prenda='" + cb_prenda1.Text + "'  and Fecha between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker3.Value.ToShortDateString() + "'");
                Monto = neg.ObtenerDatos("select sum(total) from ventas where Tienda='" + cb_tienda2.Text + "' and Prenda='" + cb_prenda1.Text + "'  and Fecha between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker3.Value.ToShortDateString() + "'");
                if (Total != String.Empty && Monto != String.Empty)
                {
                    lb_total.Text = Total;
                    lb_monto.Text = Monto;
                    Tablas("where Tienda='" + cb_tienda2.Text + "' and Prenda='" + cb_prenda1.Text + "'  and Fecha between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker3.Value.ToShortDateString() + "'");
                }
                else
                {
                    lb_total.Text = "0";
                    lb_monto.Text = "0";
                    MessageBox.Show("No hay ventas de la Prenda y Tienda seleccionada entre las fechas: \n " + dateTimePicker2.Value.ToShortDateString() + " y " + dateTimePicker3.Value.ToShortDateString(), "No hay ventas");
                }
            }
            else
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha Inicial", "Fechas invalidas");
        }
        #endregion

        #region Formulario KeyDown
        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (b_nuevo.Enabled == true)
                    b_nuevo_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.M)
            {
                if (b_modificar.Enabled == true)
                    b_modificar_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (b_eliminar.Enabled == true)
                    b_eliminar_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (b_guardar.Enabled == true)
                    b_guardar_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (b_cancelar.Enabled == true)
                    b_cancelar_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                if (b_historial.Enabled == true)
                    b_historial_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (b_salir.Enabled == true)
                    b_salir_Click(this, null);
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                if (b_imprimir.Enabled == true)
                    b_imprimir_Click(this, null);
            }
        }
        #endregion

        #region Header
        private void b_nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            tb_orden.Text = neg.NuevoOrden("Ventas").ToString();
        }


        private void b_modificar_Click(object sender, EventArgs e)
        {
            contar = neg.Contar("Ventas", "Orden='" + tb_orden.Text + "'");
            anulados = neg.Contar("Ventas", "Orden='" + tb_orden.Text + "' and Estado='Anulado'");
            if (anulados == 0)
            {
                if (contar != 0)
                {
                    DataTable Lista = neg.SelectDataTable("select * from Ventas where Orden='" + tb_orden.Text + "'");
                    String[] Separar = Lista.Rows[0][1].ToString().Split(' ');
                    tb_serie.Text = Separar[0];
                    tb_secuencial.Text = Separar[2];
                    cb_tienda.Text = Lista.Rows[0][2].ToString();
                    cb_prenda.Text = Lista.Rows[0][3].ToString();
                    cb_tipo.Text = Lista.Rows[0][4].ToString();
                    tb_cantidad.Text = Lista.Rows[0][5].ToString();
                    tb_precio.Text = Lista.Rows[0][6].ToString();
                    tb_total.Text = Lista.Rows[0][7].ToString();
                    dateTimePicker1.Text = Lista.Rows[0][8].ToString();
                    AntiguoOrden = Lista.Rows[0][10].ToString();
                    tb_orden.Text = neg.NuevoOrden("Ventas").ToString();
                    Modificar();
                }
                else
                    MessageBox.Show("Código Inválido");
            }
            else
                MessageBox.Show("Código Anulado");
        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            contar = neg.Contar("Ventas", "Orden='" + AntiguoOrden + "' and Estado='Anulado'");
            if (contar != 0)
                MessageBox.Show("El registro ya fue eliminado");
            else
            {
                if (neg.EliminarVentas(AntiguoOrden))
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    Cancelar();
                }
                else
                    MessageBox.Show("Error al eliminar");
            }
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            Boleta = tb_serie.Text + " - " + tb_secuencial.Text;
            mensaje = ver.CamposVacios(this, panel1);
            if (mensaje.Equals("Los siguientes datos no pueden estar vacios:"))
            {
                if (Boleta.Length == 13)
                {
                    //agregar accion para boleta, fecha, tienda, prenda y tipo iguales
                    //si el tipo es por mayor, y luego al modificar, cambia al por menor?
                    // o si al ingresar datos, se ingresa todo igual excepto el tipo    ?
                    Codigo = neg.ObtenerDatos("select Orden from Ventas where Boleta='" + Boleta + "' and Tienda='" + cb_tienda.Text + "' and Prenda='" + cb_prenda.Text + "' and Fecha = '" + dateTimePicker1.Value.ToShortDateString() + "'");
                    if (Codigo == String.Empty)
                    {
                        Valor = neg.GuardarVentas(modo, Boleta, cb_tienda.Text, cb_prenda.Text, cb_tipo.Text, tb_cantidad.Text, tb_precio.Text.Replace(".", ","), tb_total.Text.Replace(".", ","), dateTimePicker1.Value.Date, tb_orden.Text, AntiguoOrden);
                        if (Valor == 1)
                        {
                            MessageBox.Show("Registro guardado correctamente");
                            if (varios == 0)
                                Cancelar();
                            else
                                GuardarConCheckBox();
                        }
                        else if (Valor == 2)
                            MessageBox.Show("Error al guardar el registro");
                        else if (Valor == 3)
                        {
                            MessageBox.Show("Registro actualizado correctamente");
                            Cancelar();
                        }
                        else if (Valor == 4)
                            MessageBox.Show("Error al actualizar el registro");
                        else
                            MessageBox.Show("Error desconocido");
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe, por favor camcele e ingrese en la opción Modificar", "Datos existentes");
                        //Valor = neg.GuardarVentas(2, Boleta, cb_tienda.Text, cb_prenda.Text, cb_tipo.Text, tb_cantidad.Text, tb_precio.Text.Replace(",", "."), tb_total.Text.Replace(",", "."), dateTimePicker1.Value.Date, tb_orden.Text, Codigo);
                        //if (Valor == 3)
                        //{
                        //    MessageBox.Show("Registro actualizado correctamente");
                        //    Cancelar();
                        //}
                        //else if (Valor == 4)
                        //    MessageBox.Show("Error al actualizar el registro");
                        //else
                        //    MessageBox.Show("Error desconocido");
                    }
                }
                else
                    MessageBox.Show("La boleta debe tener " + Boleta.Length + " carácteres válidos");
            }
            else
                MessageBox.Show(ver.CamposVacios(this, panel1));
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }


        private void b_historial_Click(object sender, EventArgs e)
        {
            HistorialVentas pr = new HistorialVentas();
            pr.ShowDialog(this);
        }

        public void Nuevo()
        {
            modo = 1;
            limpiar.BorrarCampos(this, panel1);
            limpiar.BorrarCampos(this, groupBox2);
            //Botones
            b_nuevo.Enabled = false;
            b_modificar.Enabled = false;
            b_salir.Enabled = false;
            b_imprimir.Enabled = false;
            b_historial.Enabled = false;
            b_eliminar.Enabled = false;
            b_guardar.Enabled = true;
            b_cancelar.Enabled = true;
            //Textos
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            tb_serie.Enabled = true;
            dateTimePicker1.Enabled = true;
            cb_tienda.Enabled = true;
            cb_prenda.Enabled = true;
            cb_tipo.Enabled = true;
            tb_cantidad.Enabled = true;
            tb_precio.Enabled = true;
            //Otros GroupBox
            cb_tienda1.Enabled = false;
            tb_serie1.Enabled = false;
            tb_secuencial1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            cb_tienda2.Enabled = false;
            cb_prenda1.Enabled = false;
            b_limpiar.Enabled = false;
            b_calcular.Enabled = false;
        }
        public void Modificar()
        {
            modo = 2;
            //Botones
            b_nuevo.Enabled = false;
            b_modificar.Enabled = false;
            b_salir.Enabled = false;
            b_imprimir.Enabled = false;
            b_historial.Enabled = false;
            b_eliminar.Enabled = true;
            b_guardar.Enabled = true;
            b_cancelar.Enabled = true;
            //Textos
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            tb_serie.Enabled = false;
            tb_secuencial.Enabled = true;
            dateTimePicker1.Enabled = true;
            cb_tienda.Enabled = true;
            cb_prenda.Enabled = true;
            cb_tipo.Enabled = true;
            tb_cantidad.Enabled = true;
            tb_precio.Enabled = true;
            //Otros GroupBox
            cb_tienda1.Enabled = false;
            tb_serie1.Enabled = false;
            tb_secuencial1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            cb_tienda2.Enabled = false;
            cb_prenda1.Enabled = false;
            b_limpiar.Enabled = false;
            b_calcular.Enabled = false;
        }
        public void Cancelar()
        {
            varios = 0;
            modo = 0;
            Tablas(null);
            limpiar.BorrarCampos(this, panel1);
            //Botones
            b_nuevo.Enabled = true;
            b_modificar.Enabled = true;
            b_salir.Enabled = true;
            b_imprimir.Enabled = true;
            b_historial.Enabled = true;
            b_eliminar.Enabled = false;
            b_guardar.Enabled = false;
            b_cancelar.Enabled = false;
            //Textos
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            tb_serie.Enabled = false;
            tb_secuencial.Enabled = false;
            dateTimePicker1.Enabled = false;
            cb_tienda.Enabled = false;
            cb_prenda.Enabled = false;
            cb_tipo.Enabled = false;
            tb_cantidad.Enabled = false;
            tb_precio.Enabled = false;
            tb_total.Enabled = false;
            //Otros GroupBox
            cb_tienda1.Enabled = true;
            tb_serie1.Enabled = true;
            tb_secuencial1.Enabled = false;
            dateTimePicker2.Enabled = true;
            dateTimePicker3.Enabled = true;
            cb_tienda2.Enabled = true;
            cb_prenda1.Enabled = true;
            b_limpiar.Enabled = true;
            b_calcular.Enabled = true;
        }
        #endregion

        #region Footer

        private void b_inicio_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 2)
            {
                MessageBox.Show("No hay registros para mostrar");
            }
            else
            {
                dataGridView1.CurrentCell = dataGridView1[1, 0];
            }
        }

        private void b_anterior_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 2)
            {
                MessageBox.Show("No hay registros para mostrar");
            }
            else
            {
                Int32 FilaSeleccionada = dataGridView1.CurrentCell.RowIndex;
                if (FilaSeleccionada != 0)
                    dataGridView1.CurrentCell = dataGridView1[1, FilaSeleccionada - 1];
            }
        }

        private void b_siguiente_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 2)
            {
                MessageBox.Show("No hay registros para mostrar");
            }
            else
            {
                Int32 FilaSeleccionada = dataGridView1.CurrentCell.RowIndex;
                Int32 UltimaFila = dataGridView1.NewRowIndex;
                if (FilaSeleccionada != UltimaFila - 1)
                    dataGridView1.CurrentCell = dataGridView1[1, FilaSeleccionada + 1];
            }
        }

        private void b_final_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 2)
            {
                MessageBox.Show("No hay registros para mostrar");
            }
            else
            {
                Int32 UltimaFila = dataGridView1.NewRowIndex;
                dataGridView1.CurrentCell = dataGridView1[1, UltimaFila - 1];
            }
        }

        private void b_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_imprimir_Click(object sender, EventArgs e)
        {
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Ventas", "Registro Ventas"))
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = printDocument1;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            imp.Impresion(printDocument1, e);
        }
        #endregion


    }
}
