using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class UserModel
    {
        private string _id;
        private string _nickname ="";
        private string _name;
        private string _email;
        private string _password;
        private string _position;
        private string _lastName;

        public string Id 
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }
        public string Nickname 
        {
            get => _nickname;
            set
            {
                if (_nickname != value)
                {
                    _nickname = value;
                }
            }
        }
        public string Password 
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }
        public string Name 
        {
            get => _name;
            set
            {
                if(_password != value)
                {
                    _name = value;
                }
            }
        }
        public string LastName 
        {
            get => _lastName;
            set
            {
                if(_lastName != value)
                {
                    _lastName = value;
                }
            }
        }
        public string Position 
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                }
            }
        }
        public string Email 
        { 
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
            }
        }
    }
}
