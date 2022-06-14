using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPersona
    {
        #region Propiedades

        public int Codigo { get; set; }

        public int DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public BERol Rol { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }

        #endregion
    }
}
