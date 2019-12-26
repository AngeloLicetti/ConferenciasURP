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
    public partial class frmGestionarExpositor : Form
    {
        ExpositorNeg objExpositorNeg;
        public frmGestionarExpositor()
        {
            InitializeComponent();
            objExpositorNeg = new ExpositorNeg();
            cargarExpositors();
        }

        private void cargarExpositors()
        {
            DataSet dsExpositors = objExpositorNeg.LeerExpositors();
            dgvExpositors.DataSource = dsExpositors.Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            (new frmAgregarExpositor()).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarExpositors();
        }
    }
}
