using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEContacto
    {
        public int Codigo { get; set; }

        public string Contacto { get; set; }

        public BEPersona Persona { get; set; }

        public string Descripcion_Persona { get; set; }
    }
}
