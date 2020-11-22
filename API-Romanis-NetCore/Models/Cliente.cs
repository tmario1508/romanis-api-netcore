using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Models
{
    public class Cliente:Usuario
    {
        public Domicilio Domicilio { get; set; }
        public int NumTarjeta { get; set; }
        public double Saldo { get; set; }
    }

}
