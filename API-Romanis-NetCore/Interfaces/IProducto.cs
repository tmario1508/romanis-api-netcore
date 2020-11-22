using API_Romanis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Interfaces
{
    public interface IProducto : IDisposable
    {
        List<Producto> GetProductos();
        List<Producto> GetProductosByCategory(int Categoria);
        int InsertarProducto(string Nombre, string Descripcion,float Precio, string Imagen, int Categoria);
    }
}
