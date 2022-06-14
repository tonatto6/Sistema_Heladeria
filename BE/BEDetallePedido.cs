using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDetallePedido
    {
        public BEDetallePedido(BEProducto producto, decimal precio_unitario)
        {
            Producto = producto;
            Precio_Unitario = precio_unitario;
        }


        #region Propiedades
        public int N_Pedido { get; set; }

        public List<BEProducto> Lista_Productos { get; set; }

        public BEProducto Producto { get; set; }

        public decimal Precio_Unitario { get; set; }

        public int Cantidad { get; set; }

        #endregion
    }
}
