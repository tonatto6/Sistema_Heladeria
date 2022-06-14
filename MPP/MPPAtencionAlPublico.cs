using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.Xml;

namespace MPP
{
    public class MPPAtencionAlPublico
    {

        #region Campos

        MPPMenu oMPPMenu;
        MPPUsuario oMPPUsuario;
        #endregion

        #region Funciones

        public List<BEAtencionAlPublico> Listar_Atencion_Al_Publico()
        {
            oMPPMenu = new MPPMenu();
            oMPPUsuario = new MPPUsuario();

            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            var consulta = from Atencion_Al_Publico in XElement.Load("Encargados_Atencion_Publico.xml").Elements("Encargado_Atencion")
                           select new BEAtencionAlPublico
                           {
                               Codigo = Convert.ToInt32(Convert.ToString(Atencion_Al_Publico.Attribute("Codigo").Value).Trim()),
                               DNI = Convert.ToInt32(Convert.ToString(Atencion_Al_Publico.Element("DNI").Value).Trim()),
                               Nombre = Convert.ToString(Atencion_Al_Publico.Element("Nombre").Value).Trim(),
                               Apellido = Convert.ToString(Atencion_Al_Publico.Element("Apellido").Value).Trim(),
                               Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Atencion_Al_Publico.Element("Codigo_Usuario").Value)),
                               Rol = oMPPMenu.Buscar_Rol(Convert.ToInt32(Atencion_Al_Publico.Element("Codigo_Rol").Value)),
                           };
            List<BEAtencionAlPublico> lista_Atencion_Al_Publico = consulta.ToList<BEAtencionAlPublico>();
            return lista_Atencion_Al_Publico;
        }

        public List<BEAtencionAlPublico> Buscar_Encargado(string pApellido)
        {
            oMPPUsuario = new MPPUsuario();
            XElement xmlDoc = XElement.Load("Encargados_Atencion_Publico.xml");

            var consulta = 
                from Encargado_Atencion in xmlDoc.Descendants("Encargado_Atencion") where
                Encargado_Atencion.Element("Apellido").Value.StartsWith(pApellido) select
                new BEAtencionAlPublico()
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Encargado_Atencion.Attribute("Codigo").Value.Trim())),
                    DNI = Convert.ToInt32(Encargado_Atencion.Element("DNI").Value.Trim().ToString()),
                    Nombre = Encargado_Atencion.Element("Nombre").Value.Trim().ToString(),
                    Apellido = Encargado_Atencion.Element("Apellido").Value.Trim().ToString(),
                    Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Encargado_Atencion.Element("Codigo_Usuario").Value.Trim().ToString())),
                };

            List<BEAtencionAlPublico> lista_Encargados_Atencion = consulta.ToList<BEAtencionAlPublico>();
            return lista_Encargados_Atencion;
        }

        public BEAtencionAlPublico Seleccionar_Encargado(int pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            XElement Encargado_Atencion = xmlDoc.Descendants("Encargado_Atencion").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo.ToString());

            BEAtencionAlPublico oBEAtencionPublico = new BEAtencionAlPublico();
            
            if(Encargado_Atencion != null)
            {
                oBEAtencionPublico.Codigo = Convert.ToInt32(Encargado_Atencion.Attribute("Codigo").Value);
                oBEAtencionPublico.DNI = Convert.ToInt32(Encargado_Atencion.Element("DNI").Value);
                oBEAtencionPublico.Nombre = Convert.ToString(Encargado_Atencion.Element("Nombre").Value);
                oBEAtencionPublico.Apellido = Convert.ToString(Encargado_Atencion.Element("Apellido").Value);
            }
            else { oBEAtencionPublico = null; }

            return oBEAtencionPublico;
        }

        public BEAtencionAlPublico Seleccionar_Encargado(string pDNI)
        {
            oMPPUsuario = new MPPUsuario();
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            XElement Encargado_Atencion = xmlDoc.Descendants("Encargado_Atencion").FirstOrDefault(x => x.Element("DNI").Value == pDNI);

            BEAtencionAlPublico oBEAtencionPublico = new BEAtencionAlPublico();

            if (Encargado_Atencion != null)
            {
                oBEAtencionPublico.Codigo = Convert.ToInt32(Encargado_Atencion.Attribute("Codigo").Value);
                oBEAtencionPublico.DNI = Convert.ToInt32(Encargado_Atencion.Element("DNI").Value);
                oBEAtencionPublico.Nombre = Convert.ToString(Encargado_Atencion.Element("Nombre").Value);
                oBEAtencionPublico.Apellido = Convert.ToString(Encargado_Atencion.Element("Apellido").Value);
                oBEAtencionPublico.Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Encargado_Atencion.Element("Codigo_Usuario").Value));
            }
            else { oBEAtencionPublico = null; }

            return oBEAtencionPublico;
        }

        public BEAtencionAlPublico Seleccionar_Encargado(BEUsuario Usuario)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            XElement Encargado_Atencion = xmlDoc.Descendants("Encargado_Atencion").FirstOrDefault(x => x.Element("Codigo_Usuario").Value == Usuario.Codigo.ToString());

            BEAtencionAlPublico oBEAtencionPublico = new BEAtencionAlPublico();

            if (Encargado_Atencion != null)
            {
                oBEAtencionPublico.Codigo = Convert.ToInt32(Encargado_Atencion.Attribute("Codigo").Value);
                oBEAtencionPublico.DNI = Convert.ToInt32(Encargado_Atencion.Element("DNI").Value);
                oBEAtencionPublico.Nombre = Convert.ToString(Encargado_Atencion.Element("Nombre").Value);
                oBEAtencionPublico.Apellido = Convert.ToString(Encargado_Atencion.Element("Apellido").Value);
                oBEAtencionPublico.Rol = new BERol();
                oBEAtencionPublico.Rol.Codigo = Convert.ToInt32(Encargado_Atencion.Element("Codigo_Rol").Value.ToString());
            }
            else { oBEAtencionPublico = null; }

            return oBEAtencionPublico;
        }
        
        public bool Agregar(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            xmlDoc.Element("Encargados_Atencion_Publico").Add(new XElement("Encargado_Atencion",
                new XAttribute("Codigo", oBEAtencionAlPublico.Codigo),
                new XElement("DNI", oBEAtencionAlPublico.DNI),
                new XElement("Nombre", oBEAtencionAlPublico.Nombre),
                new XElement("Apellido", oBEAtencionAlPublico.Apellido),
                new XElement("Codigo_Usuario", oBEAtencionAlPublico.Usuario.Codigo),
                new XElement("Codigo_Rol", oBEAtencionAlPublico.Rol.Codigo)));

            xmlDoc.Save("Encargados_Atencion_Publico.xml");
            return true;
        }

        public bool Eliminar(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            XElement AtencionAlPublico = xmlDoc.Descendants("Encargado_Atencion").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEAtencionAlPublico.Codigo);
            if(AtencionAlPublico != null)
            {
                AtencionAlPublico.Remove();
                xmlDoc.Save("Encargados_Atencion_Publico.xml");

                return true;
            }
            else { return false; }
        }

        public bool Modificar(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            XDocument xmlDoc = XDocument.Load("Encargados_Atencion_Publico.xml");
            XElement AtencionAlPublico = xmlDoc.Descendants("Encargado_Atencion").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEAtencionAlPublico.Codigo);
            if(AtencionAlPublico != null)
            {
                AtencionAlPublico.Element("DNI").Value = oBEAtencionAlPublico.DNI.ToString();
                AtencionAlPublico.Element("Nombre").Value = oBEAtencionAlPublico.Nombre;
                AtencionAlPublico.Element("Apellido").Value = oBEAtencionAlPublico.Apellido;
                xmlDoc.Save("Encargados_Atencion_Publico.xml");

                return true;
            }
            else { return false; }
        
        }

        public int Crear_Codigo_Atencion_Al_Publico()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Encargados_Atencion_Publico.xml");

            XmlNodeList Atencion_Al_Publico = xmlDoc.GetElementsByTagName("Encargados_Atencion_Publico");
            XmlNodeList lista = ((XmlElement)Atencion_Al_Publico[0]).GetElementsByTagName("Encargado_Atencion");

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

        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            BEAtencionAlPublico Atencion_Publico = (BEAtencionAlPublico)Seleccionar_Encargado(pDNI);
            
            if(Atencion_Publico != null)
            {
                XDocument xmlDoc = XDocument.Load("Usuarios.xml", LoadOptions.None);

                IEnumerable<XElement> Usuarios = xmlDoc.Descendants("Usuario");

                foreach (XElement oUsuario in Usuarios)
                {
                    if (oUsuario.Attribute("Codigo").Value == Atencion_Publico.Usuario.Codigo.ToString())
                    {
                        oUsuario.Element("Contraseña").Value = pNuevaContraseña;

                        xmlDoc.Save("Usuarios.xml");

                        return true;
                    }
                }
            }

            return false;
        }

        public bool Verificar_Encargado_Atencion_Pedido(BEAtencionAlPublico oBEAtencionAlPublico)
        {
            XDocument xmlDoc = XDocument.Load("Pedidos.xml");
            XElement Atencion_Al_Publico = xmlDoc.Descendants("Pedido").FirstOrDefault(x => (x.Element("Id_Encargado_Atencion").Value) == oBEAtencionAlPublico.Codigo.ToString());

            if (Atencion_Al_Publico != null)
            {
                return true;
            }
            else { return false; }
        }

        #endregion

    }
}
