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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para AddUsersView.xaml
    /// </summary>
    public partial class AddUsersView : UserControl
    {
        public AddUsersView()
        {
            InitializeComponent();
        }
        
           private void OnPasswordChanged (object sender, RoutedEventArgs e)
            {
                if (pbPassword.Password.Length > 0)
                {
                    waterMark.Visibility = Visibility.Hidden;
                }
                else
                {
                    waterMark.Visibility = Visibility.Visible;
                }
            }
    }
}
