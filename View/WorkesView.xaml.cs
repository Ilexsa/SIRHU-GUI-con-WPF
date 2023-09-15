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
