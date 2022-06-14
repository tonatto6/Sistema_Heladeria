using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI.Forms
{
    public partial class frmMetodosDePago : Form
    {

        #region Campos

        BEMetodoDePago oBEMetodoDePago;
        BLLMetodoDePago oBLLMetodoDePago;

        #endregion

        public frmMetodosDePago()
        {
            InitializeComponent();
        }

        #region Propiedades

        public int Operacion { get; set; }

        #endregion

        #region Funciones privadas

        private void Cargar_Grilla()
        {
            try
            {
                oBLLMetodoDePago = new BLLMetodoDePago();
                grdMetodosDePago.DataSource = null;
                grdMetodosDePago.DataSource = oBLLMetodoDePago.Listar_Metodos_De_Pago();

                if(grdMetodosDePago.Rows.Count > 0)
                {
                    grdMetodosDePago.Columns["Codigo"].Visible = false;
                }


                if(grdMetodosDePago.Rows.Count == 0)
                {
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                }
                else 
                {
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Borrar()
        {
            txtNombre.Text = "";
            groupBox2.Visible = false;
        }

        private void Asignar()
        {
            oBLLMetodoDePago = new BLLMetodoDePago();

            if(oBEMetodoDePago.Codigo == 0)
            { oBEMetodoDePago.Codigo = oBLLMetodoDePago.Crear_Codigo_Metodo_Pago(); }

            oBEMetodoDePago.Nombre = txtNombre.Text;
        }

        #endregion

        private void frmMetodosDePago_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = 1;
                oBEMetodoDePago = new BEMetodoDePago();
                oBEMetodoDePago.Codigo = 0;
                groupBox2.Visible = true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = 2;

                DialogResult result = MessageBox.Show("¿Desea eliminar el metodo de pago seleccionado?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    oBLLMetodoDePago = new BLLMetodoDePago();
                    oBEMetodoDePago = (BEMetodoDePago)grdMetodosDePago.CurrentRow.DataBoundItem;

                    oBLLMetodoDePago.Operacion(oBEMetodoDePago, Operacion);

                    Cargar_Grilla();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = 3;

                oBEMetodoDePago = (BEMetodoDePago)grdMetodosDePago.CurrentRow.DataBoundItem;
                txtNombre.Text = oBEMetodoDePago.Nombre;

                groupBox2.Visible = true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text != "")
                {
                    Asignar();
                    oBLLMetodoDePago = new BLLMetodoDePago();

                    oBLLMetodoDePago.Operacion(oBEMetodoDePago, Operacion);

                    Borrar();
                    Cargar_Grilla();
                }
                else { MessageBox.Show("Debe completar todos los campos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
        }
    }
}
