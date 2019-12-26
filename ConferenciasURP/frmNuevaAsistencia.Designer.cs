namespace ConferenciasURP
{
    partial class frmNuevaAsistencia
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
            this.dgvExpositors = new System.Windows.Forms.DataGridView();
            this.txtCodigoConferencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultarConferencias = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpositor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoAlumno = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnConsultarAlumnos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpositors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExpositors
            // 
            this.dgvExpositors.AllowUserToAddRows = false;
            this.dgvExpositors.AllowUserToDeleteRows = false;
            this.dgvExpositors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpositors.Enabled = false;
            this.dgvExpositors.Location = new System.Drawing.Point(56, 159);
            this.dgvExpositors.Name = "dgvExpositors";
            this.dgvExpositors.Size = new System.Drawing.Size(964, 309);
            this.dgvExpositors.TabIndex = 1;
            // 
            // txtCodigoConferencia
            // 
            this.txtCodigoConferencia.Location = new System.Drawing.Point(179, 24);
            this.txtCodigoConferencia.Name = "txtCodigoConferencia";
            this.txtCodigoConferencia.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConferencia.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo de conferencia:";
            // 
            // btnConsultarConferencias
            // 
            this.btnConsultarConferencias.Location = new System.Drawing.Point(63, 61);
            this.btnConsultarConferencias.Name = "btnConsultarConferencias";
            this.btnConsultarConferencias.Size = new System.Drawing.Size(146, 23);
            this.btnConsultarConferencias.TabIndex = 4;
            this.btnConsultarConferencias.Text = "Consultar conferencias";
            this.btnConsultarConferencias.UseVisualStyleBackColor = true;
            this.btnConsultarConferencias.Click += new System.EventHandler(this.btnConsultarConferencias_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(297, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtLugar
            // 
            this.txtLugar.Enabled = false;
            this.txtLugar.Location = new System.Drawing.Point(106, 110);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(173, 20);
            this.txtLugar.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lugar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(340, 110);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(178, 20);
            this.txtFecha.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Expositor:";
            // 
            // txtExpositor
            // 
            this.txtExpositor.Enabled = false;
            this.txtExpositor.Location = new System.Drawing.Point(838, 110);
            this.txtExpositor.Name = "txtExpositor";
            this.txtExpositor.Size = new System.Drawing.Size(182, 20);
            this.txtExpositor.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tema:";
            // 
            // txtTema
            // 
            this.txtTema.Enabled = false;
            this.txtTema.Location = new System.Drawing.Point(581, 110);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(176, 20);
            this.txtTema.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Asistencia:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Registrar asistencia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código de alumno:";
            // 
            // txtCodigoAlumno
            // 
            this.txtCodigoAlumno.Location = new System.Drawing.Point(158, 517);
            this.txtCodigoAlumno.Name = "txtCodigoAlumno";
            this.txtCodigoAlumno.Size = new System.Drawing.Size(173, 20);
            this.txtCodigoAlumno.TabIndex = 17;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(366, 515);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 18;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnConsultarAlumnos
            // 
            this.btnConsultarAlumnos.Location = new System.Drawing.Point(56, 561);
            this.btnConsultarAlumnos.Name = "btnConsultarAlumnos";
            this.btnConsultarAlumnos.Size = new System.Drawing.Size(146, 23);
            this.btnConsultarAlumnos.TabIndex = 19;
            this.btnConsultarAlumnos.Text = "Consultar alumnos";
            this.btnConsultarAlumnos.UseVisualStyleBackColor = true;
            this.btnConsultarAlumnos.Click += new System.EventHandler(this.btnConsultarAlumnos_Click);
            // 
            // frmNuevaAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConferenciasURP.Properties.Resources.fondo7;
            this.ClientSize = new System.Drawing.Size(1029, 596);
            this.Controls.Add(this.btnConsultarAlumnos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCodigoAlumno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExpositor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnConsultarConferencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoConferencia);
            this.Controls.Add(this.dgvExpositors);
            this.Name = "frmNuevaAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpositors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpositors;
        private System.Windows.Forms.TextBox txtCodigoConferencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarConferencias;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExpositor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoAlumno;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnConsultarAlumnos;
    }
}