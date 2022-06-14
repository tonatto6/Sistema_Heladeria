using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI.Forms
{
    public partial class frmPrecios : Form
    {
        #region Campos

        BEProducto oBEProducto;
        BLLProducto oBLLProducto;

        #endregion

        public frmPrecios()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private void Cargar_Grilla_Productos()
        {
            grdProductos.DataSource = null;
            oBLLProducto = new BLLProducto();
            grdProductos.DataSource = oBLLProducto.Listar_Productos();

            if(grdProductos.Rows.Count > 0)
            {
                grdProductos.Columns["Codigo"].Visible = false;
                grdProductos.Columns["Nombre"].HeaderText = "Productos";
            }
        }

        private void Borrar()
        {
            lblProducto.Text = "";
            txtPrecio.Text = "";
            groupBox2.Visible = false;
            txtBuscarProducto.Text = "";
        }

        //private bool Verificar_Permisos()
        //{
        //    try
        //    {
        //        if (Program.Rol == "Jefe")
        //        { return true; }
        //        else { return false; }
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        private void Asignar_Nuevo_Precio()
        {
            oBEProducto.Precio = Convert.ToDecimal(txtPrecio.Text);
        }

        private void Buscar_Productos()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductos.DataSource = null;
                grdProductos.DataSource = oBLLProducto.Buscar_Producto(txtBuscarProducto.Text);
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void frmPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla_Productos();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtBuscarProducto.Text != "")
                {
                    Buscar_Productos();
                }
                else { MessageBox.Show("El campo no puede estar vacio", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Verificar_Permisos() == true)
                //{
                    oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;

                    groupBox2.Visible = true;
                    lblProducto.Text = oBEProducto.Nombre;
                    txtPrecio.Text = oBEProducto.Precio.ToString();
                //}
                //else { MessageBox.Show("No tiene permisos para modificar el precio del producto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPrecio.Text != "" && Convert.ToInt32(txtPrecio.Text) > 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea modificar el precio del producto?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        Asignar_Nuevo_Precio();

                        oBLLProducto = new BLLProducto();
                        oBLLProducto.Operacion(oBEProducto, 3);

                        Borrar();
                        Cargar_Grilla_Productos();
                    }
                }
                else { MessageBox.Show("El precio debe ser mayor a 0", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarProducto.TextLength > 0)
                {
                    Buscar_Productos();
                }
                else { Cargar_Grilla_Productos(); }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
