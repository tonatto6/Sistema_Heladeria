using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPedido
    {

        private List<BEDetallePedido> Lista_Detalle_Pedidos;

        public BEPedido()
        { Lista_Detalle_Pedidos = new List<BEDetallePedido>(); }

        #region Propiedades

        public int N_Pedido { get; set; }

        public BEPersona Encargado_Venta { get; set; }

        public BECliente Cliente { get; set; }

        public decimal Monto_Total { get; set; }

        public DateTime Fecha { get; set; }

        public BEMetodoDePago Metodo_Pago { get; set; }

        public BEDetallePedido Detalle_Pedido { get; set; }

        #endregion

        public void Agregar_Detalle_Pedido(BEProducto producto)
        {
            BEDetallePedido detalle_pedido = new BEDetallePedido(producto, producto.Precio);
            Lista_Detalle_Pedidos.Add(detalle_pedido);
        }
    
        public List<BEDetallePedido> Retornar_ListaDetalles(BEPedido oBEPedido)
        { return oBEPedido.Lista_Detalle_Pedidos; }
    }
}
