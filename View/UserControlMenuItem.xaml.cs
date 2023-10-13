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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        MainView _context;

        public UserControlMenuItem(ItemMenu itemMenu, MainView context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
            var listView = (ListView)sender;
            var selectedSubItem = (SubItem)listView.SelectedItem;
            

            if (selectedSubItem != null)
            {
                // Aquí realizas la acción deseada al seleccionar un elemento,
                // por ejemplo, cambiar la vista principal.
                _context.SwitchScreen(selectedSubItem.Screen);

                // Deseleccionar el elemento
                listView.SelectedItem = null;
            }
        }
    }
}
