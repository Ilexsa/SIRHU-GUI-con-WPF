using SIRHU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SIRHU.ViewModel;

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
                command.CommandText = "InsertOrUpdateTrabajador";
                command.Parameters.Add("@CEDULA", System.Data.SqlDbType.VarChar).Value = workerModel.Cedula;
                command.Parameters.Add("@NOMBRES", System.Data.SqlDbType.NVarChar).Value = workerModel.Nombres;
                command.Parameters.Add("@NOMBRES", System.Data.SqlDbType.NVarChar).Value = workerModel.Apellidos;
                command.Parameters.Add("@DISCAPACIDAD", System.Data.SqlDbType.Bit).Value = workerModel.Discapacidad;
                command.Parameters.Add("@PORCENTAJE_DISCAPACIDAD", System.Data.SqlDbType.Int).Value = workerModel.PorcentajeDiscapacidad;
                command.Parameters.Add("@TIPO_DISCAPACIDAD", System.Data.SqlDbType.NVarChar).Value = workerModel.TipoDiscapacidad;
                command.Parameters.Add("@EDAD", System.Data.SqlDbType.Int).Value = workerModel.Edad;
                command.Parameters.Add("@NACIONALIDAD", System.Data.SqlDbType.NVarChar).Value = workerModel.Nacionalidad;
                command.Parameters.Add("@CELULAR", System.Data.SqlDbType.VarChar).Value = workerModel.Celular;
                command.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar).Value = workerModel.Telefono;
                command.Parameters.Add("@CORREO1", System.Data.SqlDbType.NVarChar).Value = workerModel.Correo1;
                command.Parameters.Add("@CORREO2", System.Data.SqlDbType.NVarChar).Value = workerModel.Correo2;
                command.Parameters.Add("@ESTADO_CIVIL", System.Data.SqlDbType.NVarChar).Value = workerModel.EstadoCivil;
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
                command.CommandText = "DELETE FROM TRABAJADOR WHERE CEDULA = @CEDULA";
                command.Parameters.Add("@CEDULA", System.Data.SqlDbType.VarChar).Value = cedula;
            }
        }

        internal ObservableCollection <WorkerModel> Get()
        {
            ObservableCollection<WorkerModel> listResult = new ObservableCollection<WorkerModel>();
            string query = "SELECT * FROM TRABAJADOR";
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listResult.Add(new WorkerModel()
                        {
                            Cedula = (string)reader["CEDULA"],
                            Nombres = (string)reader["NOMBRES"],
                            Apellidos = (string)reader["APELLIDOS"],
                            Discapacidad = (bool)reader["DISCAPACIDA"],
                            PorcentajeDiscapacidad = (int)reader["PORCENTAJE_DISCAPACIDAD"],
                            TipoDiscapacidad = (string)reader["TIPO_DISCAPACIDAD"],
                            FechaNacimiento = (DateTime)reader["FECHA_NACIMIENTO"],
                            Edad = (int)reader["EDAD"],
                            Nacionalidad = (string)reader["NACIONALIDAD"],
                            Celular = (string)reader["CELULAR"],
                            Telefono = (string)reader["TELEFONO"],
                            Correo1 = (string)reader["CORREO1"],
                            Correo2 = (string)reader["CORREO2"],
                            EstadoCivil = (string)reader["ESTADO_CIVIL"]
                        });
                    }
                    reader.Close();
                    connection.Close();
                }
                return listResult;
            }
        }
    }
}
