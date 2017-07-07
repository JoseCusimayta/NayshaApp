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
    public partial class ConsultasVentas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        String prendas, ventas;
        DataTable datatablas, tablas1, tablas2;

        public ConsultasVentas()
        {
            InitializeComponent(); if (neg.BaseDeDatos())
            {
                if (Tablas(null))
                    DiseñoTablas();
                ComboBox();
            }
        }
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

        #region Llenar datos y verificar que existan tablas/datos
        public bool Tablas(String condicion)
        {
            datatablas = neg.SelectDataTable("select V.Fecha, HoraSistema, V.Tienda, V.Prenda, V.Cantidad, V.Total from Ventas as V inner join HistorialVentas as HV on V.Codigo=HV.Codigo " + condicion);
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
            tablas1 = neg.SelectDataTable("Select Tienda from Tiendas");
            tablas2 = neg.SelectDataTable("Select Prenda from Prendas");
            if (tablas1.Rows.Count == 0 || tablas2.Rows.Count == 0)
            {
                Error("No hay Datos de Tiendas o Prendas", "Tiendas y Prendas");
                return false;
            }
            else
            {
                cb_tienda.DataSource =
                new ListSelectionWrapper<DataRow>(
                    tablas1.Rows,
                    "Tienda" 
                    );
                cb_tienda.DisplayMemberSingleItem = "Name";
                cb_tienda.DisplayMember = "NameConcatenated";
                cb_tienda.ValueMember = "Selected";
                cb_prenda.DataSource =
                    new ListSelectionWrapper<DataRow>(
                        tablas2.Rows,
                        "Prenda" 
                        );
                cb_prenda.DisplayMemberSingleItem = "Name";
                cb_prenda.DisplayMember = "NameConcatenated";
                cb_prenda.ValueMember = "Selected";
                return true;
            }

        }

        private void ConsultasVentas_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from EntradasSalidas"))
            {
                Error("No se ha encontrado este componente", "EntradasSalidas");
            }
        }

        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
            panel1.Enabled = false;
            panel2.Enabled = false;
        }
        #endregion        

        #region Condiguración de los combobox
        private void cb_tienda_Click(object sender, EventArgs e)
        {
            cb_tienda.Focus();
        }

        private void cb_tienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_tienda_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_prenda_Click(object sender, EventArgs e)
        {
            cb_prenda.Focus();
        }

        private void cb_prenda_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_prenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Configuración CheckBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                cb_prenda.Enabled = false;
            else
                cb_prenda.Enabled = true;
        }
        #endregion

        #region Buscar y Limpiar
        private void b_buscar_Click(object sender, EventArgs e)
        {
            TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
            if (difference.Days >= 0)
            {
                if (cb_tienda.Text != String.Empty)
                {
                    if (checkBox1.Checked)
                    {
                        Tablas("where Tienda in (" + cb_tienda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'");
                        prendas = neg.ObtenerDatos("select sum(cantidad)  from Ventas where Tienda in (" + cb_tienda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' and Estado <> 'Anulado'");
                        if (prendas != string.Empty)
                            lb_prendas.Text = prendas;
                        else
                            lb_prendas.Text = "0";
                        ventas = neg.ObtenerDatos("select sum(Total)  from Ventas where Tienda in (" + cb_tienda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' and Estado <> 'Anulado'");
                        if (ventas != string.Empty)
                            lb_ventas.Text = ventas;
                        else
                            lb_ventas.Text = "0";
                    }
                    else
                    {
                        if (cb_prenda.Text != String.Empty)
                        {
                            Tablas("where Tienda in (" + cb_tienda.Text + ") and Prenda in (" + cb_prenda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'");
                            prendas = neg.ObtenerDatos("select sum(cantidad)  from Ventas where Tienda in (" + cb_tienda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' and Estado <> 'Anulado'");
                            if (prendas != string.Empty)
                                lb_prendas.Text = prendas;
                            else
                                lb_prendas.Text = "0";
                            ventas = neg.ObtenerDatos("select sum(Total)  from Ventas where Tienda in (" + cb_tienda.Text + ") and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' and Estado <> 'Anulado'");
                            if (ventas != string.Empty)
                                lb_ventas.Text = ventas;
                            else
                                lb_ventas.Text = "0";
                        }
                        else
                            MessageBox.Show("La Prenda no pueden esta vacía", "Prenda Vacía");
                    }
                }
                else
                    MessageBox.Show("La Tienda no pueden esta vacía", "Tienda Vacía");
            }
            else
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha Inicial", "Fechas invalidas");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablas(null);
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Consulta Ventas", "Consulta Ventas"))
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
