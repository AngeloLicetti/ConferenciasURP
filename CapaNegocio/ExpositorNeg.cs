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
    public class ExpositorNeg
    {
        ExpositorDat objExpositorDat;
        public ExpositorNeg()
        {
            objExpositorDat = new ExpositorDat();
        }
        public void RegistrarExpositor(Expositor objExpositor)
        {
            bool correcto = true;
            //dni de Expositor:  maximo 8 digitos; error = 1
            int nDni;
            try
            {
                nDni = int.Parse(objExpositor.Dni);
                correcto = (nDni <= 99999999 && objExpositor.Dni.Length==8);
            }
            catch
            {
                correcto = false;
            }
            if (!correcto)
            {
                objExpositor.Estado = 1;
                return;
            }
            //Apellidos: entre 2 caracter significativo y 30; error = 2
            string sApellidos = objExpositor.Apellidos.Trim();
            correcto = sApellidos.Length > 1 && sApellidos.Length < 31;
            if (!correcto)
            {
                objExpositor.Estado = 2;
                return;
            }
            objExpositor.Apellidos = sApellidos;
            //Nombres: entre 2 caracter significativo y 30; error 3
            string sNombres = objExpositor.Nombres.Trim();
            correcto = sNombres.Length > 1 && sNombres.Length < 31;
            if (!correcto)
            {
                objExpositor.Estado = 3;
                return;
            }
            objExpositor.Nombres = sNombres;
            //Empresa: maximo 60 caracteres; error = 4
            string sEspecialidad = objExpositor.Especialidad.Trim();
            correcto = sEspecialidad.Length < 60;
            if (!correcto)
            {
                objExpositor.Estado = 4;
                return;
            }
            objExpositor.Especialidad = sEspecialidad;
            //Empresa: maximo 60 caracteres; error = 5
            string sEmpresa = objExpositor.Empresa.Trim();
            correcto = sEmpresa.Length < 60;
            if (!correcto)
            {
                objExpositor.Estado = 5;
                return;
            }
            objExpositor.Empresa = sEmpresa;
            //Verificar duplicidad: error = 22
            Expositor objExpositorT = new Expositor();
            objExpositorT.Dni = objExpositor.Dni;
            correcto = !objExpositorDat.SelectExpositor(objExpositorT);
            if (!correcto)
            {
                objExpositor.Estado = 22;
                return;
            }
            //registro de la Expositor en la tabla
            objExpositorDat.InsertExpositor(objExpositor);
            objExpositor.Estado = 99;
        }
        public void ActualizarExpositor(Expositor objExpositor)
        {
            bool correcto = true;
            //Verificar que Expositor exista, error = 1
            Expositor objExpositorT = new Expositor();
            objExpositorT.Dni = objExpositor.Dni;
            correcto = objExpositorDat.SelectExpositor(objExpositorT);

            if (!correcto)
            {
                objExpositor.Estado = 1;
                return;
            }

            //Apellidos: entre 2 caracter significativo y 30; error = 2
            string sApellidos = objExpositor.Apellidos.Trim();
            correcto = sApellidos.Length > 1 && sApellidos.Length < 31;
            if (!correcto)
            {
                objExpositor.Estado = 2;
                return;
            }
            objExpositor.Apellidos = sApellidos;
            //Nombres: entre 2 caracter significativo y 30; error 3
            string sNombres = objExpositor.Nombres.Trim();
            correcto = sNombres.Length > 1 && sNombres.Length < 31;
            if (!correcto)
            {
                objExpositor.Estado = 3;
                return;
            }
            objExpositor.Nombres = sNombres;
            //Empresa: maximo 60 caracteres; error = 4
            string sEspecialidad = objExpositor.Especialidad.Trim();
            correcto = sEspecialidad.Length < 60;
            if (!correcto)
            {
                objExpositor.Estado = 4;
                return;
            }
            objExpositor.Especialidad = sEspecialidad;
            //Empresa: maximo 60 caracteres; error = 5
            string sEmpresa = objExpositor.Empresa.Trim();
            correcto = sEmpresa.Length < 60;
            if (!correcto)
            {
                objExpositor.Estado = 5;
                return;
            }
            objExpositor.Empresa = sEmpresa;
            //registro de actualizacion de Expositor en tabla
            objExpositorDat.UpdateExpositor(objExpositor);
            objExpositor.Estado = 99;
        }
        public void EliminarExpositor(Expositor objExpositor)
        {
            bool correcto = true;
            //Verificar que Expositor exista, error = 1
            Expositor objExpositorT = new Expositor();
            objExpositorT.Dni = objExpositor.Dni;
            correcto = objExpositorDat.SelectExpositor(objExpositorT);

            if (!correcto)
            {
                objExpositor.Estado = 1;
                return;
            }
            //eliminacion de Expositor en tabla
            objExpositorDat.DeleteExpositor(objExpositor);
            objExpositor.Estado = 99;
        }

        public bool LeerExpositor(Expositor objExpositor)
        {
            return objExpositorDat.SelectExpositor(objExpositor);
        }

        public DataSet LeerExpositors()
        {
            return objExpositorDat.SelectExpositors();
        }
    }
}
