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
    public class MPPPedidos
    {

        #region Campos

        MPPAtencionAlPublico oMPPAtencionPublico;
        MPPCliente oMPPCliente;
        MPPMetodoDePago oMPPMetodoPago;
        MPPJefe oMPPJefe;
        MPPMenu oMPPMenu;

        #endregion

        #region Funciones

        public int Generar_Numero_Pedido()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Pedidos.xml");

            XmlNodeList Pedido = xmlDoc.GetElementsByTagName("Pedidos");
            XmlNodeList lista = ((XmlElement)Pedido[0]).GetElementsByTagName("Pedido");

            int nuevo_NPedido = 0;

            foreach(XmlElement nodo in lista)
            {
                int _nPedido = Convert.ToInt32(nodo.GetAttribute("N_Pedido"));

                if(_nPedido > nuevo_NPedido)
                {
                    nuevo_NPedido = _nPedido;
                }
            }

            nuevo_NPedido++;
            return nuevo_NPedido;
        }

        public void Agregar_Nuevo_Pedido(BEPedido oBEPedido)
        {
            XDocument xmlDoc = XDocument.Load("Pedidos.xml");
            xmlDoc.Element("Pedidos").Add(new XElement("Pedido",
                new XAttribute("N_Pedido", oBEPedido.N_Pedido),
                new XElement("Id_Encargado_Atencion", oBEPedido.Encargado_Venta.Codigo),
                new XElement("Rol", oBEPedido.Encargado_Venta.Rol.Codigo),
                new XElement("Id_Cliente", oBEPedido.Cliente.Codigo),
                new XElement("Monto_Total", oBEPedido.Monto_Total),
                new XElement("Fecha", oBEPedido.Fecha.ToShortDateString()),
                new XElement("Id_Metodo_Pago", oBEPedido.Metodo_Pago.Codigo)));

            xmlDoc.Save("Pedidos.xml");

            Agregar_Detalle_Pedidos(oBEPedido);
        }
    
        public void Agregar_Detalle_Pedidos(BEPedido oBEPedido)
        {
            XDocument xmlDoc = XDocument.Load("Detalle_Pedidos.xml");

            foreach(BEDetallePedido detalle_pedido in oBEPedido.Retornar_ListaDetalles(oBEPedido))
            {
                xmlDoc.Element("Detalle_Pedidos").Add(new XElement("Detalle_Pedido",
                new XAttribute("N_Pedido", oBEPedido.N_Pedido),
                new XElement("Codigo_Producto", detalle_pedido.Producto.Codigo),
                new XElement("Precio_Unitario", detalle_pedido.Producto.Precio)));
            }

            xmlDoc.Save("Detalle_Pedidos.xml");

        }
    
        public List<BEPedido> Listar_Pedidos()
        {

            #region Campos

            oMPPCliente = new MPPCliente();
            oMPPMetodoPago = new MPPMetodoDePago();
            oMPPMenu = new MPPMenu();

            #endregion

            List<BEPedido> Lista_Pedidos = new List<BEPedido>();

            XDocument xmlDoc = XDocument.Load("Pedidos.xml", LoadOptions.None);
            XElement Lista_Pedido = xmlDoc.Element("Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach(XElement Pedido in Pedidos)
            {
                BEPedido oBEPedido = new BEPedido();
                oBEPedido.N_Pedido = Convert.ToInt32(Pedido.Attribute("N_Pedido").Value);
                if(Pedido.Element("Rol").Value == "1")
                {
                    //El encargado de venta es un jefe
                    oMPPJefe = new MPPJefe();
                    oBEPedido.Encargado_Venta = oMPPJefe.Seleccionar_Jefe(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                }
                else
                {
                    //Es un encargado de atencion al publico
                    oMPPAtencionPublico = new MPPAtencionAlPublico();
                    oBEPedido.Encargado_Venta = oMPPAtencionPublico.Seleccionar_Encargado(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                }
                oBEPedido.Encargado_Venta.Rol = oMPPMenu.Buscar_Rol(Convert.ToInt32(Pedido.Element("Rol").Value));
                oBEPedido.Cliente = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Pedido.Element("Id_Cliente").Value));
                oBEPedido.Monto_Total = Convert.ToDecimal(Pedido.Element("Monto_Total").Value);
                oBEPedido.Fecha = Convert.ToDateTime(Pedido.Element("Fecha").Value);
                oBEPedido.Metodo_Pago = oMPPMetodoPago.Seleccionar_Metodo(Convert.ToInt32(Pedido.Element("Id_Metodo_Pago").Value));

                Lista_Pedidos.Add(oBEPedido);
            }

            return Lista_Pedidos;
        }

        public List<BEProducto> Listar_Productos_Por_Pedido(string pN_Pedido)
        {

            #region Campos

            List<BEProducto> Lista_Productos = new List<BEProducto>();
            MPPProducto oMPPProducto = new MPPProducto();
            BEProducto oBEProducto;

            #endregion

            XDocument xmlDoc = XDocument.Load("Detalle_Pedidos.xml", LoadOptions.None);

            XElement Lista_Pedidos = xmlDoc.Element("Detalle_Pedidos");

            IEnumerable<XElement> Detalle_Pedidos = xmlDoc.Descendants("Detalle_Pedido");

            foreach (XElement Detalle_Pedido in Detalle_Pedidos)
            {
                if(Detalle_Pedido.Attribute("N_Pedido").Value == pN_Pedido)
                {
                    oBEProducto = new BEProducto();
                    oBEProducto = oMPPProducto.Seleccionar_Producto(Detalle_Pedido.Element("Codigo_Producto").Value);
                    oBEProducto.Precio = Convert.ToDecimal(Detalle_Pedido.Element("Precio_Unitario").Value);
                    Lista_Productos.Add(oBEProducto);
                    //Lista_Productos.Add(oMPPProducto.Seleccionar_Producto(Detalle_Pedido.Element("Codigo_Producto").Value));
                }
            }

            return Lista_Productos;
        }

        public List<BEPedido> Listar_Pedidos_X_Fecha(DateTime pFecha)
        {
            #region Campos

            oMPPCliente = new MPPCliente();
            oMPPMetodoPago = new MPPMetodoDePago();
            oMPPMenu = new MPPMenu();

            #endregion

            List<BEPedido> Lista_Pedidos = new List<BEPedido>();

            XDocument xmlDoc = XDocument.Load("Pedidos.xml", LoadOptions.None);
            XElement Lista_Pedido = xmlDoc.Element("Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach (XElement Pedido in Pedidos)
            {
                if (Convert.ToDateTime(Pedido.Element("Fecha").Value) == pFecha.Date)
                {
                    BEPedido oBEPedido = new BEPedido();
                    oBEPedido.N_Pedido = Convert.ToInt32(Pedido.Attribute("N_Pedido").Value);
                    if (Pedido.Element("Rol").Value == "1")
                    {
                        //El encargado de venta es un jefe
                        oMPPJefe = new MPPJefe();
                        oBEPedido.Encargado_Venta = oMPPJefe.Seleccionar_Jefe(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                    }
                    else
                    {
                        //Es un encargado de atencion al publico
                        oMPPAtencionPublico = new MPPAtencionAlPublico();
                        oBEPedido.Encargado_Venta = oMPPAtencionPublico.Seleccionar_Encargado(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                    }
                    oBEPedido.Encargado_Venta.Rol = oMPPMenu.Buscar_Rol(Convert.ToInt32(Pedido.Element("Rol").Value));
                    oBEPedido.Cliente = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Pedido.Element("Id_Cliente").Value));
                    oBEPedido.Monto_Total = Convert.ToDecimal(Pedido.Element("Monto_Total").Value);
                    oBEPedido.Fecha = Convert.ToDateTime(Pedido.Element("Fecha").Value);
                    oBEPedido.Metodo_Pago = oMPPMetodoPago.Seleccionar_Metodo(Convert.ToInt32(Pedido.Element("Id_Metodo_Pago").Value));

                    Lista_Pedidos.Add(oBEPedido);
                }

            }

            return Lista_Pedidos;
        }

        public List<BEPedido> Listar_Pedidos_X_Mes(int pMes)
        {
            #region Campos

            oMPPCliente = new MPPCliente();
            oMPPMetodoPago = new MPPMetodoDePago();
            oMPPMenu = new MPPMenu();

            #endregion

            List<BEPedido> Lista_Pedidos = new List<BEPedido>();

            XDocument xmlDoc = XDocument.Load("Pedidos.xml", LoadOptions.None);
            XElement Lista_Pedido = xmlDoc.Element("Pedidos");
            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach (XElement Pedido in Pedidos)
            {
                if(Convert.ToDateTime(Pedido.Element("Fecha").Value).Month == pMes)
                {

                    BEPedido oBEPedido = new BEPedido();
                    oBEPedido.N_Pedido = Convert.ToInt32(Pedido.Attribute("N_Pedido").Value);
                    if (Pedido.Element("Rol").Value == "1")
                    {
                        //El encargado de venta es un jefe
                        oMPPJefe = new MPPJefe();
                        oBEPedido.Encargado_Venta = oMPPJefe.Seleccionar_Jefe(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                    }
                    else
                    {
                        //Es un encargado de atencion al publico
                        oMPPAtencionPublico = new MPPAtencionAlPublico();
                        oBEPedido.Encargado_Venta = oMPPAtencionPublico.Seleccionar_Encargado(Convert.ToInt32(Pedido.Element("Id_Encargado_Atencion").Value));
                    }
                    oBEPedido.Encargado_Venta.Rol = oMPPMenu.Buscar_Rol(Convert.ToInt32(Pedido.Element("Rol").Value));
                    oBEPedido.Cliente = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Pedido.Element("Id_Cliente").Value));
                    oBEPedido.Monto_Total = Convert.ToDecimal(Pedido.Element("Monto_Total").Value);
                    oBEPedido.Fecha = Convert.ToDateTime(Pedido.Element("Fecha").Value);
                    oBEPedido.Metodo_Pago = oMPPMetodoPago.Seleccionar_Metodo(Convert.ToInt32(Pedido.Element("Id_Metodo_Pago").Value));

                    Lista_Pedidos.Add(oBEPedido);
                }

            }

            return Lista_Pedidos;
        }

        public double Calcular_Total_Todos_Los_Pedidos()
        {
            double monto_total = 0;

            XDocument xmlDoc = XDocument.Load("Pedidos.xml", LoadOptions.None);

            XElement Lista_Pedidos = xmlDoc.Element("Pedidos");

            IEnumerable<XElement> Pedidos = xmlDoc.Descendants("Pedido");

            foreach(XElement Pedido in Pedidos)
            {
                monto_total = monto_total + Convert.ToDouble(Pedido.Element("Monto_Total").Value);
            }

            return monto_total;
        }

        #endregion

    }
}
