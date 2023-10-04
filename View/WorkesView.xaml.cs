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
using System.Globalization;
using System.Data.SqlClient;
using SIRHU.Repositories;
using System.Windows.Markup;
using System.Data;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Org.BouncyCastle.Crmf;

namespace SIRHU.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //GMapMarker marker = new GMapMarker(new PointLatLng(##, ##));
        //marker.Shape = new PinControl();
        //gmap.Markers.Add(marker);


        public HomeView()
        {
            InitializeComponent();
            cmbEstadoCivil.SelectedIndex = 0;
            cmbNacionalidad.SelectedIndex = 0;
            cmbDiscapacidad.SelectedIndex = 0;
            //txtCedula.Text = string.Empty;
            
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
            var utilidad = new Validations.ComboBoxUtility();
            utilidad.abrirCMB(cmbNacionalidad, e);
        }

        private void chkDiscpacidad_Checked(object sender, RoutedEventArgs e)
        {
            AnimateControlMargin(contentGrid, new Thickness(0, 0, 0, 0));
            // Ocultar los controles gradualmente
            AnimateVisibility(txtPorcentajeDiscapacidad, Visibility.Visible);
            AnimateVisibility(cmbDiscapacidad, Visibility.Visible);

        }

        private void chkDiscpacidad_Unchecked(object sender, RoutedEventArgs e)
        {
            AnimateControlMargin(contentGrid, new Thickness(250, 0, 0, 0));

            
            AnimateVisibility(txtPorcentajeDiscapacidad, Visibility.Hidden);
            AnimateVisibility(cmbDiscapacidad, Visibility.Hidden);
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

        private void AnimateVisibility(UIElement element, Visibility visibility)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                To = (visibility == Visibility.Visible) ? 1 : 0,
                Duration = TimeSpan.FromSeconds(1)
            };

            element.Visibility = visibility;
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void txtNombres_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            utilidad.mayusAutos(txtNombres);
        }

        private void txtApellidos_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            utilidad.mayusAutos(txtApellidos);
        }

        private void txtCelular_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            utilidad.mayusAutos(txtCelular);
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            
        }

        private void txtCorreo1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            utilidad.minusAutos(txtCorreo1);
        }

        private void txtCorreo2_TextChanged(object sender, TextChangedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            utilidad.minusAutos(txtCorreo2);
        }

        private void txtCorreo1_LostFocus(object sender, RoutedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            if (utilidad.validarCorreo(txtCorreo1.Text) == false)
            {
                MessageBox.Show("Por favor ingrese un correo electronico valido", "Error");
            }

        }

        private void txtCorreo2_LostFocus(object sender, RoutedEventArgs e)
        {
            var utilidad = new Validations.TextBoxValidationsUtilitys();
            if (utilidad.validarCorreo(txtCorreo2.Text) == false)
            {
                MessageBox.Show("Por favor ingrese un correo electronico valido", "Error");
            }
        }

        private void txtEdad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void dtpFechaNacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpFechaNacimiento.SelectedDate.HasValue)
            {
                DateTime selectedDate = dtpFechaNacimiento.SelectedDate.Value;
                string formattedDate = selectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                dtpFechaNacimiento.Text = formattedDate;
            }

            DateTime nacimiento = dtpFechaNacimiento.SelectedDate.Value; //Fecha de nacimiento

            if (nacimiento <= DateTime.Now)
            {
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                string edadcadena = edad.ToString();
                txtCedula.Text = edadcadena;
            }
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            //double Latinicial = -2.138212840521418;
            //double Lnginicial = -79.899110000004884;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            mapView.Position = new GMap.NET.PointLatLng(-2.138212840521418, -79.899110000004884);
            // whole world zoom
            mapView.Zoom = 50;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            //mapView.DragButton = MouseButton.Left;
            //markerOverlay = new GMapOverlay("Marcador");
            //marker = new GMarkerGoogle(new PointLatLng(Latinicial, Lnginicial), GMarkerGoogleType.green);
            //markerOverlay.Markers.Add(marker);

            //marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format("Ubicacion: \n Latitud:{0} \n Longitud:{1}", Latinicial, Lnginicial);

        }


        private void ValidarNumero(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Solo permitir números y punto decimal
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }

            // Validar solo un punto decimal
            if (e.Text == "." && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ValidarTexto(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Validar que solo se ingresen letras y admitir espacio
            if (!char.IsLetter(e.Text, 0) && e.Text != " " && !char.IsControl(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ValidarSoloNumeroYpunto(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Solo permitir números y punto decimal
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }

            // Validar solo un punto decimal
            if (e.Text == "." && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtNombres_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void txtApellidos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void txtCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void txtCelular_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtCedula_LostFocus(object sender, RoutedEventArgs e)
        {
            var validacion = new Validations.TextBoxValidationsUtilitys();

            bool resultado = validacion.P_Valida_Cedula(txtCedula.Text);
                
            if ( chkPasaporte.IsChecked == false) { 
                if (resultado == false )
                {
                    MessageBox.Show("Error", "Cedula no valida");
                }
                else
                {
                    MessageBox.Show("Success", "Cedula valida");
                }
            } 
        }
       
        
        private void AgregarTrabajadorDB()
        {
            using (SqlConnection cone = new SqlConnection("Data Source = 10.0.0.206; Initial Catalog = ROLES; User ID = sa; Password ="))
            {
                cone.Open();
                using (SqlCommand cmd = new SqlCommand("InsertOrUpdateTrabajador", cone))
                {
                    int edad = Convert.ToInt32(txtEdad.Text);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CEDULA", txtCedula.Text);
                    cmd.Parameters.AddWithValue("@NOMBRES", txtNombres.Text);
                    cmd.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text);
                    cmd.Parameters.AddWithValue("@DISCAPACIDAD", chkDiscpacidad.IsChecked == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@PORCENTAJE_DISCAPACIDAD", edad);
                    cmd.Parameters.AddWithValue("@TIPO_DISCAPACIDAD", (cmbDiscapacidad.SelectedItem as ComboBoxItem)?.Content.ToString());
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", Convert.ToDateTime(dtpFechaNacimiento.SelectedDate));
                    cmd.Parameters.AddWithValue("@EDAD", edad);
                    cmd.Parameters.AddWithValue("@NACIONALIDAD", (cmbNacionalidad.SelectedItem as ComboBoxItem)?.Content.ToString());
                    cmd.Parameters.AddWithValue("@CELULAR", txtCelular.Text);
                    cmd.Parameters.AddWithValue("@TELEFONO", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@CORREO1", txtCorreo1.Text);
                    cmd.Parameters.AddWithValue("@CORREO2", txtCorreo2.Text);
                    cmd.Parameters.AddWithValue("@ESTADO_CIVIL", (cmbEstadoCivil.SelectedItem as ComboBoxItem)?.Content.ToString());

                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void AgregarDomicilioDB()
        {
            using (SqlConnection cone = new SqlConnection("Data Source = 10.0.0.206; Initial Catalog = ROLES; User ID = sa; Password ="))
            {
                cone.Open();
                using (SqlCommand cmd = new SqlCommand("InsertOrUpdateDomicilio", cone))
                {
                    int edad = Convert.ToInt32(txtEdad.Text);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CEDULA", txtCedula.Text);
                    cmd.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@REFERENCIAS", txtReferencias.Text);
                    cmd.Parameters.AddWithValue("@LATITUD", chkDiscpacidad.IsChecked == true ? 1 : 0);
                    cmd.Parameters.AddWithValue("@LONGITUD", edad);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void mapView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            

        }

        private void btnGuardarDomicilio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
