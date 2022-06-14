using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermiso
    {
        public int Codigo { get; set; }

        public BERol Rol { get; set; }

        public BEMenu Menu { get; set; }

        public int Activo { get; set; }
    }
}
