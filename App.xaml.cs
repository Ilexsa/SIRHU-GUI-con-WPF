using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SIRHU.View;

namespace SIRHU
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            //var mainView = new MainView();
            //mainView.Show();
            var frmLoginView = new frmLoginView();
            frmLoginView.Show();
            frmLoginView.IsVisibleChanged += (s, ev) =>
            {
                if (frmLoginView.IsVisible == false && frmLoginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    frmLoginView.Close();
                }
            };
        }
    }
}
