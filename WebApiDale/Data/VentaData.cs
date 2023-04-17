using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDale.Models;

namespace WebApiDale.Data
{
    public class VentaData
    {
        public static bool Registrar(ventas oVenta)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar_venta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", oVenta.cedula);
                cmd.Parameters.AddWithValue("@valorTotal", oVenta.PrecioTotal);
                cmd.Parameters.AddWithValue("@direccion", oVenta.direccion);
                cmd.Parameters.AddWithValue("@fecha", oVenta.fecha);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Modificar(ventas oVentas)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar_venta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oVentas.idPedido);
                cmd.Parameters.AddWithValue("@cedula", oVentas.cedula);
                cmd.Parameters.AddWithValue("@valorTotal", oVentas.PrecioTotal);
                cmd.Parameters.AddWithValue("@direccion", oVentas.direccion);
                cmd.Parameters.AddWithValue("@fecha", oVentas.fecha);



                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<ventas> Listar()
        {
            List<ventas> oListaVenta = new List<ventas>();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_pedidosE", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaVenta.Add(new ventas()
                            {
                                idPedido = Convert.ToInt32(dr["idPedido"]),
                                cedula = dr["cedula"].ToString(),
                                fecha = DateTime.Parse(dr["fecha"].ToString()),
                                direccion = dr["direccion"].ToString(),
                                PrecioTotal = Convert.ToDouble(dr["PrecioTotal"].ToString()),
                            });
                        }
                    }
                    return oListaVenta;
                }
                catch (Exception ex)
                {
                    return oListaVenta;
                }
            }
        }
        public static ventas obtener(int idVenta)
        {
            ventas oVenta = new ventas();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ups_obtener_venta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idVenta);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oVenta = new ventas()
                            {
                                idPedido = Convert.ToInt32(dr["id"]),                              
                                cedula = dr["cedula"].ToString(),
                                fecha = DateTime.Parse(dr["fecha"].ToString()),
                                direccion = dr["direccion"].ToString(),
                                PrecioTotal = Convert.ToDouble(dr["valorTotal"].ToString()),
                            };
                        }

                    }

                    return oVenta;
                }
                catch (Exception ex)
                {
                    return oVenta;
                }
            }
        }
        public static bool Eliminar(int idVenta)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_borrar_venta", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idVenta);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}