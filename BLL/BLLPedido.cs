using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLPedido
    {
        MPPPedidos oMPPPedido;

        public List<BEPedido> Listar_Pedidos()
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Listar_Pedidos();
        }

        public List<BEPedido> Listar_Pedido_X_Fecha(DateTime pFecha)
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Listar_Pedidos_X_Fecha(pFecha);
        }

        public List<BEProducto> Listar_Productos_X_Pedido(string pN_Pedido)
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Listar_Productos_Por_Pedido(pN_Pedido);
        }

        public List<BEPedido> Listar_Pedidos_X_Mes(int pMes)
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Listar_Pedidos_X_Mes(pMes);
        }

        public int Generar_Numero_Pedido()
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Generar_Numero_Pedido();
        }
    
        public void Agregar_Pedido(BEPedido oBEPedido)
        {
            oMPPPedido = new MPPPedidos();
            oMPPPedido.Agregar_Nuevo_Pedido(oBEPedido);
        }

        public double Calcular_Total_Todos_Los_Pedidos()
        {
            oMPPPedido = new MPPPedidos();
            return oMPPPedido.Calcular_Total_Todos_Los_Pedidos();
        }
    }
}
