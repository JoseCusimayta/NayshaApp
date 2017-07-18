using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComponenteVistas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Arrancar());
            /*
            Login frm = new Login();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                Application.Run(new Arrancar());
                */
        }
    }
}
