using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHorario
    {
        public int Codigo { get; set; }

        public DateTime Fecha { get; set; }

        public string Hora_Inicio { get; set; }

        public string Hora_Fin { get; set; }

        public int Cantidad_Empleados { get; set; }

        public BEDetalleHorario Detalle_Horario { get; set; }
    }
}
