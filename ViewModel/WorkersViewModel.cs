using SIRHU.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SIRHU.Models;
using MaterialDesignThemes.Wpf;

namespace SIRHU.ViewModel
{
    public class WorkersViewModel : ViewModelBase
    {
        //Fields
        private string _cedula;
        private int _idLocalidad;
        private int _idDepartamento;
        private string _nombres;
        private DateTime _fechaIngreso;
        private string _cargo;
        private float _sueldoBase;
        private bool _perDiscapacidad;
        private string _correo;
        private float _hE25;
        private float _hE50;
        private float _hE100;
        private bool _estado;
        private DateTime _fechaInactivo;
        private DateTime _fechaReingreso;
        private float _dT;
        private int _porcentajeDiscapacidad;
        private string _tipoDiscapacidad;
        private DateTime _fechaNacimiento;
        private string _numCelular;
        private string _direccion;
        private string _referenciaDireccion;
        private string _latitudD;
        private string _longitudD;
        private string _telefonoConvencional;
        private string _telefonoCelular;
        private string _correo2;
        private string _estadoCivil;
        private string _tipoRelacionLaboral;
        private string _novedadIngreso;
        private byte[] _pdfIngreso;
        private int _idContrato;
        private int _idSectorial;
        private int _idCargas;
        private byte[] _foto;
        private string _nacionalidad;
        private string _cargoFundasen;

        private IWorkerRepository workerRepository;

        //properties
        public string Cedula
        {
            get { return _cedula; }
            set
            {
                _cedula = value;
                OnPropertyChanged(nameof(Cedula));
            }
        }

        public int IdLocalidad
        {
            get { return _idLocalidad; }
            set
            {
                _idLocalidad = value;
                OnPropertyChanged(nameof(IdLocalidad));
            }
        }

        public int IdDepartamento
        {
            get { return _idDepartamento; }
            set
            {
                _idDepartamento = value;
                OnPropertyChanged(nameof(IdDepartamento));
            }
        }

        public string Nombres
        {
            get { return _nombres; }
            set
            {
                _nombres = value;
                OnPropertyChanged(nameof(Nombres));
            }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set
            {
                _fechaIngreso = value;
                OnPropertyChanged(nameof(FechaIngreso));
            }
        }

        public string Cargo
        {
            get { return _cargo; }
            set
            {
                _cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }

        public float SueldoBase
        {
            get { return _sueldoBase; }
            set
            {
                _sueldoBase = value;
                OnPropertyChanged(nameof(SueldoBase));
            }
        }

        public bool PerDiscapacidad
        {
            get { return _perDiscapacidad; }
            set
            {
                _perDiscapacidad = value;
                OnPropertyChanged(nameof(PerDiscapacidad));
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                _correo = value;
                OnPropertyChanged(nameof(Correo));
            }
        }

        public float HE25
        {
            get { return _hE25; }
            set
            {
                _hE25 = value;
                OnPropertyChanged(nameof(HE25));
            }
        }

        public float HE50
        {
            get { return _hE50; }
            set
            {
                _hE50 = value;
                OnPropertyChanged(nameof(HE50));
            }
        }

        public float HE100
        {
            get { return _hE100; }
            set
            {
                _hE100 = value;
                OnPropertyChanged(nameof(HE100));
            }
        }

        public bool Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged(nameof(Estado));
            }
        }

        public DateTime FechaInactivo
        {
            get { return _fechaInactivo; }
            set
            {
                _fechaInactivo = value;
                OnPropertyChanged(nameof(FechaInactivo));
            }
        }

        public DateTime FechaReingreso
        {
            get { return _fechaReingreso; }
            set
            {
                _fechaReingreso = value;
                OnPropertyChanged(nameof(FechaReingreso));
            }
        }

        public float DT
        {
            get { return _dT; }
            set
            {
                _dT = value;
                OnPropertyChanged(nameof(DT));
            }
        }


        public int PorcentajeDiscapacidad
        {
            get { return _porcentajeDiscapacidad; }
            set
            {
                _porcentajeDiscapacidad = value;
                OnPropertyChanged(nameof(PorcentajeDiscapacidad));
            }
        }

