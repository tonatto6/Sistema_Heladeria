using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace MPP
{
    public class MPPMenu
    {
        public List<BEMenu> Listar_Menu()
        {
            var consulta =
                from Menu in XElement.Load("Menu.xml").Elements("Menu")
                select new BEMenu
                {
                    codigo = Convert.ToInt32(Convert.ToString(Menu.Attribute("Codigo").Value).Trim()),
                    Nombre = Convert.ToString(Menu.Element("Nombre").Value).Trim(),
                };

            List<BEMenu> lista_menu = consulta.ToList<BEMenu>();
            return lista_menu;
        }

        public BERol Buscar_Rol(int pCodigo_Rol)
        {
            XDocument xmlDoc = XDocument.Load("Rol.xml");
            XElement Rol = xmlDoc.Descendants("Rol").FirstOrDefault(x => (x.Attribute("Codigo").Value) == pCodigo_Rol.ToString());

            if (Rol != null)
            {
                BERol oBERol = new BERol();
                oBERol.Codigo = Convert.ToInt32(Rol.Attribute("Codigo").Value);
                oBERol.Nombre = Rol.Element("Nombre").Value.ToString();
                return oBERol;
            }
            else { return null; }
        }

        public List<BEPermiso> Listar_Permisos(int pRol)
        {
            List<BEPermiso> lista_permisos = new List<BEPermiso>();

            XDocument xmlDoc = XDocument.Load("Permisos.xml");
            IEnumerable<XElement> Permisos = xmlDoc.Descendants("Permiso");

            foreach (XElement Permiso in Permisos)
            {
                if (Permiso.Element("Codigo_Rol").Value == pRol.ToString())
                {
                    BEPermiso oBEPermiso = new BEPermiso();
                    oBEPermiso.Codigo = Convert.ToInt32(Permiso.Attribute("Codigo").Value);
                    oBEPermiso.Menu = new BEMenu();
                    oBEPermiso.Menu.codigo = Convert.ToInt32(Permiso.Element("Codigo_Menu").Value);
                    oBEPermiso.Activo = Convert.ToInt32(Permiso.Element("Activo").Value);

                    lista_permisos.Add(oBEPermiso);
                }
            }

            return lista_permisos;
        }
    }
}
