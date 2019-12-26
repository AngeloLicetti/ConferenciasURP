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
    public class EscuelaNeg
    {
        EscuelaDat objEscuelaDat;
        public EscuelaNeg()
        {
            objEscuelaDat = new EscuelaDat();
        }
        public void RegistrarEscuela(Escuela objEscuela)
        {
            bool correcto = true;
            //Verificar duplicidad: error = 22
            Escuela objEscuelaT = new Escuela();
            objEscuelaT.Codigo = objEscuela.Codigo;
            correcto = !objEscuelaDat.SelectEscuela(objEscuelaT);
            if (!correcto)
            {
                objEscuela.Estado = 22;
                return;
            }
            //registro de la Escuela en la tabla
            objEscuelaDat.InsertEscuela(objEscuela);
            objEscuela.Estado = 99;
        }
        public void ActualizarEscuela(Escuela objEscuela)
        {
            bool correcto = true;
            //Verificar que Escuela exista, error = 1
            Escuela objEscuelaT = new Escuela();
            objEscuelaT.Codigo = objEscuela.Codigo;
            correcto = objEscuelaDat.SelectEscuela(objEscuelaT);

            if (!correcto)
            {
                objEscuela.Estado = 1;
                return;
            }

            //registro de actualizacion de Escuela en tabla
            objEscuelaDat.UpdateEscuela(objEscuela);
            objEscuela.Estado = 99;
        }
        public void EliminarEscuela(Escuela objEscuela)
        {
            bool correcto = true;
            //Verificar que Escuela exista, error = 1
            Escuela objEscuelaT = new Escuela();
            objEscuelaT.Codigo = objEscuela.Codigo;
            correcto = objEscuelaDat.SelectEscuela(objEscuelaT);

            if (!correcto)
            {
                objEscuela.Estado = 1;
                return;
            }
            //eliminacion de Escuela en tabla
            objEscuelaDat.DeleteEscuela(objEscuela);
            objEscuela.Estado = 99;
        }

        public bool LeerEscuela(Escuela objEscuela)
        {
            return objEscuelaDat.SelectEscuela(objEscuela);
        }

        public DataSet LeerEscuelas()
        {
            return objEscuelaDat.SelectEscuelas();
        }
    }
}
