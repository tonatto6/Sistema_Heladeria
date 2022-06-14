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
    public partial class frmInformeVentas : Form
    {

        #region Campos

        BLLPedido oBLLPedido;
        BEPedido oBEPedido;

        #endregion

        public frmInformeVentas()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private void Cargar_Grilla()
        {
            try
            {
                oBLLPedido = new BLLPedido();
                grdPedidos.DataSource = null;
                grdPedidos.DataSource = oBLLPedido.Listar_Pedidos();

                if(grdPedidos.Rows.Count > 0)
                {
                    grdPedidos.Columns["N_Pedido"].Visible = false;
                    grdPedidos.Columns["Metodo_Pago"].Visible = false;
                    grdPedidos.Columns["Detalle_Pedido"].Visible = false;

                    grdPedidos.Columns["Encargado_Venta"].HeaderText = "Encargado";
                    grdPedidos.Columns["Monto_Total"].HeaderText = "Monto total";
                }
                else { grdPedidos.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_X_Fecha()
        {
            try
            {
                oBLLPedido = new BLLPedido();
                grdPedidos.DataSource = null;
                grdPedidos.DataSource = oBLLPedido.Listar_Pedido_X_Fecha(dtpFecha.Value);

                if (grdPedidos.Rows.Count > 0)
                {
                    grdPedidos.Columns["N_Pedido"].Visible = false;
                    grdPedidos.Columns["Metodo_Pago"].Visible = false;
                    grdPedidos.Columns["Detalle_Pedido"].Visible = false;

                    grdPedidos.Columns["Encargado_Venta"].HeaderText = "Encargado";
                    grdPedidos.Columns["Monto_Total"].HeaderText = "Monto total";
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos con los filtros ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cargar_Grilla();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Calcular_Total_Todos_Los_Pedidos()
        {
            try
            {
                oBLLPedido = new BLLPedido();
                lblTotalTodosLosPedidos.Text = oBLLPedido.Calcular_Total_Todos_Los_Pedidos().ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        private void Listar_Pedidos_X_Mes(int pMes)
        {
            try
            {
                oBLLPedido = new BLLPedido();
                grdPedidos.DataSource = null;
                grdPedidos.DataSource = oBLLPedido.Listar_Pedidos_X_Mes(pMes);

                if(grdPedidos.Rows.Count > 0)
                {
                    grdPedidos.Columns["N_Pedido"].Visible = false;
                    grdPedidos.Columns["Metodo_Pago"].Visible = false;
                    grdPedidos.Columns["Detalle_Pedido"].Visible = false;

                    grdPedidos.Columns["Encargado_Venta"].HeaderText = "Encargado";
                    grdPedidos.Columns["Monto_Total"].HeaderText = "Monto total";
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos para el mes seleccionado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cargar_Grilla();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void frmInformeVentas_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla();
                Calcular_Total_Todos_Los_Pedidos();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla_X_Fecha();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            try
            {
                oBEPedido = (BEPedido)grdPedidos.CurrentRow.DataBoundItem;

                oBLLPedido = new BLLPedido();
                grdProductos_Pedidos.DataSource = null;
                grdProductos_Pedidos.DataSource = oBLLPedido.Listar_Productos_X_Pedido(oBEPedido.N_Pedido.ToString());
            
                if(grdProductos_Pedidos.Rows.Count > 0)
                {
                    grdProductos_Pedidos.Columns["Codigo"].Visible = false;
                    grdProductos_Pedidos.Columns["Cantidad"].Visible = false;

                    grdProductos_Pedidos.Columns["Precio"].HeaderText = "Precio unitario";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnFiltrarMes_Click(object sender, EventArgs e)
        {
            try
            {
                switch(cboMes.Text)
                {
                    case "Enero":
                        Listar_Pedidos_X_Mes(1);
                        break;

                    case "Febrero":
                        Listar_Pedidos_X_Mes(2);
                        break;

                    case "Marzo":
                        Listar_Pedidos_X_Mes(3);
                        break;

                    case "Abril":
                        Listar_Pedidos_X_Mes(4);
                        break;

                    case "Mayo":
                        Listar_Pedidos_X_Mes(5);
                        break;

                    case "Junio":
                        Listar_Pedidos_X_Mes(6);
                        break;

                    case "Julio":
                        Listar_Pedidos_X_Mes(7);
                        break;

                    case "Agosto":
                        Listar_Pedidos_X_Mes(8);
                        break;

                    case "Septiembre":
                        Listar_Pedidos_X_Mes(9);
                        break;

                    case "Octubre":
                        Listar_Pedidos_X_Mes(10);
                        break;

                    case "Noviembre":
                        Listar_Pedidos_X_Mes(11);
                        break;

                    case "Diciembre":
                        Listar_Pedidos_X_Mes(12);
                        break;

                    default:
                        Cargar_Grilla();
                        break;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
