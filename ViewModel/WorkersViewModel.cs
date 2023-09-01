using SIRHU.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SIRHU.Models;

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
        public string Cedula { get => _cedula; set => _cedula = value; }
        public int IdLocalidad { get => _idLocalidad; set => _idLocalidad = value; }
        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }
        public float SueldoBase { get => _sueldoBase; set => _sueldoBase = value; }
        public bool PerDiscapacidad { get => _perDiscapacidad; set => _perDiscapacidad = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public float HE25 { get => _hE25; set => _hE25 = value; }
        public float HE50 { get => _hE50; set => _hE50 = value; }
        public float HE100 { get => _hE100; set => _hE100 = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public DateTime FechaInactivo { get => _fechaInactivo; set => _fechaInactivo = value; }
        public DateTime FechaReingreso { get => _fechaReingreso; set => _fechaReingreso = value; }
        public float DT { get => _dT; set => _dT = value; }
        public int PorcentajeDiscapacidad { get => _porcentajeDiscapacidad; set => _porcentajeDiscapacidad = value; }
        public string TipoDiscapacidad { get => _tipoDiscapacidad; set => _tipoDiscapacidad = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string NumCelular { get => _numCelular; set => _numCelular = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string ReferenciaDireccion { get => _referenciaDireccion; set => _referenciaDireccion = value; }
        public string LatitudD { get => _latitudD; set => _latitudD = value; }
        public string LongitudD { get => _longitudD; set => _longitudD = value; }
        public string TelefonoConvencional { get => _telefonoConvencional; set => _telefonoConvencional = value; }
        public string TelefonoCelular { get => _telefonoCelular; set => _telefonoCelular = value; }
        public string Correo2 { get => _correo2; set => _correo2 = value; }
        public string EstadoCivil { get => _estadoCivil; set => _estadoCivil = value; }
        public string TipoRelacionLaboral { get => _tipoRelacionLaboral; set => _tipoRelacionLaboral = value; }
        public string NovedadIngreso { get => _novedadIngreso; set => _novedadIngreso = value; }
        public byte[] PdfIngreso { get => _pdfIngreso; set => _pdfIngreso = value; }
        public int IdContrato { get => _idContrato; set => _idContrato = value; }
        public int IdSectorial { get => _idSectorial; set => _idSectorial = value; }
        public int IdCargas { get => _idCargas; set => _idCargas = value; }
        public byte[] Foto { get => _foto; set => _foto = value; }
        public string Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        public string CargoFundasen { get => _cargoFundasen; set => _cargoFundasen = value; }
        
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
            var isValidCedula = workerRepository.Add(new WorkerModel(Cedula, IdLocalidad,IdDepartamento, Nombres, FechaIngreso, fe ) );
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
