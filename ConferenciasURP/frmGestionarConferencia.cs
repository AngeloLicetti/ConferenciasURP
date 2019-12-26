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
    public partial class frmGestionarConferencia : Form
    {
        ConferenciaNeg objConferenciaNeg;
        public frmGestionarConferencia()
        {
            InitializeComponent();
            objConferenciaNeg = new ConferenciaNeg();
            cargarConferencias();
        }

        private void cargarConferencias()
        {
            DataSet dsConferencias = objConferenciaNeg.LeerConferencias();
            dgvConferencias.DataSource = dsConferencias.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            (new frmAgregarConferencia()).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarConferencias();
        }
    }
}
