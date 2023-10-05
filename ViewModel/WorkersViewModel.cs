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
using System.Windows;

namespace SIRHU.ViewModel
{
    public class WorkersViewModel : ViewModelBase
    {
        //Fields
        //private string _cedula;
        //private string _nombres;
        //private string _apellidos;
        //private bool _discapacidad;
        //private int _porcentajeDiscapacidad;
        //private string _tipoDiscapacidad;
        //private DateTime _fechaNacimiento = DateTime.Now;
        //private int _edad;
        //private string _nacionalidad;
        //private string _celular;
        //private string _telefono;
        //private string _correo1;
        //private string _correo2;
        //private string _estadoCivil;
        private string _errorMessageAddWorker;
        private string _succesMessageAddWorker;

        private WorkerModel _worker;


        private ObservableCollection<WorkerModel> _trabajadoresRegistrados;

        private IWorkerRepository workerRepository;

        //properties
        public WorkerModel Worker 
        {
            get {return _worker;}
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }
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
            _worker=new WorkerModel();
            workerRepository = new WorkerRepository();
            AddWorker = new ViewModelCommand(ExecuteAddWorker, CanExecuteAddWorker);
            DeleteWorker = new ViewModelCommand(ExecuteDeleteWorker, CanExecuteDeleteWorker);
        }

        private void ExecuteDeleteWorker(object obj)
        {
            try
            {
                workerRepository.Remove(Worker);
                workerRepository.Get(Worker);
                MessageBox.Show("Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanExecuteDeleteWorker(object obj)
        {
            bool validData;

            if (string.IsNullOrEmpty(Worker.Cedula) || Worker.Cedula.Length < 10)
                validData = false;

            else validData = true;

            return validData;
        }

        private void ExecuteAddWorker(object obj)
        {
            try 
            { 
            workerRepository.Add(Worker);
            //TrabajadoresRegistrados = _workerRepository.Get();
            SuccesMessageAddWorker = "Trabajador grabado/modificado exitosamente";
            }catch (Exception ex)
            {
                ErrorMessageAddWorker = ex.Message;
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool CanExecuteAddWorker(object obj)
        {
            bool validData;

            if (string.IsNullOrEmpty(Worker.Cedula) || Worker.Cedula.Length < 10)
                validData = false;

            else validData = true;

            return validData;
        }
    }

    
}
