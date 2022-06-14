using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace BLL
{
    public class BLLMetodoDePago
    {
        MPPMetodoDePago oMPPMetodoDePago;

        public List<BEMetodoDePago> Listar_Metodos_De_Pago()
        {
            oMPPMetodoDePago = new MPPMetodoDePago();
            return oMPPMetodoDePago.Listar_Metodos_De_Pago();
        }
    
        public void Operacion(BEMetodoDePago oBEMetodoPago, int pOperacion)
        {
            oMPPMetodoDePago = new MPPMetodoDePago();

            switch(pOperacion)
            {
                case 1:
                    oMPPMetodoDePago.Agregar_Metodo_Pago(oBEMetodoPago);
                    break;
                
                case 2:
                    oMPPMetodoDePago.Eliminar_Metodo_Pago(oBEMetodoPago);
                    break;
                
                case 3:
                    oMPPMetodoDePago.Modificar_Metodo_Pago(oBEMetodoPago);
                    break;

                default:
                    break;
            }
        }

        public int Crear_Codigo_Metodo_Pago()
        {
            oMPPMetodoDePago = new MPPMetodoDePago();
            return oMPPMetodoDePago.Crear_Codigo_Metodo_Pago();
        }
    }
}
