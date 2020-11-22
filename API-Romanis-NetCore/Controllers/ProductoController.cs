﻿using API_Romanis.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // POST INSERTA PRODUCTO
        [HttpPost("insert")]
        public int InsertProducto([FromBody] Producto value)
        {
            int id = 0;
            var ConnectionStringLocal = _configuration.GetValue<string>("ServidorLocal");
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
            var ConnectionStringLocal = _configuration.GetValue<string>("ServidorLocal");

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listProductos = producto.GetProductos();
            }

            return listProductos;

        }

        // POST CONSULTA POR CATEGORIA
        [HttpPost("category/{id}")]
        public IEnumerable<Producto> GetProductosByCategoria([FromRoute] int id)
        {
            List<Producto> listProductos = new List<Producto>();
            var ConnectionStringLocal = _configuration.GetValue<string>("ServidorLocal");

            using (IProducto producto = Factorizador.CrearConexionServicio(ConnectionType.MSSQL, ConnectionStringLocal))
            {
                listProductos = producto.GetProductosByCategory(id);
            }

            return listProductos;

        }

        // PUT ACTUALIZA PRODUCTO
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE ELIMINA PRODUCTO
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}