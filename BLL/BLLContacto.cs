using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLContacto
    {
        MPPContacto oMPPContacto;

        public List<BEContacto> Listar_Contactos(BEPersona oBEPersona, string pDescripcion_Persona)
        {
            oMPPContacto = new MPPContacto();
            return oMPPContacto.Listar_Contactos(oBEPersona, pDescripcion_Persona);
        }

        public void Agregar_Contacto(List<BEContacto> Lista_Contacto)
        {
            oMPPContacto = new MPPContacto();
            oMPPContacto.Agregar_Contacto(Lista_Contacto);
        }

        public int Crear_Codigo_Contacto()
        {
            oMPPContacto = new MPPContacto();
            return oMPPContacto.Crear_Codigo_Contacto();
        }

        public void Eliminar_Contactos(BEPersona oBEPersona, string pDescripcion_Persona)
        {
            oMPPContacto = new MPPContacto();
            oMPPContacto.Eliminar_Contactos(oBEPersona, pDescripcion_Persona);
        }
    
        public void Agregar_Un_Contacto(BEContacto oBEContacto)
        {
            oMPPContacto = new MPPContacto();
            oMPPContacto.Agregar_Un_Contacto(oBEContacto);
        }

        public void Eliminar_Contacto(BEContacto oBEContacto)
        {
            oMPPContacto = new MPPContacto();
            oMPPContacto.Eliminar_Contacto(oBEContacto);
        }

        public void Modificar_Contacto(BEContacto oBEContacto)
        {
            oMPPContacto = new MPPContacto();
            oMPPContacto.Modificar_Contacto(oBEContacto);
        }
    
        public bool Verificar_Contacto_Existe(BEContacto oBEContacto)
        {
            oMPPContacto = new MPPContacto();
            return oMPPContacto.Verificar_Contacto_Existe(oBEContacto);
        }
    }
}
