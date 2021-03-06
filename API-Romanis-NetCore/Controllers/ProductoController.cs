using API_Romanis.Models;
using API_Romanis_NetCore.Interfaces;
using API_Romanis_NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        string serverName = "ServidorLocal";
        private readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // POST INSERTA PRODUCTO
        [HttpPost("insert")]
        public int InsertProducto([FromBody] Producto value)
        {
            int id = 0;
            var ConnectionStringLocal = _configuration.GetValue<string>(serverName);
            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                id = producto.InsertarProducto(value.Nombre, value.Descripcion, value.Precio, value.Imagen, (int)value.IdCategoria);
            }
            return id;
        }

        // GET OBTIENE TODOS LOS PRODUCTOS
        [HttpGet]
        public IEnumerable<Producto> GetProductos()
        {
            List<Producto> listProductos = new List<Producto>();
            var ConnectionStringLocal = _configuration.GetValue<string>(serverName);

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listProductos = producto.GetProductos();
            }

            return listProductos;

        }

        // GET CONSULTA DATOS DEL PRODUCTO POR ID
        [HttpGet("search/{id}")]
        public IEnumerable<Producto> GetProductoById([FromRoute] int id)
        {
            List<Producto> listProductos = new List<Producto>();
            var ConnectionStringLocal = _configuration.GetValue<string>(serverName);

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listProductos = producto.GetProductoById(id);
            }

            return listProductos;
        }


        // GET CONSULTA POR CATEGORIA
        [HttpGet("category/{categoria}")]
        public IEnumerable<Producto> GetProductosByCategoria([FromRoute] int categoria)
        {
            List<Producto> listProductos = new List<Producto>();
            var ConnectionStringLocal = _configuration.GetValue<string>(serverName);

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listProductos = producto.GetProductosByCategory(categoria);
            }

            return listProductos;
        }

        // PUT ACTUALIZA PRODUCTO
        [HttpPut("update/{id}")]
        public int UpdateProducto([FromRoute] int id, [FromBody] Producto value)
        {
            try
            {
                var ConnectionStringLocal = _configuration.GetValue<string>(serverName);
                using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
                {
                    producto.UpdateProducto(id, value.Nombre, value.Descripcion, value.Precio, value.Imagen, (int)value.IdCategoria);
                }
                return 200;
            }
            catch
            {
                return 500;
            }
        }

        // DELETE ELIMINA PRODUCTO
        [HttpDelete("delete/{id}")]
        public void DeleteProducto([FromRoute] int id)
        {
            var ConnectionStringLocal = _configuration.GetValue<string>(serverName);

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                 producto.DeleteProducto(id);
            }
        }
    }
}
