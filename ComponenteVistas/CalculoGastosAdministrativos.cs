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
    public partial class CalculoGastosAdministrativos : Form
    {
        Negocio neg = new Negocio();
        Verificar ver = new Verificar();
        Limpiar limpiar = new Limpiar();
        Imprimir imp = new Imprimir();
        DataTable datatablas, tablas1, Lista;
        int modo = 0, contar = 0, Valor;
        Decimal num1, num2, num3, num4, suma;
        string NuevoOrden, AntiguoOrden, Codigo, mensaje;

        public CalculoGastosAdministrativos()
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
            datatablas = neg.SelectDataTable("select * from CalculoGastos " + condicion);
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
                Error("No hay Datos de Tiendas", "Tiendas");
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
            if (!neg.Comprobar("select * from CalculoGastos"))
            {
                Error("No se ha encontrado este componente", "CalculoGastos");
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
                    Codigo = row.Cells[0].Value.ToString().Trim();
                    cb_tienda.Text = row.Cells[1].Value.ToString().Trim();
                    dateTimePicker1.Text = row.Cells[2].Value.ToString();
                    tb_monto1.Text = row.Cells[3].Value.ToString();
                    tb_pagos.Text = row.Cells[4].Value.ToString();
                    tb_materia.Text = row.Cells[5].Value.ToString();
                    tb_total.Text = row.Cells[6].Value.ToString();
                    AntiguoOrden = row.Cells[8].Value.ToString();
                    tb_orden.Text = row.Cells[8].Value.ToString(); 
                }
            }
        }

        #endregion

        #region Cajas de Textos
        private void tb_monto_TextChanged(object sender, EventArgs e)
        {
            if (tb_monto.Text != String.Empty)
                tb_monto1.Text = tb_monto.Text;
            else
                tb_monto1.Text = "0";
        }
        private void GastosPagos(object sender, EventArgs e)
        {
            Pagos(tb_tienda, tb_personal, tb_taller, tb_tienda1, tb_pagos);

        }
        private void GastosMateriaPrima(object sender, EventArgs e)
        {
            Pagos(tb_telas, tb_hijos, tb_accesorios, tb_planchado, tb_materia);
        }
        private void GastosTotal(object sender, EventArgs e)
        {
            Pagos(tb_monto1, tb_pagos, tb_materia, tb_total);
        }
        private void Pagos(TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, TextBox tb5)
        {
                if (tb1.Text != String.Empty)
                {
                    Decimal.TryParse(tb1.Text.Replace(".", ","), out num1);
                    if (num1 == 0)
                    {
                        MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                    }
                }
                else
                    num1 = 0;
                if (tb2.Text != String.Empty)
                {
                    Decimal.TryParse(tb2.Text.Replace(".", ","), out num2);
                    if (num2 == 0)
                    {
                        MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                    }
                }
                else
                    num2 = 0;
                if (tb3.Text != String.Empty)
                {
                    Decimal.TryParse(tb3.Text.Replace(".", ","), out num3); if (num3 == 0)
                    {
                        MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                    }
                }
                else
                    num3 = 0;
                if (tb4.Text != String.Empty)
                {
                    Decimal.TryParse(tb4.Text.Replace(".", ","), out num4); if (num4 == 0)
                    {
                        MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                    }
                }
                else
                    num4 = 0;
                suma = num1 + num2 + num3 + num4;
                tb5.Text = suma.ToString("F");
            
        }
        private void Pagos(TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb5)
        {
            if (tb1.Text != String.Empty)
            {
                Decimal.TryParse(tb1.Text.Replace(".", ","), out num1);
                if (num1 == 0)
                {
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                }
            }
            else
                num1 = 0;
            if (tb2.Text != String.Empty)
            {
                Decimal.TryParse(tb2.Text.Replace(".", ","), out num2); if (num2 == 0)
                {
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                }
            }
            else
                num2 = 0;
            if (tb3.Text != String.Empty)
            {
                Decimal.TryParse(tb3.Text.Replace(".", ","), out num3); if (num3 == 0)
                {
                    MessageBox.Show("Una de las casillas de este grupo tiene un número inválido\n Por favor, escriba un número válido en esa casilla para continuar ", "Un número tiene formato no válido");
                }
            }
            else
                num3 = 0;
            suma = num1 + num2 + num3;
            tb5.Text = suma.ToString("F");
        }
        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            ver.SoloDecimal(e);
        }
        #endregion

        #region Header
        private void b_nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            tb_orden.Text = neg.NuevoOrden("CalculoGastos").ToString();
            Codigo = neg.NuevoCodigo("CalculoGastos");
            cb_tienda.Focus();
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            Lista = neg.SelectDataTable("select * from HistorialCalculoGastos where NuevoOrden='" + AntiguoOrden + "' and Estado<>'Anulado'");
            if (Lista.Rows.Count != 0)
            {
                cb_tienda.Text = Lista.Rows[0][2].ToString();
                dateTimePicker1.Text = Lista.Rows[0][3].ToString();
                tb_tienda.Text = Lista.Rows[0][4].ToString();
                tb_personal.Text = Lista.Rows[0][5].ToString();
                tb_taller.Text = Lista.Rows[0][6].ToString();
                tb_tienda1.Text = Lista.Rows[0][7].ToString();
                tb_telas.Text = Lista.Rows[0][8].ToString();
                tb_hijos.Text = Lista.Rows[0][9].ToString();
                tb_accesorios.Text = Lista.Rows[0][10].ToString();
                tb_planchado.Text = Lista.Rows[0][11].ToString();
                tb_monto.Text = Lista.Rows[0][12].ToString();
                Modificar();
            }
            else
                MessageBox.Show("Fila de datos no válida", "Datos no válidos");
        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            Lista = neg.SelectDataTable("select * from HistorialCalculoGastos where Codigo='" + Codigo + "' and Estado<>'Anulado'");
            if (Lista.Rows.Count != 0)
            {
                if (neg.EliminarCalculoGastos(Codigo,
                    Lista.Rows[0][2].ToString(),
                    DateTime.Now.Date, 
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
                Valor = neg.GuardarCalculoGastos(modo, Codigo,cb_tienda.Text, dateTimePicker1.Value, 
                    tb_tienda.Text,tb_personal.Text,tb_taller.Text,tb_tienda1.Text,tb_telas.Text,tb_hijos.Text,tb_accesorios.Text,
                    tb_planchado.Text,tb_monto1.Text,tb_pagos.Text,tb_materia.Text,tb_total.Text,tb_orden.Text, AntiguoOrden);
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
                MessageBox.Show(ver.CamposVacios(this, groupBox1));
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }


        private void b_historial_Click(object sender, EventArgs e)
        {
            HistorialGastosAdministrativos pr = new HistorialGastosAdministrativos();
            pr.ShowDialog(this);
        }

        public void Nuevo()
        {
            modo = 1;
            limpiar.BorrarCampos(this, groupBox1);
            limpiar.BorrarCampos(this, groupBox2);
            limpiar.BorrarCampos(this, groupBox3);
            limpiar.BorrarCampos(this, groupBox4);
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
        }
        public void Cancelar()
        {
            limpiar.BorrarCampos(this, groupBox1);
            limpiar.BorrarCampos(this, groupBox2);
            limpiar.BorrarCampos(this, groupBox3);
            limpiar.BorrarCampos(this, groupBox4);
            modo = 0;
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Calculo de Gastos Administrativos", "Calculo de Gastos Administrativos"))
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