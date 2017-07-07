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
    public partial class ConsultasEntradasSalidas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas, tablas1, tablas2, tablas3;
        String TiendaIngreso = null, TiendaSalida = null, Prenda = null, busqueda = null, Inicio = null, Final = null, Cantidad = null, Ordenar;
        public ConsultasEntradasSalidas()
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
            datatablas = neg.SelectDataTable("select ES.Fecha, HoraSistema as 'Hora', ES.Salida as 'Tienda Salida', ES.Ingreso as 'Tienda Ingreso', ES.Prenda as 'Prenda Salida', ES.Cantidad'Cantidad de Prendas' from EntradasSalidas as ES inner join HistorialEntradasSalidas as HES on ES.Codigo=HES.Codigo " + condicion);
            bool tabla;
            if (datatablas == null)
            {
                tabla = false;
                Error("Problemas en las búsquedas de datos, se bloqueará la ventana por seguridad", "Tablas Vacias");
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
            tablas2 = neg.SelectDataTable("Select Tienda from Tiendas");
            tablas3 = neg.SelectDataTable("Select Prenda from Prendas");
            if (tablas1.Rows.Count == 0 || tablas2.Rows.Count == 0 || tablas3.Rows.Count == 0)
            {
                Error("No hay Datos de Tiendas o Prendas", "Tiendas y Prendas");
                return false;
            }
            else
            {
                checkedListBox1.DataSource = tablas1;
                checkedListBox1.DisplayMember = "Tienda";
                checkedListBox2.DataSource = tablas2;
                checkedListBox2.DisplayMember = "Tienda";
                checkedListBox3.DataSource = tablas3;
                checkedListBox3.DisplayMember = "Prenda";
                return true;
            }
        }
        private void Formulario_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from EntradasSalidas"))
            {
                Error("No se ha encontrado este componente", "EntradasSalidas");
            }
        }
        public void Error(String Mensaje, String Titulo)
        {
            MessageBox.Show(Mensaje, Titulo);
            panel2.Enabled = false;
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

        #region CheckBox
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, false);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
        }
        #endregion

        #region Filtros de Búsqueda Específica
        private void b_buscar_Click(object sender, EventArgs e)
        {
            TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
            if (difference.Days >= 0)
            {
                if (VerificarCheckBox(checkedListBox1))
                {
                    if (VerificarCheckBox(checkedListBox2))
                    {
                        if (VerificarCheckBox(checkedListBox3))
                        {
                            foreach (DataRowView item in checkedListBox1.CheckedItems)
                            {
                                if (TiendaSalida == null)
                                    TiendaSalida = string.Format("where (ES.Salida='{0}' ", item["Tienda"]);
                                else
                                    TiendaSalida += string.Format("or ES.Salida='{0}' ", item["Tienda"]);
                            }
                            TiendaSalida += ") ";
                            foreach (DataRowView item in checkedListBox2.CheckedItems)
                            {
                                if (TiendaIngreso == null)
                                    TiendaIngreso += string.Format("and (ES.Ingreso='{0}' ", item["Tienda"]);
                                else
                                    TiendaIngreso += string.Format("or ES.Ingreso='{0}' ", item["Tienda"]);
                            }
                            TiendaIngreso += ") ";
                            foreach (DataRowView item in checkedListBox3.CheckedItems)
                            {
                                if (Prenda == null)
                                    Prenda += string.Format("and (ES.Prenda='{0}' ", item["Prenda"]);
                                else
                                    Prenda += string.Format("or ES.Prenda='{0}' ", item["Prenda"]);
                            }
                            Prenda += ") ";
                            Inicio = dateTimePicker1.Value.ToShortDateString();
                            Final = dateTimePicker2.Value.ToShortDateString();
                            busqueda = TiendaSalida+TiendaIngreso + Prenda + " and ES.Fecha between '" + Inicio + "' and '" + Final + "' ";
                            //textBox1.Text = busqueda;
                            Tablas(busqueda + Ordenar);
                            Cantidad = neg.ObtenerDatos(" select sum(cantidad) from EntradasSalidas " + busqueda);
                            if (Cantidad != String.Empty)
                                lb_total.Text = Cantidad;
                            else
                                lb_total.Text = "0";
                            TiendaIngreso = null;
                            TiendaSalida = null;
                            Prenda = null;
                            Inicio = null;
                            Final = null;
                            Cantidad = null;
                        }
                        else
                            MessageBox.Show("Debe seleccionar al menos una Prenda para Buscar", "Prendas vacías");
                    }
                    else
                        MessageBox.Show("Debe seleccionar al menos una Tienda de Ingreso para Buscar", "Tienda Ingreso vacía");
                }
                else
                    MessageBox.Show("Debe seleccionar al menos una Tienda de Salida para Buscar", "Tienda Salida vacía");
            }
            else
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha Inicial", "Fechas invalidas");
        }
        public bool VerificarCheckBox(CheckedListBox e)
        {
            bool marcados = false;
            for (int i = 0; i < e.Items.Count; i++)
            {
                if (e.GetItemCheckState(i) == CheckState.Checked)
                    marcados = true;
            }
            return marcados;
        }
        private void b_limpiar_Click(object sender, EventArgs e)
        {
            lb_total.Text = "0";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;            
            VaciarCheckBox(checkedListBox1);
            VaciarCheckBox(checkedListBox2);
            VaciarCheckBox(checkedListBox3);
        }
        public void VaciarCheckBox(CheckedListBox e)
        {
            for (int i = 0; i < e.Items.Count; i++)
            {
                e.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        #endregion

        #region Filtros de Búsqueda por Fecha

        private void b_buscar2_Click(object sender, EventArgs e)
        {
            busqueda = "where Fecha='" + dateTimePicker3.Value.ToShortDateString() + "'";
            Tablas(busqueda + Ordenar);
            Cantidad = neg.ObtenerDatos(" select sum(cantidad) from EntradasSalidas " + busqueda);
            if (Cantidad != String.Empty)
                lb_total1.Text = Cantidad;
            else
                lb_total1.Text = "0";
        }
        #endregion

        #region Ordenar Datos
        private void cb_ordenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ordenar.Text == "Tienda Ingreso")
            {
                Ordenar = " order by Ingreso";
                Tablas(busqueda + Ordenar);
            }
            if (cb_ordenar.Text == "Tienda Salida")
            {
                Ordenar = " order by Salida";
                Tablas(busqueda + Ordenar);
            }
        }

        private void b_actualizar_Click(object sender, EventArgs e)
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Consulta Entradas y Salidas", "Consulta Entradas y Salidas"))
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
