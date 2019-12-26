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
    public partial class frmAgregarConferencia : Form
    {
        private Conferencia objConferencia;
        private ConferenciaNeg objConferenciaNeg;
        private EscuelaNeg objEscuelaNeg;
        private DataSet dsEscuelas;
        private ExpositorNeg objExpositorNeg;
        private DataSet dsExpositors;

        public frmAgregarConferencia()
        {
            InitializeComponent();
            objConferenciaNeg = new ConferenciaNeg();
            objEscuelaNeg = new EscuelaNeg();
            objExpositorNeg = new ExpositorNeg();
            cargarEscuelas();
            cargarExpositors();
        }

        private void cargarEscuelas()
        {
            dsEscuelas = objEscuelaNeg.LeerEscuelas();
            //cbEscuela.DataSource = dsEscuelas.Tables[0].Rows;
            //cbEscuela.DataBindings = data
            foreach (DataRow dr in dsEscuelas.Tables[0].Rows)
            {
                cbEscuela.Items.Add(dr.Field<String>(1).ToString());
            }
        }

        private void cargarExpositors()
        {
            dsExpositors = objExpositorNeg.LeerExpositors();
            //cbExpositor.DataSource = dsExpositors.Tables[0].Rows;
            //cbExpositor.DataBindings = data
            foreach (DataRow dr in dsExpositors.Tables[0].Rows)
            {
                cbExpositor.Items.Add(dr.Field<String>(1).ToString() + " " + dr.Field<String>(2).ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            objConferencia = new Conferencia();
            objConferencia.Semestre = txtSemestre.Text;
            try
            {
                if (dtpFechaInicio.Value.Date.CompareTo(DateTime.Now.Date) < 0)
                {
                    throw new Exception();
                }
                else if(dtpFechaInicio.Value.Date.CompareTo(DateTime.Now.Date) == 0)
                {
                    if (dtpHoraInicio.Value.TimeOfDay.CompareTo(DateTime.Now.TimeOfDay) < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        objConferencia.Fecha_Inicio = dtpFechaInicio.Value.Date + dtpHoraInicio.Value.TimeOfDay;
                    }
                }
                else
                {
                    objConferencia.Fecha_Inicio = dtpFechaInicio.Value.Date + dtpHoraInicio.Value.TimeOfDay;
                }
            }
            catch
            {
                objConferencia.Estado = 3;
                mostrarMsjeRegistrar(objConferencia);
                return;
            }
            try
            {
                if (dtpFechaFin.Value.Date.CompareTo(dtpFechaInicio.Value.Date) < 0)
                {
                    throw new Exception();
                }
                else if (dtpFechaFin.Value.Date.CompareTo(dtpFechaInicio.Value.Date) == 0)
                {
                    if(dtpHoraFin.Value.TimeOfDay.CompareTo(dtpHoraInicio.Value.TimeOfDay) < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        objConferencia.Fecha_Fin = dtpFechaFin.Value.Date + dtpHoraFin.Value.TimeOfDay;
                    }
                }
                else
                {
                    objConferencia.Fecha_Fin= dtpFechaFin.Value.Date + dtpHoraFin.Value.TimeOfDay;
                }
            }
            catch
            {
                objConferencia.Estado = 4;
                mostrarMsjeRegistrar(objConferencia);
                return;
            }
            objConferencia.Lugar = txtLugar.Text;
            objConferencia.Tema = txtTema.Text;
            try
            {
                int nPeso = int.Parse(txtPeso.Text);
                objConferencia.Peso = nPeso;
            }
            catch
            {
                objConferencia.Estado = 7;
                mostrarMsjeRegistrar(objConferencia);
                return;
            }
            objConferencia.Dni_Expositor = dsExpositors.Tables[0].Rows[cbExpositor.SelectedIndex].Field<String>(0).ToString();
            objConferencia.Codigo_Escuela = dsEscuelas.Tables[0].Rows[cbEscuela.SelectedIndex].Field<String>(0).ToString();
            objConferenciaNeg.RegistrarConferencia(objConferencia);
            mostrarMsjeRegistrar(objConferencia);
            if (objConferencia.Estado == 99)
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtSemestre.Clear();
            txtLugar.Clear();
            txtTema.Clear();
            txtPeso.Clear();
            //cb
        }

        private void mostrarMsjeRegistrar(Conferencia objConferencia)
        {
            if (objConferencia.Estado == 3)
            {
                MessageBox.Show("La fecha de inicio no puede ser una fecha pasada.", "Atención");
            }
            else if (objConferencia.Estado == 4)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Atención");
            }
            else if (objConferencia.Estado == 7)
            {
                MessageBox.Show("El peso debe ser un número entero.", "Atención");
            }
            else if (objConferencia.Estado == 99)
            {
                MessageBox.Show("Conferencia registrada satisfactoriamente.", "Éxito");
            }
        }

        private void btnConsultarExpositor_Click(object sender, EventArgs e)
        {
            (new frmGestionarExpositor()).ShowDialog();
        }
    }
}
