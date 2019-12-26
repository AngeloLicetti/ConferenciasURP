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
    public partial class ReporteAsistencia : Form
    {
        public ReporteAsistencia()
        {
            InitializeComponent();
        }

        public int cod_conf { get; set; }

        private void ReporteAsistencia_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.sp_ReporteByCodigoConferencia' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteByCodigoConferenciaTableAdapter.Fill(this.DataSetPrincipal.sp_ReporteByCodigoConferencia,cod_conf);
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.sp_datos_conferencia_seleccionada' Puede moverla o quitarla según sea necesario.
            this.sp_datos_conferencia_seleccionadaTableAdapter.Fill(this.DataSetPrincipal.sp_datos_conferencia_seleccionada,cod_conf);
           
            this.reportViewer1.RefreshReport();

           
        }
    }
}
