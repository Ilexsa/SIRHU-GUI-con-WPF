using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Controls;

namespace SIRHU.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, System.Windows.Controls.UserControl screen = null)
        {
            Name = name;
            Screen = screen;

        }

        public string Name { get; private set; }
        public System.Windows.Controls.UserControl Screen { get; private set; }
    }
}
