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
    public partial class StockPrendas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas, tablas1;
        Int32 Valor1, Valor2;
        String Busqueda;
        public StockPrendas()
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
            datatablas = neg.SelectDataTable("select Codigo, Tienda,Prenda,Fecha,StockInicial,StockIngreso,StockSalida,StockVentas, StockIngreso-StockSalida-StockVentas as 'StockFinal',StockReal, Variacion,Disponible from StocK " + condicion + " order by Tienda ");
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
                Error("No hay Datos de Tiendas o Prendas", "Tiendas y Prendas");
                return false;
            }
            else
            {
                cb_tienda.DataSource = tablas1;
                cb_tienda.DisplayMember = "Tienda";
                return true;
            }
        }

        private void StockPrendas_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from Stock"))
            {
                Error("No se ha encontrado este componente", "Stock");
            }
        }
        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
            panel2.Enabled = false;
            groupBox1.Enabled = false;
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Codigo" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Tienda" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Prenda" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Fecha" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "StockInicial" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "StockIngreso" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "StockSalida" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "StockVentas" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "StockFinal" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Variacion" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "Disponible")
            {
                dataGridView1.Columns[e.ColumnIndex].ReadOnly = true;
            }            
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "StockReal")
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = "";
                int newInteger;
                if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
                }
            }
            
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string variacion = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string codigo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            neg.ActualizarStock(Convert.ToInt16(variacion), Convert.ToInt16(codigo));
            Tablas(Busqueda);
        }
        #endregion

        #region botones
        private void b_buscar_Click(object sender, EventArgs e)
        {            
            TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
            if (difference.Days >= 0)
            {
                Busqueda = "where Tienda='" + cb_tienda.Text + "' and Fecha between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "' ";
                Tablas(Busqueda);
            }
            else
                MessageBox.Show("La Fecha de Cierre debe ser mayor o igual a la Fecha de Inicio", "Fechas invalidas");
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Int32 Codigo, StockInicial, StockIngreso, StockSalida, StockVentas, StockReal, Variacion;
                String Tienda, Prenda, Disponible;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Codigo = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Tienda = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Prenda = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    StockInicial = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    StockIngreso = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    StockSalida = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    StockVentas = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());
                    StockReal = Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value.ToString());
                    Variacion = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString());
                    Disponible = dataGridView1.Rows[i].Cells[11].Value.ToString();
                    Valor1 = neg.GuardarReporte(Codigo, Tienda, Prenda, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), StockInicial, StockIngreso, StockSalida, StockVentas, StockReal, Variacion, Disponible);
                }
                Valor2 = neg.GuardarRelacion(cb_tienda.Text);
                if (Valor2 == 0 && Valor1 == 0)
                    MessageBox.Show("Registro guardado correctamente");
                else if (Valor2 == 1 && Valor1 == 1)
                    MessageBox.Show("Error al guardar el registro");
                else
                    MessageBox.Show("Error desconocido");
                Tablas(Busqueda);
            }
            else
                MessageBox.Show("No hay registros para guardar", "Datos Vacíos");
        }
        private void b_limpiar_Click(object sender, EventArgs e)
        {
            Busqueda = null;
            Tablas(null);
        }

        private void b_historial_Click(object sender, EventArgs e)
        {
            RelacionStock pr = new RelacionStock();
            pr.ShowDialog();
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Stock Prendas", "Stock Prendas"))
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
