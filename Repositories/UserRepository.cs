﻿using MaterialDesignThemes.Wpf;
using SIRHU.Models;
using System;
using System.Collections.Generic;
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
                    command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Users (nickname, Password, Name, LastName, Position, Email) values (@nickname, @Password, @Name, @LastName, @Position, @Email)";
                command.Parameters.AddWithValue("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
                command.Parameters.AddWithValue("@Password", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
                command.Parameters.AddWithValue("@Name", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
                command.Parameters.AddWithValue("@LastName", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
                command.Parameters.AddWithValue("@Position", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
                command.Parameters.AddWithValue("@Email", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
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
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
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
                            nickname = reader[1].ToString(),
                            //Password = .Empty,
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
            using (var command = new SqlCommand()) {
                connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from [Users] where nickname = @nickname";
            command.Parameters.Add("@nickname", System.Data.SqlDbType.NVarChar).Value = userModel.nickname;
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
