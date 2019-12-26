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
    public partial class frmGestionarAlumno : Form
    {
        AlumnoNeg objAlumnoNeg;
        public frmGestionarAlumno()
        {
            InitializeComponent();
            objAlumnoNeg = new AlumnoNeg();
            cargarAlumnos();
        }

        private void cargarAlumnos()
        {
            DataSet dsAlumnos = objAlumnoNeg.LeerAlumnos();
            dgvAlumnos.DataSource = dsAlumnos.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            (new frmAgregarAlumno()).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarAlumnos();
        }
    }
}
