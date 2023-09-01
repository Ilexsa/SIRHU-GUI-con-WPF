using SIRHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace SIRHU.Repositories
{
    public class WorkerRepository : Repositories.RepositoryBase, IWorkerRepository
    {
        public void Add(WorkerModel workerModel)
        {
            using (var connection = GetConnection())
                using (var command = new SqlCommand())
            {
                connection.Open(); ;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_SubirTrabajadores";
                command.Parameters.Add("@CEDULA",System.Data.SqlDbType.VarChar).Value=workerModel.Cedula;
                command.Parameters.Add("@IdLocalidad", System.Data.SqlDbType.Int).Value = workerModel.IdLocalidad;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = workerModel.IdDepartamento;
                command.Parameters.Add("@NOMBRES", System.Data.SqlDbType.VarChar).Value = workerModel.Nombres;
                command.Parameters.Add("@FECHA_INGRESO", System.Data.SqlDbType.Date).Value = workerModel.FechaIngreso;
                command.Parameters.Add("@CARGO", System.Data.SqlDbType.VarChar).Value = workerModel.Cargo;
                command.Parameters.Add("@SUELDO_BASE", System.Data.SqlDbType.Float).Value = workerModel.SueldoBase;
                command.Parameters.Add("@NACIONALIDAD", System.Data.SqlDbType.VarChar).Value = workerModel.Nacionalidad;
                command.Parameters.Add("@CORREO", System.Data.SqlDbType.NVarChar).Value = workerModel.Correo;
                command.Parameters.Add("@H_E25", System.Data.SqlDbType.Float).Value = workerModel.HE25;
                command.Parameters.Add("@H_E50", System.Data.SqlDbType.Float).Value = workerModel.HE50;
                command.Parameters.Add("@H_E100", System.Data.SqlDbType.Float).Value = workerModel.HE100;
                command.Parameters.Add("@FECHA_INACTIVO", System.Data.SqlDbType.Date).Value = workerModel.FechaInactivo;
                command.Parameters.Add("@FECHA_REINGRESO", System.Data.SqlDbType.Date).Value = workerModel.FechaReingreso;
                command.Parameters.Add("@DT", System.Data.SqlDbType.NVarChar).Value = workerModel.DT;
                command.Parameters.Add("@FECHA_NACIMIENTO", System.Data.SqlDbType.Date).Value = workerModel.FechaNacimiento;
                command.Parameters.Add("@DIRECCION", System.Data.SqlDbType.NVarChar).Value = workerModel.Direccion;
                command.Parameters.Add("@REFERENCIA_DIRECCION", System.Data.SqlDbType.NVarChar).Value = workerModel.ReferenciaDireccion;
                command.Parameters.Add("@TELEFONO_CONVENCIONAL", System.Data.SqlDbType.NVarChar).Value = workerModel.TelefonoConvencional;
                command.Parameters.Add("@TELEFONO_CELULAR", System.Data.SqlDbType.NVarChar).Value = workerModel.TelefonoCelular;
                command.Parameters.Add("@CORREO2", System.Data.SqlDbType.NVarChar).Value = workerModel.Correo2;
                command.Parameters.Add("@ESTADO_CIVIL", System.Data.SqlDbType.Int).Value = workerModel.EstadoCivil;
                command.Parameters.Add("@TIPO_RELACION_LABORAL", System.Data.SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@NOVEDAD_INGRESO", System.Data.SqlDbType.Int).Value = DBNull.Value;
                command.Parameters.Add("@PDF_INGRESO", System.Data.SqlDbType.VarBinary).Value = workerModel.PdfIngreso;
                command.Parameters.Add("@ID_CONTRATO", System.Data.SqlDbType.Int).Value = workerModel.IdContrato;
                command.Parameters.Add("@ID_SECTORIAL", System.Data.SqlDbType.Int).Value = workerModel.IdSectorial;
                command.Parameters.Add("@FOTO", System.Data.SqlDbType.Image).Value = workerModel.Foto;
                command.Parameters.Add("@CARGO_F", System.Data.SqlDbType.NVarChar).Value = workerModel;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(WorkerModel workerModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkerModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public WorkerModel GetById(string cedula)
        {
            throw new NotImplementedException();
        }

        public WorkerModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(string cedula)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM TRABAJADORES WHERE CEDULA = @CEDULA";
                command.Parameters.Add("@CEDULA", System.Data.SqlDbType.VarChar).Value = cedula;
            }
        }
    }
}