        public string TipoDiscapacidad
        {
            get { return _tipoDiscapacidad; }
            set
            {
                _tipoDiscapacidad = value;
                OnPropertyChanged(nameof(TipoDiscapacidad));
            }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                _fechaNacimiento = value;
                OnPropertyChanged(nameof(FechaNacimiento));
            }
        }

        public string NumCelular
        {
            get { return _numCelular; }
            set
            {
                _numCelular = value;
                OnPropertyChanged(nameof(NumCelular));
            }
        }

        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        public string ReferenciaDireccion
        {
            get { return _referenciaDireccion; }
            set
            {
                _referenciaDireccion = value;
                OnPropertyChanged(nameof(ReferenciaDireccion));
            }
        }

        public string LatitudD
        {
            get { return _latitudD; }
            set
            {
                _latitudD = value;
                OnPropertyChanged(nameof(LatitudD));
            }
        }

        public string LongitudD
        {
            get { return _longitudD; }
            set
            {
                _longitudD = value;
                OnPropertyChanged(nameof(LongitudD));
            }
        }

        public string TelefonoConvencional
        {
            get { return _telefonoConvencional; }
            set
            {
                _telefonoConvencional = value;
                OnPropertyChanged(nameof(TelefonoConvencional));
            }
        }

        public string TelefonoCelular
        {
            get { return _telefonoCelular; }
            set
            {
                _telefonoCelular = value;
                OnPropertyChanged(nameof(TelefonoCelular));
            }
        }

        public string Correo2
        {
            get { return _correo2; }
            set
            {
                _correo2 = value;
                OnPropertyChanged(nameof(Correo2));
            }
        }

        public string EstadoCivil
        {
            get { return _estadoCivil; }
            set
            {
                _estadoCivil = value;
                OnPropertyChanged(nameof(EstadoCivil));
            }
        }

        public string TipoRelacionLaboral
        {
            get { return _tipoRelacionLaboral; }
            set
            {
                _tipoRelacionLaboral = value;
                OnPropertyChanged(nameof(TipoRelacionLaboral));
            }
        }

        public string NovedadIngreso
        {
            get { return _novedadIngreso; }
            set
            {
                _novedadIngreso = value;
                OnPropertyChanged(nameof(NovedadIngreso));
            }
        }

        public byte[] PdfIngreso
        {
            get { return _pdfIngreso; }
            set
            {
                _pdfIngreso = value;
                OnPropertyChanged(nameof(PdfIngreso));
            }
        }

        public int IdContrato
        {
            get { return _idContrato; }
            set
            {
                _idContrato = value;
                OnPropertyChanged(nameof(IdContrato));
            }
        }

        public int IdSectorial
        {
            get { return _idSectorial; }
            set
            {
                _idSectorial = value;
                OnPropertyChanged(nameof(IdSectorial));
            }
        }

        public int IdCargas
        {
            get { return _idCargas; }
            set
            {
                _idCargas = value;
                OnPropertyChanged(nameof(IdCargas));
            }
        }

        public byte[] Foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
                OnPropertyChanged(nameof(Foto));
            }
        }

        public string Nacionalidad
        {
            get { return _nacionalidad; }
            set
            {
                _nacionalidad = value;
                OnPropertyChanged(nameof(Nacionalidad));
            }
        }

        public string CargoFundasen
        {
            get { return _cargoFundasen; }
            set
            {
                _cargoFundasen = value;
                OnPropertyChanged(nameof(CargoFundasen));
            }
        }

        // Commands

        public ICommand AddWorker { get; }
        public ICommand DeleteWorker { get; }

        public WorkersViewModel()
        {
            workerRepository = new WorkerRepository();
            AddWorker = new ViewModelCommand(ExecuteAddWorker, CanExecuteAddWorker);
            DeleteWorker = new ViewModelCommand(ExecuteDeleteWorker, CanExecuteDeleteWorker);
        }

        private void ExecuteDeleteWorker(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteDeleteWorker(object obj)
        {
            bool validData;

            if (string.IsNullOrEmpty(Cedula) || Cedula.Length < 10)
                validData = false;

            else validData = true;

            return validData;
        }

        private void ExecuteAddWorker(object obj)
        {
            workerRepository.Add(new WorkerModel()); ;
        }

        private bool CanExecuteAddWorker(object obj)
        {
            bool validData;

            if (string.IsNullOrEmpty(Cedula) || Cedula.Length < 10)
                validData = false;

            else validData = true;

            return validData;
        }
    }

    
}
