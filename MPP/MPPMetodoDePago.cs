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
    public class MPPMetodoDePago
    {
        public List<BEMetodoDePago> Listar_Metodos_De_Pago()
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            var consulta =
                from Metodo_Pago in XElement.Load("Metodos_De_Pago.xml").Elements("Metodo_Pago")
                select new BEMetodoDePago
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Metodo_Pago.Attribute("Codigo").Value).Trim()),
                    Nombre = Convert.ToString(Metodo_Pago.Element("Nombre").Value).Trim(),
                };

            List<BEMetodoDePago> lista_Metodos_De_Pago = consulta.ToList<BEMetodoDePago>();
            return lista_Metodos_De_Pago;
        }

        public BEMetodoDePago Seleccionar_Metodo_Pago(string pNombre)
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            XElement Metodo_Pago = xmlDoc.Descendants("Metodo_Pago").FirstOrDefault(x => x.Element("Nombre").Value == pNombre);

            BEMetodoDePago oBEMetodoPago = new BEMetodoDePago();

            if(Metodo_Pago != null)
            {
                oBEMetodoPago.Codigo = Convert.ToInt32(Metodo_Pago.Attribute("Codigo").Value);
                oBEMetodoPago.Nombre = Metodo_Pago.Element("Nombre").Value.ToString();
            }
            else { oBEMetodoPago = null; }

            return oBEMetodoPago;
        }

        public void Agregar_Metodo_Pago(BEMetodoDePago oBEMetodoPago)
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            xmlDoc.Element("Metodos_Pago").Add(new XElement("Metodo_Pago",
                new XAttribute("Codigo", oBEMetodoPago.Codigo),
                new XElement("Nombre", oBEMetodoPago.Nombre)));

            xmlDoc.Save("Metodos_De_Pago.xml");
        }
  
        public void Eliminar_Metodo_Pago(BEMetodoDePago oBEMetodoPago)
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            XElement Metodo_Pago = xmlDoc.Descendants("Metodo_Pago").FirstOrDefault(x => (Convert.ToInt32(x.Attribute("Codigo").Value)) == oBEMetodoPago.Codigo);
            
            if(Metodo_Pago != null)
            {
                Metodo_Pago.Remove();
                xmlDoc.Save("Metodos_De_Pago.xml");
            }
        }
    
        public void Modificar_Metodo_Pago(BEMetodoDePago oBEMetodoPago)
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            XElement Metodo_Pago = xmlDoc.Descendants("Metodo_Pago").FirstOrDefault(x => (Convert.ToInt32(x.Attribute("Codigo").Value)) == oBEMetodoPago.Codigo);
            if(Metodo_Pago != null)
            {
                Metodo_Pago.Element("Nombre").Value = oBEMetodoPago.Nombre.ToString();
                xmlDoc.Save("Metodos_De_Pago.xml");
            }
        }

        public BEMetodoDePago Seleccionar_Metodo(int pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Metodos_De_Pago.xml");
            XElement Metodo_Pago = xmlDoc.Descendants("Metodo_Pago").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo.ToString());

            BEMetodoDePago oBEMetodoPago = new BEMetodoDePago();

            if(Metodo_Pago != null)
            {
                oBEMetodoPago.Codigo = Convert.ToInt32(Metodo_Pago.Attribute("Codigo").Value);
                oBEMetodoPago.Nombre = Metodo_Pago.Element("Nombre").Value.ToString();
            }
            else { oBEMetodoPago = null; }

            return oBEMetodoPago;
        }

        public int Crear_Codigo_Metodo_Pago()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Metodos_De_Pago.xml");

            XmlNodeList Metodo = xmlDoc.GetElementsByTagName("Metodos_Pago");
            XmlNodeList lista = ((XmlElement)Metodo[0]).GetElementsByTagName("Metodo_Pago");

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

    }
}
