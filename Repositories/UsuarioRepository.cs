using GestionVuelos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionVuelos.Repositories
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public void Add(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public bool AutenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using(var connection =GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Usuario where userName=@userName and password=@password";
                command.Parameters.Add("@userName", SqlDbType.VarChar).Value=credential.UserName;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value=credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetByUserName(string userName)
        {
            UsuarioModel user=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Usuario where userName=@userName";
                command.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UsuarioModel()
                        {
                            id = (int)reader[0],
                            userName = reader[1].ToString(),
                            password = String.Empty,
                            name = reader[3].ToString(),
                            lastName = reader[4].ToString(),
                            email = reader[5].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
