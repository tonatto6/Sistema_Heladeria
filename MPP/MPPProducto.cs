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
    public class MPPProducto
    {

        #region Funciones

        public List<BEProducto> Listar_Producto()
        {
            var consulta =
                from Producto in XElement.Load("Productos.xml").Elements("Producto")
                select new BEProducto
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Producto.Attribute("Codigo").Value).Trim()),
                    Nombre = Convert.ToString(Producto.Element("Nombre").Value).Trim(),
                    Precio = Convert.ToDecimal(Convert.ToString(Producto.Element("Precio").Value).Trim()),
                    Cantidad = Convert.ToInt32(Convert.ToString(Producto.Element("Cantidad").Value).Trim()),
                };

            List<BEProducto> lista_Productos = consulta.ToList<BEProducto>();
            return lista_Productos;
        }
        
        public List<BEProducto> Buscar_Producto(string pProducto)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            var consulta=
                from Producto in xmlDoc.Descendants("Producto") where
                Producto.Element("Nombre").Value.StartsWith(pProducto) 
                select new BEProducto()
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Producto.Attribute("Codigo").Value.Trim())),
                    Nombre= Convert.ToString(Producto.Element("Nombre").Value.Trim()),
                    Precio = Convert.ToDecimal(Convert.ToString(Producto.Element("Precio").Value.Trim())),
                    Cantidad = Convert.ToInt32(Convert.ToString(Producto.Element("Cantidad").Value.Trim())),
                };

            List<BEProducto> lista_Productos = consulta.ToList<BEProducto>();
            return lista_Productos;
        }

        public List<BEProducto> Listar_Productos_Cantidad(int pCantidad)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            var consulta =
                from Producto in xmlDoc.Descendants("Producto")
                where Producto.Element("Cantidad").Value == pCantidad.ToString()
                select new BEProducto()
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Producto.Attribute("Codigo").Value.Trim())),
                    Nombre = Convert.ToString(Producto.Element("Nombre").Value.Trim()),
                    Precio = Convert.ToDecimal(Convert.ToString(Producto.Element("Precio").Value.Trim())),
                    Cantidad = Convert.ToInt32(Convert.ToString(Producto.Element("Cantidad").Value.Trim())),
                };

            List<BEProducto> lista_Productos = consulta.ToList<BEProducto>();
            return lista_Productos;
        }

        public BEProducto Seleccionar_Producto(string pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            XElement Producto = xmlDoc.Descendants("Producto").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo);

            BEProducto oBEProducto = new BEProducto();

            if(Producto != null)
            {
                oBEProducto.Codigo = Convert.ToInt32(Producto.Attribute("Codigo").Value);
                oBEProducto.Nombre = Producto.Element("Nombre").Value.ToString();
                oBEProducto.Precio = Convert.ToDecimal(Producto.Element("Precio").Value);
                oBEProducto.Cantidad = Convert.ToInt32(Producto.Element("Cantidad").Value);
            }
            else { oBEProducto = null; }

            return oBEProducto;
        }

        public void Agregar(BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            xmlDoc.Element("Productos").Add(new XElement("Producto",
                new XAttribute("Codigo", oBEProducto.Codigo),
                new XElement("Nombre", oBEProducto.Nombre),
                new XElement("Precio", oBEProducto.Precio),
                new XElement("Cantidad", oBEProducto.Cantidad)));

            xmlDoc.Save("Productos.xml");
        }
    
        public void Eliminar(BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            XElement Producto = xmlDoc.Descendants("Producto").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEProducto.Codigo);
        
            if(Producto != null)
            {
                Producto.Remove();
                xmlDoc.Save("Productos.xml");
            }
        }

        public void Modificar(BEProducto oBEProducto)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            XElement Producto = xmlDoc.Descendants("Producto").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEProducto.Codigo);

            if(Producto != null)
            {
                Producto.Element("Nombre").Value = oBEProducto.Nombre;
                Producto.Element("Precio").Value = oBEProducto.Precio.ToString();
                Producto.Element("Cantidad").Value = oBEProducto.Cantidad.ToString();
                xmlDoc.Save("Productos.xml");
            }
        }

        public int Crear_Codigo_Producto()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Productos.xml");

            XmlNodeList Producto = xmlDoc.GetElementsByTagName("Productos");
            XmlNodeList lista = ((XmlElement)Producto[0]).GetElementsByTagName("Producto");

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

        public void Restar_Producto(string pCodigo_Producto)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            XElement Producto = xmlDoc.Descendants("Producto").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo_Producto);
        
            if(Producto != null)
            {
                int cantidad = Convert.ToInt32(Producto.Element("Cantidad").Value);
                cantidad = cantidad - 1;
                Producto.Element("Cantidad").Value = cantidad.ToString();
                xmlDoc.Save("Productos.xml");
            }
        }

        public int Verificar_Cantidad_Producto(string pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Productos.xml");
            XElement Producto = xmlDoc.Descendants("Producto").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo);

            int _cantidad_Producto = 0;
            
            if (Producto != null)
            {
                _cantidad_Producto = Convert.ToInt32(Producto.Element("Cantidad").Value);
            }

            return _cantidad_Producto;
        }

        public bool Verificar_Eliminacion_Producto(BEProducto oBEProducto)
        {
            bool _producto = false;
            XDocument xmlDoc = XDocument.Load("Detalle_Pedidos.xml", LoadOptions.None);

            XElement lista_Pedidos = xmlDoc.Element("Detalle_Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Detalle_Pedido");

            foreach(XElement Pedido in Pedidos)
            {
                if(Pedido.Element("Codigo_Producto").Value == oBEProducto.Codigo.ToString())
                {
                    _producto = true;
                }
            }

            return _producto;
        }

        #endregion

    }
}
