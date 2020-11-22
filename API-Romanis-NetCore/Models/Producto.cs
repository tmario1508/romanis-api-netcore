using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public CategoryType IdCategoria { get; set; }

    }

    public enum CategoryType : int
    {
        Hamburguesas = 1,
        Alitas = 2,
        Bebidas = 3,
        Postres = 4
    }
}
