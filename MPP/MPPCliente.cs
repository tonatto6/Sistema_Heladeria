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
    public class MPPCliente
    {

        #region Funciones

        public List<BECliente> Listar_Clientes()
        {
            var consulta =
                from Cliente in XElement.Load("Clientes.xml").Elements("Cliente")
                select new BECliente
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Cliente.Attribute("Codigo").Value).Trim()),
                    DNI = Convert.ToInt32(Convert.ToString(Cliente.Element("DNI").Value).Trim()),
                    Nombre = Convert.ToString(Cliente.Element("Nombre").Value).Trim(),
                    Apellido = Convert.ToString(Cliente.Element("Apellido").Value).Trim(),
                };

            List<BECliente> lista_Clientes = consulta.ToList<BECliente>();
            return lista_Clientes;
        }

        public BECliente Buscar_Cliente(string pDNI)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            XElement Cliente = xmlDoc.Descendants("Cliente").FirstOrDefault(x => x.Element("DNI").Value == pDNI);

            BECliente oBECliente = new BECliente();

            if (Cliente != null)
            {
                oBECliente.Codigo = Convert.ToInt32(Cliente.Attribute("Codigo").Value);
                oBECliente.DNI = Convert.ToInt32(Cliente.Element("DNI").Value);
                oBECliente.Nombre = Cliente.Element("Nombre").Value.ToString();
                oBECliente.Apellido = Cliente.Element("Apellido").Value.ToString();
            }
            else { oBECliente = null; }

            return oBECliente;
        }

        public bool Validar_Cliente_DNI(string pDNI)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            XElement Cliente = xmlDoc.Descendants("Cliente").FirstOrDefault(x => x.Element("DNI").Value == pDNI);

            if (Cliente != null)
            {
                return true;
            }
            else { return false; }
        }

        public BECliente Seleccionar_Cliente(int pCodigo)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            XElement Cliente = xmlDoc.Descendants("Cliente").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo.ToString());

            BECliente oBECliente = new BECliente();

            if(Cliente != null)
            {
                oBECliente.Codigo = Convert.ToInt32(Cliente.Attribute("Codigo").Value);
                oBECliente.DNI = Convert.ToInt32(Cliente.Element("DNI").Value);
                oBECliente.Nombre = Convert.ToString(Cliente.Element("Nombre").Value);
                oBECliente.Apellido = Convert.ToString(Cliente.Element("Apellido").Value);
            }
            else { oBECliente = null; }
            
            return oBECliente;
        }
        
        public List<BECliente> Buscar_Clientes(string pApellido)
        {
            XElement xmlDoc = XElement.Load("Clientes.xml");
            var consulta =
                from Cliente in xmlDoc.Descendants("Cliente") where
                Cliente.Element("Apellido").Value.StartsWith(pApellido) 
                select new BECliente()
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Cliente.Attribute("Codigo").Value.Trim())),
                    DNI = Convert.ToInt32(Convert.ToString(Cliente.Element("DNI").Value.Trim())),
                    Nombre = Convert.ToString(Cliente.Element("Nombre").Value.Trim()),
                    Apellido = Convert.ToString(Cliente.Element("Apellido").Value.Trim()),
                };

            List<BECliente> lista_Clientes = consulta.ToList<BECliente>();
            return lista_Clientes;
        }

        public List<BECliente> Listar_Clientes_X_Mes(string pMes, string pAño)
        {
            List<BECliente> Lista_Clientes = new List<BECliente>();
            BECliente Cliente = new BECliente();

            XDocument xmlDoc = XDocument.Load("Pedidos.xml");
            XElement lista_Pedidos = xmlDoc.Element("Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach(XElement Pedido in Pedidos)
            {
                if (Convert.ToString(Convert.ToDateTime(Pedido.Element("Fecha").Value).Month) == pMes && Convert.ToString(Convert.ToDateTime(Pedido.Element("Fecha").Value).Year) == pAño)
                {
                    Cliente = (BECliente)Seleccionar_Cliente(Convert.ToInt32(Pedido.Element("Id_Cliente").Value));
                    int x = 0;
                    foreach(BECliente cliente in Lista_Clientes)
                    {
                        if(cliente.Codigo == Cliente.Codigo)
                        { x = 1; }
                    }

                    if(x == 0)
                    { Lista_Clientes.Add(Cliente); }
                }
            }

            return Lista_Clientes;
        }

        public void Agregar(BECliente oBECliente)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            xmlDoc.Element("Clientes").Add(new XElement("Cliente",
                new XAttribute("Codigo", oBECliente.Codigo),
                new XElement("DNI", oBECliente.DNI),
                new XElement("Nombre", oBECliente.Nombre),
                new XElement("Apellido", oBECliente.Apellido)));

            xmlDoc.Save("Clientes.xml");
        }
        
        public void Eliminar(BECliente oBECliente)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            XElement Cliente = xmlDoc.Descendants("Cliente").FirstOrDefault(X => Convert.ToInt32(X.Attribute("Codigo").Value) == oBECliente.Codigo);
            if(Cliente != null)
            {
                Cliente.Remove();
                xmlDoc.Save("Clientes.xml");
            }
        }

        public void Modificar(BECliente oBECliente)
        {
            XDocument xmlDoc = XDocument.Load("Clientes.xml");
            XElement Cliente = xmlDoc.Descendants("Cliente").FirstOrDefault(X => Convert.ToInt32(X.Attribute("Codigo").Value) == oBECliente.Codigo);
            if(Cliente != null)
            {
                Cliente.Element("DNI").Value = oBECliente.DNI.ToString();
                Cliente.Element("Nombre").Value = oBECliente.Nombre;
                Cliente.Element("Apellido").Value = oBECliente.Apellido;
                xmlDoc.Save("Clientes.xml");
            }
        }
    
        public int Crear_Codigo_Cliente()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Clientes.xml");

            XmlNodeList Cliente = xmlDoc.GetElementsByTagName("Clientes");
            XmlNodeList lista = ((XmlElement)Cliente[0]).GetElementsByTagName("Cliente");

            int _nuevoCodigo = 0;

            foreach(XmlElement nodo in lista)
            {
                int _codigo = Convert.ToInt32(nodo.GetAttribute("Codigo"));

                if(_codigo > _nuevoCodigo)
                {
                    _nuevoCodigo = _codigo;
                }
            }

            _nuevoCodigo++;
            return _nuevoCodigo;
        }
    
        public bool Verificar_Eliminacion_Cliente(BECliente oBECliente)
        {
            //Este metodo permite verificar si el cliente esta sujeto a algun pedido
            //en caso de ser que si, no se podra eliminar.
            bool _cliente = false;

            XDocument xmlDoc = XDocument.Load("Pedidos.xml", LoadOptions.None);

            XElement Lista_Pedidos = xmlDoc.Element("Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach(XElement Pedido in Pedidos)
            {
                if(Pedido.Element("Id_Cliente").Value == oBECliente.Codigo.ToString())
                {
                    _cliente = true;
                }
            }

            return _cliente;
        }

        #endregion

    }
}
