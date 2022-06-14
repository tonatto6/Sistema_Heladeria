using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLUsuario
    {
        MPPUsuario oMPPUsuario;

        public BEUsuario Seleccionar_Usuario(string pUsuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Seleccionar_Usuario(pUsuario);
        }

        public BEUsuario Seleccionar_Usuario(int pCodigo_Usuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Seleccionar_Usuario(pCodigo_Usuario);
        }

        public bool Agregar_Usuario(BEUsuario oBEUsuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Agregar_Usuario(oBEUsuario);
        }

        public bool Eliminar_Usuario(BEUsuario oBEUsuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Eliminar_Usuario(oBEUsuario);
        }

        public bool Modificar_Usuario(BEUsuario oBEUsuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Modificar_Usuario(oBEUsuario);
        }

        public int Crear_Codigo_Usuario()
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Crear_Codigo_Usuario();
        }
    
        public bool Verificar_Usuario_Existe(string pUsuario)
        {
            oMPPUsuario = new MPPUsuario();
            return oMPPUsuario.Verificar_Usuario_Existe(pUsuario);
        }
    }
}
