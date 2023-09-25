using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class WorkerModel
    {
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
                if (_nombres != value)
                {
                    _nombres = value;
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


        //public string Cedula { get; set; }
        //public int IdLocalidad { get; set; }
        //public int IdDepartamento { get; set; }
        //public string Nombres { get; set; }
        //public DateTime FechaIngreso { get; set; }
        //public string Cargo { get; set; }
        //public float SueldoBase { get; set; }
        //public bool PerDiscapacidad { get; set; }
        //public string Correo { get; set; }
        //public float HE25 { get; set; }
        //public float HE50 { get; set; }
        //public float HE100 { get; set; }
        //public bool Estado { get; set; }
        //public DateTime FechaInactivo { get; set; }
        //public DateTime FechaReingreso { get; set; }
        //public float DT { get; set; }
        //public int PorcentajeDiscapacidad { get; set; }
        //public string TipoDiscapacidad { get; set; }
        //public DateTime FechaNacimiento { get; set; }
        //public string NumCelular { get; set; }
        //public string Direccion { get; set; }
        //public string ReferenciaDireccion { get; set; }
        //public string LatitudD { get; set; }
        //public string LongitudD { get; set; }
        //public string TelefonoConvencional { get; set; }
        //public string TelefonoCelular { get; set; }
        //public string Correo2 { get; set; }
        //public string EstadoCivil { get; set; }
        //public string TipoRelacionLaboral { get; set; }
        //public string NovedadIngreso { get; set; }
        //public byte[] PdfIngreso { get; set; }
        //public int IdContrato { get; set; }
        //public int IdSectorial { get; set; }
        //public int IdCargas { get; set; }
        //public byte[] Foto { get; set; }
        //public string Nacionalidad { get; set; }
        //public string CargoFundasen { get; set; }
    }
}
