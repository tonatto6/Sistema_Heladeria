using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLEncargado_Produccion
    {

        #region Campos

        MPPEncargadoDeProduccion oMPPEncargado_Produccion;

        #endregion

        #region Funciones

        public List<BEEncargadoProduccion> Listar_Encargados_Produccion()
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Listar_Encargados_Produccion();
        }

        //public BEEncargadoProduccion Seleccionar_Usuario(BEEncargadoProduccion oBEEncargadoProduccion)
        //{
        //    oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
        //    return oMPPEncargado_Produccion.Seleccionar_Usuario(oBEEncargadoProduccion);
        //}

        public BEEncargadoProduccion Seleccionar_Encargado(BEUsuario Usuario)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Seleccionar_Encargado_Produccion(Usuario);
        }

        public bool Operacion(BEEncargadoProduccion oBEEncargado_Produccion, int pOperacion)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            
            switch(pOperacion)
            {
                case 1:
                    return oMPPEncargado_Produccion.Agregar(oBEEncargado_Produccion);
                case 2:
                    return oMPPEncargado_Produccion.Eliminar(oBEEncargado_Produccion);
                case 3:
                    return oMPPEncargado_Produccion.Modificar(oBEEncargado_Produccion);
                default:
                    return false;
            }
        }
    
        public int Crear_Codigo_Encargado_Produccion()
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Crear_Codigo_Encargado_Produccion();
        }

        public void Verificar_Usuario_Encargado_Produccion(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            //return oMPPEncargado_Produccion.Validar_Usuario_Encargado_Produccion(oBEEncargadoProduccion);
        }

        public List<BEEncargadoProduccion> Buscar_Encargado_Produccion(string pApellido)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Buscar_Encargado_Produccion(pApellido);
        }

        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Modificar_Contraseña(pDNI, pUsuario, pNuevaContraseña);
        }

        public bool Verificar_Encargado_Atencion_Pedido(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            oMPPEncargado_Produccion = new MPPEncargadoDeProduccion();
            return oMPPEncargado_Produccion.Verificar_Encargado_Produccion_Pedido(oBEEncargadoProduccion);
        }

        #endregion

    }
}
