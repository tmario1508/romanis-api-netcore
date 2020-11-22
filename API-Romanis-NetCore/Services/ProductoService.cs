using API_Romanis.Helpers;
using API_Romanis.Models;
using API_Romanis_NetCore.Interfaces;
using API_Romanis_NetCore.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Services
{
    public class ProductoService : IProducto, IDisposable
    {
        SqlConexion sql = null;
        ConnectionType type = ConnectionType.NONE;

        public static ProductoService CrearInstanciaSQL(SqlConexion sql)
        {
            ProductoService log = new ProductoService
            {
                sql = sql,
                type = ConnectionType.MSSQL
            };

            return log;
        }

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (sql != null)
                    {
                        sql.Desconectar();
                        sql.Dispose();
                    }// TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public List<Producto> GetProductosByCategory(int Categoria)
        {
            List<Producto> list = new List<Producto>();
            Producto user = new Producto();
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            try
            {
                _Parametros.Add(new SqlParameter("@id", Categoria));
                sql.PrepararProcedimiento("dbo.[GetProductoCategory]", _Parametros);
                DataTableReader dtr = sql.EjecutarTableReader(CommandType.StoredProcedure);
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        var Json = dtr["Producto"].ToString();
                        if (Json != string.Empty)
                        {
                            JArray arr = JArray.Parse(Json);
                            foreach (JObject jsonOperaciones in arr.Children<JObject>())
                            {
                                list.Add(new Producto()
                                {
                                    IdProducto = Convert.ToInt32(jsonOperaciones["IdProducto"].ToString()),
                                    Nombre = jsonOperaciones["Nombre"].ToString(),
                                    Descripcion = jsonOperaciones["Descripcion"].ToString(),
                                    Precio = (float)Convert.ToDouble(jsonOperaciones["Precio"].ToString()),
                                    Imagen = jsonOperaciones["Imagen"].ToString(),
                                    IdCategoria = (CategoryType)Convert.ToInt32(jsonOperaciones["Categoria"].ToString()),
                                });

                            }

                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return list;
        }


        public List<Producto> GetProductos()
        {
            List<Producto> list = new List<Producto>();
            Producto user = new Producto();
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            try
            {
                sql.PrepararProcedimiento("dbo.[GetProductosJSON]", _Parametros);
                DataTableReader dtr = sql.EjecutarTableReader(CommandType.StoredProcedure);
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        var Json = dtr["Producto"].ToString();
                        if (Json != string.Empty)
                        {
                            JArray arr = JArray.Parse(Json);
                            foreach (JObject jsonOperaciones in arr.Children<JObject>())
                            {
                                list.Add(new Producto()
                                {
                                    IdProducto = Convert.ToInt32(jsonOperaciones["IdProducto"].ToString()),
                                    Nombre = jsonOperaciones["Nombre"].ToString(),
                                    Descripcion = jsonOperaciones["Descripcion"].ToString(),
                                    Precio = (float)Convert.ToDouble(jsonOperaciones["Precio"].ToString()),
                                    Imagen = jsonOperaciones["Imagen"].ToString(),
                                    IdCategoria = (CategoryType)Convert.ToInt32(jsonOperaciones["Categoria"].ToString()),
                                });

                            }

                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return list;
        }

        public int InsertarProducto(string Nombre, string Descripcion,float Precio, string Imagen, int Categoria)
        {
            int IdProducto = 0;
            List<SqlParameter> _Parametros = new List<SqlParameter>();
            try
            {
                //PARAMETROS
                _Parametros.Add(new SqlParameter("@Nombre", Nombre));
                _Parametros.Add(new SqlParameter("@Descripcion", Descripcion));
                _Parametros.Add(new SqlParameter("@Precio", Precio));
                _Parametros.Add(new SqlParameter("@Imagen", Imagen));
                _Parametros.Add(new SqlParameter("@Categoria", Categoria));

                //PARAMETROS OUTPUT
                SqlParameter valreg = new SqlParameter();
                valreg.ParameterName = "@IdProducto";
                valreg.DbType = DbType.Int32;
                valreg.Direction = ParameterDirection.Output;
                _Parametros.Add(valreg);

                sql.PrepararProcedimiento("dbo.[InsertProducto]", _Parametros);
                IdProducto = int.Parse(sql.EjecutarProcedimientoOutput().ToString());
                return IdProducto;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
    
}
