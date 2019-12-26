using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace CapaDatos
{
    public class ExpositorDat
    {
        SqlConnection conexion;

        public ExpositorDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertExpositor(Expositor objExpositor)
        {
            string insert = "EXEC [sp_insertar_Expositor] '" + objExpositor.Dni + "', '" + objExpositor.Nombres + "', '" + objExpositor.Apellidos + "', '" + objExpositor.Titulado + "', '" + objExpositor.Especialidad + "', '" + objExpositor.Empresa + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateExpositor(Expositor objExpositor)
        {
            string update = "EXEC [sp_actualizar_Expositor] '" + objExpositor.Dni + "', '" + objExpositor.Nombres + "', '" + objExpositor.Apellidos + "', '" + objExpositor.Titulado + "', '" + objExpositor.Especialidad + "', '" + objExpositor.Empresa + "'";
            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteExpositor(Expositor objExpositor)
        {
            string delete = "EXEC [sp_eliminar_Expositor] '" + objExpositor.Dni + "'";
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectExpositors()
        {
            DataSet dsExpositors = new DataSet();
            string select = "EXEC [sp_listar_Expositor]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsExpositors, "Expositors");
            return dsExpositors;
        }

        public bool SelectExpositor(Expositor objExpositor)
        {
            string select = "EXEC [sp_getExpositorByDni] '" + objExpositor.Dni + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objExpositor.Nombres = (string)reader[1];
                objExpositor.Apellidos = (string)reader[2];
                objExpositor.Titulado = (bool)reader[3];
                objExpositor.Especialidad = (string)reader[4];
                objExpositor.Empresa = (string)reader[5];
                objExpositor.Estado = 99;
            }
            else
            {
                objExpositor.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
