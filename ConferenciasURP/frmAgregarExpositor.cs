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
    public partial class frmAgregarExpositor : Form
    {
        private Expositor objExpositor;
        private ExpositorNeg objExpositorNeg;

        public frmAgregarExpositor()
        {
            InitializeComponent();
            objExpositorNeg = new ExpositorNeg();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            objExpositor = new Expositor();
            objExpositor.Dni = txtDni.Text;
            objExpositor.Nombres = txtNombres.Text;
            objExpositor.Apellidos = txtApellidos.Text;
            objExpositor.Titulado = radioButton1.Checked;
            objExpositor.Especialidad = txtEspecialidad.Text;
            objExpositor.Empresa = txtEmpresa.Text;
            objExpositorNeg.RegistrarExpositor(objExpositor);
            mostrarMsjeRegistrar(objExpositor);
            if (objExpositor.Estado == 99)
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            radioButton1.Checked = true;
            txtEspecialidad.Clear();
            txtEmpresa.Clear();
        }

        private void mostrarMsjeRegistrar(Expositor objExpositor)
        {
            if (objExpositor.Estado == 99)
            {
                MessageBox.Show("Expositor registrado satisfactoriamente.", "Éxito");
            }
        }
    }
}
