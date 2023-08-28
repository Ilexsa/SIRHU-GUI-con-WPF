using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SIRHU.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, ICommand command = null)
        {
            Name = name;
            Command = command;

        }

        public string Name { get; private set; }
        public ICommand Command { get; private set;}
    }
}
