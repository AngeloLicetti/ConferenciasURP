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
    public partial class frmReporteAsistencia : Form
    {
        bool asistenciaAbierta;
        Conferencia objConferencia;
        ConferenciaNeg objConferenciaNeg;
        Expositor objExpositor;
        ExpositorNeg objExpositorNeg;
        public frmReporteAsistencia()
        {
            InitializeComponent();
            objConferenciaNeg = new ConferenciaNeg();
            objExpositorNeg = new ExpositorNeg();
            asistenciaAbierta = false;
            desactivar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (asistenciaAbierta == true)
            {
                desactivar();
                asistenciaAbierta = false;
            }
            else
            {
                buscarConferencia();
            }
        }

        private void desactivar()
        {
            btnBuscar.Text = "Consultar";
            txtCodigoConferencia.Enabled = true;
            txtCodigoConferencia.Clear();
            txtLugar.Clear();
            txtFecha.Clear();
            txtTema.Clear();
            txtExpositor.Clear();
            limpiarDgv();
            btnGenerarPdf.Enabled = false;
            txtCodigoConferencia.Focus();
        }

        private void buscarConferencia()
        {
            objConferencia = new Conferencia();
            try
            {
                if (txtCodigoConferencia.Text == "")
                {
                    throw new Exception();
                }
                int cod = int.Parse(txtCodigoConferencia.Text);
                objConferencia.Codigo = cod;
            }
            catch (Exception)
            {
                objConferencia.Estado = 1;
                mostraMjeBuscar(objConferencia);
                return;
            }
            objConferenciaNeg.LeerConferencia(objConferencia);
            mostraMjeBuscar(objConferencia);
            if (objConferencia.Estado == 99)
            {
                cargarDatos();
                cargarDgv();
                asistenciaAbierta = true;
                activar();
            }
        }

        private void mostraMjeBuscar(Conferencia objConferencia)
        {
            if (objConferencia.Estado != 99)
            {
                MessageBox.Show("Conferencia con codigo " + Convert.ToString(objConferencia.Codigo) + " no existe", "Alerta");
            }
        }

        private void activar()
        {
            btnBuscar.Text = "Regresar";
            txtCodigoConferencia.Enabled = false;
            btnGenerarPdf.Enabled = true;
        }

        private void limpiarDgv()
        {
            dgvExpositors.DataSource = null;
        }

        private void cargarDgv()
        {
            try
            {
                DataSet dsReporte = objConferenciaNeg.ReportePorConferencia(objConferencia);
                dgvExpositors.DataSource = dsReporte.Tables[0];
            }
            catch
            {
                MessageBox.Show("Ocurrió un error inesperado.");
                desactivar();
            }
        }

        private void cargarDatos()
        {
            txtLugar.Text = objConferencia.Lugar;
            txtFecha.Text = objConferencia.Fecha_Inicio.ToString();
            txtTema.Text = objConferencia.Tema;

            objExpositor = new Expositor();
            objExpositor.Dni = objConferencia.Dni_Expositor;
            objExpositorNeg.LeerExpositor(objExpositor);
            if (objExpositor.Estado == 99)
            {
                txtExpositor.Text = objExpositor.Nombres + " " + objExpositor.Apellidos;
            }
        }

        private void btnConsultarConferencias_Click(object sender, EventArgs e)
        {
            (new frmGestionarConferencia()).ShowDialog();
        }

        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            ReporteAsistencia reporte = new ReporteAsistencia();
            reporte.cod_conf = Int32.Parse(txtCodigoConferencia.Text);

            reporte.ShowDialog();
        }
    }
}
