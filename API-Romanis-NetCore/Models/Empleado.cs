using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Models
{
    public class Empleado:Usuario
    {
        public Domicilio Domicilio { get; set; }
        public int Salario { get; set; }
        public string Turno { get; set; }
        public string Tipo { get; set;}
    }
}
