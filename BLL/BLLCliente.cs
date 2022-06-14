using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace BLL
{
    public class BLLCliente
    {
        #region Campos

        MPPCliente oMPPCliente;

        #endregion

        #region Funciones

        public List<BECliente> Listar_Clientes()
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Listar_Clientes();
        }
        
        public BECliente Buscar_Cliente(string pDNI)
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Buscar_Cliente(pDNI);
        }

        public void Operacion(BECliente oBECliente, int pOperacion)
        {
            oMPPCliente = new MPPCliente();

            switch(pOperacion)
            {
                case 1:
                    oMPPCliente.Agregar(oBECliente);
                    break;
                case 2:
                    oMPPCliente.Eliminar(oBECliente);
                    break;
                case 3:
                    oMPPCliente.Modificar(oBECliente);
                    break;
                default:
                    break;
            }
        }
    
        public int Crear_Codigo_Cliente()
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Crear_Codigo_Cliente();
        }
    
        public List<BECliente> Buscar_Clientes(string pApellido)
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Buscar_Clientes(pApellido);
        }

        public bool Verificar_Eliminacion_Cliente(BECliente oBECliente)
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Verificar_Eliminacion_Cliente(oBECliente);
        }

        public List<BECliente> Listar_Clientes_X_Mes(string pMes, string pAño)
        {
            oMPPCliente = new MPPCliente();
            return oMPPCliente.Listar_Clientes_X_Mes(pMes, pAño);
        }

        #endregion

    }
}
