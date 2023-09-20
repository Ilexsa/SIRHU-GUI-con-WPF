using MaterialDesignThemes.Wpf;
using SIRHU.CustomControls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIRHU.Validations;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        public HomeView()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(TextBox), new PropertyMetadata(string.Empty));

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private void cmbEstadoCivil_KeyDown(object sender, KeyEventArgs e)
        {
            var utilidad = new Validations.ComboBoxUtility();
            utilidad.abrirCMB(cmbEstadoCivil, e);
        }

        private void cmbNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //private void mapView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
        //    // choose your provider here
        //    mapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
        //    mapView.MinZoom = 2;
        //    mapView.MaxZoom = 17;
        //    mapView.Position = new GMap.NET.PointLatLng(-2.138212840521418, -79.899110000004884);
        //    // whole world zoom
        //    mapView.Zoom = 50;
        //    // lets the map use the mousewheel to zoom
        //    mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
        //    // lets the user drag the map
        //    mapView.CanDragMap = true;
        //    // lets the user drag the map with the left mouse button
        //    mapView.DragButton = MouseButton.Left;
        //}
    }
}
