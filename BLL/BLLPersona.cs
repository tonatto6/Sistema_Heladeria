using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPersona
    {
        #region Funciones de validacion

        public bool Validar_Nombre_Apellido(string cadena)
        {
            try
            {
                Regex re = new Regex("^[a-zA-Z]+$");
                if (!re.IsMatch(cadena))
                { return false; }
                else { return true; }
            }
            catch (Exception ex) { throw ex; }

        }

        public bool Validar_Fecha(string cadena)
        {
            try
            {
                Regex re = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|[2-9][0-9])\d\d$");
                if (!re.IsMatch(cadena))
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex) { throw ex; }

        }

        public bool Validar_DNI(string cadena)
        {
            try
            {
                Regex re = new Regex(@"^[1-9]{1}[0-9]{7}$");
                if (!re.IsMatch(cadena))
                {
                    return false;
                }
                else { return true; }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
