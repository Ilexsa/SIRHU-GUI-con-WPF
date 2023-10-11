using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class CompanyModel
    {

        //fields company
        private string _ruc;
        private string _nombreCompany;
        private string _direccion;
        private string _correo;
        private string _tipoCompañia;
        private string _razonComercial;
        private string _pagina;
        private string _representanteLegal;

        //fields sucursales

        private int _idSucursal;
        private string _nombreSucursal;
        private string _direccionSucursal;
        private string _telefonoSucursal;

        //field departamento

        private int _idDepartamento;
        private string _nombreDepartamento;
        private string _jefeDepartamento;



        // Properties for Company
        public string Ruc
        {
            get => _ruc;
            set
            {
                if (_ruc != value)
                {
                    _ruc = value;
                }
            }
        }

        public string NombreCompany
        {
            get => _nombreCompany;
            set
            {
                if (_nombreCompany != value)
                {
                    _nombreCompany = value;
                }
            }
        }

        public string Direccion
        {
            get => _direccion;
            set
            {
                if (_direccion != value)
                {
                    _direccion = value;
                }
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                if (_correo != value)
                {
                    _correo = value;
                }
            }
        }

        public string TipoCompañia
        {
            get => _tipoCompañia;
            set
            {
                if (_tipoCompañia != value)
                {
                    _tipoCompañia = value;
                }
            }
        }

        public string RazonComercial
        {
            get => _razonComercial;
            set
            {
                if (_razonComercial != value)
                {
                    _razonComercial = value;
                }
            }
        }

        public string Pagina
        {
            get => _pagina;
            set
            {
                if (_pagina != value)
                {
                    _pagina = value;
                }
            }
        }

        public string RepresentanteLegal
        {
            get => _representanteLegal;
            set
            {
                if (_representanteLegal != value)
                {
                    _representanteLegal = value;
                }
            }
        }

        // Properties for Branches (Sucursales)
        public int IdSucursal
        {
            get => _idSucursal;
            set
            {
                if (_idSucursal != value)
                {
                    _idSucursal = value;
                }
            }
        }

        public string NombreSucursal
        {
            get => _nombreSucursal;
            set
            {
                if (_nombreSucursal != value)
                {
                    _nombreSucursal = value;
                }
            }
        }

        public string DireccionSucursal
        {
            get => _direccionSucursal;
            set
            {
                if (_direccionSucursal != value)
                {
                    _direccionSucursal = value;
                }
            }
        }

        public string TelefonoSucursal
        {
            get => _telefonoSucursal;
            set
            {
                if (_telefonoSucursal != value)
                {
                    _telefonoSucursal = value;
                }
            }
        }

        // Properties for Departments (Departamento)
        public int IdDepartamento
        {
            get => _idDepartamento;
            set
            {
                if (_idDepartamento != value)
                {
                    _idDepartamento = value;
                }
            }
        }

        public string NombreDepartamento
        {
            get => _nombreDepartamento;
            set
            {
                if (_nombreDepartamento != value)
                {
                    _nombreDepartamento = value;
                }
            }
        }

        public string JefeDepartamento
        {
            get => _jefeDepartamento;
            set
            {
                if (_jefeDepartamento != value)
                {
                    _jefeDepartamento = value;
                }
            }
        }
    }
}
