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
    public class AsistenciaDat
    {
        SqlConnection conexion;

        public AsistenciaDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertAsistencia(Asistencia objAsistencia)
        {
            //string insert = "EXEC [sp_insertar_Asistencia] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno + "', '" + objAsistencia.Hora_Entrada.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string insert = "EXEC [sp_insertar_Asistencia] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno + "', '" + objAsistencia.Hora_Entrada.Date.ToString("yyyy-dd-MM HH:mm:ss") + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateAsistencia(Asistencia objAsistencia)
        {
            //string update = "EXEC [sp_actualizar_Asistencia] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno + "', '" + objAsistencia.Hora_Entrada.Date.ToString("yyyy-MM-dd HH:mm:ss")+ "'";
            string update = "EXEC [sp_actualizar_Asistencia] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno + "', '" + objAsistencia.Hora_Entrada.Date.ToString("yyyy-dd-MM HH:mm:ss") + "'";

            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteAsistencia(Asistencia objAsistencia)
        {
            string delete = "EXEC [sp_eliminar_Asistencia] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno +"'";
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectAsistencias()
        {
            DataSet dsAsistencias = new DataSet();
            string select = "EXEC [sp_listar_Asistencia]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsAsistencias, "Asistencias");
            return dsAsistencias;
        }

        public bool SelectAsistencia(Asistencia objAsistencia)
        {
            string select = "EXEC [sp_getAsistenciaByConferenciaAlumno] '" + objAsistencia.Codigo_Conferencia + "', '" + objAsistencia.Codigo_Alumno + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objAsistencia.Hora_Entrada = (DateTime)reader[2];
                objAsistencia.Estado = 99;
            }
            else
            {
                objAsistencia.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
