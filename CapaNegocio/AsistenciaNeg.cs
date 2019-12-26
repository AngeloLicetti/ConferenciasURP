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
    public class AsistenciaNeg
    {
        AsistenciaDat objAsistenciaDat;
        ConferenciaDat objConferenciaDat;
        AlumnoDat objAlumnoDat;
        public AsistenciaNeg()
        {
            objAsistenciaDat = new AsistenciaDat();
            objConferenciaDat = new ConferenciaDat();
            objAlumnoDat = new AlumnoDat();
        }
        public void RegistrarAsistencia(Asistencia objAsistencia)
        {
            bool correcto = true;
            //Verificar que Conferencia exista; error 1
            Conferencia objConferenciaT = new Conferencia();
            objConferenciaT.Codigo = objAsistencia.Codigo_Conferencia;
            correcto = objConferenciaDat.SelectConferencia(objConferenciaT);
            if (!correcto)
            {
                objAsistencia.Estado = 1;
                return;
            }
            //Verificar que Alumno exista; error 2
            Alumno objAlumnoT = new Alumno();
            objAlumnoT.Codigo = objAsistencia.Codigo_Alumno;
            correcto = objAlumnoDat.SelectAlumno(objAlumnoT);
            if (!correcto)
            {
                objAsistencia.Estado = 2;
                return;
            }
            //Verificar duplicidad: error = 22
            Asistencia objAsistenciaT = new Asistencia();
            objAsistenciaT.Codigo_Conferencia = objAsistencia.Codigo_Conferencia;
            objAsistenciaT.Codigo_Alumno = objAsistencia.Codigo_Alumno;
            correcto = !objAsistenciaDat.SelectAsistencia(objAsistenciaT);
            if (!correcto)
            {
                objAsistencia.Estado = 22;
                return;
            }
            //registro de la Asistencia en la tabla
            objAsistenciaDat.InsertAsistencia(objAsistencia);
            objAsistencia.Estado = 99;
        }
        public void ActualizarAsistencia(Asistencia objAsistencia)
        {
            bool correcto = true;
            //Verificar que Asistencia exista, error = 1
            Asistencia objAsistenciaT = new Asistencia();
            objAsistenciaT.Codigo_Conferencia = objAsistencia.Codigo_Conferencia;
            objAsistenciaT.Codigo_Alumno = objAsistencia.Codigo_Alumno;
            correcto = objAsistenciaDat.SelectAsistencia(objAsistenciaT);

            if (!correcto)
            {
                objAsistencia.Estado = 1;
                return;
            }

            //registro de actualizacion de Asistencia en tabla
            objAsistenciaDat.UpdateAsistencia(objAsistencia);
            objAsistencia.Estado = 99;
        }
        public void EliminarAsistencia(Asistencia objAsistencia)
        {
            bool correcto = true;
            //Verificar que Asistencia exista, error = 1
            Asistencia objAsistenciaT = new Asistencia();
            objAsistenciaT.Codigo_Conferencia = objAsistencia.Codigo_Conferencia;
            objAsistenciaT.Codigo_Alumno = objAsistencia.Codigo_Alumno;
            correcto = objAsistenciaDat.SelectAsistencia(objAsistenciaT);

            if (!correcto)
            {
                objAsistencia.Estado = 1;
                return;
            }
            //eliminacion de Asistencia en tabla
            objAsistenciaDat.DeleteAsistencia(objAsistencia);
            objAsistencia.Estado = 99;
        }

        public bool LeerAsistencia(Asistencia objAsistencia)
        {
            return objAsistenciaDat.SelectAsistencia(objAsistencia);
        }

        public DataSet LeerAsistencias()
        {
            return objAsistenciaDat.SelectAsistencias();
        }
    }
}
