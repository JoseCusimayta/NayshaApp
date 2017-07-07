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
    public partial class VistasTiendas : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas;
        int modo = 0, contar, anulados, comparar, estados;
        String mensaje, estado;
        public VistasTiendas()
        {
            InitializeComponent();
            if (neg.BaseDeDatos())
            {
                if (Tablas(null))
                    DiseñoTablas();
            }
        }
        private void VistasTiendas_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from Tiendas"))
            {
                MessageBox.Show("No se ha encontrado este componente", "Tiendas");
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
            }
            VerificarVencimiento();
        }

        #region Llenar datos y verificar que existan tablas/datos
        public bool Tablas(String condicion)
        {
            datatablas = neg.SelectDataTable("select Codigo, Tienda, Vendedor, Fecha_Inicio as 'Fecha Inicio', Fecha_Cierre as 'Fecha Cierre', Alquiler, Estado, Orden from Tiendas " + condicion);
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
        #endregion

        #region Diseño del dataGridView

        public void DiseñoTablas()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Ivory;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.Columns["Alquiler"].DefaultCellStyle.Format = "S/'.' .00";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Estado")
            {
                String valor = e.Value as String;
                if (valor == "Cerrado")
                {
                    Int32 fila = e.RowIndex;
                    dataGridView1.Rows[fila].DefaultCellStyle.BackColor = Color.LightPink;
                    dataGridView1.Rows[fila].DefaultCellStyle.SelectionBackColor = Color.DeepPink;
                }
            }
        }

        #endregion

        #region Verificar Ingreso de Teclado y Fechas

        private void tb_alquiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeroYLetras(e);
        }

        public void VerificarVencimiento()
        {
            DataTable Cierre = neg.SelectDataTable("select * from Tiendas where Fecha_Cierre<DATEADD(d,-1,GETDATE()) and Estado='Activo'");
            if (Cierre != null)
            {
                for (int i = 0; i < Cierre.Rows.Count; i++)
                {
                    contar = neg.GuardarTiendas(2, Cierre.Rows[i][0].ToString(), Cierre.Rows[i][1].ToString(), Cierre.Rows[i][2].ToString(), Cierre.Rows[i][3].ToString(), Cierre.Rows[i][4].ToString(), Cierre.Rows[i][5].ToString().Replace(",", "."), "En Espera", Convert.ToInt16(Cierre.Rows[i][7].ToString()));
                }
            }
            List<String> Lista = neg.Listas("select Tienda from Tiendas where Fecha_Cierre<DATEADD(day,15,GETDATE()) and Estado='Activo'");
            String Tiendas = "Las siguientes tiendas estan por vencerse\n";
            String tiemporestante;
            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    tiemporestante = neg.ObtenerDatos("select DATEDIFF(day,GETDATE(),Fecha_Cierre) from Tiendas where Tienda='" + Lista[i] + "'");
                    Tiendas += Lista[i] + " quedan " + tiemporestante + " días\n";
                }
                if (Tiendas != "Las siguientes tiendas estan por vencerse\n")
                    MessageBox.Show(Tiendas);
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
                    tb_codigo.Text = row.Cells[0].Value.ToString();
                    tb_tienda.Text = row.Cells[1].Value.ToString();
                    tb_vendedor.Text = row.Cells[2].Value.ToString();
                    dateTimePicker1.Text = row.Cells[3].Value.ToString();
                    dateTimePicker2.Text = row.Cells[4].Value.ToString();
                    tb_alquiler.Text = row.Cells[5].Value.ToString();
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
            tb_orden.Text = neg.NuevoOrden("Tiendas").ToString();
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            contar = neg.Contar("Tiendas", "Codigo='" + tb_codigo.Text + "'");
            anulados = neg.Contar("Tiendas", "Codigo='" + tb_codigo.Text + "' and Estado='Cerrado'");
            if (anulados == 0)
            {
                if (contar != 0)
                {
                    tb_orden.Text = neg.NuevoOrden("Tiendas").ToString();
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
            contar = neg.Contar("Tiendas", "Codigo='" + tb_codigo.Text + "' and Estado='Cerrado'");
            if (contar != 0)
            {
                MessageBox.Show("El registro ya fue eliminado");
            }
            else
            {
                if (neg.EliminarTiendas(tb_codigo.Text))
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
                    TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
                    comparar = Convert.ToInt16(difference.TotalDays);
                    if ((modo == 1 && comparar > 29) || (modo == 2 && comparar >= 0))
                    {
                        estado = neg.ObtenerDatos("Select Estado from Tiendas where Codigo ='" + tb_codigo.Text + "'");
                        if (cb_estado.Text == "Anulado" && cb_estado.Text == estado)
                            estados = 1;
                        else if (cb_estado.Text == "En Espera" && cb_estado.Text == estado)
                            estados = 1;
                        else
                            estados = 0;
                        if (estados == 0)
                        {
                            Int32 Valor = neg.GuardarTiendas(modo, tb_codigo.Text, tb_tienda.Text, tb_vendedor.Text, dateTimePicker1.Text, dateTimePicker2.Text, tb_alquiler.Text.Replace(".", ","), cb_estado.Text, Convert.ToInt32(tb_orden.Text));
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
                            MessageBox.Show("El estado no puede permanecer igual");

                    }
                    else
                        MessageBox.Show("Fechas Inválidas");
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
            HistorialTiendas pr = new HistorialTiendas();
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
            b_eliminar.Enabled = true;
            b_guardar.Enabled = true;
            b_cancelar.Enabled = true;
            //Textos
            tb_codigo.Enabled = true;
            tb_tienda.Enabled = true;
            cb_estado.Enabled = true;
            tb_vendedor.Enabled = true;
            tb_alquiler.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
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
            tb_tienda.Enabled = true;
            cb_estado.Enabled = true;
            tb_vendedor.Enabled = true;
            tb_alquiler.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
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
            tb_tienda.Enabled = false;
            cb_estado.Enabled = false;
            tb_vendedor.Enabled = false;
            tb_alquiler.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Tiendas", "Registro Tiendas"))
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
