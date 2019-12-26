using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;

namespace CapaDatos
{
    public class AlumnoDat
    {
        SqlConnection conexion;

        public AlumnoDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertAlumno(Alumno objAlumno)
        {
            string insert = "EXEC [sp_insertar_Alumno] '" + objAlumno.Codigo + "', '" + objAlumno.Nombres + "', '" + objAlumno.Apellidos + "', '" + objAlumno.Codigo_Escuela + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateAlumno(Alumno objAlumno)
        {
            string update = "EXEC [sp_actualizar_Alumno] '" + objAlumno.Codigo + "', '" + objAlumno.Nombres + "', '" + objAlumno.Apellidos + "', '" + objAlumno.Codigo_Escuela + "'";
            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteAlumno(Alumno objAlumno)
        {
            string delete = "EXEC [sp_eliminar_Alumno] '" + objAlumno.Codigo + "'";
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectAlumnos()
        {
            DataSet dsAlumnos = new DataSet();
            string select = "EXEC [sp_listar_Alumno]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsAlumnos, "Alumnos");
            return dsAlumnos;
        }

        public bool SelectAlumno(Alumno objAlumno)
        {
            string select = "EXEC [sp_getAlumnoByCodigo] '" + objAlumno.Codigo + "'";
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objAlumno.Nombres = (string)reader[1];
                objAlumno.Apellidos = (string)reader[2];
                objAlumno.Codigo_Escuela = (string)reader[3];
                objAlumno.Estado = 99;
            }
            else
            {
                objAlumno.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
