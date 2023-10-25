using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class SucursalModel
    {
        //fields
        private int _id;
        private string _name;
        private string _address;
        private string _phone;

        public int Id 
        { 
            get => _id;
            set
            {
                if(_id != value)
                {
                    _id = value;
                }
            } 
        }
        public string Name 
        { 
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                }
            }
        }
        public string Address 
        { 
            get => _address;
            set
            {
                if(_address != value)
                {
                    _address = value;
                }
            } 
        }
        public string Phone {
            get => _phone;
            set
            {
                if(_phone != value)
                {
                    _phone = value;
                }
            } 
        }
    }
}
