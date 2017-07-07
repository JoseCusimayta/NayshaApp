using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComponenteNegocios
{
    public class Limpiar
    {
        public void BorrarCampos(Control control, GroupBox e)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }
            foreach (var txt in e.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }
        }
        public void BorrarCampos(Control control, Panel e)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }
            foreach (var txt in e.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }            
        }
        public void BorrarCampos(Control control, Form e)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }
            foreach (var txt in e.Controls)
            {
                if (txt is TextBox)
                    ((TextBox)txt).Clear();
                else if (txt is ComboBox)
                    ((ComboBox)txt).SelectedIndex = 0;
            }
        }
    }
}
