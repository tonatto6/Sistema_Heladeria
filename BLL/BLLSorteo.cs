using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLSorteo
    {

        #region Campos

        MPPSorteo oMPPSorteo;

        #endregion

        #region Funciones

        public void Registrar_Sorteo(BESorteo oBESorteo)
        {
            oMPPSorteo = new MPPSorteo();
            oMPPSorteo.Registrar_Sorteo(oBESorteo);
        }

        public bool Verificar_Sorteo(string pMes, int pAño)
        {
            oMPPSorteo = new MPPSorteo();
            return oMPPSorteo.Verificar_Sorteo(pMes, pAño);
        }

        public List<BESorteo> Listar_Sorteos()
        {
            oMPPSorteo = new MPPSorteo();
            return oMPPSorteo.Listar_Sorteos();
        }

        public List<BESorteo> Listar_Sorteo_Año(int pAño)
        {
            oMPPSorteo = new MPPSorteo();
            return oMPPSorteo.Listar_Sorteos_Año(pAño);
        }

        public List<BESorteo> Listar_Sorteos_Mes_Año(string pMes, int pAño)
        {
            oMPPSorteo = new MPPSorteo();
            return oMPPSorteo.Listar_Sorteos_x_Mes_Año(pMes, pAño);
        }

        #endregion
    
    }
}
