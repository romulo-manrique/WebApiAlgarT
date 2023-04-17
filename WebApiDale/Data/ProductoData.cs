using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDale.Models;

namespace WebApiDale.Data
{
    public class ProductoData
    {
        public static bool Registrar(producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreProducto", oProducto.nombreProducto);
                cmd.Parameters.AddWithValue("@valorUnitario", oProducto.valorUnitario);           

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
        public static bool Modificar(producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modicar_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", oProducto.idProducto);
                cmd.Parameters.AddWithValue("@nombreProducto", oProducto.nombreProducto);
                cmd.Parameters.AddWithValue("@valorUnitario", oProducto.valorUnitario);


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
        public static List<producto> Listar()
        {
            List<producto> oListaProducto = new List<producto>();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_productos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaProducto.Add(new producto()
                            {
                                idProducto = Convert.ToInt32(dr["idProducto"]),
                                nombreProducto = dr["nombreProducto"].ToString(),
                                valorUnitario = Convert.ToDouble(dr["valorUnitario"].ToString()),
                            });
                        }

                    }



                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    return oListaProducto;
                }
            }
        }
        public static producto obtener(int idProducto)
        {
            producto oProducto = new producto();
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("ups_obtener_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oProducto = new producto()
                            {
                                idProducto = Convert.ToInt32(dr["IdProducto"]),
                                nombreProducto = dr["nombreProducto"].ToString(),
                                valorUnitario = Convert.ToDouble(dr["valorUnitario"].ToString()),
                            };
                        }

                    }



                    return oProducto;
                }
                catch (Exception ex)
                {
                    return oProducto;
                }
            }
        }
        public static bool Eliminar(int idProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_borrar_producto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

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