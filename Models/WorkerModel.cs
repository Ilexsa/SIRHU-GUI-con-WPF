using GMap.NET.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class WorkerModel
    {

        //fields Worker
        private string _cedula;
        private string _nombres;
        private string _apellidos;
        private bool _discapacidad;
        private int _porcentajeDiscapacidad;
        private string _tipoDiscapacidad;
        private DateTime _fechaNacimiento = DateTime.Now;
        private int _edad;
        private string _nacionalidad;
        private string _celular;
        private string _telefono;
        private string _correo1;
        private string _correo2;
        private string _estadoCivil;


        //fields Domicilio
        private string _direccion;
        private string _referencias;
        private string _latitud;
        private string _longitud;

        //fields Data Fundasen
        private string _cargo;
        private string _cargoFundasen;
        private int _sectorial;
        private decimal _sueldo;
        private decimal _horaExtra25;
        private decimal _horaExtra50;
        private decimal _horaExtra100;
        private string _tipoRelacionLaboral;
        private string _novedadIngreso;




        public string Cedula 
        { 
            get => _cedula;
            set 
            {
                if(_cedula != value)
                {
                    _cedula = value;
                } 
            } 
        }
        public string Nombres 
        { 
            get => _nombres;
            set
            {
                if (_nombres != value)
                {
                    _nombres = value;
                }
            }
        }
        public string Apellidos 
        { 
            get => _apellidos;
            set
            {
                if (_apellidos != value)
                {
                    _apellidos = value;
                }
            }
        }
        public bool Discapacidad 
        { 
            get => _discapacidad;
            set
            {
                if (_discapacidad != value)
                {
                    _discapacidad = value;
                }
            }
        }
        public int PorcentajeDiscapacidad 
        { 
            get => _porcentajeDiscapacidad;
            set
            {
                if (_porcentajeDiscapacidad != value)
                {
                    _porcentajeDiscapacidad = value;
                }
            }
        }
        public string TipoDiscapacidad 
        { 
            get => _tipoDiscapacidad;
            set
            {
                if (_tipoDiscapacidad != value)
                {
                    _tipoDiscapacidad = value;
                }
            }
        }
        public DateTime FechaNacimiento 
        { 
            get => _fechaNacimiento;
            set
            {
                if (_fechaNacimiento != value)
                {
                    _fechaNacimiento = value;
                }
            }
        }
        public int Edad 
        { get => _edad;
            set
            {
                if (_edad != value)
                {
                    _edad = value;
                }
            }
        }
        public string Nacionalidad 
        { 
            get => _nacionalidad;
            set
            {
                if (_nacionalidad != value)
                {
                    _nacionalidad = value;
                }
            }
        }
        public string Celular 
        { 
            get => _celular;
            set
            {
                if (_celular != value)
                {
                    _celular = value;
                }
            }
        }
        public string Telefono 
        { 
            get => _telefono;
            set
            {
                if (_telefono != value)
                {
                    _telefono = value;
                }
            }
        }
        public string Correo1 
        { 
            get => _correo1;
            set
            {
                if (_correo1 != value)
                {
                    _correo1 = value;
                }
            }
        }
        public string Correo2 
        { 
            get => _correo2;
            set
            {
                if (_correo2 != value)
                {
                    _correo2 = value;
                }
            }
        }
        public string EstadoCivil 
        { 
            get => _estadoCivil;
            set
            {
                if (_estadoCivil != value)
                {
                    _estadoCivil = value;
                }
            }
        }
        //Domicilio
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Referencias { get => _referencias; set => _referencias = value; }
        public string Latitud { get => _latitud; set => _latitud = value; }
        public string Longitud { get => _longitud; set => _longitud = value; }

        //DataFundasen

        public string Cargo { get => _cargo; set => _cargo = value; }
        public string CargoFundasen { get => _cargoFundasen; set => _cargoFundasen = value; }
        public int Sectorial { get => _sectorial; set => _sectorial = value; }
        public decimal Sueldo { get => _sueldo; set => _sueldo = value; }
        public decimal HoraExtra25 { get => _horaExtra25; set => _horaExtra25 = value; }
        public decimal HoraExtra50 { get => _horaExtra50; set => _horaExtra50 = value; }
        public decimal HoraExtra100 { get => _horaExtra100; set => _horaExtra100 = value; }
        public string TipoRelacionLaboral { get => _tipoRelacionLaboral; set => _tipoRelacionLaboral = value; }
        public string NovedadIngreso { get => _novedadIngreso; set => _novedadIngreso = value; }
    }
}
