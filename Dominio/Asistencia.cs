using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Asistencia
    {
        private int codigo_Conferencia;
        private string codigo_Alumno;
        private DateTime hora_Entrada;
        private int estado;

        public int Codigo_Conferencia
        {
            get
            {
                return codigo_Conferencia;
            }

            set
            {
                codigo_Conferencia = value;
            }
        }

        public string Codigo_Alumno
        {
            get
            {
                return codigo_Alumno;
            }

            set
            {
                codigo_Alumno = value;
            }
        }

        public DateTime Hora_Entrada
        {
            get
            {
                return hora_Entrada;
            }

            set
            {
                hora_Entrada = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
