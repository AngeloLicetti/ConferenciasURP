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
    public class ConferenciaDat
    {
        SqlConnection conexion;

        public ConferenciaDat()
        {
            conexion = new SqlConnection(Conexion.ConnetionString);
        }

        public void InsertConferencia(Conferencia objConferencia)
        {
            //string insert = "EXEC [sp_insertar_Conferencia] '" + objConferencia.Semestre + "', '" + objConferencia.Fecha_Inicio.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + objConferencia.Fecha_Fin.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + objConferencia.Lugar + "', '" + objConferencia.Tema + "', " + objConferencia.Peso + ", '" + objConferencia.Dni_Expositor + "', '" + objConferencia.Codigo_Escuela + "'";
            string insert = "EXEC [sp_insertar_Conferencia] '" + objConferencia.Semestre + "', '" + objConferencia.Fecha_Inicio.Date.ToString("yyyy-dd-MM HH:mm:ss") + "', '" + objConferencia.Fecha_Fin.Date.ToString("yyyy-dd-MM HH:mm:ss") + "', '" + objConferencia.Lugar + "', '" + objConferencia.Tema + "', " + objConferencia.Peso + ", '" + objConferencia.Dni_Expositor + "', '" + objConferencia.Codigo_Escuela + "'";
            SqlCommand unComando = new SqlCommand(insert, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdateConferencia(Conferencia objConferencia)
        {
            //string update = "EXEC [sp_actualizar_Conferencia] " + objConferencia.Codigo + ", '" + objConferencia.Semestre + "', '" + objConferencia.Fecha_Inicio.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + objConferencia.Fecha_Fin.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + objConferencia.Lugar + "', '" + objConferencia.Tema + "', " + objConferencia.Peso + ", '" + objConferencia.Dni_Expositor + "', '" + objConferencia.Codigo_Escuela + "'";
            string update = "EXEC [sp_actualizar_Conferencia] " + objConferencia.Codigo + ", '" + objConferencia.Semestre + "', '" + objConferencia.Fecha_Inicio.Date.ToString("yyyy-dd-MM HH:mm:ss") + "', '" + objConferencia.Fecha_Fin.Date.ToString("yyyy-dd-MM HH:mm:ss") + "', '" + objConferencia.Lugar + "', '" + objConferencia.Tema + "', " + objConferencia.Peso + ", '" + objConferencia.Dni_Expositor + "', '" + objConferencia.Codigo_Escuela + "'";
            SqlCommand unComando = new SqlCommand(update, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public void DeleteConferencia(Conferencia objConferencia)
        {
            string delete = "EXEC [sp_eliminar_Conferencia] " + objConferencia.Codigo;
            SqlCommand unComando = new SqlCommand(delete, conexion);

            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet SelectConferencias()
        {
            DataSet dsConferencias = new DataSet();
            string select = "EXEC [sp_listar_Conferencia]";
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsConferencias, "Conferencias");
            return dsConferencias;
        }

        public bool SelectConferencia(Conferencia objConferencia)
        {
            string select = "EXEC [sp_getConferenciaByCodigo] " + objConferencia.Codigo;
            SqlCommand command = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objConferencia.Semestre = (string)reader[1];
                objConferencia.Fecha_Inicio = (DateTime)reader[2];
                objConferencia.Fecha_Fin = (DateTime)reader[3];
                objConferencia.Lugar = (string)reader[4];
                objConferencia.Tema = (string)reader[5];
                objConferencia.Peso = (int)reader[6];
                objConferencia.Dni_Expositor = (string)reader[7];
                objConferencia.Codigo_Escuela = (string)reader[8];
                objConferencia.Estado = 99;
            }
            else
            {
                objConferencia.Estado = 1;
            }
            conexion.Close();
            return hayRegistros;
        }

        public DataSet ReporteByCodigoConferencia(Conferencia objConferencia)
        {
            DataSet dsReporte = new DataSet();
            string select = "EXEC [sp_ReporteByCodigoConferencia]" + objConferencia.Codigo;
            SqlDataAdapter unComando = new SqlDataAdapter(select, conexion);
            unComando.Fill(dsReporte, "Conferencias");
            return dsReporte;
        }
    }
}
