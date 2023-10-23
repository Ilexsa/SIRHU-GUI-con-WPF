using MaterialDesignThemes.Wpf;
using SIRHU.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SIRHU.Repositories
{
    public class UserRepository : Repositories.RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "InsertOrUpdateUser";
                command.Parameters.AddWithValue("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.Nickname;
                command.Parameters.AddWithValue("@Password", System.Data.SqlDbType.NVarChar).Value = userModel.Password;
                command.Parameters.AddWithValue("@Name", System.Data.SqlDbType.NVarChar).Value = userModel.Name;
                command.Parameters.AddWithValue("@LastName", System.Data.SqlDbType.NVarChar).Value = userModel.LastName;
                command.Parameters.AddWithValue("@Position", System.Data.SqlDbType.NVarChar).Value = userModel.Position;
                command.Parameters.AddWithValue("@Email", System.Data.SqlDbType.NVarChar).Value = userModel.Email;
                command.ExecuteNonQuery();
                }
            
        }

        public bool AuthentificateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where nickname=@nickname and [Password]=@password";
                command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validUser=command.ExecuteScalar() == null? false: true;
            }
                return validUser;
        }

        public void Edit(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "InsertOrUpdateUser";
                command.Parameters.AddWithValue("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.Nickname;
                command.Parameters.AddWithValue("@Password", System.Data.SqlDbType.NVarChar).Value = userModel.Password;
                command.Parameters.AddWithValue("@Name", System.Data.SqlDbType.NVarChar).Value = userModel.Name;
                command.Parameters.AddWithValue("@LastName", System.Data.SqlDbType.NVarChar).Value = userModel.LastName;
                command.Parameters.AddWithValue("@Position", System.Data.SqlDbType.NVarChar).Value = userModel.Position;
                command.Parameters.AddWithValue("@Email", System.Data.SqlDbType.NVarChar).Value = userModel.Email;
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<UserModel> Get()
        {
            ObservableCollection<UserModel> listResult = new ObservableCollection<UserModel>();
            string query = "SELECT * FROM Users";
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
                        listResult.Add(new UserModel()
                        {
                            Id = ((Guid)reader["Id"]).ToString(),
                            Name = (string)reader["Name"],
                            LastName = (string)reader["LastName"],
                            Nickname = (string)reader["nickname"],
                            Password= (string)reader["Password"],
                            Email = (string)reader["Email"],
                            Position = (string)reader["Position"],
                            
                        });
                    }
                    reader.Close();
                    connection.Close();
                }
                return listResult;
            }
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string nickname)
        {
            UserModel user=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where nickname=@nickname";
                command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = nickname;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Nickname = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public bool NoRepeatNickname(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "selectAllUsers";
                command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.Nickname;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // El lector tiene filas, por lo que retornamos false.
                        return false;
                    }
                    else
                    {
                        // El lector no tiene filas, por lo que retornamos true.
                        return true;
                    }
                }
            }
        }

        public void Remove(UserModel userModel)
        {
            using (var connection = GetConnection())
                using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection= connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText="delete from Users where nickname=@nickname";
                command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.Nickname;
                command.ExecuteNonQuery();
            }
        }

        public bool RepeatNickname(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "selectAllUsers";
                command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.Nickname;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
                }
            }
        }
    }
}
