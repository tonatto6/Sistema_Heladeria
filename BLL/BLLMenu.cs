using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;

namespace BLL
{
    public class BLLMenu
    {
        MPPMenu oMPPMenu;

        public List<BEMenu> Listar_Menu()
        {
            oMPPMenu = new MPPMenu();
            return oMPPMenu.Listar_Menu();
        }

        public BERol Buscar_Rol(int pCodigo_Rol)
        {
            oMPPMenu = new MPPMenu();
            return oMPPMenu.Buscar_Rol(pCodigo_Rol);
        }

        public List<BEPermiso> Listar_Permisos(int pRol)
        {
            oMPPMenu = new MPPMenu();
            return oMPPMenu.Listar_Permisos(pRol);
        }
    }
}
