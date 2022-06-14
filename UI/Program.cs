using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using BE;

namespace UI
{
    static class Program
    {
        #region Propiedades

        public static bool Login { get; set; }

        public static bool Logout { get; set; }

        public static BEPersona Logueado { get; set; }

        #endregion

        #region Funciones privadas 

        private static void Limpiar_Datos()
        {
            Login = false;
            Logout = false;
            Logueado = null;
        }

        #endregion

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do
            {
                Limpiar_Datos();
                    
                Application.Run(new frmLogin());
                if (Login == true)
                {
                    Application.Run(new frmMenuPrincipal());
                }
            }
            while (Logout == true);

        }
    }
}
