using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDale.Models;

namespace WebApiDale.Data
{
    public class ClienteData
    {
        public static bool Registrar(cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar_cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", oCliente.cedula);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.nombreCliente);
                cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.apellidoCliente);
                cmd.Parameters.AddWithValue("@telefonoCliente", oCliente.telefonoCliente);

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
        public static bool Modificar(cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar_cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", oCliente.cedula);
                cmd.Parameters.AddWithValue("@nombreCliente", oCliente.nombreCliente);
                cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.apellidoCliente);
                cmd.Parameters.AddWithValue("@telefonoCliente", oCliente.telefonoCliente);

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
        public static List<cliente> Listar()
        {
            List<cliente> oListaCliente = new List<cliente>();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_clientes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCliente.Add(new cliente()
                            {
                                cedula = dr["cedula"].ToString(),
                                nombreCliente = dr["nombreCliente"].ToString(),
                                apellidoCliente = dr["apellidoCliente"].ToString(),
                                telefonoCliente = dr["telefonoCliente"].ToString()
                            });
                        }

                    }

                    return oListaCliente;
                }
                catch (Exception ex)
                {
                    return oListaCliente;
                }
            }
        }
        public static cliente obtener(string cedula)
        {
            cliente oCliente = new cliente();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ups_obtener_cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new cliente()
                            {
                                cedula = dr["cedula"].ToString(),
                                nombreCliente = dr["nombreCliente"].ToString(),
                                apellidoCliente = dr["apellidoCliente"].ToString(),
                                telefonoCliente = dr["telefonoCliente"].ToString(),
                            };
                        }

                    }

                    return oCliente;
                }
                catch (Exception ex)
                {
                    return oCliente;
                }
            }
        }
        public static bool Eliminar(string cedula)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_borrar_cliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);

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