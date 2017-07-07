﻿using System;
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
    public partial class HistorialTiendas : Form
    {
        Negocio neg = new Negocio();
        Imprimir imp = new Imprimir();
        Verificar ver = new Verificar();
        public HistorialTiendas()
        {
            InitializeComponent(); 
            neg.BaseDeDatos();
            Tablas(null);
            DiseñoTablas();
        }
        public void Tablas(String condicion)
        {
            dataGridView1.DataSource = neg.SelectDataTable("select Codigo, Tienda, Vendedor, Fecha_Inicio as 'Fecha Inicio', Fecha_Cierre as 'Fecha Cierre', Alquiler, Estado, FechaSistema as 'Fecha Sistema', HoraSistema as 'Hora Sistema', Accion, NuevoOrden as 'Nuevo Orden', AntiguoOrden as 'Antiguo Orden' from HistorialTiendas " + condicion);
        }

        #region Diseño

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

        #region botones
        private void b_codigo_Click(object sender, EventArgs e)
        {
            Tablas("where Codigo='" + tb_codigo.Text + "'");
        }

        private void b_fecha_Click(object sender, EventArgs e)
        {
            Tablas("where Fecha_Inicio='" + dateTimePicker1.Value.ToShortDateString() + "'");
        }

        private void b_cierre_Click(object sender, EventArgs e)
        {
            Tablas("where Fecha_Cierre='" + dateTimePicker2.Value.ToShortDateString() + "'");
        }

        private void b_tienda_Click(object sender, EventArgs e)
        {
            Tablas("where Tienda='" + tb_tienda.Text + "'");
        }

        private void b_limpiar_Click(object sender, EventArgs e)
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
            if (imp.SetupThePrinting(printDocument1, dataGridView1, "Historial Tiendas", "Historial Tiendas"))
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

        private void tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ver.SoloNumeros(e);
        }
    }
}
