using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        //para las computadoras de la URP usar la siguiente linea:
       // private const string connetionString = "Data source = (local); initial catalog = db_conferencias;integrated security = SSPI;";

        //para la computadora de licetti usar la siguiente linea:
        //private const string connetionString = "Data source = LAPTOP-MH9EOD8T\\SQLEXPRESS01; initial catalog = db_conferencias;integrated security = SSPI;";

        private const string connetionString = "Data source = PC-00\\SQLEXPRESS; initial catalog = db_conferencias;integrated security = SSPI;";
        public static string ConnetionString
        {
            get
            {
                return connetionString;
            }
        }
    }
}
