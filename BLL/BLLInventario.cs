using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLInventario
    {
        MPPInventario oMPPInventario;

        public void Operacion(BEInventario oBEInventario, BEProducto oBEProducto, int pOperacion)
        {
            oMPPInventario = new MPPInventario();

            switch(pOperacion)
            {
                case 1:
                    oMPPInventario.Agregar(oBEInventario, oBEProducto);
                    break;

                case 2:
                    oMPPInventario.Eliminar(oBEProducto);
                    break;

                case 3:
                    oMPPInventario.Modificar(oBEInventario, oBEProducto);
                    break;

                default:
                    break;
            }
        }
    }
}
