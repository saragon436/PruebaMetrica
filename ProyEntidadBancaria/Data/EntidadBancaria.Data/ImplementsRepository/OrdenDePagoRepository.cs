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
using EntidadBancaria.Entities.Enumeration;

namespace EntidadBancaria.Data.ImplementsRepository
{
    public class OrdenDePagoRepository:IOrdenDePagoRepository
    {
        public List<OrdenDePago> Listar(int idSucursal)
        {
            var ordenes = new List<OrdenDePago>();
            var sucursalRepository = new SucursalRepository();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM OrdenDePago where IdSucursal=@id", con);
                    query.Parameters.AddWithValue("@id", idSucursal);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ordenPago = new OrdenDePago
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Monto = Convert.ToDecimal(dr["Monto"]),
                                Moneda = (MonedaEnum)Convert.ToByte(dr["Moneda"]),
                                Estado = (EstadoOrdenPagoEnum)Convert.ToByte(dr["Estado"]),
                                FechaDePago = Convert.ToDateTime(dr["FechaDePago"]),
                                IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                                Sucursal = sucursalRepository.ObtenerById(Convert.ToInt32(dr["IdSucursal"]))
                            };
                            ordenes.Add(ordenPago);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ordenes;
        }

        public OrdenDePago ObtenerById(int id)
        {
            var ordenPago = new OrdenDePago();
            var sucursalRepository = new SucursalRepository();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM OrdenDePago WHERE Id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            ordenPago.Id = Convert.ToInt32(dr["Id"]);
                            ordenPago.Monto = Convert.ToDecimal(dr["Monto"]);
                            ordenPago.Moneda = (MonedaEnum)Convert.ToByte(dr["Moneda"]);
                            ordenPago.Estado = (EstadoOrdenPagoEnum)Convert.ToByte(dr["Estado"]);
                            ordenPago.FechaDePago = Convert.ToDateTime(dr["FechaDePago"]);
                            ordenPago.IdSucursal = Convert.ToInt32(dr["IdSucursal"]);
                            ordenPago.Sucursal = sucursalRepository.ObtenerById(Convert.ToInt32(dr["IdSucursal"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ordenPago;
        }

        public bool Actualizar(OrdenDePago ordenDePago)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE OrdenDePago SET Monto = @p0, Moneda = @p1, Estado = @p2, FechaDePago=@p4, IdSucursal=@p5 WHERE Id = @p3", con);

                    query.Parameters.AddWithValue("@p0", ordenDePago.Monto);
                    query.Parameters.AddWithValue("@p1", ordenDePago.Moneda);
                    query.Parameters.AddWithValue("@p2", ordenDePago.Estado);
                    query.Parameters.AddWithValue("@p3", ordenDePago.Id);
                    query.Parameters.AddWithValue("@p4", ordenDePago.FechaDePago);
                    query.Parameters.AddWithValue("@p5", ordenDePago.IdSucursal);

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

        public bool Registrar(OrdenDePago ordenDePago)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EntidadBancariaConnection"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO OrdenDePago(Monto, Moneda, Estado,FechaDePago,IdSucursal) VALUES (@p0, @p1, @p2, @p3, @p4)", con);

                    query.Parameters.AddWithValue("@p0", ordenDePago.Monto);
                    query.Parameters.AddWithValue("@p1", ordenDePago.Moneda);
                    query.Parameters.AddWithValue("@p2", ordenDePago.Estado);
                    query.Parameters.AddWithValue("@p3", ordenDePago.FechaDePago);
                    query.Parameters.AddWithValue("@p4", ordenDePago.IdSucursal);

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

                    var query = new SqlCommand("DELETE FROM OrdenDePago WHERE Id = @p0", con);
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
