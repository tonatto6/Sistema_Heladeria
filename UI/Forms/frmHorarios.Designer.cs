
namespace UI.Forms
{
    partial class frmHorarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaEmpleadoAtencion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSeleccionarAtencionAlPulbico = new System.Windows.Forms.Button();
            this.grdAtencionAlPublico = new System.Windows.Forms.DataGridView();
            this.grdEmpleadoDeProduccion = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusquedaEmpleadoProduccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSeleccionarEncargadoProduccion = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHoraFin = new System.Windows.Forms.TextBox();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadEmpleados = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdEmpleados = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtencionAlPublico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleadoDeProduccion)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusquedaEmpleadoAtencion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSeleccionarAtencionAlPulbico);
            this.groupBox1.Controls.Add(this.grdAtencionAlPublico);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empleados de atencion al publico";
            // 
            // txtBusquedaEmpleadoAtencion
            // 
            this.txtBusquedaEmpleadoAtencion.Location = new System.Drawing.Point(187, 53);
            this.txtBusquedaEmpleadoAtencion.Name = "txtBusquedaEmpleadoAtencion";
            this.txtBusquedaEmpleadoAtencion.Size = new System.Drawing.Size(253, 22);
            this.txtBusquedaEmpleadoAtencion.TabIndex = 22;
            this.txtBusquedaEmpleadoAtencion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaEmpleadoAtencion_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Buscar empleado";
            // 
            // btnSeleccionarAtencionAlPulbico
            // 
            this.btnSeleccionarAtencionAlPulbico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSeleccionarAtencionAlPulbico.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarAtencionAlPulbico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarAtencionAlPulbico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarAtencionAlPulbico.Location = new System.Drawing.Point(343, 283);
            this.btnSeleccionarAtencionAlPulbico.Name = "btnSeleccionarAtencionAlPulbico";
            this.btnSeleccionarAtencionAlPulbico.Size = new System.Drawing.Size(97, 34);
            this.btnSeleccionarAtencionAlPulbico.TabIndex = 8;
            this.btnSeleccionarAtencionAlPulbico.Text = "Seleccionar";
            this.btnSeleccionarAtencionAlPulbico.UseVisualStyleBackColor = false;
            this.btnSeleccionarAtencionAlPulbico.Click += new System.EventHandler(this.btnSeleccionarAtencionAlPulbico_Click);
            // 
            // grdAtencionAlPublico
            // 
            this.grdAtencionAlPublico.AllowUserToAddRows = false;
            this.grdAtencionAlPublico.AllowUserToDeleteRows = false;
            this.grdAtencionAlPublico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAtencionAlPublico.BackgroundColor = System.Drawing.Color.White;
            this.grdAtencionAlPublico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAtencionAlPublico.Location = new System.Drawing.Point(28, 88);
            this.grdAtencionAlPublico.Name = "grdAtencionAlPublico";
            this.grdAtencionAlPublico.ReadOnly = true;
            this.grdAtencionAlPublico.Size = new System.Drawing.Size(412, 182);
            this.grdAtencionAlPublico.TabIndex = 1;
            // 
            // grdEmpleadoDeProduccion
            // 
            this.grdEmpleadoDeProduccion.AllowUserToAddRows = false;
            this.grdEmpleadoDeProduccion.AllowUserToDeleteRows = false;
            this.grdEmpleadoDeProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEmpleadoDeProduccion.BackgroundColor = System.Drawing.Color.White;
            this.grdEmpleadoDeProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmpleadoDeProduccion.Location = new System.Drawing.Point(41, 88);
            this.grdEmpleadoDeProduccion.Name = "grdEmpleadoDeProduccion";
            this.grdEmpleadoDeProduccion.ReadOnly = true;
            this.grdEmpleadoDeProduccion.Size = new System.Drawing.Size(412, 182);
            this.grdEmpleadoDeProduccion.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusquedaEmpleadoProduccion);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnSeleccionarEncargadoProduccion);
            this.groupBox2.Controls.Add(this.grdEmpleadoDeProduccion);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(504, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 361);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empleados de produccion";
            // 
            // txtBusquedaEmpleadoProduccion
            // 
            this.txtBusquedaEmpleadoProduccion.Location = new System.Drawing.Point(200, 53);
            this.txtBusquedaEmpleadoProduccion.Name = "txtBusquedaEmpleadoProduccion";
            this.txtBusquedaEmpleadoProduccion.Size = new System.Drawing.Size(253, 22);
            this.txtBusquedaEmpleadoProduccion.TabIndex = 23;
            this.txtBusquedaEmpleadoProduccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaEmpleadoProduccion_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Buscar empleado";
            // 
            // btnSeleccionarEncargadoProduccion
            // 
            this.btnSeleccionarEncargadoProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSeleccionarEncargadoProduccion.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarEncargadoProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarEncargadoProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarEncargadoProduccion.Location = new System.Drawing.Point(356, 283);
            this.btnSeleccionarEncargadoProduccion.Name = "btnSeleccionarEncargadoProduccion";
            this.btnSeleccionarEncargadoProduccion.Size = new System.Drawing.Size(97, 34);
            this.btnSeleccionarEncargadoProduccion.TabIndex = 9;
            this.btnSeleccionarEncargadoProduccion.Text = "Seleccionar";
            this.btnSeleccionarEncargadoProduccion.UseVisualStyleBackColor = false;
            this.btnSeleccionarEncargadoProduccion.Click += new System.EventHandler(this.btnSeleccionarEncargadoProduccion_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtHoraFin);
            this.groupBox3.Controls.Add(this.txtHoraInicio);
            this.groupBox3.Controls.Add(this.dtpFecha);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAceptar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtCantidadEmpleados);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.grdEmpleados);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(997, 325);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Horario";
            // 
            // txtHoraFin
            // 
            this.txtHoraFin.Location = new System.Drawing.Point(228, 167);
            this.txtHoraFin.Name = "txtHoraFin";
            this.txtHoraFin.Size = new System.Drawing.Size(212, 22);
            this.txtHoraFin.TabIndex = 19;
            this.txtHoraFin.Text = "13:00";
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(228, 114);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(212, 22);
            this.txtHoraInicio.TabIndex = 18;
            this.txtHoraInicio.Text = "12:00";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(228, 61);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(212, 22);
            this.dtpFecha.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hora fin";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(733, 271);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 34);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(848, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 34);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Lista de empleados atencion";
            // 
            // txtCantidadEmpleados
            // 
            this.txtCantidadEmpleados.Location = new System.Drawing.Point(228, 220);
            this.txtCantidadEmpleados.Name = "txtCantidadEmpleados";
            this.txtCantidadEmpleados.Size = new System.Drawing.Size(212, 22);
            this.txtCantidadEmpleados.TabIndex = 15;
            this.txtCantidadEmpleados.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cantidad de empleados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hora inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha";
            // 
            // grdEmpleados
            // 
            this.grdEmpleados.AllowUserToAddRows = false;
            this.grdEmpleados.AllowUserToDeleteRows = false;
            this.grdEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.grdEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEmpleados.Location = new System.Drawing.Point(569, 61);
            this.grdEmpleados.Name = "grdEmpleados";
            this.grdEmpleados.ReadOnly = true;
            this.grdEmpleados.Size = new System.Drawing.Size(376, 182);
            this.grdEmpleados.TabIndex = 9;
            // 
            // frmHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 752);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHorarios";
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.frmHorarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtencionAlPublico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleadoDeProduccion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdAtencionAlPublico;
        private System.Windows.Forms.DataGridView grdEmpleadoDeProduccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSeleccionarAtencionAlPulbico;
        private System.Windows.Forms.Button btnSeleccionarEncargadoProduccion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdEmpleados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadEmpleados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtHoraFin;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBusquedaEmpleadoAtencion;
        private System.Windows.Forms.TextBox txtBusquedaEmpleadoProduccion;
        private System.Windows.Forms.Label label7;
    }
}