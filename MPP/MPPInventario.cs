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
    public class MPPInventario
    {
        public int Crear_Codigo_Inventario()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Inventario.xml");

            XmlNodeList Inventario = xmlDoc.GetElementsByTagName("Inventarios");
            XmlNodeList lista = ((XmlElement)Inventario[0]).GetElementsByTagName("Inventario");

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

        public void Agregar(BEInventario oBEInventario, BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Inventario.xml");
            xmlDoc.Element("Inventarios").Add(new XElement("Inventario",
                new XAttribute("Codigo", oBEInventario.Codigo),
                new XElement("Codigo_Producto", oBEProducto.Codigo),
                new XElement("Cantidad", oBEInventario.Cantidad_Producto)));

            xmlDoc.Save("Inventario.xml");
        }
    
        public void Eliminar(BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Inventario.xml");
            XElement Inventario = xmlDoc.Descendants("Inventario").FirstOrDefault(x => Convert.ToInt32(x.Element("Codigo_Producto").Value) == oBEProducto.Codigo);
            if(Inventario != null)
            {
                Inventario.Remove();
                xmlDoc.Save("Inventario.xml");
            }
        }
    
        public void Modificar(BEInventario oBEInventario, BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Inventario.xml");
            XElement Inventario = xmlDoc.Descendants("Inventario").FirstOrDefault(x => Convert.ToInt32(x.Element("Codigo_Producto").Value) == oBEProducto.Codigo); 
            if(Inventario != null)
            {
                Inventario.Element("Cantidad").Value = oBEInventario.Cantidad_Producto.ToString();
                xmlDoc.Save("Inventario.xml");
            }
        }
    }
}
