using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESorteo
    {

        public string Mes { get; set; }

        public int Año { get; set; }

        public DateTime Fecha_Sorteo { get; set; }

        public List<BECliente> Lista_Participantes { get; set; }

        public BECliente Ganador { get; set; }

    }
}
