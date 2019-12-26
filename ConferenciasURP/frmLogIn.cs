using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using CapaNegocio;

namespace ConferenciasURP
{
    public partial class frmLogIn : Form
    {
        UsuarioNeg objNegUsuario;
        Usuario objUsuario;
        public frmLogIn()
        {
            InitializeComponent();
            objNegUsuario = new UsuarioNeg();
            objUsuario = new Usuario();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            objUsuario.Usuraio = txtUsuario.Text;
            objUsuario.Contrasena = txtContrasena.Text;
            if (objNegUsuario.LogIn(objUsuario))
            {
                this.Hide();
                txtUsuario.Clear();
                txtContrasena.Clear();
                txtUsuario.Focus();
                (new frmMenu(this)).Show();
                (new frmAyuda()).ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
