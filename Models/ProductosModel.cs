﻿using Login.config;
using Login.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Models
{
    internal class ProductosModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Codigo_Barras { get; set; }
        public int? cantidad { get; set; }
        public string unidadmedidad { get; set; } = null;

        public List<ProductosModel> todos()
        {
            var productos = new List<ProductosModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT Productos.Nombre, stock.cantidad, stock.unidadmedidad, " +
                        "Productos.Codigo_Barras, Productos.IdProducto FROM Productos " +
                        "INNER JOIN stock ON Productos.IdProducto = stock.idProducto";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                productos.Add(new ProductosModel
                                {
                                    IdProducto = Convert.ToInt32(lector["IdProducto"].ToString()),
                                    Codigo_Barras = lector["Codigo_Barras"].ToString(),
                                    Nombre = lector["Nombre"].ToString(),
                                    cantidad = Convert.ToInt32(lector["cantidad"].ToString()),
                                    unidadmedidad = lector["unidadmedidad"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la lista de usuarios. SQL");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la lista de usuarios.");
            }
            return productos;
        }


        public ProductosModel inserat(ProductosModel producto)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "insert into Productos(Nombre, Codigo_Barras) " +
                    " output inserted.IdProducto, inserted.Nombre, inserted.Codigo_Barras " +
                    " values(@Nombre, @Codigo_Barras) ";
                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@Codigo_Barras", producto.Codigo_Barras);
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new ProductosModel
                                {
                                    IdProducto = Convert.ToInt32(lector["IdProducto"]),
                                    Nombre = lector["Nombre"].ToString(),
                                    Codigo_Barras = lector["Codigo_Barras"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al insertar el usuario.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el usuario.");
            }
            return null;
        }
    }
}
