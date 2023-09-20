using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SIRHU.Validations
{
    public class ComboBoxUtility
    {
        public  void abrirCMB(ComboBox cmb, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!cmb.IsDropDownOpen)
                {
                    cmb.IsDropDownOpen = true;
                    e.Handled = true;
                }
                else if (cmb.HasItems)
                {
                    int selectedIndex = cmb.SelectedIndex;

                    if (selectedIndex == -1)
                    {
                        selectedIndex = 0;
                    }
                    else
                    {
                        if (e.Key == Key.Down)
                        {
                            selectedIndex = (selectedIndex + 1) % cmb.Items.Count;
                        }
                        else if (e.Key == Key.Up)
                        {
                            selectedIndex = (selectedIndex - 1 + cmb.Items.Count) % cmb.Items.Count;
                        }
                    }

                    cmb.SelectedIndex = selectedIndex;
                    e.Handled = true;
                }
            }
        }
    }
}
