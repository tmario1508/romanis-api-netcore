using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountType Rol { get; set; }
        public string Imagen { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum AccountType : int
    {
        Cliente = 1,
        Empleado = 2,
        Administrador = 3
    }
}
