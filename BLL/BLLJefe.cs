using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLJefe
    {
        MPPJefe oMPPJefe;

        public List<BEJefe> Listar_Jefe()
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Listar_Jefe();
        }

        public BEJefe Seleccionar_Jefe(BEUsuario oBEUsuario)
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Seleccionar_Jefe(oBEUsuario);
        }

        public void Verificar_Usuario(BEJefe pJefe)
        {
            oMPPJefe = new MPPJefe();
            //return oMPPJefe.Verificar_Usuario(pJefe);
        }

        public void Operacion(BEJefe oBEJefe, int pOperacion)
        {
            oMPPJefe = new MPPJefe();

            switch(pOperacion)
            {
                case 1:
                    oMPPJefe.Agregar(oBEJefe);
                    break;

                case 2:
                    oMPPJefe.Eliminar(oBEJefe);
                    break;

                case 3:
                    oMPPJefe.Modificar(oBEJefe);
                    break;

                default:
                    break;
            }
        }
    
        public int Crear_Codigo_Jefe()
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Crear_Codigo_Jefe();
        }
    
        public List<BEJefe> Buscar_Jefes(string pApellido)
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Buscar_Jefes(pApellido);
        }
    
        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Modificar_Contraseña(pDNI, pUsuario, pNuevaContraseña);
        }

        public bool Verificar_Jefe_Pedido(BEJefe oBEJefe)
        {
            oMPPJefe = new MPPJefe();
            return oMPPJefe.Verificar_Jefe_Pedido(oBEJefe);
        }

    }
}
