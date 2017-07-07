using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComponenteNegocios
{
    public class Verificar
    {
        public String CamposVacios(Control control, GroupBox e)
        {
            String Mensaje = "Los siguientes datos no pueden estar vacios:";
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    TextBox text = ((TextBox)txt);
                    if (String.IsNullOrWhiteSpace(text.Text))
                    {
                        Mensaje = Mensaje + "\n " + text.Tag;
                    }
                }
            }
            foreach (var txt in e.Controls)
            {
                if (txt is TextBox)
                {
                    TextBox text = ((TextBox)txt);
                    if (String.IsNullOrWhiteSpace(text.Text))
                    {
                        Mensaje = Mensaje + "\n " + text.Tag;
                    }
                }
            }
            return Mensaje;
        }
        public String CamposVacios(Control control, Panel e)
        {
            String Mensaje = "Los siguientes datos no pueden estar vacios:";
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    TextBox text = ((TextBox)txt);
                    if (String.IsNullOrWhiteSpace(text.Text))
                    {
                        Mensaje = Mensaje + "\n " + text.Tag;
                    }
                }
            }
            foreach (var txt in e.Controls)
            {
                if (txt is TextBox)
                {
                    TextBox text = ((TextBox)txt);
                    if (String.IsNullOrWhiteSpace(text.Text))
                    {
                        Mensaje = Mensaje + "\n " + text.Tag;
                    }
                }
            }
            return Mensaje;
        }
        public bool ValidarTextBoxVacios(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    if (control.Text.Equals(""))
                    {
                        return false;
                    }
                }
                else if (control.GetType().Equals(typeof(ComboBox)))
                {
                    if (control.Text.Equals(""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void SoloLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
                v.Handled = false;
            else if (Char.IsSeparator(v.KeyChar))
                v.Handled = false;
            else if (Char.IsControl(v.KeyChar))
                v.Handled = false;
            else
                v.Handled = true;
        }
        public void SoloNumeros(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
                v.Handled = false;
            else if (Char.IsSeparator(v.KeyChar))
                v.Handled = true;
            else if (Char.IsControl(v.KeyChar))
                v.Handled = false;
            else
                v.Handled = true;
        }
        public void SoloDecimal(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
                v.Handled = false;
            else if (Char.IsSeparator(v.KeyChar))
                v.Handled = true;
            else if (Char.IsControl(v.KeyChar))
                v.Handled = false;
            else if (v.KeyChar.ToString().Equals("."))
                v.Handled = false;
            else
                v.Handled = true;
        }
        public void SoloNumeroYLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
                v.Handled = false;
            else if (Char.IsControl(v.KeyChar))
                v.Handled = false;
            else if (Char.IsDigit(v.KeyChar))
                v.Handled = false;
            else
                v.Handled = true;
        }
    }
}
