using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace SIRHU.CustomControls
{
    /// <summary>
    /// Lógica de interacción para BindablePasswordBox1.xaml
    /// </summary>
    public partial class BindablePasswordBox1 : UserControl
    {
        public event EventHandler PasswordChanged;

        public static readonly DependencyProperty PasswordProperty =
           DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox1),
            new PropertyMetadata(string.Empty));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox1()
        {
            InitializeComponent();
            pbPassword.PasswordChanged += OnPasswordChanged;
            
            pbPassword.PasswordChanged += (sender, e) =>
            {
                PasswordChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = pbPassword.Password;

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
