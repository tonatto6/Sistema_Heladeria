using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLProducto
    {

        #region Campos

        MPPProducto oMPPProducto;

        #endregion

        #region Funciones

        public List<BEProducto> Listar_Productos()
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Listar_Producto();
        }
        
        public List<BEProducto> Buscar_Producto(string pProducto)
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Buscar_Producto(pProducto);
        }

        public List<BEProducto> Listar_Productos_Cantidad(int pCantidad)
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Listar_Productos_Cantidad(pCantidad);
        }

        public void Operacion(BEProducto oBEProducto, int pOperacion)
        {
            oMPPProducto = new MPPProducto();

            switch(pOperacion)
            {
                case 1:
                    oMPPProducto.Agregar(oBEProducto);
                    break;
                case 2:
                    oMPPProducto.Eliminar(oBEProducto);
                    break;
                case 3:
                    oMPPProducto.Modificar(oBEProducto);
                    break;
                default:
                    break;
            }
        }
    
        public int Crear_Codigo_Producto()
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Crear_Codigo_Producto();
        }

        public void Restar_Cantidad_Producto(string pCodigo_Producto)
        {
            oMPPProducto = new MPPProducto();
            oMPPProducto.Restar_Producto(pCodigo_Producto);
        }

        public int Verificar_Cantidad_Producto(string pCodigo)
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Verificar_Cantidad_Producto(pCodigo);
        }

        public bool Verificar_Eliminacion_Producto(BEProducto oBEProducto)
        {
            oMPPProducto = new MPPProducto();
            return oMPPProducto.Verificar_Eliminacion_Producto(oBEProducto);
        }

        #endregion

    }
}
