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

        private void chkDiscpacidad_Checked(object sender, RoutedEventArgs e)
        {
            AnimateControlMargin(contentGrid, new Thickness(0, 0, 0, 0));
            // Ocultar los controles gradualmente
            DoubleAnimation fadeIn = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
            txtPorcentajeDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            cmbDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            IconDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeIn);

            // Cambiar la visibilidad a Visible cuando la animación haya terminado
            fadeIn.Completed += (s, _) =>
            {
                txtPorcentajeDiscapacidad.Visibility = Visibility.Visible;
                cmbDiscapacidad.Visibility = Visibility.Visible;
                IconDiscapacidad.Visibility = Visibility.Visible;
                txtPorcentajeDiscapacidad.IsEnabled = true;
                cmbDiscapacidad.IsEnabled = true;
                IconDiscapacidad.IsEnabled = true;
            };

        }

        private void chkDiscpacidad_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateControlMargin(contentGrid, new Thickness(250, 0, 0, 0));
            DoubleAnimation fadeOut = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
            txtPorcentajeDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            cmbDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            IconDiscapacidad.BeginAnimation(UIElement.OpacityProperty, fadeOut);

            // Cambiar la visibilidad a Hidden cuando la animación haya terminado
            fadeOut.Completed += (s, _) =>
            {
                txtPorcentajeDiscapacidad.Visibility = Visibility.Hidden;
                cmbDiscapacidad.Visibility = Visibility.Hidden;
                IconDiscapacidad.Visibility = Visibility.Hidden;
                txtPorcentajeDiscapacidad.IsEnabled = false;
                cmbDiscapacidad.IsEnabled = false;
                IconDiscapacidad.IsEnabled = false;
            };
        }
        private void AnimateControlMargin(Grid grid, Thickness targetMargin)
        {
            // Crea una animación para cambiar gradualmente la propiedad Margin
            var animation = new ThicknessAnimation
            {
                To = targetMargin,
                Duration = TimeSpan.FromSeconds(0.5), // Duración de la animación (ajusta según tu preferencia)
                FillBehavior = FillBehavior.HoldEnd
            };

            // Asigna la animación a la propiedad Margin del Grid
            grid.BeginAnimation(Grid.MarginProperty, animation);
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
