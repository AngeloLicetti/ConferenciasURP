using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Conferencia
    {
        private int codigo;
        private string semestre;
        private DateTime fecha_Inicio;
        private DateTime fecha_Fin;
        private string lugar;
        private string tema;
        private int peso;
        private string dni_Expositor;
        private string codigo_Escuela;
        private int estado;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Semestre
        {
            get
            {
                return semestre;
            }

            set
            {
                semestre = value;
            }
        }

        public DateTime Fecha_Inicio
        {
            get
            {
                return fecha_Inicio;
            }

            set
            {
                fecha_Inicio = value;
            }
        }

        public DateTime Fecha_Fin
        {
            get
            {
                return fecha_Fin;
            }

            set
            {
                fecha_Fin = value;
            }
        }

        public string Lugar
        {
            get
            {
                return lugar;
            }

            set
            {
                lugar = value;
            }
        }

        public string Tema
        {
            get
            {
                return tema;
            }

            set
            {
                tema = value;
            }
        }

        public int Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public string Dni_Expositor
        {
            get
            {
                return dni_Expositor;
            }

            set
            {
                dni_Expositor = value;
            }
        }

        public string Codigo_Escuela
        {
            get
            {
                return codigo_Escuela;
            }

            set
            {
                codigo_Escuela = value;
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
