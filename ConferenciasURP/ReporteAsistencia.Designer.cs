namespace ConferenciasURP
{
    partial class ReporteAsistencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteByCodigoConferenciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPrincipal = new ConferenciasURP.DataSetPrincipal();
            this.sp_datos_conferencia_seleccionadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteByCodigoConferenciaTableAdapter = new ConferenciasURP.DataSetPrincipalTableAdapters.sp_ReporteByCodigoConferenciaTableAdapter();
            this.sp_datos_conferencia_seleccionadaTableAdapter = new ConferenciasURP.DataSetPrincipalTableAdapters.sp_datos_conferencia_seleccionadaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteByCodigoConferenciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_datos_conferencia_seleccionadaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_ReporteByCodigoConferenciaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.sp_datos_conferencia_seleccionadaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ConferenciasURP.ReporteAsistenciaMOD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReporteByCodigoConferenciaBindingSource
            // 
            this.sp_ReporteByCodigoConferenciaBindingSource.DataMember = "sp_ReporteByCodigoConferencia";
            this.sp_ReporteByCodigoConferenciaBindingSource.DataSource = this.DataSetPrincipal;
            // 
            // DataSetPrincipal
            // 
            this.DataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.DataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_datos_conferencia_seleccionadaBindingSource
            // 
            this.sp_datos_conferencia_seleccionadaBindingSource.DataMember = "sp_datos_conferencia_seleccionada";
            this.sp_datos_conferencia_seleccionadaBindingSource.DataSource = this.DataSetPrincipal;
            // 
            // sp_ReporteByCodigoConferenciaTableAdapter
            // 
            this.sp_ReporteByCodigoConferenciaTableAdapter.ClearBeforeFill = true;
            // 
            // sp_datos_conferencia_seleccionadaTableAdapter
            // 
            this.sp_datos_conferencia_seleccionadaTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteAsistencia";
            this.Text = "ReporteAsistencia";
            this.Load += new System.EventHandler(this.ReporteAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteByCodigoConferenciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_datos_conferencia_seleccionadaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteByCodigoConferenciaBindingSource;
        private DataSetPrincipal DataSetPrincipal;
        private DataSetPrincipalTableAdapters.sp_ReporteByCodigoConferenciaTableAdapter sp_ReporteByCodigoConferenciaTableAdapter;
        private System.Windows.Forms.BindingSource sp_datos_conferencia_seleccionadaBindingSource;
        private DataSetPrincipalTableAdapters.sp_datos_conferencia_seleccionadaTableAdapter sp_datos_conferencia_seleccionadaTableAdapter;
    }
}