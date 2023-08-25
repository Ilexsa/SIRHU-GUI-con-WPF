using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void txtCedula_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCedula.Text == "Cédula")
            {
                txtCedula.Text = "";
            }
        }

        private void txtCedula_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCedula.Text == "")
            {
                txtCedula.Text = "Cédula";
            }
        }

        private void txtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "Apellidos y Nombres")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Apellidos y Nombres";
            }
        }
    }
}
