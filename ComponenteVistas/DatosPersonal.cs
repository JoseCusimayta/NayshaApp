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
    public partial class DatosPersonal : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas, tablas1;
        int modo = 0, contar, anulados, Valor;
        String mensaje, AntiguoOrden = null, Contrato, Vacaciones, ContratoDias, VacacionesDias, VacacionesTitulo = "Aviso de Vacaciones\n", ContratoTitulo = "Aviso de Contrato\n";
        TimeSpan difference;
        Decimal num1, num2;

        public DatosPersonal()
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
            datatablas = neg.SelectDataTable("select * from DatosPersonal " + condicion);
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
            if (tablas1.Rows.Count == 0)
            {
                Error("No hay Datos de Tiendas", "Tiendas Vacías");
                return false;
            }
            else
            {
                cb_tienda.DataSource = tablas1;
                cb_tienda.DisplayMember = "Tienda";
                return true;
            }
        }
        private void Formulario_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from DatosPersonal"))
            {
                Error("No se ha encontrado este componente", "DatosPersonal");
            }
            else
            {
                VerificarVencimiento();
            }
        }

        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
            panel2.Enabled = false;
            panel3.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }
        public void VerificarVencimiento()
        {
            DataTable Cierre = neg.SelectDataTable("select * from DatosPersonal where FechaFinal<DATEADD(d,-1,GETDATE()) and Estado='Activo'");
            if (Cierre != null)
            {
                for (int i = 0; i < Cierre.Rows.Count; i++)
                {
                    contar = neg.GuardarTiendas(2, Cierre.Rows[i][0].ToString(), Cierre.Rows[i][1].ToString(), Cierre.Rows[i][2].ToString(), Cierre.Rows[i][3].ToString(), Cierre.Rows[i][4].ToString(), Cierre.Rows[i][5].ToString().Replace(",", "."), "En Espera", Convert.ToInt16(Cierre.Rows[i][7].ToString()));
                }
            }
            List<String> Lista = neg.Listas("select Nombres from DatosPersonal where FechaFinal<DATEADD(day,15,GETDATE()) and Estado='Activo'");
            List<Int32> Lista2 = neg.ListasEnteros("select Orden from DatosPersonal where FechaFinal<DATEADD(day,15,GETDATE()) and Estado='Activo'");
            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    ContratoDias = neg.ObtenerDatos("select DATEDIFF(day,GETDATE(),FechaFinal) from DatosPersonal where Orden=" + Lista2[i] + "");
                    Contrato += "El contrato de " + Lista[i] + " vence en " + ContratoDias + " días\n";
                }
            }
            else Contrato = null;

            Lista = neg.Listas("select Nombres from DatosPersonal where FechaVacaciones<DATEADD(day,400,GETDATE()) and Estado='Activo'");
            Lista2 = neg.ListasEnteros("select Orden from DatosPersonal where FechaVacaciones<DATEADD(day,400,GETDATE()) and Estado='Activo'");
            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    VacacionesDias = neg.ObtenerDatos("select DATEDIFF(day,GETDATE(),FechaVacaciones) from DatosPersonal where Orden=" + Lista2[i] + "");
                    if (VacacionesDias == "5" || VacacionesDias == "10" || VacacionesDias == "15")
                    {
                        Vacaciones += Lista[i] + " tendrá vacaciones en " + VacacionesDias + " días\n";
                    }
                }
            }
            else Vacaciones = null;

            mensaje = null;
            if (Contrato != null)
                mensaje += ContratoTitulo + Contrato;
            if (Vacaciones != null)
                mensaje += VacacionesTitulo + Vacaciones;
            if (mensaje != null)
                MessageBox.Show(mensaje);
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
                if (valor == "Anulado")
                {
                    Int32 fila = e.RowIndex;
                    dataGridView1.Rows[fila].DefaultCellStyle.BackColor = Color.LightPink;
                    dataGridView1.Rows[fila].DefaultCellStyle.SelectionBackColor = Color.DeepPink;
                }
            }
        }

        #endregion

        #region Programacion de las celdas
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
                    tb_codigo.Text = row.Cells[0].Value.ToString();
                    tb_nombres.Text = row.Cells[1].Value.ToString();
                    tb_apellidos.Text = row.Cells[2].Value.ToString();
                    tb_dni.Text = row.Cells[3].Value.ToString();
                    tb_fijo.Text = row.Cells[4].Value.ToString();
                    tb_direccion.Text = row.Cells[5].Value.ToString();
                    tb_celular.Text = row.Cells[6].Value.ToString();
                    tb_referencia.Text = row.Cells[7].Value.ToString();
                    dateTimePicker1.Text = row.Cells[8].Value.ToString();
                    dateTimePicker2.Text = row.Cells[9].Value.ToString();
                    dateTimePicker3.Text = row.Cells[10].Value.ToString();
                    cb_estado.Text = row.Cells[11].Value.ToString();
                    cb_tienda.Text = row.Cells[12].Value.ToString().Trim();
                    tb_salario.Text = row.Cells[13].Value.ToString();
                    cb_seguro.Text = row.Cells[14].Value.ToString();
                    tb_descuento.Text = row.Cells[15].Value.ToString();
                    tb_total.Text = row.Cells[16].Value.ToString();
                }
            }
        }

        #endregion

        #region Vacaciones
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Value = dateTimePicker1.Value.AddDays(365);
        }

        private void b_vacaciones_Click(object sender, EventArgs e)
        {
            dateTimePicker3.Enabled = true;
        }
        #endregion

        #region Cajas de Texto

        private void tb_salario_TextChanged(object sender, EventArgs e)
        {
            SumarTotal(tb_salario, tb_descuento, tb_total);
        }

        private void tb_descuento_TextChanged(object sender, EventArgs e)
        {
            SumarTotal(tb_salario, tb_descuento, tb_total);
        }
        public void SumarTotal(TextBox tb1, TextBox tb2, TextBox tb3)
        {
            if (tb1.Text != String.Empty && tb2.Text != String.Empty)
            {
                Decimal.TryParse(tb1.Text.Replace(".", ","), out num1);
                Decimal.TryParse(tb2.Text.Replace(".", ","), out num2);
                if (num1 != 0 && num2 != 0)
                {
                    num1 = Decimal.Parse(tb1.Text.Replace(".", ","));
                    num2 = Decimal.Parse(tb2.Text.Replace(".", ","));
                    tb3.Text = (num1 - num2).ToString("F");
                }
                else
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido", "Un número tiene formato no válido");
            }
            else tb3.Text = null;
        }
        #endregion

        #region Solo Numeros, Decimales o Letras
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }

        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            ver.SoloLetras(e);
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
            tb_codigo.Text = neg.NuevoOrden("DatosPersonal").ToString();
            tb_dni.Focus();
        }
        private void b_modificar_Click(object sender, EventArgs e)
        {
            contar = neg.Contar("DatosPersonal", "Orden='" + tb_codigo.Text + "'");
            anulados = neg.Contar("DatosPersonal", "Orden='" + tb_codigo.Text + "' and Estado='Anulado'");
            if (anulados == 0)
            {
                if (contar != 0)
                {
                    DataTable row = neg.SelectDataTable("select * from DatosPersonal where Orden='" + tb_codigo.Text + "'");
                    AntiguoOrden = row.Rows[0][0].ToString();
                    tb_nombres.Text = row.Rows[0][1].ToString();
                    tb_apellidos.Text = row.Rows[0][2].ToString();
                    tb_dni.Text = row.Rows[0][3].ToString();
                    tb_fijo.Text = row.Rows[0][4].ToString();
                    tb_direccion.Text = row.Rows[0][5].ToString();
                    tb_celular.Text = row.Rows[0][6].ToString();
                    tb_referencia.Text = row.Rows[0][7].ToString();
                    dateTimePicker1.Text = row.Rows[0][8].ToString();
                    dateTimePicker2.Text = row.Rows[0][9].ToString();
                    dateTimePicker3.Text = row.Rows[0][10].ToString();
                    cb_estado.Text = row.Rows[0][11].ToString();
                    cb_tienda.Text = row.Rows[0][12].ToString().Trim();
                    tb_salario.Text = row.Rows[0][13].ToString();
                    cb_seguro.Text = row.Rows[0][14].ToString();
                    tb_descuento.Text = row.Rows[0][15].ToString();
                    tb_total.Text = row.Rows[0][16].ToString();
                    tb_codigo.Text = neg.NuevoOrden("DatosPersonal").ToString();
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
            contar = neg.Contar(" DatosPersonal ", " Orden = '" + AntiguoOrden + "' and Estado='Anulado'");
            if (contar != 0)
                MessageBox.Show("El registro ya fue eliminado");
            else
            {
                if (neg.EliminarPersonal(AntiguoOrden))
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
            mensaje = ver.CamposVacios(this, groupBox1);
            if (mensaje.Equals("Los siguientes datos no pueden estar vacios:"))
            {
                difference = dateTimePicker2.Value - dateTimePicker1.Value;
                if (difference.Days >= 0)
                {
                    Valor = neg.GuardarPersonal(modo, AntiguoOrden, tb_nombres.Text, tb_apellidos.Text, tb_dni.Text, tb_fijo.Text, tb_direccion.Text, tb_celular.Text, tb_referencia.Text, dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker3.Value, cb_estado.Text, cb_tienda.Text, tb_salario.Text, cb_seguro.Text, tb_descuento.Text, tb_total.Text);
                    if (Valor == 1)
                    {
                        MessageBox.Show("Registro guardado correctamente");
                        Cancelar();
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
                    MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio");
            }
            else
                MessageBox.Show(ver.CamposVacios(this, groupBox1));
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void b_historial_Click(object sender, EventArgs e)
        {
            HistorialDatosPersonal pr = new HistorialDatosPersonal();
            pr.ShowDialog(this);
        }

        public void Nuevo()
        {
            modo = 1;
            limpiar.BorrarCampos(this, groupBox1);
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
            b_vacaciones.Enabled = false;
            //GroupBox
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
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
            b_vacaciones.Enabled = true;
            //GroupBox
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }
        public void Cancelar()
        {
            modo = 0;
            Tablas(null);
            limpiar.BorrarCampos(this, groupBox1);
            limpiar.BorrarCampos(this, groupBox2);
            //Botones
            b_nuevo.Enabled = true;
            b_modificar.Enabled = true;
            b_salir.Enabled = true;
            b_imprimir.Enabled = true;
            b_historial.Enabled = true;
            b_eliminar.Enabled = false;
            b_guardar.Enabled = false;
            b_cancelar.Enabled = false;
            //GroupBox
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            dateTimePicker3.Enabled = false;
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Datos del Personal", "Datos del Personal"))
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
