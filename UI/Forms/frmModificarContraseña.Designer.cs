
namespace UI.Forms
{
    partial class frmModificarContraseña
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
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEncargadoProduccion = new System.Windows.Forms.CheckBox();
            this.cbAtencionAlPublico = new System.Windows.Forms.CheckBox();
            this.cbJefe = new System.Windows.Forms.CheckBox();
            this.txtCancelar = new System.Windows.Forms.Button();
            this.btnAaceptar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepetirContraseña = new System.Windows.Forms.TextBox();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(191, 56);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(183, 22);
            this.txtDNI.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtCancelar);
            this.groupBox1.Controls.Add(this.btnAaceptar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRepetirContraseña);
            this.groupBox1.Controls.Add(this.txtNuevaContraseña);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(47, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 476);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEncargadoProduccion);
            this.groupBox2.Controls.Add(this.cbAtencionAlPublico);
            this.groupBox2.Controls.Add(this.cbJefe);
            this.groupBox2.Location = new System.Drawing.Point(77, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 143);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar ";
            // 
            // cbEncargadoProduccion
            // 
            this.cbEncargadoProduccion.AutoSize = true;
            this.cbEncargadoProduccion.Location = new System.Drawing.Point(19, 104);
            this.cbEncargadoProduccion.Name = "cbEncargadoProduccion";
            this.cbEncargadoProduccion.Size = new System.Drawing.Size(206, 20);
            this.cbEncargadoProduccion.TabIndex = 10;
            this.cbEncargadoProduccion.Text = "Encargado de produccion";
            this.cbEncargadoProduccion.UseVisualStyleBackColor = true;
            this.cbEncargadoProduccion.Click += new System.EventHandler(this.cbEncargadoProduccion_Click);
            // 
            // cbAtencionAlPublico
            // 
            this.cbAtencionAlPublico.AutoSize = true;
            this.cbAtencionAlPublico.Location = new System.Drawing.Point(19, 68);
            this.cbAtencionAlPublico.Name = "cbAtencionAlPublico";
            this.cbAtencionAlPublico.Size = new System.Drawing.Size(188, 20);
            this.cbAtencionAlPublico.TabIndex = 9;
            this.cbAtencionAlPublico.Text = "Encargado de atencion";
            this.cbAtencionAlPublico.UseVisualStyleBackColor = true;
            this.cbAtencionAlPublico.Click += new System.EventHandler(this.cbAtencionAlPublico_Click);
            // 
            // cbJefe
            // 
            this.cbJefe.AutoSize = true;
            this.cbJefe.Checked = true;
            this.cbJefe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbJefe.Location = new System.Drawing.Point(19, 31);
            this.cbJefe.Name = "cbJefe";
            this.cbJefe.Size = new System.Drawing.Size(57, 20);
            this.cbJefe.TabIndex = 8;
            this.cbJefe.Text = "Jefe";
            this.cbJefe.UseVisualStyleBackColor = true;
            this.cbJefe.Click += new System.EventHandler(this.cbJefe_Click);
            // 
            // txtCancelar
            // 
            this.txtCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCancelar.FlatAppearance.BorderSize = 0;
            this.txtCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCancelar.Location = new System.Drawing.Point(211, 424);
            this.txtCancelar.Name = "txtCancelar";
            this.txtCancelar.Size = new System.Drawing.Size(97, 34);
            this.txtCancelar.TabIndex = 9;
            this.txtCancelar.Text = "Cancelar";
            this.txtCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAaceptar
            // 
            this.btnAaceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAaceptar.FlatAppearance.BorderSize = 0;
            this.btnAaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAaceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAaceptar.Location = new System.Drawing.Point(77, 424);
            this.btnAaceptar.Name = "btnAaceptar";
            this.btnAaceptar.Size = new System.Drawing.Size(97, 34);
            this.btnAaceptar.TabIndex = 8;
            this.btnAaceptar.Text = "Aceptar";
            this.btnAaceptar.UseVisualStyleBackColor = false;
            this.btnAaceptar.Click += new System.EventHandler(this.btnAaceptar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Repetir contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nueva contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // txtRepetirContraseña
            // 
            this.txtRepetirContraseña.Location = new System.Drawing.Point(191, 200);
            this.txtRepetirContraseña.Name = "txtRepetirContraseña";
            this.txtRepetirContraseña.Size = new System.Drawing.Size(183, 22);
            this.txtRepetirContraseña.TabIndex = 4;
            this.txtRepetirContraseña.UseSystemPasswordChar = true;
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Location = new System.Drawing.Point(191, 152);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(183, 22);
            this.txtNuevaContraseña.TabIndex = 3;
            this.txtNuevaContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(191, 104);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(183, 22);
            this.txtUsuario.TabIndex = 2;
            // 
            // frmModificarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(508, 515);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmModificarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar contraseña";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRepetirContraseña;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtCancelar;
        private System.Windows.Forms.Button btnAaceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEncargadoProduccion;
        private System.Windows.Forms.CheckBox cbAtencionAlPublico;
        private System.Windows.Forms.CheckBox cbJefe;
    }
}