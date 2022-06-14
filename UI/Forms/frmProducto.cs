using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI.Forms
{
    public partial class frmProducto : Form
    {
        #region Campos

        BEProducto oBEProducto;
        BLLProducto oBLLProducto;

        BEInventario oBEInventario;

        List<BEProducto> Lista_Reposicion;

        #endregion
        
        public frmProducto()
        {
            InitializeComponent();
        }

        #region Propiedades

        public int Operacion { get; set; }

        #endregion

        #region Funciones privadas

        private void Borrar()
        {
            txtProducto.Text = "";
            txtPrecioUnitario.Text = "";
            txtCantidad.Text = "";
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            txtNombreArchivo.Text = "";
            grdProductosReposicion.DataSource = null;
            grdProductosSelecionados.DataSource = null;
            txtBuscarProductoReposicion.Text = "";
            txtCantidadProducto.Text = "";
        }

        private void Asignar()
        {
            try
            {
                oBLLProducto = new BLLProducto();

                if(oBEProducto.Codigo == 0)
                { oBEProducto.Codigo = oBLLProducto.Crear_Codigo_Producto(); }

                oBEProducto.Nombre = txtProducto.Text;
                oBEProducto.Precio = Convert.ToDecimal(txtPrecioUnitario.Text);
                oBEProducto.Cantidad = Convert.ToInt32(txtCantidad.Text);
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductos.DataSource = null;
                grdProductos.DataSource = oBLLProducto.Listar_Productos();

                if(grdProductos.Rows.Count > 0)
                {
                    grdProductos.Columns["Codigo"].Visible = false;
                }
                else { grdProductos.DataSource = null; }
            }
            catch (Exception ex) {throw ex; }
        }

        private void Habilitar()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void Deshabilitar()
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void Buscar_Producto()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductos.DataSource = null;
                grdProductos.DataSource = oBLLProducto.Buscar_Producto(txtBuscarProducto.Text);
                if (grdProductos.Rows.Count > 0)
                {
                    grdProductos.Columns["Codigo"].Visible = false;
                }
                else { grdProductos.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Campos()
        {
            try
            {
                if (txtProducto.Text != "" && txtPrecioUnitario.Text != "" && txtCantidad.Text != "")
                { return true; }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_Productos_Reposicion()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductosReposicion.DataSource = null;
                grdProductosReposicion.DataSource = oBLLProducto.Listar_Productos();

                if (grdProductosReposicion.Rows.Count > 0)
                {
                    grdProductosReposicion.Columns["Codigo"].Visible = false;
                }
                else { grdProductosReposicion.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Producto_Reposicion()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductosReposicion.DataSource = null;
                grdProductosReposicion.DataSource = oBLLProducto.Buscar_Producto(txtBuscarProductoReposicion.Text);

                if (grdProductosReposicion.Rows.Count > 0)
                {
                    grdProductosReposicion.Columns["Codigo"].Visible = false;
                }
                else { grdProductosReposicion.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Producto_Seleccionado(BEProducto oBEProducto)
        {
            try
            {
                foreach(BEProducto Producto in Lista_Reposicion)
                {
                    if(oBEProducto.Codigo == Producto.Codigo)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(DialogResult.Yes == result)
                {
                    Operacion = 2;

                    oBLLProducto = new BLLProducto();
                    oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;
                    if(oBLLProducto.Verificar_Eliminacion_Producto(oBEProducto) != true)
                    {
                        oBLLProducto.Operacion(oBEProducto, Operacion);

                        MessageBox.Show("El producto fue eliminado exitosamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Cargar_Grilla();
                    }
                    else { MessageBox.Show("No se puede eliminar el producto seleccionado porque esta sujeto a otros datos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacion = 1;
                groupBox2.Visible = true;
                oBEProducto = new BEProducto();
                oBEProducto.Codigo = 0;
                Deshabilitar();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;

                txtProducto.Text = oBEProducto.Nombre;
                txtPrecioUnitario.Text = oBEProducto.Precio.ToString();
                txtCantidad.Text = oBEProducto.Cantidad.ToString();

                groupBox2.Visible = true;

                Operacion = 3;
                Deshabilitar();
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validar_Campos() == true)
                {
                    if (Convert.ToInt32(txtCantidad.Text) > 0 && Convert.ToInt32(txtPrecioUnitario.Text) > 0)
                    {
                        oBLLProducto = new BLLProducto();

                        if (Operacion == 1)
                        {
                            Asignar();

                            oBLLProducto.Operacion(oBEProducto, Operacion);
                        }
                        else
                        {
                            Asignar();
                            oBLLProducto.Operacion(oBEProducto, Operacion);
                        }

                        Borrar();
                        Habilitar();
                        Cargar_Grilla();
                    }
                    else { MessageBox.Show("La cantidad y/o precio unitario debe ser mayor a 0", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("Debe completar todos los campos", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
            Habilitar();
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarProducto.TextLength > 0)
                { Buscar_Producto(); }
                else { Cargar_Grilla(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox3.Visible = true;
                Cargar_Grilla_Productos_Reposicion();
                Lista_Reposicion = new List<BEProducto>();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductosReposicion.DataSource = null;
                grdProductosReposicion.DataSource = oBLLProducto.Listar_Productos_Cantidad(Convert.ToInt32(txtCantidadProducto.Text));

                if (grdProductosReposicion.Rows.Count > 0)
                {
                    grdProductosReposicion.Columns["Codigo"].Visible = false;
                }
                else { grdProductosReposicion.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtCantidadProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtCantidadProducto.Text == "")
                { Cargar_Grilla_Productos_Reposicion(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBuscarProductoReposicion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBuscarProductoReposicion.TextLength > 0)
                { Buscar_Producto_Reposicion(); }
                else { Cargar_Grilla_Productos_Reposicion(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                oBEProducto = (BEProducto)grdProductosReposicion.CurrentRow.DataBoundItem;

                if(Validar_Producto_Seleccionado(oBEProducto) == false)
                {
                    Lista_Reposicion.Add(oBEProducto);
                    grdProductosSelecionados.DataSource = null;
                    grdProductosSelecionados.DataSource = Lista_Reposicion;
                    if (grdProductosSelecionados.Rows.Count > 0)
                    {
                        grdProductosSelecionados.Columns["Codigo"].Visible = false;
                        grdProductosSelecionados.Columns["Precio"].Visible = false;
                    }
                    else { grdProductosSelecionados.DataSource = null; }
                }
                else { MessageBox.Show("El producto seleccionado ya fue agregado a la lista", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            }
            catch (Exception ex) { throw ex; }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                oBEProducto = (BEProducto)grdProductosSelecionados.CurrentRow.DataBoundItem;
                Lista_Reposicion.Remove(oBEProducto);
                grdProductosSelecionados.DataSource = null;
                grdProductosSelecionados.DataSource = Lista_Reposicion;
                if (grdProductosSelecionados.Rows.Count > 0)
                {
                    grdProductosSelecionados.Columns["Codigo"].Visible = false;
                }
                else { grdProductosSelecionados.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnFinalizarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdProductosSelecionados.Rows.Count > 0)
                {
                    if(txtNombreArchivo.Text != "")
                    {
                        string nombrearchivo = txtNombreArchivo.Text;
                        string path = "C:\\" + nombrearchivo + ".txt";

                        if (!File.Exists(path))
                        {
                            StreamWriter file = new StreamWriter(path, true);

                            file.WriteLine("Heladeria");
                            file.WriteLine("Orden de reposición");
                            file.WriteLine("Fecha:" + DateTime.Now.ToString());
                            file.WriteLine("");
                            file.WriteLine("Productos:");
                            
                            foreach(BEProducto Producto in Lista_Reposicion)
                            {
                                file.WriteLine(Producto.Nombre);
                            }

                            file.Close();
                            file.Dispose();

                            MessageBox.Show("Orden creada correctamente", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Borrar();
                            Cargar_Grilla();
                        }
                        else { MessageBox.Show("Debe ingresar otro nombre porque el ingresado ya se encuentra en uso", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else { MessageBox.Show("Debe completar el nombre del archivo", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe seleccionar como minimo un producto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                Borrar();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
