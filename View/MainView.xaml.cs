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
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;
using SIRHU.ViewModel;
using MaterialDesignThemes.Wpf;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public ICommand SwitchScreenCommand { get; private set; }

        public MainView()
        {
            var mainViewModel = new MainViewModel();
            InitializeComponent();

            //Primer Submenu e Items
            var menuManteGeneral = new List<SubItem>();
            menuManteGeneral.Add(new SubItem("Empresa, establecimientos y sucursales", mainViewModel.ShowWorkersCommand));
            menuManteGeneral.Add(new SubItem("Usuarios"));
            menuManteGeneral.Add(new SubItem("Perfiles"));
            menuManteGeneral.Add(new SubItem("Asignar perfiles"));
            var item0 = new ItemMenu("Matenimiento General", menuManteGeneral, PackIconKind.Tools);
            //segundo

            var menuManteLaboral = new List<SubItem>();
            menuManteLaboral.Add(new SubItem("Tipo de contrato"));
            menuManteLaboral.Add(new SubItem("Cargo"));
            menuManteLaboral.Add(new SubItem("Sectorial iess"));
            var item1 = new ItemMenu("Matenimiento Laboral", menuManteLaboral, PackIconKind.FileSign);

            //tercero

            var menuRegistroTrabajador = new List<SubItem>();
            menuRegistroTrabajador.Add(new SubItem("Datos"));
            menuRegistroTrabajador.Add(new SubItem("Cargas familiares"));
            menuRegistroTrabajador.Add(new SubItem("Documentos adjuntos"));
            var item2 = new ItemMenu("Registro Trabajador", menuRegistroTrabajador, PackIconKind.CardAccountDetails);
            //cuarto 

            var menuNovedadesTrabajador = new List<SubItem>();
            menuNovedadesTrabajador.Add(new SubItem("Novedades de ingreso"));
            menuNovedadesTrabajador.Add(new SubItem("Novedades de egreso"));
            var item3 = new ItemMenu("Novedades del Trabajador", menuNovedadesTrabajador, PackIconKind.ClipboardTextMultiple);

            MenusButtons.Children.Add(new UserControlMenuItem(item0, this));
            MenusButtons.Children.Add(new UserControlMenuItem(item1, this));
            MenusButtons.Children.Add(new UserControlMenuItem(item2, this));
            MenusButtons.Children.Add(new UserControlMenuItem(item3, this));
        }

        [DllImport("user32.dll")]
        public static extern  IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

    }
}
