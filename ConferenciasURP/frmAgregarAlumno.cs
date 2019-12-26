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
    public partial class frmAgregarAlumno : Form
    {
        private Alumno objAlumno;
        private AlumnoNeg objAlumnoNeg;
        private EscuelaNeg objEscuelaNeg;
        private DataSet dsEscuelas;

        public frmAgregarAlumno()
        {
            InitializeComponent();
            objAlumnoNeg = new AlumnoNeg();
            objEscuelaNeg = new EscuelaNeg();
            cargarEscuelas();
        }

        private void cargarEscuelas()
        {
            dsEscuelas = objEscuelaNeg.LeerEscuelas();
            //cbEscuela.DataSource = dsEscuelas.Tables[0].Rows;
            //cbEscuela.DataBindings = data
            foreach(DataRow dr in dsEscuelas.Tables[0].Rows)
            {
                cbEscuela.Items.Add(dr.Field<String>(1).ToString());
            }
            cbEscuela.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            objAlumno = new Alumno();
            objAlumno.Codigo = txtCodigo.Text;
            objAlumno.Nombres = txtNombres.Text;
            objAlumno.Apellidos = txtApellidos.Text;
            objAlumno.Codigo = txtCodigo.Text;
            //esc
            objAlumno.Codigo_Escuela = dsEscuelas.Tables[0].Rows[cbEscuela.SelectedIndex].Field<String>(0).ToString();
            objAlumnoNeg.RegistrarAlumno(objAlumno);
            mostrarMsjeRegistrar(objAlumno);
            if (objAlumno.Estado == 99)
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            //cb
        }

        private void mostrarMsjeRegistrar(Alumno objAlumno)
        {
            if (objAlumno.Estado == 4)
            {
                MessageBox.Show("La escuela no existe.", "Atención");
            }
            else if (objAlumno.Estado == 99)
            {
                MessageBox.Show("Alumno registrado satisfactoriamente.", "Éxito");
            }
        }
    }
}
