
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Romanis_NetCore.Interfaces
{
    using API_Romanis.Helpers;
    using Services;
    public static class Factorizador
    {
        public static IProducto CrearConexionServicio(Models.ConnectionType type, string connectionString)
        {
            IProducto nuevoMotor = null; ;
            switch (type)
            {
                case Models.ConnectionType.NONE:
                    break;
                case Models.ConnectionType.MSSQL:
                    SqlConexion sql = SqlConexion.Conectar(connectionString);
                    nuevoMotor = ProductoService.CrearInstanciaSQL(sql);
                    break;
                case Models.ConnectionType.MYSQL:
                    break;
                default:
                    break;
            }

            return nuevoMotor;
        }
    }
}
