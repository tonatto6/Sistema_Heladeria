
namespace UI.Forms
{
    partial class frmInformeVentas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdProductos_Pedidos = new System.Windows.Forms.DataGridView();
            this.btnDetallePedido = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.grdPedidos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFiltrarMes = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFiltrarFecha = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalTodosLosPedidos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductos_Pedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grdProductos_Pedidos);
            this.groupBox1.Controls.Add(this.btnDetallePedido);
            this.groupBox1.Controls.Add(this.btnRefrescar);
            this.groupBox1.Controls.Add(this.grdPedidos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(308, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1033, 414);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de pedidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Pedidos";
            // 
            // grdProductos_Pedidos
            // 
            this.grdProductos_Pedidos.AllowUserToAddRows = false;
            this.grdProductos_Pedidos.AllowUserToDeleteRows = false;
            this.grdProductos_Pedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProductos_Pedidos.BackgroundColor = System.Drawing.Color.White;
            this.grdProductos_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductos_Pedidos.Location = new System.Drawing.Point(662, 70);
            this.grdProductos_Pedidos.Name = "grdProductos_Pedidos";
            this.grdProductos_Pedidos.ReadOnly = true;
            this.grdProductos_Pedidos.Size = new System.Drawing.Size(365, 261);
            this.grdProductos_Pedidos.TabIndex = 24;
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDetallePedido.FlatAppearance.BorderSize = 0;
            this.btnDetallePedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetallePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallePedido.Location = new System.Drawing.Point(442, 350);
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.Size = new System.Drawing.Size(137, 34);
            this.btnDetallePedido.TabIndex = 23;
            this.btnDetallePedido.Text = "Ver detalle pedido";
            this.btnDetallePedido.UseVisualStyleBackColor = false;
            this.btnDetallePedido.Click += new System.EventHandler(this.btnDetallePedido_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.Location = new System.Drawing.Point(299, 350);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(97, 34);
            this.btnRefrescar.TabIndex = 22;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            // 
            // grdPedidos
            // 
            this.grdPedidos.AllowUserToAddRows = false;
            this.grdPedidos.AllowUserToDeleteRows = false;
            this.grdPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPedidos.BackgroundColor = System.Drawing.Color.White;
            this.grdPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPedidos.Location = new System.Drawing.Point(30, 70);
            this.grdPedidos.Name = "grdPedidos";
            this.grdPedidos.ReadOnly = true;
            this.grdPedidos.Size = new System.Drawing.Size(549, 261);
            this.grdPedidos.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFiltrarMes);
            this.groupBox2.Controls.Add(this.cboMes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar mes";
            // 
            // btnFiltrarMes
            // 
            this.btnFiltrarMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFiltrarMes.FlatAppearance.BorderSize = 0;
            this.btnFiltrarMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMes.Location = new System.Drawing.Point(97, 118);
            this.btnFiltrarMes.Name = "btnFiltrarMes";
            this.btnFiltrarMes.Size = new System.Drawing.Size(97, 34);
            this.btnFiltrarMes.TabIndex = 21;
            this.btnFiltrarMes.Text = "Filtrar";
            this.btnFiltrarMes.UseVisualStyleBackColor = false;
            this.btnFiltrarMes.Click += new System.EventHandler(this.btnFiltrarMes_Click);
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "Todos",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cboMes.Location = new System.Drawing.Point(27, 70);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(167, 24);
            this.cboMes.TabIndex = 2;
            this.cboMes.Text = "Todos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFiltrarFecha);
            this.groupBox3.Controls.Add(this.dtpFecha);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 171);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccionar fecha";
            // 
            // btnFiltrarFecha
            // 
            this.btnFiltrarFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFiltrarFecha.FlatAppearance.BorderSize = 0;
            this.btnFiltrarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarFecha.Location = new System.Drawing.Point(97, 120);
            this.btnFiltrarFecha.Name = "btnFiltrarFecha";
            this.btnFiltrarFecha.Size = new System.Drawing.Size(97, 34);
            this.btnFiltrarFecha.TabIndex = 22;
            this.btnFiltrarFecha.Text = "Filtrar";
            this.btnFiltrarFecha.UseVisualStyleBackColor = false;
            this.btnFiltrarFecha.Click += new System.EventHandler(this.btnFiltrarFecha_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(27, 76);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(167, 22);
            this.dtpFecha.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotalTodosLosPedidos);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(308, 498);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(227, 160);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Suma de todos los pedidos";
            // 
            // lblTotalTodosLosPedidos
            // 
            this.lblTotalTodosLosPedidos.AutoSize = true;
            this.lblTotalTodosLosPedidos.Location = new System.Drawing.Point(95, 76);
            this.lblTotalTodosLosPedidos.Name = "lblTotalTodosLosPedidos";
            this.lblTotalTodosLosPedidos.Size = new System.Drawing.Size(18, 16);
            this.lblTotalTodosLosPedidos.TabIndex = 5;
            this.lblTotalTodosLosPedidos.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // frmInformeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1353, 700);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInformeVentas";
            this.Text = "Informe ventas";
            this.Load += new System.EventHandler(this.frmInformeVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductos_Pedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView grdPedidos;
        private System.Windows.Forms.Button btnFiltrarMes;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnFiltrarFecha;
        private System.Windows.Forms.Button btnDetallePedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdProductos_Pedidos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTotalTodosLosPedidos;
        private System.Windows.Forms.Label label3;
    }
}