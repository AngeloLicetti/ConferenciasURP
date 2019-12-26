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
    public class FacultadNeg
    {
        FacultadDat objFacultadDat;
        public FacultadNeg()
        {
            objFacultadDat = new FacultadDat();
        }
        public void RegistrarFacultad(Facultad objFacultad)
        {
            bool correcto = true;
            //Verificar duplicidad: error = 22
            Facultad objFacultadT = new Facultad();
            objFacultadT.Codigo = objFacultad.Codigo;
            correcto = !objFacultadDat.SelectFacultad(objFacultadT);
            if (!correcto)
            {
                objFacultad.Estado = 22;
                return;
            }
            //registro de la Facultad en la tabla
            objFacultadDat.InsertFacultad(objFacultad);
            objFacultad.Estado = 99;
        }
        public void ActualizarFacultad(Facultad objFacultad)
        {
            bool correcto = true;
            //Verificar que Facultad exista, error = 1
            Facultad objFacultadT = new Facultad();
            objFacultadT.Codigo = objFacultad.Codigo;
            correcto = objFacultadDat.SelectFacultad(objFacultadT);

            if (!correcto)
            {
                objFacultad.Estado = 1;
                return;
            }
            
            //registro de actualizacion de Facultad en tabla
            objFacultadDat.UpdateFacultad(objFacultad);
            objFacultad.Estado = 99;
        }
        public void EliminarFacultad(Facultad objFacultad)
        {
            bool correcto = true;
            //Verificar que Facultad exista, error = 1
            Facultad objFacultadT = new Facultad();
            objFacultadT.Codigo = objFacultad.Codigo;
            correcto = objFacultadDat.SelectFacultad(objFacultadT);

            if (!correcto)
            {
                objFacultad.Estado = 1;
                return;
            }
            //eliminacion de Facultad en tabla
            objFacultadDat.DeleteFacultad(objFacultad);
            objFacultad.Estado = 99;
        }

        public bool LeerFacultad(Facultad objFacultad)
        {
            return objFacultadDat.SelectFacultad(objFacultad);
        }

        public DataSet LeerFacultads()
        {
            return objFacultadDat.SelectFacultads();
        }
    }
}
