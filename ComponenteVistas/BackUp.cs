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
    public partial class BackUp : Form
    {
        public String var;
        string mensaje;
        Negocio neg = new Negocio();
        public BackUp()
        {
            InitializeComponent();
        }

        private void b_buscar1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_guardar.Text = dlg.SelectedPath;
            }
        }

        private void b_guardar_Click(object sender, EventArgs e)
        {
            if (neg.GuardarBD(tb_guardar.Text))
                MessageBox.Show("La base de datos ha sido correctamente guardada", "BackUp Completo");
            else
                MessageBox.Show("La base de datos no se ha podido guardar", "Problemas al guardar");
        }

        private void b_buscar2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup files(*.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_restaurar.Text = dlg.FileName;
            }
        }

        private void b_restaurar_Click(object sender, EventArgs e)
        {
            mensaje = neg.RestaurarBD(tb_restaurar.Text);
            MessageBox.Show(mensaje);
        }

    }
}