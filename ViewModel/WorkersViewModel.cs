using SIRHU.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SIRHU.Models;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;

namespace SIRHU.ViewModel
{
    public class WorkersViewModel : ViewModelBase
    {
        //Fields
        private string _cedula;
        private string _nombres;
        private string _apellidos;
        private bool _discapacidad;
        private int _porcentajeDiscapacidad;
        private string _tipoDiscapacidad;
        private DateTime _fechaNacimiento;
        private int _edad;
        private string _nacionalidad;
        private string _celular;
        private string _telefono;
        private string _correo1;
        private string _correo2;
        private string _estadoCivil;
        private string _errorMessageAddWorker;
        private string _succesMessageAddWorker;



        private WorkerModel workerModel;

        private WorkerRepository _workerRepository;

        private ObservableCollection<WorkerModel> _trabajadoresRegistrados;

        private IWorkerRepository workerRepository;

        //properties
        public string ErrorMessageAddWorker
        {
            get { return _errorMessageAddWorker; } 
            set
            {
                _errorMessageAddWorker = value;
                OnPropertyChanged(nameof(ErrorMessageAddWorker));
            }
            
        }

        public string SuccesMessageAddWorker
        {
            get { return _succesMessageAddWorker; }
            set
            {
                _succesMessageAddWorker = value;
                OnPropertyChanged(nameof(SuccesMessageAddWorker));
            }

        }

        public string Cedula
        {
            get { return _cedula; }
            set
            {
                _cedula = value;
                OnPropertyChanged(nameof(Cedula));
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

        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value;
                OnPropertyChanged(nameof(Apellidos));
            }
        }

        public bool Discapacidad 
        {
            get {return _discapacidad;}
            set
            {
                _discapacidad = value;
                OnPropertyChanged(nameof(Discapacidad));
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

        public int Edad
        {
            get { return _edad; }
            set
            {
                _edad = value;
                OnPropertyChanged(nameof(Edad));
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
        
        public string Celular
        {
            get { return _celular; }
            set
            {
                _celular = value;
                OnPropertyChanged(nameof(Celular));
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public string Correo1
        {
            get { return _correo1; }
            set
            {
                _correo1 = value;
                OnPropertyChanged(nameof(Correo1));
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

        public ObservableCollection<WorkerModel> TrabajadoresRegistrados
        {
            get => _trabajadoresRegistrados;
            set
            {
                if(_trabajadoresRegistrados != value)
                {
                    _trabajadoresRegistrados = value;
                    OnPropertyChanged(nameof(TrabajadoresRegistrados));
                }
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
            try 
            { 
            workerRepository.Add(workerModel);
            TrabajadoresRegistrados = _workerRepository.Get();
            SuccesMessageAddWorker = "Trabajador grabado/modificado exitosamente";
            }catch (Exception ex)
            {
                ErrorMessageAddWorker = ex.Message;
            }
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
