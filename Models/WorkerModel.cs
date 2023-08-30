using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public class WorkerModel
    {
        public string Cedula { get; set; }
        public int IdLocalidad { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
        public float SueldoBase { get; set; }
        public bool PerDiscapacidad { get; set; }
        public string Correo { get; set; }
        public float HE25 { get; set; }
        public float HE50 { get; set; }
        public float HE100 { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaInactivo { get; set; }
        public DateTime FechaReingreso { get; set; }
        public float DT { get; set; }
        public int PorcentajeDiscapacidad { get; set; }
        public string TipoDiscapacidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumCelular { get; set; }
        public string Direccion { get; set; }
        public string ReferenciaDireccion { get; set; }
        public string LatitudD { get; set; }
        public string LongitudD { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public string Correo2 { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoRelacionLaboral { get; set; }
        public string NovedadIngreso { get; set; }
        public byte[] PdfIngreso { get; set; }
        public int IdContrato { get; set; }
        public int IdSectorial { get; set; }
        public int IdCargas { get; set; }
        public byte[] Foto { get; set; }
        public string Nacionalidad { get; set; }
        public string CargoFundasen { get; set; }
    }
}
