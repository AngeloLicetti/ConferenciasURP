namespace ConferenciasURP
{
    partial class frmReporteAsistencia
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnConsultarConferencias = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoConferencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvExpositors = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpositor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.btnGenerarPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpositors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(282, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnConsultarConferencias
            // 
            this.btnConsultarConferencias.Location = new System.Drawing.Point(48, 70);
            this.btnConsultarConferencias.Name = "btnConsultarConferencias";
            this.btnConsultarConferencias.Size = new System.Drawing.Size(146, 23);
            this.btnConsultarConferencias.TabIndex = 8;
            this.btnConsultarConferencias.Text = "Consultar conferencias";
            this.btnConsultarConferencias.UseVisualStyleBackColor = true;
            this.btnConsultarConferencias.Click += new System.EventHandler(this.btnConsultarConferencias_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Codigo de conferencia:";
            // 
            // txtCodigoConferencia
            // 
            this.txtCodigoConferencia.Location = new System.Drawing.Point(164, 33);
            this.txtCodigoConferencia.Name = "txtCodigoConferencia";
            this.txtCodigoConferencia.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConferencia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Asistencia:";
            // 
            // dgvExpositors
            // 
            this.dgvExpositors.AllowUserToAddRows = false;
            this.dgvExpositors.AllowUserToDeleteRows = false;
            this.dgvExpositors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpositors.Enabled = false;
            this.dgvExpositors.Location = new System.Drawing.Point(44, 162);
            this.dgvExpositors.Name = "dgvExpositors";
            this.dgvExpositors.Size = new System.Drawing.Size(964, 332);
            this.dgvExpositors.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(771, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Expositor:";
            // 
            // txtExpositor
            // 
            this.txtExpositor.Enabled = false;
            this.txtExpositor.Location = new System.Drawing.Point(830, 106);
            this.txtExpositor.Name = "txtExpositor";
            this.txtExpositor.Size = new System.Drawing.Size(182, 20);
            this.txtExpositor.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Tema:";
            // 
            // txtTema
            // 
            this.txtTema.Enabled = false;
            this.txtTema.Location = new System.Drawing.Point(573, 106);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(176, 20);
            this.txtTema.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(332, 106);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(178, 20);
            this.txtFecha.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Lugar:";
            // 
            // txtLugar
            // 
            this.txtLugar.Enabled = false;
            this.txtLugar.Location = new System.Drawing.Point(98, 106);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(173, 20);
            this.txtLugar.TabIndex = 17;
            // 
            // btnGenerarPdf
            // 
            this.btnGenerarPdf.Location = new System.Drawing.Point(44, 516);
            this.btnGenerarPdf.Name = "btnGenerarPdf";
            this.btnGenerarPdf.Size = new System.Drawing.Size(114, 23);
            this.btnGenerarPdf.TabIndex = 25;
            this.btnGenerarPdf.Text = "Generar PDF:";
            this.btnGenerarPdf.UseVisualStyleBackColor = true;
            this.btnGenerarPdf.Click += new System.EventHandler(this.btnGenerarPdf_Click);
            // 
            // frmReporteAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConferenciasURP.Properties.Resources.fondo7;
            this.ClientSize = new System.Drawing.Size(1049, 562);
            this.Controls.Add(this.btnGenerarPdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExpositor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvExpositors);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnConsultarConferencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoConferencia);
            this.Name = "frmReporteAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpositors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnConsultarConferencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoConferencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvExpositors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExpositor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Button btnGenerarPdf;
    }
}