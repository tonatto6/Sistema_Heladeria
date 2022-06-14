using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using Capa_Encriptacion;
using System.Xml;

namespace MPP
{
    public class MPPJefe
    {
        MPPUsuario oMPPUsuario;

        public List<BEJefe> Listar_Jefe()
        {
            oMPPUsuario = new MPPUsuario();

            var consulta = from Jefe in XElement.Load("Jefes.xml").Elements("Jefe")
                           select new BEJefe
                           {
                               Codigo = Convert.ToInt32(Convert.ToString(Jefe.Attribute("Codigo").Value).Trim()),
                               DNI = Convert.ToInt32(Convert.ToString(Jefe.Element("DNI").Value).Trim()),
                               Nombre = Convert.ToString(Jefe.Element("Nombre").Value).Trim(),
                               Apellido = Convert.ToString(Jefe.Element("Apellido").Value).Trim(),
                               Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Jefe.Element("Codigo_Usuario").Value)),
                               Fecha_Nacimiento = Convert.ToDateTime(Convert.ToString(Jefe.Element("Fecha_Nacimiento").Value).Trim()),
                               Direccion = Convert.ToString(Jefe.Element("Direccion").Value).Trim()
                           };

            
            List<BEJefe> Lista_Jefe = consulta.ToList<BEJefe>();
            return Lista_Jefe;
        }

        public BEJefe Seleccionar_Jefe(int pCodigo)
        {
            oMPPUsuario = new MPPUsuario();
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => x.Attribute("Codigo").Value == pCodigo.ToString());

            BEJefe oBEJefe = new BEJefe();

            if(Jefe != null)
            {
                oBEJefe.Codigo = Convert.ToInt32(Jefe.Attribute("Codigo").Value);
                oBEJefe.DNI = Convert.ToInt32(Jefe.Element("DNI").Value);
                oBEJefe.Nombre = Jefe.Element("Nombre").Value;
                oBEJefe.Apellido = Jefe.Element("Apellido").Value;
                oBEJefe.Usuario = oMPPUsuario.Seleccionar_Usuario(Jefe.Element("Codigo_Usuario").Value);
                oBEJefe.Fecha_Nacimiento = Convert.ToDateTime(Jefe.Element("Fecha_Nacimiento").Value);
                oBEJefe.Direccion = Jefe.Element("Direccion").Value;
            }
            else { oBEJefe = null; }

            return oBEJefe;
        }

        public BEJefe Seleccionar_Jefe(string pDNI)
        {
            oMPPUsuario = new MPPUsuario();
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => x.Element("DNI").Value == pDNI);

            BEJefe oBEJefe = new BEJefe();

            if (Jefe != null)
            {
                oBEJefe.Codigo = Convert.ToInt32(Jefe.Attribute("Codigo").Value);
                oBEJefe.DNI = Convert.ToInt32(Jefe.Element("DNI").Value);
                oBEJefe.Nombre = Jefe.Element("Nombre").Value;
                oBEJefe.Apellido = Jefe.Element("Apellido").Value;
                oBEJefe.Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Jefe.Element("Codigo_Usuario").Value));
                oBEJefe.Fecha_Nacimiento = Convert.ToDateTime(Jefe.Element("Fecha_Nacimiento").Value);
                oBEJefe.Direccion = Jefe.Element("Direccion").Value;
            }
            else { oBEJefe = null; }

            return oBEJefe;
        }

        public BEJefe Seleccionar_Jefe(BEUsuario oBEUsuario)
        {
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => x.Element("Codigo_Usuario").Value == oBEUsuario.Codigo.ToString());

            BEJefe oBEJefe = new BEJefe();

            if (Jefe != null)
            {
                oBEJefe.Codigo = Convert.ToInt32(Jefe.Attribute("Codigo").Value);
                oBEJefe.DNI = Convert.ToInt32(Jefe.Element("DNI").Value);
                oBEJefe.Nombre = Jefe.Element("Nombre").Value;
                oBEJefe.Apellido = Jefe.Element("Apellido").Value;
                oBEJefe.Rol = new BERol();
                oBEJefe.Rol.Codigo = Convert.ToInt32(Jefe.Element("Codigo_Rol").Value.ToString());
                oBEJefe.Fecha_Nacimiento = Convert.ToDateTime(Jefe.Element("Fecha_Nacimiento").Value);
                oBEJefe.Direccion = Jefe.Element("Direccion").Value;
            }
            else { oBEJefe = null; }

            return oBEJefe;
        }

        //public bool Verificar_Usuario(BEJefe pJefe)
        //{
        //    XDocument xmlDoc = XDocument.Load("Jefes.xml");
        //    XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => (x.Element("Usuario").Value) == pJefe.Usuario);
            
        //    if(Jefe != null)
        //    { return true; }
        //    else { return false; }
        //}

        public void Agregar(BEJefe oBEJefe)
        {
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            xmlDoc.Element("Jefes").Add(new XElement("Jefe",
                new XAttribute("Codigo", oBEJefe.Codigo),
                new XElement("DNI", oBEJefe.DNI),
                new XElement("Nombre", oBEJefe.Nombre),
                new XElement("Apellido", oBEJefe.Apellido),
                new XElement("Codigo_Usuario", oBEJefe.Usuario.Codigo),
                new XElement("Fecha_Nacimiento", oBEJefe.Fecha_Nacimiento),
                new XElement("Direccion", oBEJefe.Direccion),
                new XElement("Codigo_Rol", oBEJefe.Rol.Codigo)));

            xmlDoc.Save("Jefes.xml");
        }

        public void Eliminar(BEJefe oBEJefe)
        {
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEJefe.Codigo);
            if(Jefe != null)
            {
                Jefe.Remove();
                xmlDoc.Save("Jefes.xml");
            }
        }

        public void Modificar(BEJefe oBEJefe)
        {
            XDocument xmlDoc = XDocument.Load("Jefes.xml");
            XElement Jefe = xmlDoc.Descendants("Jefe").FirstOrDefault(x => Convert.ToInt32(x.Attribute("Codigo").Value) == oBEJefe.Codigo);
            if(Jefe != null)
            {
                Jefe.Element("DNI").Value = oBEJefe.DNI.ToString();
                Jefe.Element("Nombre").Value = oBEJefe.Nombre;
                Jefe.Element("Apellido").Value = oBEJefe.Apellido;
                Jefe.Element("Fecha_Nacimiento").Value = oBEJefe.Fecha_Nacimiento.ToString();
                Jefe.Element("Direccion").Value = oBEJefe.Direccion;
                xmlDoc.Save("Jefes.xml");
            }
        }

        public int Crear_Codigo_Jefe()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Jefes.xml");

            XmlNodeList Jefe = xmlDoc.GetElementsByTagName("Jefes");
            XmlNodeList lista = ((XmlElement)Jefe[0]).GetElementsByTagName("Jefe");

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

        public List<BEJefe> Buscar_Jefes(string pApellido)
        {
            XElement xmlDoc = XElement.Load("Jefes.xml");
            var consulta = from Jefe in xmlDoc.Descendants("Jefe")
                           where Jefe.Element("Apellido").Value.StartsWith(pApellido)
                           select new BEJefe()
                           {
                               Codigo = Convert.ToInt32(Convert.ToString(Jefe.Attribute("Codigo").Value.Trim())),
                               DNI = Convert.ToInt32(Convert.ToString(Jefe.Element("DNI").Value.Trim())),
                               Nombre = Convert.ToString(Jefe.Element("Nombre").Value.Trim()),
                               Apellido = Convert.ToString(Jefe.Element("Apellido").Value.Trim()),
                               Usuario = oMPPUsuario.Seleccionar_Usuario(Convert.ToInt32(Jefe.Element("Codigo_Usuario").Value)),
                               Fecha_Nacimiento = Convert.ToDateTime(Convert.ToString(Jefe.Element("Fecha_Nacimiento").Value.Trim())),
                               Direccion = Convert.ToString(Jefe.Element("Direccion").Value.Trim()),
                           };

            List<BEJefe> lista_Jefe = consulta.ToList<BEJefe>();
            return lista_Jefe;
        }

        public bool Modificar_Contraseña(string pDNI, string pUsuario, string pNuevaContraseña)
        {
            BEJefe Jefe = (BEJefe)Seleccionar_Jefe(pDNI);
            
            if(Jefe != null)
            {
                XDocument xmlDoc = XDocument.Load("Usuarios.xml", LoadOptions.None);

                IEnumerable<XElement> Usuario = xmlDoc.Descendants("Usuario");

                foreach (XElement oUsuario in Usuario)
                {
                    if (oUsuario.Attribute("Codigo").Value == Jefe.Usuario.Codigo.ToString())
                    {
                        oUsuario.Element("Contraseña").Value = pNuevaContraseña;

                        xmlDoc.Save("Usuarios.xml");

                        return true;
                    }
                }
            }

            return false;
        }

        public bool Verificar_Jefe_Pedido(BEJefe oBEJefe)
        {
            XDocument xmlDoc = XDocument.Load("Pedidos.xml");
            XElement Jefe = xmlDoc.Descendants("Pedido").FirstOrDefault(x => (x.Element("Id_Encargado_Atencion").Value) == oBEJefe.Codigo.ToString());

            if (Jefe != null)
            {
                return true;
            }
            else { return false; }
        }

    }
}
