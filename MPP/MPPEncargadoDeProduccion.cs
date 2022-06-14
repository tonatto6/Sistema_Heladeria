using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Encriptacion;
using BE;
using System.Xml.Linq;
using System.Xml;

namespace MPP
{
    public class MPPEncargadoDeProduccion
    {

        #region campos

        MPPMenu oMPPMenu;
        MPPUsuario oMPPUsuario;

        #endregion


        #region Funciones

        public List<BEEncargadoProduccion> Listar_Encargados_Produccion()
        {
            oMPPMenu = new MPPMenu();
            oMPPUsuario = new MPPUsuario();

            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            var consulta = from Encargado_Produccion in XElement.Load("Encargados_Produccion.xml").Elements("Encargado_Produccion")
                           select new BEEncargadoProduccion
                           {
                               Codigo = Convert.ToInt32(Convert.ToString(Encargado_Produccion.Attribute("Codigo").Value).Trim()),
                               DNI = Convert.ToInt32(Convert.ToString(Encargado_Produccion.Element("DNI").Value).Trim()),
                               Nombre = Convert.ToString(Encargado_Produccion.Element("Nombre").Value).Trim(),
                               Apellido = Convert.ToString(Encargado_Produccion.Element("Apellido").Value).Trim(),
                               Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Encargado_Produccion.Element("Codigo_Usuario").Value)),
                               Rol = oMPPMenu.Buscar_Rol(Convert.ToInt32(Encargado_Produccion.Element("Codigo_Rol").Value)),
                           };
            List<BEEncargadoProduccion> lista_Encargado_Produccion = consulta.ToList<BEEncargadoProduccion>();
            return lista_Encargado_Produccion;
        }

        public BEEncargadoProduccion Seleccionar_Encargado_Produccion(int pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Encargado_Produccion").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo.ToString());

            BEEncargadoProduccion oBEEncargadoProduccion = new BEEncargadoProduccion();

            if(Encargado_Produccion != null)
            {
                oBEEncargadoProduccion.Codigo = Convert.ToInt32(Encargado_Produccion.Attribute("Codigo").Value);
                oBEEncargadoProduccion.DNI = Convert.ToInt32(Encargado_Produccion.Element("DNI").Value);
                oBEEncargadoProduccion.Nombre = Convert.ToString(Encargado_Produccion.Element("Nombre").Value);
                oBEEncargadoProduccion.Apellido = Convert.ToString(Encargado_Produccion.Element("Apellido").Value);
            }
            else { oBEEncargadoProduccion = null; }

            return oBEEncargadoProduccion;
        }

        public BEEncargadoProduccion Seleccionar_Encargado_Produccion(string pDNI)
        {
            oMPPUsuario = new MPPUsuario();
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Encargado_Produccion").FirstOrDefault(x => x.Element("DNI").Value == pDNI);

            BEEncargadoProduccion oBEEncargadoProduccion = new BEEncargadoProduccion();

            if (Encargado_Produccion != null)
            {
                oBEEncargadoProduccion.Codigo = Convert.ToInt32(Encargado_Produccion.Attribute("Codigo").Value);
                oBEEncargadoProduccion.DNI = Convert.ToInt32(Encargado_Produccion.Element("DNI").Value);
                oBEEncargadoProduccion.Nombre = Convert.ToString(Encargado_Produccion.Element("Nombre").Value);
                oBEEncargadoProduccion.Apellido = Convert.ToString(Encargado_Produccion.Element("Apellido").Value);
                oBEEncargadoProduccion.Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Encargado_Produccion.Element("Codigo_Usuario").Value));
            }
            else { oBEEncargadoProduccion = null; }

            return oBEEncargadoProduccion;
        }

        public BEEncargadoProduccion Seleccionar_Encargado_Produccion(BEUsuario Usuario)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Encargado_Produccion").FirstOrDefault(x => x.Element("Codigo_Usuario").Value == Usuario.Codigo.ToString());

            BEEncargadoProduccion oBEEncargadoProduccion = new BEEncargadoProduccion();

            if (Encargado_Produccion != null)
            {
                oBEEncargadoProduccion.Codigo = Convert.ToInt32(Encargado_Produccion.Attribute("Codigo").Value);
                oBEEncargadoProduccion.DNI = Convert.ToInt32(Encargado_Produccion.Element("DNI").Value);
                oBEEncargadoProduccion.Nombre = Convert.ToString(Encargado_Produccion.Element("Nombre").Value);
                oBEEncargadoProduccion.Apellido = Convert.ToString(Encargado_Produccion.Element("Apellido").Value);
                oBEEncargadoProduccion.Rol = new BERol();
                oBEEncargadoProduccion.Rol.Codigo = Convert.ToInt32(Encargado_Produccion.Element("Codigo_Rol").Value.ToString());
            }
            else { oBEEncargadoProduccion = null; }

            return oBEEncargadoProduccion;
        }

        public bool Agregar(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            xmlDoc.Element("Encargados_Produccion").Add(new XElement("Encargado_Produccion",
                new XAttribute("Codigo", oBEEncargadoProduccion.Codigo),
                new XElement("DNI", oBEEncargadoProduccion.DNI),
                new XElement("Nombre", oBEEncargadoProduccion.Nombre),
                new XElement("Apellido", oBEEncargadoProduccion.Apellido),
                new XElement("Codigo_Usuario", oBEEncargadoProduccion.Usuario.Codigo),
                new XElement("Codigo_Rol", oBEEncargadoProduccion.Rol.Codigo)));

            xmlDoc.Save("Encargados_Produccion.xml");
            return true;
        }

        public bool Eliminar(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Encargado_Produccion").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEEncargadoProduccion.Codigo);
            if(Encargado_Produccion != null)
            {
                Encargado_Produccion.Remove();
                xmlDoc.Save("Encargados_Produccion.xml");
                return true;
            }
            else { return false; }
        }
    
        public bool Modificar(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Produccion.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Encargado_Produccion").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEEncargadoProduccion.Codigo);
            if(Encargado_Produccion != null)
            {
                Encargado_Produccion.Element("DNI").Value = oBEEncargadoProduccion.DNI.ToString();
                Encargado_Produccion.Element("Nombre").Value = oBEEncargadoProduccion.Nombre;
                Encargado_Produccion.Element("Apellido").Value = oBEEncargadoProduccion.Apellido;
                xmlDoc.Save("Encargados_Produccion.xml");

                return true;
            }
            else { return false; }
        }

        public int Crear_Codigo_Encargado_Produccion()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Encargados_Produccion.xml");

            XmlNodeList Encargado_Produccion = xmlDoc.GetElementsByTagName("Encargados_Produccion");
            XmlNodeList lista = ((XmlElement)Encargado_Produccion[0]).GetElementsByTagName("Encargado_Produccion");

            int _nuevoCodigo = 0;

            foreach (XmlElement nodo in lista)
            {
                int _codigo = Convert.ToInt32(nodo.GetAttribute("Codigo"));

                if (_codigo > _nuevoCodigo)
                {
                    _nuevoCodigo = _codigo;
                }
            }

            _nuevoCodigo++;
            return _nuevoCodigo;
        }

        public List<BEEncargadoProduccion> Buscar_Encargado_Produccion(string pApellido)
        {
            XElement xmlDoc = XElement.Load("Encargados_Produccion.xml");

            var consulta =
                from Encargado_Produccion in xmlDoc.Descendants("Encargado_Produccion") where
                Encargado_Produccion.Element("Apellido").Value.StartsWith(pApellido) select new BEEncargadoProduccion()
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Encargado_Produccion.Attribute("Codigo").Value.Trim())),
                    DNI = Convert.ToInt32(Encargado_Produccion.Element("DNI").Value.Trim().ToString()),
                    Nombre = Encargado_Produccion.Element("Nombre").Value.Trim().ToString(),
                    Apellido = Encargado_Produccion.Element("Apellido").Value.Trim().ToString(),
                };

            List<BEEncargadoProduccion> lista_Encargados_Produccion = consulta.ToList<BEEncargadoProduccion>();

            return lista_Encargados_Produccion;
        }

        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            BEEncargadoProduccion Encargado_Produccion = (BEEncargadoProduccion)Seleccionar_Encargado_Produccion(pDNI);
            if(Encargado_Produccion != null)
            {
                XDocument xmlDoc = XDocument.Load("Usuarios.xml", LoadOptions.None);

                IEnumerable<XElement> Usuarios = xmlDoc.Descendants("Usuario");

                foreach (XElement oUsuario in Usuarios)
                {
                    if (oUsuario.Attribute("Codigo").Value == Encargado_Produccion.Usuario.Codigo.ToString())
                    {
                        oUsuario.Element("Contraseña").Value = pNuevaContraseña;

                        xmlDoc.Save("Usuarios.xml");

                        return true;
                    }
                }
            }

            return false; 
        }

        public bool Verificar_Encargado_Produccion_Pedido(BEEncargadoProduccion oBEEncargadoProduccion)
        {
            XDocument xmlDoc = XDocument.Load("Pedidos.xml");
            XElement Encargado_Produccion = xmlDoc.Descendants("Pedido").FirstOrDefault(x => (x.Element("Id_Encargado_Atencion").Value) == oBEEncargadoProduccion.Codigo.ToString());

            if (Encargado_Produccion != null)
            {
                return true;
            }
            else { return false; }
        }

        #endregion

    }
}
