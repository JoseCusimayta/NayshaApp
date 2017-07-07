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
    public partial class RelacionStock : Form
    {
        Negocio neg = new Negocio();
        Imprimir imp = new Imprimir();
        Verificar ver = new Verificar();
        DataTable datatablas, tablas1;
        public RelacionStock()
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
            datatablas = neg.SelectDataTable("select * from RelacionStock " + condicion);
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
            if (tablas1 == null)
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
        private void Formulario_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from RelacionStock"))
            {
                Error("No se ha encontrado este componente", "EntradasSalidas");
            }
        }
        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
        }
        #endregion

        #region Diseño del dataGridView

        public void DiseñoTablas()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HistorialStock ventana = new HistorialStock();
            String Tienda = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String Fecha = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Busqueda = " where Tienda='" + Tienda + "' and FechaInv='" + Fecha + "'";
            ventana.Busqueda = Busqueda;
            ventana.dataGridView1.DataSource = neg.SelectDataTable("select * from HistorialStock "+Busqueda);
            ventana.ShowDialog();
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Relacion Stock", "Relacion Stock"))
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

        #region Botones de Búsqueda
        private void b_tienda_Click(object sender, EventArgs e)
        {
            Tablas("where Tienda='" + cb_tienda.Text + "'");
        }
        private void b_codigo_Click(object sender, EventArgs e)
        {
            Tablas("where Codigo='" + tb_codigo.Text + "'");
        }

        private void b_limpiar_Click(object sender, EventArgs e)
        {
            Tablas(null);
        }
        private void b_fecha_Click(object sender, EventArgs e)
        {
            Tablas("where Fecha='" + dateTimePicker1.Value.ToShortDateString() + "'");
        }
        #endregion

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }
    }
}
