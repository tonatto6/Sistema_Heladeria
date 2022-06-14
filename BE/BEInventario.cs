using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEInventario
    {
        #region Propiedades

            public int Codigo { get; set; }

            public BEProducto Codigo_Producto { get; set; }
            
            public int Cantidad_Producto { get; set; }

        #endregion
    }
}
