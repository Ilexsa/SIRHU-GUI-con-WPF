using SIRHU.Models;
using SIRHU.ViewModel;
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
using System.Windows.Shapes;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para EditUsersView.xaml
    /// </summary>
    public partial class EditUsersView : Window
    {
        string Id;
        public EditUsersView(string UserId)
        {
            InitializeComponent();

            Id = UserId;

            LoginViewModel loginViewModel = new LoginViewModel();
            var st = loginViewModel.UsersRegister.Where(item => item.Id == Id).ToList();
            if (st.Count > 0)
            {
                txtID.Text = st[0].Id;
                txtFirstName.Text = st[0].Name;
                txtLastName.Text = st[0].LastName;
                txtEmail.Text = st[0].Email;
                txtPosition.Text = st[0].Position;
                txtUserName.Text = st[0].Nickname;
                pbPassword.Password = st[0].Password;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
