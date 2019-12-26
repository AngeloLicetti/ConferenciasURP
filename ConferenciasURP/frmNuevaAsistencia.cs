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
    public partial class frmNuevaAsistencia : Form
    {
        Asistencia objAsistencia;
        AsistenciaNeg objAsistenciaNeg;
        Conferencia objConferencia;
        ConferenciaNeg objConferenciaNeg;
        Expositor objExpositor;
        ExpositorNeg objExpositorNeg;
        bool asistenciaAbierta;
        public frmNuevaAsistencia()
        {
            InitializeComponent();
            objAsistenciaNeg = new AsistenciaNeg();
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

        private void mostraMjeRegistro(Asistencia objAsistencia)
        {
            if (objAsistencia.Estado == 2)
            {
                MessageBox.Show("Codigo de alumno no existe o es incorrecto", "Atención");
            }
            if (objAsistencia.Estado == 22)
            {
                MessageBox.Show("El alumno con ese código ya está registrado", "Atención");
            }
            txtCodigoAlumno.Focus();
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

        private void mostraMjeBuscar(Conferencia objConferencia)
        {
            if (objConferencia.Estado != 99)
            {
                MessageBox.Show("Conferencia con codigo " + Convert.ToString(objConferencia.Codigo) + " no existe", "Alerta");
            }
        }

        private void desactivar()
        {
            btnBuscar.Text = "Abrir";
            txtCodigoConferencia.Enabled = true;
            txtCodigoConferencia.Clear();
            txtLugar.Clear();
            txtFecha.Clear();
            txtTema.Clear();
            txtExpositor.Clear();
            limpiarDgv();
            txtCodigoAlumno.Clear();
            txtCodigoAlumno.Enabled = false;
            btnRegistrar.Enabled = false;
            txtCodigoConferencia.Focus();
        }

        private void activar()
        {
            btnBuscar.Text = "Regresar";
            txtCodigoConferencia.Enabled = false;
            txtCodigoAlumno.Enabled = true;
            btnRegistrar.Enabled = true;
            txtCodigoAlumno.Focus();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            objAsistencia = new Asistencia();
            objAsistencia.Codigo_Conferencia = int.Parse(txtCodigoConferencia.Text);
            //objAsistencia.Hora_Entrada = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            objAsistencia.Hora_Entrada = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            objAsistencia.Codigo_Alumno = txtCodigoAlumno.Text;
            objAsistenciaNeg.RegistrarAsistencia(objAsistencia);
            mostraMjeRegistro(objAsistencia);
            if (objAsistencia.Estado == 99)
            {
                cargarDgv();
                txtCodigoAlumno.Clear();
            }
        }

        private void btnConsultarConferencias_Click(object sender, EventArgs e)
        {
            (new frmGestionarConferencia()).ShowDialog();
        }

        private void btnConsultarAlumnos_Click(object sender, EventArgs e)
        {
            (new frmGestionarAlumno()).ShowDialog();
        }
    }
}
