using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponenteNegocios;

namespace ComponenteVistas
{
    public partial class Arrancar : Form
    {
        Negocio neg = new Negocio();
        DialogResult dialog;
        public Arrancar()
        {
            InitializeComponent();
        }
        private void Verificar()
        {
            if (!neg.BaseDeDatos())
            {
                dialog = MessageBox.Show("Reportar problemas de conexión con Base de Datos ", "Oops");
                menuStrip2.Enabled = false;
                toolStripMenuItem7.Enabled = false;
                toolStripMenuItem8.Enabled = false;
                toolStripMenuItem9.Enabled = false;
                toolStripMenuItem10.Enabled = false;
            }
            else
            {
                menuStrip2.Enabled = true;
                toolStripMenuItem7.Enabled = true;
                toolStripMenuItem8.Enabled = true;
                toolStripMenuItem9.Enabled = true;
                toolStripMenuItem10.Enabled = true;
            }
        }
        private void Arrancar_Shown(object sender, EventArgs e)
        {
            Verificar();
        }
        private void prendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistasPrendas ventana = new VistasPrendas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VistasTiendas ventana = new VistasTiendas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VistasEntradasSalidas ventana = new VistasEntradasSalidas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VistasVentas ventana = new VistasVentas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ConsultasEntradasSalidas ventana = new ConsultasEntradasSalidas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ConsultasVentas ventana = new ConsultasVentas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            StockPrendas ventana = new StockPrendas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DatosPersonal ventana = new DatosPersonal();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DatosAdministrativos ventana = new DatosAdministrativos();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            CalculoPrendas ventana = new CalculoPrendas();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CalculoGastosAdministrativos ventana = new CalculoGastosAdministrativos();
            ventana.ShowDialog(this);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            BackUp ventana = new BackUp();
            DialogResult res = ventana.ShowDialog();
            if (res == DialogResult.OK)            
                Verificar();            
        }

        private void Arrancar_FormClosing(object sender, FormClosingEventArgs e)
        {
            neg.TerminarConexion();
        }
    }
}