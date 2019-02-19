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
    public class SucursalRepository:ISucursalRepository
    {
        public List<Sucursal> ListarTodas()
        {
            var sucursales = new List<Sucursal>();
            var bancoRepository = new BancoRepository();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Sucursal", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // banco
                            var sucursal = new Sucursal
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                FechaDeRegistro = Convert.ToDateTime(dr["FechaDeRegistro"]),
                                IdBanco = Convert.ToInt32(dr["IdBanco"]),
                                Banco = bancoRepository.ObtenerById(Convert.ToInt32(dr["IdBanco"]))
                            };

                            // Agregamos el banco a la lista genreica
                            sucursales.Add(sucursal);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sucursales;
        }
        public List<Sucursal> Listar(int idBanco)
        {
            var sucursales = new List<Sucursal>();
            var bancoRepository = new BancoRepository();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Sucursal where IdBanco=@id", con);
                    query.Parameters.AddWithValue("@id", idBanco);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // banco
                            var sucursal = new Sucursal
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                FechaDeRegistro = Convert.ToDateTime(dr["FechaDeRegistro"]),
                                IdBanco = Convert.ToInt32(dr["IdBanco"]),
                                Banco = bancoRepository.ObtenerById(Convert.ToInt32(dr["IdBanco"]))
                            };

                            // Agregamos el banco a la lista genreica
                            sucursales.Add(sucursal);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sucursales;
        }

        public Sucursal ObtenerById(int id)
        {
            var sucursal = new Sucursal();
            var bancoRepository = new BancoRepository();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Sucursal WHERE Id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            sucursal.Id = Convert.ToInt32(dr["Id"]);
                            sucursal.Nombre = dr["Nombre"].ToString();
                            sucursal.Direccion = dr["Direccion"].ToString();
                            sucursal.FechaDeRegistro = Convert.ToDateTime(dr["FechaDeRegistro"]);
                            sucursal.IdBanco = Convert.ToInt32(dr["IdBanco"]);
                            sucursal.Banco = bancoRepository.ObtenerById(Convert.ToInt32(dr["IdBanco"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return sucursal;
        }

        public bool Actualizar(Sucursal sucursal)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Sucursal SET Nombre = @p0, Direccion = @p1, FechaDeRegistro = @p2, IdBanco=@p4 WHERE Id = @p3", con);

                    query.Parameters.AddWithValue("@p0", sucursal.Nombre);
                    query.Parameters.AddWithValue("@p1", sucursal.Direccion);
                    query.Parameters.AddWithValue("@p2", sucursal.FechaDeRegistro);
                    query.Parameters.AddWithValue("@p3", sucursal.Id);
                    query.Parameters.AddWithValue("@p4", sucursal.IdBanco);

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

        public bool Registrar(Sucursal sucursal)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Sucursal(Nombre, Direccion, FechaDeRegistro,IdBanco) VALUES (@p0, @p1, @p2, @p3)", con);

                    query.Parameters.AddWithValue("@p0", sucursal.Nombre);
                    query.Parameters.AddWithValue("@p1", sucursal.Direccion);
                    query.Parameters.AddWithValue("@p2", sucursal.FechaDeRegistro);
                    query.Parameters.AddWithValue("@p3", sucursal.IdBanco);

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

                    var query = new SqlCommand("DELETE FROM Sucursal WHERE Id = @p0", con);
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
