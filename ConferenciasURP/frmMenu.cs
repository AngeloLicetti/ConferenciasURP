using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferenciasURP
{
    public partial class frmMenu : Form
    {
        frmLogIn objFrmLogIn;
        public frmMenu(frmLogIn objFrmLogIn)
        {
            InitializeComponent();
            this.objFrmLogIn = objFrmLogIn;
        }

        private void expositorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmGestionarExpositor()).ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            objFrmLogIn.Show();
        }

        private void nuevaAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmNuevaAsistencia()).ShowDialog();
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmGestionarAlumno()).ShowDialog();
        }

        private void conferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmGestionarConferencia()).ShowDialog();
        }

        private void asistenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new frmReporteAsistencia()).ShowDialog();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmAyuda()).ShowDialog();
        }
    }
}
