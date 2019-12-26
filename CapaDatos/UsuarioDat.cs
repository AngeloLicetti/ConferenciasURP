using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioDat
    {
        SqlConnection conexion;

        public UsuarioDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public bool LogIn(Usuario usuario)
        {
            string select = "EXEC sp_getUsuarioByUsuarioContrasena '" + usuario.Usuraio +  "', '" + usuario.Contrasena + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                usuario.Usuraio = (string)reader[0];
                usuario.Contrasena = (string)reader[1];
                usuario.Estado = 99;
            }
            else
            {
                usuario.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
