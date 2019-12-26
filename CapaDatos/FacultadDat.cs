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
    public class FacultadDat
    {
        SqlConnection conexion;

        public FacultadDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertFacultad(Facultad objFacultad)
        {
            string insert = "EXEC [sp_insertar_Facultad] '" + objFacultad.Codigo + "', '" + objFacultad.Nombre + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateFacultad(Facultad objFacultad)
        {
            string update = "EXEC [sp_actualizar_Facultad] '" + objFacultad.Codigo + "', '" + objFacultad.Nombre + "'";
            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteFacultad(Facultad objFacultad)
        {
            string delete = "EXEC [sp_eliminar_Facultad] '" + objFacultad.Codigo + "'";
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectFacultads()
        {
            DataSet dsFacultads = new DataSet();
            string select = "EXEC [sp_listar_Facultad]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsFacultads, "Facultads");
            return dsFacultads;
        }

        public bool SelectFacultad(Facultad objFacultad)
        {
            string select = "EXEC [sp_getFacultadByCodigo] '" + objFacultad.Codigo + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objFacultad.Nombre = (string)reader[1];
                objFacultad.Estado = 99;
            }
            else
            {
                objFacultad.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
