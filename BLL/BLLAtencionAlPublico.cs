using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLAtencionAlPublico
    {

        #region Campos

        MPPAtencionAlPublico oMPPAtencionAlPublico;

        #endregion

        #region Funciones

        public List<BEAtencionAlPublico> Listar_Atencion_Al_Publico()
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Listar_Atencion_Al_Publico();
        }
        
        public List<BEAtencionAlPublico> Buscar_Encargado_Atencion(string pApellido)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Buscar_Encargado(pApellido);
        }

        //public BEAtencionAlPublico Seleccionar_Usuario(BEAtencionAlPublico pBEAtencionAlPublico)
        //{
        //    oMPPAtencionAlPublico = new MPPAtencionAlPublico();
        //    return oMPPAtencionAlPublico.Seleccionar_Usuario(pBEAtencionAlPublico);
        //}
        
        public BEAtencionAlPublico Seleccionar_Encargado(BEUsuario Usuario)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Seleccionar_Encargado(Usuario);
        }

        public bool Operacion(BEAtencionAlPublico oBEAtencionAlPublico, int pOperacion)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();

            switch (pOperacion)
            {
                case 1:
                    return oMPPAtencionAlPublico.Agregar(oBEAtencionAlPublico);

                case 2:
                    return oMPPAtencionAlPublico.Eliminar(oBEAtencionAlPublico);

                case 3:
                    return oMPPAtencionAlPublico.Modificar(oBEAtencionAlPublico);

                default:
                    return false;

            }
        }
    
        public int Crear_Codigo_Atencion_Al_Publico()
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Crear_Codigo_Atencion_Al_Publico();
        }
    
        public void Verificar_Usuario_Atencion_Al_Publico(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            //return oMPPAtencionAlPublico.Verificar_Usuario_Atencion_Al_Publico(oBEAtencionAlPublico);
        }

        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Modificar_Contraseña(pDNI, pUsuario, pNuevaContraseña);
        }

        public bool Verificar_Encargado_Atencion_Pedido(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            return oMPPAtencionAlPublico.Verificar_Encargado_Atencion_Pedido(oBEAtencionAlPublico);
        }
        #endregion

    }
}
