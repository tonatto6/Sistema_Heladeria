
namespace UI.Forms
{
    partial class frmPersonal
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
            this.grdEncargadoProduccion = new System.Windows.Forms.DataGridView();
            this.btnAgregarEncargadoProduccion = new System.Windows.Forms.Button();
            this.btnEliminarEncargadoProduccion = new System.Windows.Forms.Button();
            this.btnModificarEncargadoProduccion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusquedaEncargadoProduccion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdAtencionAlPublico = new System.Windows.Forms.DataGridView();
            this.txtBusquedaAtencionAlPublico = new System.Windows.Forms.TextBox();
            this.btnModificarAtencionAlPublico = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminarAtencionAlPublico = new System.Windows.Forms.Button();
            this.btnAgregarAtencionAlPublico = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdVerContactosProduccion = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdVerContactosAtencion = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnOcultar = new System.Windows.Forms.Button();
            this.btnAgregarNuevoContacto = new System.Windows.Forms.Button();
            this.btnEliminarContacto = new System.Windows.Forms.Button();
            this.btnModificarContacto = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModificarContacto = new System.Windows.Forms.TextBox();
            this.grdModificarContactos = new System.Windows.Forms.DataGridView();
            this.btnContactosProduccion = new System.Windows.Forms.Button();
            this.btnContactosAtencion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdEncargadoProduccion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtencionAlPublico)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerContactosProduccion)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerContactosAtencion)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModificarContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEncargadoProduccion
            // 
            this.grdEncargadoProduccion.AllowUserToAddRows = false;
            this.grdEncargadoProduccion.AllowUserToDeleteRows = false;
            this.grdEncargadoProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEncargadoProduccion.BackgroundColor = System.Drawing.Color.White;
            this.grdEncargadoProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEncargadoProduccion.Location = new System.Drawing.Point(26, 73);
            this.grdEncargadoProduccion.Name = "grdEncargadoProduccion";
            this.grdEncargadoProduccion.ReadOnly = true;
            this.grdEncargadoProduccion.Size = new System.Drawing.Size(611, 271);
            this.grdEncargadoProduccion.TabIndex = 0;
            this.grdEncargadoProduccion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEncargadoProduccion_CellClick);
            // 
            // btnAgregarEncargadoProduccion
            // 
            this.btnAgregarEncargadoProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarEncargadoProduccion.FlatAppearance.BorderSize = 0;
            this.btnAgregarEncargadoProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEncargadoProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEncargadoProduccion.Location = new System.Drawing.Point(26, 360);
            this.btnAgregarEncargadoProduccion.Name = "btnAgregarEncargadoProduccion";
            this.btnAgregarEncargadoProduccion.Size = new System.Drawing.Size(103, 34);
            this.btnAgregarEncargadoProduccion.TabIndex = 1;
            this.btnAgregarEncargadoProduccion.Text = "Agregar";
            this.btnAgregarEncargadoProduccion.UseVisualStyleBackColor = false;
            this.btnAgregarEncargadoProduccion.Click += new System.EventHandler(this.btnAgregarEncargadoProduccion_Click);
            // 
            // btnEliminarEncargadoProduccion
            // 
            this.btnEliminarEncargadoProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarEncargadoProduccion.FlatAppearance.BorderSize = 0;
            this.btnEliminarEncargadoProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEncargadoProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarEncargadoProduccion.Location = new System.Drawing.Point(148, 360);
            this.btnEliminarEncargadoProduccion.Name = "btnEliminarEncargadoProduccion";
            this.btnEliminarEncargadoProduccion.Size = new System.Drawing.Size(103, 34);
            this.btnEliminarEncargadoProduccion.TabIndex = 2;
            this.btnEliminarEncargadoProduccion.Text = "Eliminar";
            this.btnEliminarEncargadoProduccion.UseVisualStyleBackColor = false;
            this.btnEliminarEncargadoProduccion.Click += new System.EventHandler(this.btnEliminarEncargadoProduccion_Click);
            // 
            // btnModificarEncargadoProduccion
            // 
            this.btnModificarEncargadoProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificarEncargadoProduccion.FlatAppearance.BorderSize = 0;
            this.btnModificarEncargadoProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarEncargadoProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarEncargadoProduccion.Location = new System.Drawing.Point(270, 360);
            this.btnModificarEncargadoProduccion.Name = "btnModificarEncargadoProduccion";
            this.btnModificarEncargadoProduccion.Size = new System.Drawing.Size(103, 34);
            this.btnModificarEncargadoProduccion.TabIndex = 3;
            this.btnModificarEncargadoProduccion.Text = "Modificar";
            this.btnModificarEncargadoProduccion.UseVisualStyleBackColor = false;
            this.btnModificarEncargadoProduccion.Click += new System.EventHandler(this.btnModificarEncargadoProduccion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar encargado de produccion por apellido";
            // 
            // txtBusquedaEncargadoProduccion
            // 
            this.txtBusquedaEncargadoProduccion.Location = new System.Drawing.Point(365, 39);
            this.txtBusquedaEncargadoProduccion.Name = "txtBusquedaEncargadoProduccion";
            this.txtBusquedaEncargadoProduccion.Size = new System.Drawing.Size(272, 22);
            this.txtBusquedaEncargadoProduccion.TabIndex = 5;
            this.txtBusquedaEncargadoProduccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaEncargadoProduccion_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnContactosProduccion);
            this.groupBox1.Controls.Add(this.grdEncargadoProduccion);
            this.groupBox1.Controls.Add(this.txtBusquedaEncargadoProduccion);
            this.groupBox1.Controls.Add(this.btnModificarEncargadoProduccion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEliminarEncargadoProduccion);
            this.groupBox1.Controls.Add(this.btnAgregarEncargadoProduccion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 414);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encargados de producción";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnContactosAtencion);
            this.groupBox2.Controls.Add(this.grdAtencionAlPublico);
            this.groupBox2.Controls.Add(this.txtBusquedaAtencionAlPublico);
            this.groupBox2.Controls.Add(this.btnModificarAtencionAlPublico);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnEliminarAtencionAlPublico);
            this.groupBox2.Controls.Add(this.btnAgregarAtencionAlPublico);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(705, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 414);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encargados de atención al publico";
            // 
            // grdAtencionAlPublico
            // 
            this.grdAtencionAlPublico.AllowUserToAddRows = false;
            this.grdAtencionAlPublico.AllowUserToDeleteRows = false;
            this.grdAtencionAlPublico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAtencionAlPublico.BackgroundColor = System.Drawing.Color.White;
            this.grdAtencionAlPublico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAtencionAlPublico.Location = new System.Drawing.Point(26, 73);
            this.grdAtencionAlPublico.Name = "grdAtencionAlPublico";
            this.grdAtencionAlPublico.ReadOnly = true;
            this.grdAtencionAlPublico.Size = new System.Drawing.Size(601, 271);
            this.grdAtencionAlPublico.TabIndex = 0;
            this.grdAtencionAlPublico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAtencionAlPublico_CellClick);
            // 
            // txtBusquedaAtencionAlPublico
            // 
            this.txtBusquedaAtencionAlPublico.Location = new System.Drawing.Point(350, 39);
            this.txtBusquedaAtencionAlPublico.Name = "txtBusquedaAtencionAlPublico";
            this.txtBusquedaAtencionAlPublico.Size = new System.Drawing.Size(277, 22);
            this.txtBusquedaAtencionAlPublico.TabIndex = 5;
            this.txtBusquedaAtencionAlPublico.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaAtencionAlPublico_KeyUp);
            // 
            // btnModificarAtencionAlPublico
            // 
            this.btnModificarAtencionAlPublico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificarAtencionAlPublico.FlatAppearance.BorderSize = 0;
            this.btnModificarAtencionAlPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarAtencionAlPublico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarAtencionAlPublico.Location = new System.Drawing.Point(270, 360);
            this.btnModificarAtencionAlPublico.Name = "btnModificarAtencionAlPublico";
            this.btnModificarAtencionAlPublico.Size = new System.Drawing.Size(103, 34);
            this.btnModificarAtencionAlPublico.TabIndex = 3;
            this.btnModificarAtencionAlPublico.Text = "Modificar";
            this.btnModificarAtencionAlPublico.UseVisualStyleBackColor = false;
            this.btnModificarAtencionAlPublico.Click += new System.EventHandler(this.btnModificarAtencionAlPublico_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar encargado de atencion por apellido";
            // 
            // btnEliminarAtencionAlPublico
            // 
            this.btnEliminarAtencionAlPublico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarAtencionAlPublico.FlatAppearance.BorderSize = 0;
            this.btnEliminarAtencionAlPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAtencionAlPublico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAtencionAlPublico.Location = new System.Drawing.Point(148, 360);
            this.btnEliminarAtencionAlPublico.Name = "btnEliminarAtencionAlPublico";
            this.btnEliminarAtencionAlPublico.Size = new System.Drawing.Size(103, 34);
            this.btnEliminarAtencionAlPublico.TabIndex = 2;
            this.btnEliminarAtencionAlPublico.Text = "Eliminar";
            this.btnEliminarAtencionAlPublico.UseVisualStyleBackColor = false;
            this.btnEliminarAtencionAlPublico.Click += new System.EventHandler(this.btnEliminarAtencionAlPublico_Click);
            // 
            // btnAgregarAtencionAlPublico
            // 
            this.btnAgregarAtencionAlPublico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarAtencionAlPublico.FlatAppearance.BorderSize = 0;
            this.btnAgregarAtencionAlPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAtencionAlPublico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAtencionAlPublico.Location = new System.Drawing.Point(26, 360);
            this.btnAgregarAtencionAlPublico.Name = "btnAgregarAtencionAlPublico";
            this.btnAgregarAtencionAlPublico.Size = new System.Drawing.Size(103, 34);
            this.btnAgregarAtencionAlPublico.TabIndex = 1;
            this.btnAgregarAtencionAlPublico.Text = "Agregar";
            this.btnAgregarAtencionAlPublico.UseVisualStyleBackColor = false;
            this.btnAgregarAtencionAlPublico.Click += new System.EventHandler(this.btnAgregarAtencionAlPublico_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdVerContactosProduccion);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(26, 460);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 214);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contactos";
            // 
            // grdVerContactosProduccion
            // 
            this.grdVerContactosProduccion.AllowUserToAddRows = false;
            this.grdVerContactosProduccion.AllowUserToDeleteRows = false;
            this.grdVerContactosProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdVerContactosProduccion.BackgroundColor = System.Drawing.Color.White;
            this.grdVerContactosProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVerContactosProduccion.Location = new System.Drawing.Point(39, 45);
            this.grdVerContactosProduccion.Name = "grdVerContactosProduccion";
            this.grdVerContactosProduccion.ReadOnly = true;
            this.grdVerContactosProduccion.Size = new System.Drawing.Size(380, 150);
            this.grdVerContactosProduccion.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.grdVerContactosAtencion);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(705, 460);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(463, 214);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contactos";
            // 
            // grdVerContactosAtencion
            // 
            this.grdVerContactosAtencion.AllowUserToAddRows = false;
            this.grdVerContactosAtencion.AllowUserToDeleteRows = false;
            this.grdVerContactosAtencion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdVerContactosAtencion.BackgroundColor = System.Drawing.Color.White;
            this.grdVerContactosAtencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVerContactosAtencion.Location = new System.Drawing.Point(39, 45);
            this.grdVerContactosAtencion.Name = "grdVerContactosAtencion";
            this.grdVerContactosAtencion.ReadOnly = true;
            this.grdVerContactosAtencion.Size = new System.Drawing.Size(380, 150);
            this.grdVerContactosAtencion.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnOcultar);
            this.groupBox5.Controls.Add(this.btnAgregarNuevoContacto);
            this.groupBox5.Controls.Add(this.btnEliminarContacto);
            this.groupBox5.Controls.Add(this.btnModificarContacto);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtModificarContacto);
            this.groupBox5.Controls.Add(this.grdModificarContactos);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(26, 693);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(665, 273);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Modificar contactos";
            this.groupBox5.Visible = false;
            // 
            // btnOcultar
            // 
            this.btnOcultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnOcultar.FlatAppearance.BorderSize = 0;
            this.btnOcultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultar.Location = new System.Drawing.Point(600, 21);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(41, 34);
            this.btnOcultar.TabIndex = 41;
            this.btnOcultar.Text = "X";
            this.btnOcultar.UseVisualStyleBackColor = false;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // btnAgregarNuevoContacto
            // 
            this.btnAgregarNuevoContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarNuevoContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevoContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNuevoContacto.Location = new System.Drawing.Point(432, 139);
            this.btnAgregarNuevoContacto.Name = "btnAgregarNuevoContacto";
            this.btnAgregarNuevoContacto.Size = new System.Drawing.Size(97, 34);
            this.btnAgregarNuevoContacto.TabIndex = 40;
            this.btnAgregarNuevoContacto.Text = "Agregar";
            this.btnAgregarNuevoContacto.UseVisualStyleBackColor = false;
            this.btnAgregarNuevoContacto.Click += new System.EventHandler(this.btnAgregarNuevoContacto_Click);
            // 
            // btnEliminarContacto
            // 
            this.btnEliminarContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarContacto.FlatAppearance.BorderSize = 0;
            this.btnEliminarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarContacto.Location = new System.Drawing.Point(432, 199);
            this.btnEliminarContacto.Name = "btnEliminarContacto";
            this.btnEliminarContacto.Size = new System.Drawing.Size(209, 34);
            this.btnEliminarContacto.TabIndex = 39;
            this.btnEliminarContacto.Text = "Eliminar contacto";
            this.btnEliminarContacto.UseVisualStyleBackColor = false;
            this.btnEliminarContacto.Click += new System.EventHandler(this.btnEliminarContacto_Click);
            // 
            // btnModificarContacto
            // 
            this.btnModificarContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificarContacto.FlatAppearance.BorderSize = 0;
            this.btnModificarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarContacto.Location = new System.Drawing.Point(544, 139);
            this.btnModificarContacto.Name = "btnModificarContacto";
            this.btnModificarContacto.Size = new System.Drawing.Size(97, 34);
            this.btnModificarContacto.TabIndex = 38;
            this.btnModificarContacto.Text = "Modificar";
            this.btnModificarContacto.UseVisualStyleBackColor = false;
            this.btnModificarContacto.Click += new System.EventHandler(this.btnModificarContacto_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(429, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "Contacto";
            // 
            // txtModificarContacto
            // 
            this.txtModificarContacto.Location = new System.Drawing.Point(432, 111);
            this.txtModificarContacto.Name = "txtModificarContacto";
            this.txtModificarContacto.Size = new System.Drawing.Size(209, 22);
            this.txtModificarContacto.TabIndex = 38;
            // 
            // grdModificarContactos
            // 
            this.grdModificarContactos.AllowUserToAddRows = false;
            this.grdModificarContactos.AllowUserToDeleteRows = false;
            this.grdModificarContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdModificarContactos.BackgroundColor = System.Drawing.Color.White;
            this.grdModificarContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModificarContactos.Location = new System.Drawing.Point(15, 83);
            this.grdModificarContactos.Name = "grdModificarContactos";
            this.grdModificarContactos.ReadOnly = true;
            this.grdModificarContactos.Size = new System.Drawing.Size(380, 150);
            this.grdModificarContactos.TabIndex = 17;
            this.grdModificarContactos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdModificarContactos_CellClick);
            // 
            // btnContactosProduccion
            // 
            this.btnContactosProduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnContactosProduccion.FlatAppearance.BorderSize = 0;
            this.btnContactosProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContactosProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactosProduccion.Location = new System.Drawing.Point(479, 360);
            this.btnContactosProduccion.Name = "btnContactosProduccion";
            this.btnContactosProduccion.Size = new System.Drawing.Size(158, 34);
            this.btnContactosProduccion.TabIndex = 6;
            this.btnContactosProduccion.Text = "Modificar contactos";
            this.btnContactosProduccion.UseVisualStyleBackColor = false;
            this.btnContactosProduccion.Click += new System.EventHandler(this.btnContactosProduccion_Click);
            // 
            // btnContactosAtencion
            // 
            this.btnContactosAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnContactosAtencion.FlatAppearance.BorderSize = 0;
            this.btnContactosAtencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContactosAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContactosAtencion.Location = new System.Drawing.Point(469, 360);
            this.btnContactosAtencion.Name = "btnContactosAtencion";
            this.btnContactosAtencion.Size = new System.Drawing.Size(158, 34);
            this.btnContactosAtencion.TabIndex = 7;
            this.btnContactosAtencion.Text = "Modificar contactos";
            this.btnContactosAtencion.UseVisualStyleBackColor = false;
            this.btnContactosAtencion.Click += new System.EventHandler(this.btnContactosAtencion_Click);
            // 
            // frmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 977);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPersonal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEncargadoProduccion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtencionAlPublico)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerContactosProduccion)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerContactosAtencion)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModificarContactos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEncargadoProduccion;
        private System.Windows.Forms.Button btnAgregarEncargadoProduccion;
        private System.Windows.Forms.Button btnEliminarEncargadoProduccion;
        private System.Windows.Forms.Button btnModificarEncargadoProduccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusquedaEncargadoProduccion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdAtencionAlPublico;
        private System.Windows.Forms.TextBox txtBusquedaAtencionAlPublico;
        private System.Windows.Forms.Button btnModificarAtencionAlPublico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarAtencionAlPublico;
        private System.Windows.Forms.Button btnAgregarAtencionAlPublico;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdVerContactosProduccion;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grdVerContactosAtencion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnOcultar;
        private System.Windows.Forms.Button btnAgregarNuevoContacto;
        private System.Windows.Forms.Button btnEliminarContacto;
        private System.Windows.Forms.Button btnModificarContacto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModificarContacto;
        private System.Windows.Forms.DataGridView grdModificarContactos;
        private System.Windows.Forms.Button btnContactosProduccion;
        private System.Windows.Forms.Button btnContactosAtencion;
    }
}