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
        public void Add(WorkerModel worker)
        {

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open(); ;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "InsertOrUpdateTrabajador";
                command.Parameters.Add("@CEDULA", System.Data.SqlDbType.VarChar).Value = worker.Cedula;
                command.Parameters.Add("@NOMBRES", System.Data.SqlDbType.NVarChar).Value = worker.Nombres;
                command.Parameters.Add("@APELLIDOS", System.Data.SqlDbType.NVarChar).Value = worker.Apellidos;
                command.Parameters.Add("@DISCAPACIDAD", System.Data.SqlDbType.Bit).Value = worker.Discapacidad;
                command.Parameters.Add("@PORCENTAJE_DISCAPACIDAD", System.Data.SqlDbType.Int).Value = worker.PorcentajeDiscapacidad;
                command.Parameters.Add("@TIPO_DISCAPACIDAD", System.Data.SqlDbType.NVarChar).Value = worker.TipoDiscapacidad;
                command.Parameters.Add("@FECHA_NACIMIENTO", System.Data.SqlDbType.Date).Value = worker.FechaNacimiento;
                command.Parameters.Add("@EDAD", System.Data.SqlDbType.Int).Value = worker.Edad;
                command.Parameters.Add("@NACIONALIDAD", System.Data.SqlDbType.NVarChar).Value = worker.Nacionalidad;
                command.Parameters.Add("@CELULAR", System.Data.SqlDbType.VarChar).Value = worker.Celular;
                command.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar).Value = worker.Telefono;
                command.Parameters.Add("@CORREO1", System.Data.SqlDbType.NVarChar).Value = worker.Correo1;
                command.Parameters.Add("@CORREO2", System.Data.SqlDbType.NVarChar).Value = worker.Correo2;
                command.Parameters.Add("@ESTADO_CIVIL", System.Data.SqlDbType.NVarChar).Value = worker.EstadoCivil;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(WorkersViewModel workerModel)
        {

        }

        public ObservableCollection<WorkerModel> Get(WorkerModel workerModel)
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
                            PorcentajeDiscapacidad = (string)reader["PORCENTAJE_DISCAPACIDAD"],
                            TipoDiscapacidad = (string)reader["TIPO_DISCAPACIDAD"],
                            FechaNacimiento = (DateTime)reader["FECHA_NACIMIENTO"],
                            Edad = (string)reader["EDAD"],
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

        public void Remove(WorkerModel worker)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM TRABAJADOR WHERE CEDULA = @CEDULA";
                command.Parameters.Add("@CEDULA", System.Data.SqlDbType.VarChar).Value = worker.Cedula;
                command.ExecuteNonQuery();
            }
        }


        internal ObservableCollection<WorkerModel> Get()
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
                            PorcentajeDiscapacidad = (string)reader["PORCENTAJE_DISCAPACIDAD"],
                            TipoDiscapacidad = (string)reader["TIPO_DISCAPACIDAD"],
                            FechaNacimiento = (DateTime)reader["FECHA_NACIMIENTO"],
                            Edad = (string)reader["EDAD"],
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