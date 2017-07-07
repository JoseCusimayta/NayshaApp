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
    public partial class VistasPrendas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas;
        int modo = 0, contar, anulados;
        String mensaje;
        public VistasPrendas()
        {
            InitializeComponent();
            if (neg.BaseDeDatos())
            {
                if (Tablas(null))
                    DiseñoTablas();
            }
        }

        #region Llenar datos y verificar que existan tablas/datos
        public bool Tablas(String condicion)
        {
            datatablas = neg.SelectDataTable("select Codigo, Prenda, Color, Talla, PxMayor as 'Por Mayor', PxMenor as 'Por Menor', Estado, Orden from prendas " + condicion);
            bool tabla;
            if (datatablas == null)
            {
                tabla = false;
                MessageBox.Show("No hay Datos", "Tablas Vacias");
            }
            else
            {
                dataGridView1.DataSource = datatablas;
                tabla = true;
            }
            return tabla;
        }
        private void VistasPrendas_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from Prendas"))
            {
                MessageBox.Show("No se ha encontrado este componente", "Prendas");
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
            }
        }
        #endregion

        #region Diseño del dataGridView

        public void DiseñoTablas()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.Columns["Por Mayor"].DefaultCellStyle.Format = "S/'.' .00";
            dataGridView1.Columns["Por Menor"].DefaultCellStyle.Format = "S/'.' .00";
            dataGridView1.Columns["Por Mayor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Por Menor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        #region Verificar Ingreso de Teclado y Fechas
        private void tb_pxmayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }

        private void tb_pxmenor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeroYLetras(e);
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
                    tb_codigo.Text = row.Cells[0].Value.ToString();
                    tb_prenda.Text = row.Cells[1].Value.ToString();
                    tb_color.Text = row.Cells[2].Value.ToString();
                    cb_talla.Text = row.Cells[3].Value.ToString();
                    tb_pxmayor.Text = row.Cells[4].Value.ToString();
                    tb_pxmenor.Text = row.Cells[5].Value.ToString();
                    cb_estado.Text = row.Cells[6].Value.ToString();
                    tb_orden.Text = row.Cells[7].Value.ToString();
                }
            }
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
            tb_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tb_orden.Text = neg.NuevoOrden("Prendas").ToString();
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            contar = neg.Contar("Prendas", "Codigo='" + tb_codigo.Text + "'");
            anulados = neg.Contar("Prendas", "Codigo='" + tb_codigo.Text + "' and Estado='Anulado'");
            if (anulados == 0)
            {
                if (contar != 0)
                {
                    tb_orden.Text = neg.NuevoOrden("Prendas").ToString();
                    tb_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            contar = neg.Contar("Prendas", "Codigo='" + tb_codigo.Text + "' and Estado='Anulado'");
            if (contar != 0)
                MessageBox.Show("El registro ya fue eliminado");
            else
            {
                if (neg.EliminarPrendas(tb_codigo.Text))
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
            mensaje = ver.CamposVacios(this, panel1);
            if (mensaje.Equals("Los siguientes datos no pueden estar vacios:"))
            {
                if (tb_codigo.TextLength == 6)
                {
                    Int32 Valor = neg.GuardarPrendas(modo, tb_codigo.Text, tb_prenda.Text, tb_color.Text, cb_talla.Text, tb_pxmayor.Text.Replace(",", "."), tb_pxmenor.Text.Replace(",", "."), cb_estado.Text, Convert.ToInt32(tb_orden.Text));
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
                    MessageBox.Show("El código debe tener 6 carácteres válidos");

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
            HistorialPrendas pr = new HistorialPrendas();
            pr.ShowDialog(this);
        }

        public void Nuevo()
        {
            modo = 1;
            limpiar.BorrarCampos(this, panel1);
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
            tb_codigo.Enabled = true;
            tb_prenda.Enabled = true;
            tb_color.Enabled = true;
            cb_estado.Enabled = true;
            cb_talla.Enabled = true;
            tb_pxmayor.Enabled = true;
            tb_pxmenor.Enabled = true;
            //Focus
            tb_codigo.Focus();
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
            tb_codigo.Enabled = true;
            tb_prenda.Enabled = true;
            tb_color.Enabled = true;
            cb_estado.Enabled = true;
            cb_talla.Enabled = true;
            tb_pxmayor.Enabled = true;
            tb_pxmenor.Enabled = true;
            //Focus
            tb_codigo.Focus();
        }
        public void Cancelar()
        {
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
            tb_codigo.Enabled = false;
            tb_prenda.Enabled = false;
            tb_color.Enabled = false;
            cb_estado.Enabled = false;
            cb_talla.Enabled = false;
            tb_pxmayor.Enabled = false;
            tb_pxmenor.Enabled = false;

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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Prendas", "Registro Prendas"))
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