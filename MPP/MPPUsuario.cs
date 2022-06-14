using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BE;

namespace MPP
{
    public class MPPUsuario
    {

        public BEUsuario Seleccionar_Usuario(string pUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            XElement Usuario = xmlDoc.Descendants("Usuario").FirstOrDefault(x => (x.Element("Nombre_Usuario").Value) == pUsuario);

            BEUsuario oBEUsuario = new BEUsuario();

            if(Usuario != null)
            {
                oBEUsuario.Codigo = Convert.ToInt32(Usuario.Attribute("Codigo").Value);
                oBEUsuario.Nombre_Usuario = Usuario.Element("Nombre_Usuario").Value.ToString();
                oBEUsuario.Contraseña = Usuario.Element("Contraseña").Value.ToString();
            }
            else { oBEUsuario = null; }

            return oBEUsuario;
        }

        public BEUsuario Seleccionar_Usuario(int pCodigo_Usuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            XElement Usuario = xmlDoc.Descendants("Usuario").FirstOrDefault(x => (x.Attribute("Codigo").Value) == pCodigo_Usuario.ToString());

            BEUsuario oBEUsuario = new BEUsuario();

            if (Usuario != null)
            {
                oBEUsuario.Codigo = Convert.ToInt32(Usuario.Attribute("Codigo").Value);
                oBEUsuario.Nombre_Usuario = Usuario.Element("Nombre_Usuario").Value.ToString();
                oBEUsuario.Contraseña = Usuario.Element("Contraseña").Value.ToString();
            }
            else { oBEUsuario = null; }

            return oBEUsuario;
        }

        public bool Agregar_Usuario(BEUsuario oBEUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            xmlDoc.Element("Usuarios").Add(new XElement("Usuario",
                new XAttribute("Codigo", oBEUsuario.Codigo),
                new XElement("Nombre_Usuario", oBEUsuario.Nombre_Usuario),
                new XElement("Contraseña", oBEUsuario.Contraseña)));

            xmlDoc.Save("Usuarios.xml");
            return true;
        }
    
        public bool Modificar_Usuario(BEUsuario oBEUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            XElement Usuario = xmlDoc.Descendants("Usuario").FirstOrDefault(x=> (x.Attribute("Codigo").Value) == oBEUsuario.Codigo.ToString());
        
            if(Usuario != null)
            {
                Usuario.Element("Nombre_Usuario").Value = oBEUsuario.Nombre_Usuario;
                Usuario.Element("Contraseña").Value = oBEUsuario.Contraseña;
                xmlDoc.Save("Usuarios.xml");
                return true;
            }

            return false;
        }

        public bool Eliminar_Usuario(BEUsuario oBEUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            XElement Usuario = xmlDoc.Descendants("Usuario").FirstOrDefault(x => (x.Attribute("Codigo").Value) == oBEUsuario.Codigo.ToString());
            
            if(Usuario != null)
            {
                Usuario.Remove();
                xmlDoc.Save("Usuarios.xml");
                return true;
            }

            return false;
        }

        public int Crear_Codigo_Usuario()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Usuarios.xml");

            XmlNodeList Usuario = xmlDoc.GetElementsByTagName("Usuarios");
            XmlNodeList lista = ((XmlElement)Usuario[0]).GetElementsByTagName("Usuario");

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

        public bool Verificar_Usuario_Existe(string pUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Usuarios.xml");
            XElement Usuario = xmlDoc.Descendants("Usuario").FirstOrDefault(x => (x.Element("Nombre_Usuario").Value) == pUsuario);

            if(Usuario != null)
            { return true; } //Usuario existe 
            else { return false; } //Usuario no existe
        }

    }
}
