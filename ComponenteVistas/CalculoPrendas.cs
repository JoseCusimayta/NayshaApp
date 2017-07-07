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
    public partial class CalculoPrendas : Form
    {
        Negocio neg = new Negocio();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        Verificar ver = new Verificar();
        Decimal num1, num2, num3,num4,num5,igv=0.18m, total;
        int modo = 0, contar = 0, Valor;
        DataTable datatablas, Lista;
        string NuevoOrden, AntiguoOrden,Codigo, mensaje;

        public CalculoPrendas()
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
            datatablas = neg.SelectDataTable("select * from CalculoPrendas " + condicion);
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
        private void Formulario_Shown(object sender, EventArgs e)
        {
            if (!neg.Comprobar("select * from CalculoPrendas"))
            {
                Error("No se ha encontrado este componente", "CalculoPrendas");
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
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
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
                    Codigo = row.Cells[0].Value.ToString();
                    tb_tela4.Text = tb_tela3.Text = row.Cells[1].Value.ToString();
                    tb_app4.Text = tb_app3.Text = row.Cells[2].Value.ToString();
                    tb_dec4.Text = tb_dec3.Text = row.Cells[3].Value.ToString();
                    tb_serv7.Text = tb_serv6.Text = row.Cells[4].Value.ToString();
                    tb_igv.Text = row.Cells[5].Value.ToString();
                    tb_total.Text = row.Cells[6].Value.ToString();
                    AntiguoOrden = row.Cells[9].Value.ToString();
                    NuevoOrden = neg.NuevoOrden("CalculoPrendas").ToString();
                }
            }
        }

        #endregion       

        #region Cajas de Textos
        private void Telas(object sender, EventArgs e)
        {
            SumarSubTotal(tb_tela1, tb_tela2, tb_tela3, tb_tela4);
        }
        private void Aplicaciones(object sender, EventArgs e)
        {
            SumarSubTotal(tb_app1, tb_app2, tb_app3, tb_app4);
        }
        private void Decoraciones(object sender, EventArgs e)
        {
            SumarSubTotal(tb_dec1, tb_dec2, tb_dec3, tb_dec4);
        }

        private void Servicios(object sender, EventArgs e)
        {
            if (tb_serv1.Text != String.Empty &&
                tb_serv2.Text != String.Empty &&
                tb_serv3.Text != String.Empty &&
                tb_serv4.Text != String.Empty &&
                tb_serv5.Text != String.Empty)
            {
                Decimal.TryParse(tb_serv1.Text.Replace(".", ","), out num1);
                Decimal.TryParse(tb_serv2.Text.Replace(".", ","), out num2);
                Decimal.TryParse(tb_serv3.Text.Replace(".", ","), out num3);
                Decimal.TryParse(tb_serv4.Text.Replace(".", ","), out num4);
                Decimal.TryParse(tb_serv5.Text.Replace(".", ","), out num5);
                if (num1 != 0 && num2 != 0 && num3 != 0 && num4 != 0 && num5 != 0)
                {
                    tb_serv6.Text = (num1 + num2 + num3 + num4 + num5).ToString("F");
                }
                else
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
            }
            else tb_serv6.Text = null;
            tb_serv7.Text = tb_serv6.Text;
        }
        public void SumarSubTotal(TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4)
        {
            if (tb1.Text != String.Empty && tb2.Text != String.Empty)
            {
                Decimal.TryParse(tb1.Text.Replace(".", ","), out num1);
                Decimal.TryParse(tb2.Text.Replace(".", ","), out num2);
                if (num1 != 0 && num2 != 0)
                {
                    num1 = Decimal.Parse(tb1.Text.Replace(".", ","));
                    num2 = Decimal.Parse(tb2.Text.Replace(".", ","));
                    tb3.Text = (num1 * num2).ToString("F");
                }
                else
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
            }
            else tb3.Text = null;
            tb4.Text = tb3.Text;
        }

        public void CalculoTotal(object sender, EventArgs e)
        {
            TextoVacio(tb_tela4);
            TextoVacio(tb_app4);
            TextoVacio(tb_dec4);
            TextoVacio(tb_serv7);
            TextoVacio(tb_igv);
            total = Convert.ToDecimal(tb_tela4.Text) + Convert.ToDecimal(tb_app4.Text) + Convert.ToDecimal(tb_dec4.Text) + Convert.ToDecimal(tb_serv7.Text);
            tb_igv.Text = (total * igv).ToString("F");
            tb_total.Text = (total * (igv + 1)).ToString("F");
        }
        public void TextoVacio(TextBox txt)
        {
            if (txt.Text == String.Empty)
                txt.Text = "0";
        }
        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
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
            NuevoOrden = neg.NuevoOrden("CalculoPrendas").ToString();
            Codigo = neg.NuevoCodigo("CalculoPrendas");
            tb_tela1.Focus();
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            Lista = neg.SelectDataTable("select * from HistorialCalculoPrendas where NuevoOrden='" + AntiguoOrden + "' and Estado<>'Anulado'");
            if (Lista.Rows.Count != 0)
            {
                tb_tela1.Text = Lista.Rows[0][2].ToString();
                tb_tela2.Text = Lista.Rows[0][3].ToString();
                tb_app1.Text = Lista.Rows[0][5].ToString();
                tb_app2.Text = Lista.Rows[0][6].ToString();
                tb_dec1.Text = Lista.Rows[0][8].ToString();
                tb_dec2.Text = Lista.Rows[0][9].ToString();
                tb_serv1.Text = Lista.Rows[0][11].ToString();
                tb_serv2.Text = Lista.Rows[0][12].ToString();
                tb_serv3.Text = Lista.Rows[0][13].ToString();
                tb_serv4.Text = Lista.Rows[0][14].ToString();
                tb_serv5.Text = Lista.Rows[0][15].ToString();
                Modificar();
            }
            else
                MessageBox.Show("Fila de datos no válida", "Datos no válidos");
        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            Lista = neg.SelectDataTable("select * from HistorialCalculoPrendas where Codigo='" + Codigo + "' and Estado<>'Anulado'");
            if (Lista.Rows.Count != 0)
            {
                if (neg.EliminarCalculoPrendas(Codigo,
                    Lista.Rows[0][2].ToString(),
                    Lista.Rows[0][3].ToString(),
                    Lista.Rows[0][4].ToString(),
                    Lista.Rows[0][5].ToString(),
                    Lista.Rows[0][6].ToString(),
                    Lista.Rows[0][7].ToString(),
                    Lista.Rows[0][8].ToString(),
                    Lista.Rows[0][9].ToString(),
                    Lista.Rows[0][10].ToString(),
                    Lista.Rows[0][11].ToString(),
                    Lista.Rows[0][12].ToString(),
                    Lista.Rows[0][13].ToString(),
                    Lista.Rows[0][14].ToString(),
                    Lista.Rows[0][15].ToString(),
                    Lista.Rows[0][16].ToString(),
                    Lista.Rows[0][17].ToString(),
                    Lista.Rows[0][18].ToString(),
                    DateTime.Now.Date,
                    neg.NuevoOrden("CalculoPrendas").ToString(),
                    AntiguoOrden))
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    Cancelar();
                }
                else
                    MessageBox.Show("Error al eliminar");
            }
            else
                MessageBox.Show("La fia de datos que intenta eliminar, ya ha sido eliminada", "Datos no válidos");
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            mensaje = ver.CamposVacios(this, groupBox1);
            if (mensaje.Equals("Los siguientes datos no pueden estar vacios:"))
            {
                Valor = neg.GuardarCalculoPrendas(modo, Codigo, tb_tela1.Text, tb_tela2.Text, tb_tela3.Text,
                    tb_app1.Text, tb_app2.Text, tb_app3.Text,
                    tb_dec1.Text, tb_dec2.Text, tb_dec3.Text,
                    tb_serv1.Text, tb_serv2.Text, tb_serv3.Text, tb_serv4.Text, tb_serv5.Text, tb_serv6.Text,
                    tb_igv.Text, tb_total.Text, DateTime.Now.Date, NuevoOrden, AntiguoOrden);
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

            }else
                MessageBox.Show(ver.CamposVacios(this, groupBox1));
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }


        private void b_historial_Click(object sender, EventArgs e)
        {
            HistorialGastosPrendas pr = new HistorialGastosPrendas();
            pr.ShowDialog(this);
        }

        public void Nuevo()
        {
            modo = 1;
            limpiar.BorrarCampos(this, groupBox1);
            limpiar.BorrarCampos(this, groupBox2);
            limpiar.BorrarCampos(this, groupBox3);
            limpiar.BorrarCampos(this, groupBox4);
            limpiar.BorrarCampos(this, groupBox5);
            //Botones
            b_nuevo.Enabled = false;
            b_modificar.Enabled = false;
            b_salir.Enabled = false;
            b_imprimir.Enabled = false;
            b_historial.Enabled = false;
            b_eliminar.Enabled = false;
            b_guardar.Enabled = true;
            b_cancelar.Enabled = true;
            //GroupBox
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
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
            //GroupBox
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
        }
        public void Cancelar()
        {
            modo = 0;
            limpiar.BorrarCampos(this, groupBox1);
            limpiar.BorrarCampos(this, groupBox2);
            limpiar.BorrarCampos(this, groupBox3);
            limpiar.BorrarCampos(this, groupBox4);
            limpiar.BorrarCampos(this, groupBox5);
            Tablas(null);
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
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Calculo de Prendas", "Calculo de Prendas"))
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