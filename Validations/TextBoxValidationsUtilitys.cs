using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIRHU.Validations
{
    public class TextBoxValidationsUtilitys
    {
        public void mayusAutos(System.Windows.Controls.TextBox txt)
        {
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        public void minusAutos(System.Windows.Controls.TextBox txt)
        {
            txt.Text = txt.Text.ToLower();
            txt.SelectionStart = txt.Text.Length;
        }
        public bool validarCorreo(string correo)
        {
            // Utilizamos una expresión regular para verificar si el correo contiene al menos un símbolo "@"
            Regex regex = new Regex(@"@");
            Match match = regex.Match(correo);

            // Si se encuentra al menos una coincidencia, el correo es válido
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ValidarNumero(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Solo permitir números y punto decimal
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }

            // Validar solo un punto decimal
            if (e.Text == "." && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ValidarTexto(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Validar que solo se ingresen letras y admitir espacio
            if (!char.IsLetter(e.Text, 0) && e.Text != " " && !char.IsControl(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ValidarSoloNumeroYpunto(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Solo permitir números y punto decimal
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }

            // Validar solo un punto decimal
            if (e.Text == "." && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public bool P_Valida_Cedula(string cedula)
        {
            int numero = 0;
            int suma = 0;
            int resultado = 0;
            for (int i = 0; i < cedula.Length; i++)
            {
                numero = int.Parse(cedula[i].ToString());
                if (i % 2 == 0)
                {
                    numero = numero * 2;
                    if (numero > 9)
                    {
                        numero = numero - 9;
                    }
                }
                suma = suma + numero;
            }
            if (suma % 10 != 0)
            {
                resultado = 10 - (suma % 10);
                if (resultado == numero)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return (true);
            }

        }
    }
}
