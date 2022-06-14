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
    public class MPPContacto
    {

        //BEContacto oBEContacto;

        public List<BEContacto> Listar_Contactos(BEPersona oBEPersona, string pDescripcion_Persona)
        {
            #region Campos

            List<BEContacto> Lista_Contactos = new List<BEContacto>();

            #endregion

            XDocument xmlDoc = XDocument.Load("Contactos.xml", LoadOptions.None);

            XElement Lista_Contacto = xmlDoc.Element("Contactos");

            IEnumerable<XElement> Contactos = xmlDoc.Descendants("Contacto_Persona");

            foreach (XElement Contacto in Contactos)
            {
                if (Convert.ToInt32(Contacto.Element("Persona").Value) == oBEPersona.Codigo  && Contacto.Element("Descripcion_Persona").Value.ToString() == pDescripcion_Persona)
                {
                    BEContacto oBEContacto = new BEContacto();
                    oBEContacto.Codigo = Convert.ToInt32(Contacto.Attribute("Codigo").Value);
                    oBEContacto.Contacto = Contacto.Element("Contacto").Value.ToString();
                    Lista_Contactos.Add(oBEContacto);
                }
            }

            return Lista_Contactos;
        }

        public void Agregar_Contacto(List<BEContacto> List_Contacto)
        {
            foreach(BEContacto oBEContacto in List_Contacto)
            {
                oBEContacto.Codigo = Crear_Codigo_Contacto();

                XDocument xmlDoc = XDocument.Load("Contactos.xml");
                xmlDoc.Element("Contactos").Add(new XElement("Contacto_Persona",
                    new XAttribute("Codigo", oBEContacto.Codigo),
                    new XElement("Contacto", oBEContacto.Contacto),
                    new XElement("Persona", oBEContacto.Persona.Codigo),
                    new XElement("Descripcion_Persona", oBEContacto.Descripcion_Persona)));

                xmlDoc.Save("Contactos.xml");
            }
        }

        public int Crear_Codigo_Contacto()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Contactos.xml");

            XmlNodeList Contacto = xmlDoc.GetElementsByTagName("Contactos");
            XmlNodeList lista = ((XmlElement)Contacto[0]).GetElementsByTagName("Contacto_Persona");

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

        public void Eliminar_Contactos(BEPersona oBEPersona, string pDescripcion_Persona)
        {
            List<BEContacto> lista_contactos = new List<BEContacto>();
            lista_contactos = Listar_Contactos(oBEPersona, pDescripcion_Persona);

            XDocument xmlDoc = XDocument.Load("Contactos.xml");
            
            foreach(BEContacto oBEContacto in lista_contactos)
            {
                XElement Contaccto = xmlDoc.Descendants("Contacto_Persona").FirstOrDefault(X => Convert.ToInt32(X.Attribute("Codigo").Value) == oBEContacto.Codigo);
                if (Contaccto != null)
                {
                    Contaccto.Remove();
                    xmlDoc.Save("Contactos.xml");
                }
            }

        }

        public void Agregar_Un_Contacto(BEContacto  oBEContacto)
        {
            XDocument xmlDoc = XDocument.Load("Contactos.xml");
            xmlDoc.Element("Contactos").Add(new XElement("Contacto_Persona",
                new XAttribute("Codigo", oBEContacto.Codigo),
                new XElement("Contacto", oBEContacto.Contacto),
                new XElement("Persona", oBEContacto.Persona.Codigo),
                new XElement("Descripcion_Persona", oBEContacto.Descripcion_Persona)));

            xmlDoc.Save("Contactos.xml");
        }

        public void Eliminar_Contacto(BEContacto oBEContacto)
        {
            XDocument xmlDoc = XDocument.Load("Contactos.xml");
            XElement Contacto = xmlDoc.Descendants("Contacto_Persona").FirstOrDefault(X => Convert.ToInt32(X.Attribute("Codigo").Value) == oBEContacto.Codigo);
            if (Contacto != null)
            {
                Contacto.Remove();
                xmlDoc.Save("Contactos.xml");
            }
        }

        public void Modificar_Contacto(BEContacto oBEContacto)
        {
            XDocument xmlDoc = XDocument.Load("Contactos.xml");
            XElement Contacto = xmlDoc.Descendants("Contacto_Persona").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEContacto.Codigo);

            if(Contacto != null)
            {
                Contacto.Element("Contacto").Value = oBEContacto.Contacto;
                xmlDoc.Save("Contactos.xml");
            }
        }
    
        public bool Verificar_Contacto_Existe(BEContacto oBEContacto)
        {
            bool _contacto = false;
            XDocument xmlDoc = XDocument.Load("Contactos.xml", LoadOptions.None);

            XElement Lista_Contactos = xmlDoc.Element("Contactos");
            IEnumerable<XElement> Contactos = xmlDoc.Descendants("Contacto_Persona");

            foreach (XElement Contacto in Contactos)
            {
                if (Contacto.Element("Contacto").Value == oBEContacto.Contacto)
                {
                    _contacto = true;
                }
            }

            return _contacto;
        }
    }
}
