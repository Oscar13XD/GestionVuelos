using GestionVuelos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionVuelos.Repositories
{
    public class VuelosRepository : RepositoryBase, IVuelosRepository
    {
        public bool Add(VuelosModel vuelosModel)
        {
            bool result;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into vuelos values (@ciudadOrigen, @ciudadDestino, @fecha, @horaSalida, @horaLlegada, @numeroVuelo, @aerolinea, @estadoVuelo)";
                command.Parameters.Add("@ciudadOrigen", SqlDbType.VarChar).Value = vuelosModel.ciudadOrigen;
                command.Parameters.Add("@ciudadDestino", SqlDbType.VarChar).Value = vuelosModel.ciudadDestino;
                command.Parameters.Add("@fecha", SqlDbType.DateTime).Value = vuelosModel.fecha;
                command.Parameters.Add("@horaSalida", SqlDbType.Time).Value = vuelosModel.horaSalida;
                command.Parameters.Add("@horaLlegada", SqlDbType.Time).Value = vuelosModel.horaLlegada;
                command.Parameters.Add("@numeroVuelo", SqlDbType.Int).Value = vuelosModel.numeroVuelo;
                command.Parameters.Add("@aerolinea", SqlDbType.VarChar).Value = vuelosModel.aerolinea;
                command.Parameters.Add("@estadoVuelo", SqlDbType.VarChar).Value = vuelosModel.estadoVuelo;
                try
                {
                    result = command.ExecuteScalar() == null ? true : false;
                    return result;

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return result=false;
                }
            }
        }

        public bool Edit(VuelosModel vuelosModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VuelosModel> GetByAll()
        {
            VuelosModel vuelos = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from vuelos";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vuelos = new VuelosModel()
                        {
                            id = (int)reader[0],
                            ciudadOrigen = reader[1].ToString(),
                            ciudadDestino = reader[2].ToString(),
                            fecha = reader[3].ToString(),
                            horaSalida = reader[4].ToString(),
                            horaLlegada = reader[5].ToString(),
                            numeroVuelo = (int)reader[6],
                            aerolinea = reader[7].ToString(),
                            estadoVuelo = reader[8].ToString(),
                        };
                        yield return vuelos;
                    }
                }
            }

        }

        public VuelosModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
