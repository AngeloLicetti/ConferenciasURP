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
    public class ConferenciaNeg
    {
        ConferenciaDat objConferenciaDat;
        public ConferenciaNeg()
        {
            objConferenciaDat = new ConferenciaDat();
        }
        public void RegistrarConferencia(Conferencia objConferencia)
        {
            bool correcto = true;
            //Verificar duplicidad: error = 22
            Conferencia objConferenciaT = new Conferencia();
            objConferenciaT.Codigo = objConferencia.Codigo;
            correcto = !objConferenciaDat.SelectConferencia(objConferenciaT);
            if (!correcto)
            {
                objConferencia.Estado = 22;
                return;
            }
            //registro de la Conferencia en la tabla
            objConferenciaDat.InsertConferencia(objConferencia);
            objConferencia.Estado = 99;
        }
        public void ActualizarConferencia(Conferencia objConferencia)
        {
            bool correcto = true;
            //Verificar que Conferencia exista, error = 1
            Conferencia objConferenciaT = new Conferencia();
            objConferenciaT.Codigo = objConferencia.Codigo;
            correcto = objConferenciaDat.SelectConferencia(objConferenciaT);

            if (!correcto)
            {
                objConferencia.Estado = 1;
                return;
            }

            //registro de actualizacion de Conferencia en tabla
            objConferenciaDat.UpdateConferencia(objConferencia);
            objConferencia.Estado = 99;
        }
        public void EliminarConferencia(Conferencia objConferencia)
        {
            bool correcto = true;
            //Verificar que Conferencia exista, error = 1
            Conferencia objConferenciaT = new Conferencia();
            objConferenciaT.Codigo = objConferencia.Codigo;
            correcto = objConferenciaDat.SelectConferencia(objConferenciaT);

            if (!correcto)
            {
                objConferencia.Estado = 1;
                return;
            }
            //eliminacion de Conferencia en tabla
            objConferenciaDat.DeleteConferencia(objConferencia);
            objConferencia.Estado = 99;
        }

        public bool LeerConferencia(Conferencia objConferencia)
        {

            return objConferenciaDat.SelectConferencia(objConferencia);
        }

        public DataSet LeerConferencias()
        {
            return objConferenciaDat.SelectConferencias();
        }

        public DataSet ReportePorConferencia(Conferencia objConferencia)
        {
            return objConferenciaDat.ReporteByCodigoConferencia(objConferencia);
        }
    }
}
