using SIRHU.CustomControls;
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
using SIRHU.View;

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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddUserMiniView();
            addView.ShowDialog();
        }

        //private void HandlePasswordChanged(object sender, EventArgs e)
        //{
        //    if (pbPassword.Password.Length > 0)
        //    {
        //        waterMark.Visibility = Visibility.Hidden;
        //    }
        //    else
        //    {
        //        waterMark.Visibility = Visibility.Visible;
        //    }
        //}
    }
}
