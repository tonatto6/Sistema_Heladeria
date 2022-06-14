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
    public partial class frmVenta : Form
    {

        #region Campos

        BEProducto oBEProducto;
        BECliente oBECliente;

        BLLProducto oBLLProducto;
        BLLCliente oBLLCliente;
        List<BEProducto> Lista_Productos = new List<BEProducto>();

        BEPedido oBEPedido;
        BLLPedido oBLLPedido;

        BEAtencionAlPublico oBEAtencionAlPublico;

        BEMetodoDePago oBEMetodoPago;
        BLLMetodoDePago oBLLMetodoPago;

        BLLContacto oBLLContacto;

        #endregion

        public frmVenta()
        {
            InitializeComponent();
        }

        #region Fucniones privadas

        private void Borrar()
        {
            txtBuscarProducto.Text = "";
            txtBuscarCliente.Text = "";
            lblMontoTotal.Text = "";
            grdProductosSeleccionados.DataSource = null;
            lblNombre.Text = "";
            lblApellido.Text = "";
            Lista_Productos.Clear();
            grdContactos.DataSource = null;
        }

        private void Cargar_Grilla_Productos()
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
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_Clientes()
        {
            try
            {
                oBLLCliente = new BLLCliente();
                grdClientes.DataSource = null;
                grdClientes.DataSource = oBLLCliente.Listar_Clientes();

                if(grdClientes.Rows.Count > 0)
                {
                    grdClientes.Columns["Codigo"].Visible = false;
                    grdClientes.Columns["Rol"].Visible = false;
                }
                else { grdClientes.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_Metodo_Pago()
        {
            try
            {
                oBLLMetodoPago = new BLLMetodoDePago();
                grdMetodosPago.DataSource = null;
                grdMetodosPago.DataSource = oBLLMetodoPago.Listar_Metodos_De_Pago();

                if(grdMetodosPago.Rows.Count > 0)
                { grdMetodosPago.Columns["Codigo"].Visible = false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Calcular_Monto_Total()
        {
            try
            {
                decimal montoTotal = 0;

                foreach(BEProducto producto in Lista_Productos)
                {
                    montoTotal = montoTotal + producto.Precio;
                }

                lblMontoTotal.Text = montoTotal.ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Clientes()
        {
            try
            {
                oBLLCliente = new BLLCliente();
                grdClientes.DataSource = null;
                grdClientes.DataSource = oBLLCliente.Buscar_Clientes(txtBuscarCliente.Text);

                if (grdClientes.Rows.Count > 0)
                {
                    grdClientes.Columns["Codigo"].Visible = false;
                    grdClientes.Columns["Rol"].Visible = false;
                }
                else { grdClientes.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Producto()
        {
            try
            {
                oBLLProducto = new BLLProducto();
                grdProductos.DataSource = null;
                grdProductos.DataSource = oBLLProducto.Buscar_Producto(txtBuscarProducto.Text);
            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar()
        {
            try
            {
                oBLLPedido = new BLLPedido();
                oBEPedido.N_Pedido = oBLLPedido.Generar_Numero_Pedido();
                oBEPedido.Encargado_Venta = Program.Logueado;
                oBEPedido.Cliente = oBECliente;
                oBEPedido.Monto_Total = Convert.ToDecimal(lblMontoTotal.Text);
                oBEPedido.Fecha = DateTime.Now;
                oBEPedido.Metodo_Pago = (BEMetodoDePago)grdMetodosPago.CurrentRow.DataBoundItem;
            }
            catch (Exception ex) { throw ex; }
        }

        public int Obtener_Cantidad_Producto(BEProducto oProducto)
        {
            int cantidad = 0;
            foreach(BEProducto Producto in Lista_Productos)
            {
                if(Producto == oProducto)
                { cantidad++; }
            }

            return cantidad;
        }

        private void Restar_Cantidad_Producto()
        {
            try
            {
                //Este metodo es el encargado de restar la cantidad de productos. Modifica el inventario
                //de cada producto seleccionado en la venta

                oBLLProducto = new BLLProducto();

                foreach(BEProducto Producto in Lista_Productos)
                {
                    oBLLProducto.Restar_Cantidad_Producto(Producto.Codigo.ToString());
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Verificar_Cantidad_Producto()
        {
            try
            {
                oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;

                int cantidad = 0;

                foreach(BEProducto Producto in Lista_Productos)
                {
                    if(Producto == oBEProducto)
                    {
                        cantidad = cantidad + 1;
                    }
                }

                oBLLProducto = new BLLProducto();

                if(cantidad <= oBLLProducto.Verificar_Cantidad_Producto(oBEProducto.Codigo.ToString()))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void frmVenta_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla_Productos();
                Cargar_Grilla_Clientes();
                Cargar_Grilla_Metodo_Pago();
            }
            catch (Exception ex) { throw ex; }
        }

        #region Botones

        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txtCantidadProducto.Text) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(txtCantidadProducto.Text); i++)
                    {
                        oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;
                        Lista_Productos.Add(oBEProducto);
                    }

                    if (Verificar_Cantidad_Producto() == true)
                    {
                        grdProductosSeleccionados.DataSource = null;
                        grdProductosSeleccionados.DataSource = Lista_Productos;

                        if (grdProductos.Rows.Count > 0)
                        {
                            grdProductosSeleccionados.Columns["Codigo"].Visible = false;
                            grdProductosSeleccionados.Columns["Cantidad"].Visible = false;
                        }

                        Calcular_Monto_Total();
                        txtCantidadProducto.Text = "1";
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente cantidad del producto seleccionado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        for (int i = 0; i < Convert.ToInt32(txtCantidadProducto.Text); i++)
                        {
                            oBEProducto = (BEProducto)grdProductos.CurrentRow.DataBoundItem;
                            Lista_Productos.Remove(oBEProducto);
                        }
                    }
                }
                else { MessageBox.Show("La cantidad ingresada debe ser mayor a 0", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoCliente nuevoCliente = new frmNuevoCliente();
                nuevoCliente.ShowDialog();
                Cargar_Grilla_Clientes();
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarCliente.TextLength > 0)
                { Buscar_Clientes(); }
                else { Cargar_Grilla_Clientes(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                oBECliente = (BECliente)grdClientes.CurrentRow.DataBoundItem;

                lblNombre.Text = oBECliente.Nombre;
                lblApellido.Text = oBECliente.Apellido;
                oBLLContacto = new BLLContacto();
                grdContactos.DataSource = null;
                grdContactos.DataSource = oBLLContacto.Listar_Contactos(oBECliente, "Cliente");
                if (grdContactos.Rows.Count > 0)
                {
                    grdContactos.Columns["Codigo"].Visible = false;
                    grdContactos.Columns["Persona"].Visible = false;
                    grdContactos.Columns["Descripcion_Persona"].Visible = false;
                }
                else { grdContactos.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarProducto.TextLength > 0)
                { Buscar_Producto(); }
                else { Cargar_Grilla_Productos(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if(oBECliente != null)
                {
                    if(Lista_Productos.Count > 0)
                    {
                        oBEPedido = new BEPedido();

                        Asignar();

                        DialogResult result = MessageBox.Show("¿Desea cargar la venta?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            oBLLPedido = new BLLPedido();
                            
                            foreach(BEProducto Producto in Lista_Productos)
                            {
                                oBEPedido.Agregar_Detalle_Pedido(Producto);
                            }

                            oBLLPedido.Agregar_Pedido(oBEPedido);
                            
                            Restar_Cantidad_Producto();

                            Borrar();
                            Cargar_Grilla_Clientes();
                            Cargar_Grilla_Metodo_Pago();
                            Cargar_Grilla_Productos();
                        }
                    }
                    else { MessageBox.Show("Debe seleccionar minimo un producto para confirmar la venta", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe seleccionar un cliente para confirmar la venta", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdProductosSeleccionados.Rows.Count > 0)
                {
                    if(grdProductosSeleccionados.SelectedRows.Count > 0)
                    {
                        oBEProducto = (BEProducto)grdProductosSeleccionados.CurrentRow.DataBoundItem;

                        DialogResult result = MessageBox.Show("¿Desea quitar el producto seleccionado?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            Lista_Productos.Remove(oBEProducto);
                            grdProductosSeleccionados.DataSource = null;
                            grdProductosSeleccionados.DataSource = Lista_Productos;

                            if (grdProductos.Rows.Count > 0)
                            {
                                grdProductosSeleccionados.Columns["Codigo"].Visible = false;
                                grdProductosSeleccionados.Columns["Cantidad"].Visible = false;
                            }

                            Calcular_Monto_Total();
                        }
                    }
                    else { MessageBox.Show("Debe seleccionar el producto que desea quitar", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("No hay productos para quitar", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

    }
}
