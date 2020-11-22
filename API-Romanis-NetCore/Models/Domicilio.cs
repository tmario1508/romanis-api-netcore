using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Models
{
    public class Domicilio
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Colonia { get; set; }
        public int CP { get; set; }
        public int TelefonoCasa { get; set; }
        public int Celular { get; set; }
    }
}
