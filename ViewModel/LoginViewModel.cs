using SIRHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SIRHU.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;
using System.Windows;
using System.Collections.ObjectModel;
using SIRHU.View;

namespace SIRHU.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private ObservableCollection<UserModel> _usersRegister;
        private ObservableCollection<UserModel> _searchUsers;
        private string _searchString;
        private UserModel _user;

        private IUserRepository userRepository;

        //Properties
        public string SearchString
        {
            get
            {
                return _searchString;
            }
            set 
            { 
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        public ObservableCollection<UserModel> UsersRegister
        {
            get 
            { 
                return _usersRegister; 
            }
            set 
            { 
                _usersRegister = value;
                OnPropertyChanged(nameof(UsersRegister));
            }
        }

        public ObservableCollection<UserModel> SearchUsers
        {
            get
            {
                return _searchUsers;
            }
            set
            {
                _searchUsers = value;
                OnPropertyChanged(nameof(SearchUsers));
            }
        }

        public UserModel User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage 
        { 
            get 
            { 
                return _errorMessage; 
            }
            set 
            { 
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // -> Commands
        public ICommand EditUserCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand AddUsserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand SearchByAll { get; }

        //Constructors

        public LoginViewModel()
        {
            _user = new UserModel();
            userRepository = new UserRepository();
            AddUsserCommand = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand,CanExecuteDeleteCommand);
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            EditUserCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
            SearchByAll = new ViewModelCommand(ExecuteSearchByAllCommand, CanExecuteByAllCommand);
            UsersRegister = userRepository.Get();
        }

        private bool CanExecuteByAllCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(SearchString) || SearchString.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteSearchByAllCommand(object obj)
        {
            SearchUsers = userRepository.GetByAll(SearchString);

        }

        private bool CanExecuteEditCommand(object obj)
        {
            //bool validUser = userRepository.RepeatNickname(User);
            //return validUser;
            return true;
        }

        private void ExecuteEditCommand(object obj)
        {
            try
            {

                userRepository.Edit(User);
                UsersRegister = userRepository.Get();
                _usersRegister = userRepository.Get();
                AddUsersView.dataGrid.ItemsSource = UsersRegister;

                MessageBox.Show("Usuario Editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteDeleteCommand(object obj)
        {
            return true;
        }

        private void ExecuteDeleteUserCommand(object obj)
        {
            try
            {
                userRepository.Remove(User);
                UsersRegister = userRepository.Get();
                AddUsersView.dataGrid.ItemsSource = UsersRegister;
                MessageBox.Show("Usuario Eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteAddUserCommand(object obj)
        {
            bool validUser; /*= userRepository.NoRepeatNickname(User);*/
            if(string.IsNullOrEmpty(User.Nickname) || User.Nickname.Length < 4 || userRepository.NoRepeatNickname(User) == false)
                validUser = false; else validUser = true;
            return validUser;
        }

        private void ExecuteAddUserCommand(object obj)
        {
            try
            {
                
                userRepository.Add(User);
                UsersRegister = userRepository.Get();
                _usersRegister = userRepository.Get();
                AddUsersView.dataGrid.ItemsSource = UsersRegister;
                
                MessageBox.Show("Usuario Agregado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrEmpty(Username) || Username.Length < 3 || 
                Password == null|| Password.Length<3)
                validData = false;
            else 
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthentificateUser(new NetworkCredential(Username,Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username),null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Nombre de usuario o contraseña invalida";
            }
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
