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
    public partial class Login : Form
    {
        Negocio neg = new Negocio();
        Int32 intentos = 6;
        public Login()
        {
            InitializeComponent();
            neg.BaseDeDatos();
            
        }

        private void b_ingresar_Click(object sender, EventArgs e)
        {
            if (intentos <= 1)
            {
                MessageBox.Show("Ha fallado 5 veces, el sistema se cerrará automáticamente");
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                if (neg.VerificarUsuario(tb_usuario.Text, tb_clave.Text) == "1")
                    this.DialogResult = DialogResult.OK;
                else
                {
                    intentos--;
                    if (intentos <= 3)
                        MessageBox.Show("Clave/Usuario Incorrectos - Te quedan " + intentos + " intentos");
                    else
                        MessageBox.Show("Clave/Usuario Incorrectos");
                }
            }
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
