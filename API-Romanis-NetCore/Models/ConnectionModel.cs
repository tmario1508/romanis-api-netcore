using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Models
{
    public enum ConnectionType : int
    {
        NONE = 0,
        MSSQL = 1,
        MYSQL = 2,
        MONGO = 3
    }
}
