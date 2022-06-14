using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDetalleHorario
    {
        public BEDetalleHorario(Dictionary<BEPersona, string> pLista_Empleados)
        {
            Lista_Empleados = pLista_Empleados;
        }

        public Dictionary<BEPersona, string> Lista_Empleados { get; set; }

    }
}
