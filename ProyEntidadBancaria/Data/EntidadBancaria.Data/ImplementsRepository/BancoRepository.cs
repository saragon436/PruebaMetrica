using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using EntidadBancaria.Data.Repository;
using EntidadBancaria.Entities.Entidades;

namespace EntidadBancaria.Data.ImplementsRepository
{
    public class BancoRepository:IBancoRepository
    {
        public List<Entities.Entidades.Banco> Listar()
        {
            var bancos = new List<Banco>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Banco", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // banco
                            var banco = new Banco
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                FechaDeRegistro = Convert.ToDateTime(dr["FechaDeRegistro"]),
                            };

                            // Agregamos el banco a la lista genreica
                            bancos.Add(banco);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return bancos;
        }

        public Entities.Entidades.Banco ObtenerById(int id)
        {
            var banco = new Banco();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Banco WHERE Id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            banco.Id = Convert.ToInt32(dr["Id"]);
                            banco.Nombre = dr["Nombre"].ToString();
                            banco.Direccion = dr["Direccion"].ToString();
                            banco.FechaDeRegistro = Convert.ToDateTime(dr["FechaDeRegistro"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return banco;
        }

        public bool Actualizar(Entities.Entidades.Banco banco)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Banco SET Nombre = @p0, Direccion = @p1, FechaDeRegistro = @p2 WHERE Id = @p3", con);

                    query.Parameters.AddWithValue("@p0", banco.Nombre);
                    query.Parameters.AddWithValue("@p1", banco.Direccion);
                    query.Parameters.AddWithValue("@p2", banco.FechaDeRegistro);
                    query.Parameters.AddWithValue("@p3", banco.Id);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public bool Registrar(Entities.Entidades.Banco banco)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Banco(Nombre, Direccion, FechaDeRegistro) VALUES (@p0, @p1, @p2)", con);

                    query.Parameters.AddWithValue("@p0", banco.Nombre);
                    query.Parameters.AddWithValue("@p1", banco.Direccion);
                    query.Parameters.AddWithValue("@p2", banco.FechaDeRegistro);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM Banco WHERE Id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
