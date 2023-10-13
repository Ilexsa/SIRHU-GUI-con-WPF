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

        private UserModel _user;

        private IUserRepository userRepository;

        //Properties
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

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand AddUsserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        //Constructors

        public LoginViewModel()
        {
            _user = new UserModel();
            userRepository = new UserRepository();
            AddUsserCommand = new ViewModelCommand(ExecuteAddUserCommand, CanExecuteAddUserCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand,CanExecuteDeleteCommand);
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("",""));
            UsersRegister = userRepository.Get();
        }

        private bool CanExecuteDeleteCommand(object obj)
        {
            bool validUser = userRepository.RepeatNickname(User);
            return validUser;
        }

        private void ExecuteDeleteUserCommand(object obj)
        {
            try
            {
                userRepository.Remove(User);
                UsersRegister = userRepository.Get();
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
