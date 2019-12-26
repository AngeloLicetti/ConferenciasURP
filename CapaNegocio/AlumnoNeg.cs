using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class AlumnoNeg
    {
        AlumnoDat objAlumnoDat;
        EscuelaDat objEscuelaDat;
        public AlumnoNeg()
        {
            objAlumnoDat = new AlumnoDat();
            objEscuelaDat = new EscuelaDat();
        }
        public void RegistrarAlumno(Alumno objAlumno)
        {
            bool correcto = true;
            //Verificar duplicidad: error = 22
            Alumno objAlumnoT = new Alumno();
            objAlumnoT.Codigo = objAlumno.Codigo;
            correcto = !objAlumnoDat.SelectAlumno(objAlumnoT);
            if (!correcto)
            {
                objAlumno.Estado = 22;
                return;
            }
            //Verificar que escuela exista: error = 4
            Escuela objEscuelaT = new Escuela();
            objEscuelaT.Codigo = objAlumno.Codigo_Escuela;
            correcto = objEscuelaDat.SelectEscuela(objEscuelaT);
            if (!correcto)
            {
                objAlumno.Estado = 4;
                return;
            }
            //registro de la Alumno en la tabla
            objAlumnoDat.InsertAlumno(objAlumno);
            objAlumno.Estado = 99;
        }
        public void ActualizarAlumno(Alumno objAlumno)
        {
            bool correcto = true;
            //Verificar que Alumno exista, error = 1
            Alumno objAlumnoT = new Alumno();
            objAlumnoT.Codigo = objAlumno.Codigo;
            correcto = objAlumnoDat.SelectAlumno(objAlumnoT);

            if (!correcto)
            {
                objAlumno.Estado = 1;
                return;
            }

            //registro de actualizacion de Alumno en tabla
            objAlumnoDat.UpdateAlumno(objAlumno);
            objAlumno.Estado = 99;
        }
        public void EliminarAlumno(Alumno objAlumno)
        {
            bool correcto = true;
            //Verificar que Alumno exista, error = 1
            Alumno objAlumnoT = new Alumno();
            objAlumnoT.Codigo = objAlumno.Codigo;
            correcto = objAlumnoDat.SelectAlumno(objAlumnoT);

            if (!correcto)
            {
                objAlumno.Estado = 1;
                return;
            }
            //eliminacion de Alumno en tabla
            objAlumnoDat.DeleteAlumno(objAlumno);
            objAlumno.Estado = 99;
        }

        public bool LeerAlumno(Alumno objAlumno)
        {
            return objAlumnoDat.SelectAlumno(objAlumno);
        }

        public DataSet LeerAlumnos()
        {
            return objAlumnoDat.SelectAlumnos();
        }
    }
}
