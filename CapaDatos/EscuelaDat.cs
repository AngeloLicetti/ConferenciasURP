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
    public class EscuelaDat
    {

        SqlConnection conexion;

        public EscuelaDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertEscuela(Escuela objEscuela)
        {
            string insert = "EXEC [sp_insertar_Escuela] '" + objEscuela.Codigo + "', '" + objEscuela.Nombre + "', '" + objEscuela.Codigo_Facultad + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateEscuela(Escuela objEscuela)
        {
            string update = "EXEC [sp_actualizar_Escuela] '" + objEscuela.Codigo + "', '" + objEscuela.Nombre + "', '" + objEscuela.Codigo_Facultad + "'";
            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteEscuela(Escuela objEscuela)
        {
            string delete = "EXEC [sp_eliminar_Escuela] '" + objEscuela.Codigo + "'";
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectEscuelas()
        {
            DataSet dsEscuelas = new DataSet();
            string select = "EXEC [sp_listar_Escuela]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsEscuelas, "Escuelas");
            return dsEscuelas;
        }

        public bool SelectEscuela(Escuela objEscuela)
        {
            string select = "EXEC [sp_getEscuelaByCodigo] '" + objEscuela.Codigo + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objEscuela.Nombre = (string)reader[1];
                objEscuela.Codigo_Facultad = (string)reader[2];
                objEscuela.Estado = 99;
            }
            else
            {
                objEscuela.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
