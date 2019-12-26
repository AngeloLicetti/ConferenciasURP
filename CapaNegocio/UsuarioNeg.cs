using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuarioNeg
    {
        UsuarioDat objDatUsuario;
        public UsuarioNeg()
        {
            objDatUsuario = new UsuarioDat();
        }
        public bool LogIn(Usuario objUsuario)
        {
            return objDatUsuario.LogIn(objUsuario);
        }
    }
}
