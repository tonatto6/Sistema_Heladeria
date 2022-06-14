using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEJefe : BEPersona
    {
        #region Propiedades

        public BEUsuario Usuario { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public string Direccion { get; set; }

        #endregion
    }
}
