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
using SIRHU.ViewModel;
using System.ComponentModel;
using SIRHU.Models;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para AddUsersView.xaml
    /// </summary>
    public partial class AddUsersView : UserControl
    {
        public static DataGrid dataGrid;

        public AddUsersView()
        {

            InitializeComponent();
            LoadData();
            DataContext = new LoginViewModel();
        }

        public void LoadData()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            dgUsers.ItemsSource = loginViewModel.UsersRegister;
            dataGrid = dgUsers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addView = new AddUserMiniView();
            addView.ShowDialog(); // Reemplaza MainGrid con el nombre de tu contenedor
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            
            var selectedItem = dgUsers.SelectedItem as UserModel;
            if (selectedItem != null)
            {

                var selectedId = selectedItem.Id;

                var editView = new EditUsersView(selectedId);

                editView.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel loginViewModel)
            {
                if (loginViewModel.DeleteUserCommand.CanExecute(null))
                {
                    loginViewModel.DeleteUserCommand.Execute(null);
                }
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dgUsers.SelectedItem as UserModel;
            if (selectedItem != null)
            {

                txtId.Text = selectedItem.Id;

            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtSearch.Text.Length > 3)
            {
                if (DataContext is LoginViewModel loginViewModel)
                {
                    if (loginViewModel.SearchByAll.CanExecute(null))
                    {
                        loginViewModel.SearchByAll.Execute(null);
                        dgUsers.ItemsSource = loginViewModel.SearchUsers;
                    }
                    
                }

            }
            else
            {
              LoadData();
            }

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
