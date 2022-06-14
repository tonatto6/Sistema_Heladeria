using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using BE;

namespace MPP
{
    public class MPPSorteo
    {

        public bool Verificar_Sorteo(string pMes, int pAño)
        {
            XDocument xmlDoc = XDocument.Load("Sorteos.xml");
            XElement lista_Sorteos = xmlDoc.Element("Sorteos");
            IEnumerable<XElement> Sorteos = xmlDoc.Descendants("Sorteo");

            bool sorteo_existe = false;

            foreach(XElement Sorteo in Sorteos)
            {
                if(Sorteo.Element("Mes").Value == pMes && Sorteo.Element("Año").Value == pAño.ToString())
                {
                    sorteo_existe = true;
                    break;
                }
            }

            return sorteo_existe;
        }

        public void Registrar_Sorteo(BESorteo oBESorteo)
        {
            XDocument xmlDoc = XDocument.Load("Sorteos.xml");
            xmlDoc.Element("Sorteos").Add(new XElement("Sorteo",
                new XElement("Ganador", oBESorteo.Ganador.Codigo),
                new XElement("Fecha", oBESorteo.Fecha_Sorteo),
                new XElement("Mes", oBESorteo.Mes),
                new XElement("Año", oBESorteo.Año)));

            xmlDoc.Save("Sorteos.xml");
        }
        
        public List<BESorteo> Listar_Sorteos()
        {
            MPPCliente oMPPCliente = new MPPCliente();

            var consulta =
                from Sorteo in XElement.Load("Sorteos.xml").Elements("Sorteo")
                select new BESorteo
                {
                    Ganador = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Sorteo.Element("Ganador").Value.ToString())),
                    Fecha_Sorteo = Convert.ToDateTime(Sorteo.Element("Fecha").Value.ToString()),
                    Mes = Convert.ToString(Sorteo.Element("Mes").Value),
                    Año = Convert.ToInt32(Sorteo.Element("Año").Value),

                };

            List<BESorteo> Lista_Sorteos = consulta.ToList<BESorteo>();
            return Lista_Sorteos;
        }

        public List<BESorteo> Listar_Sorteos_Año(int pAño)
        {
            MPPCliente oMPPCliente = new MPPCliente();

            var consulta =
                from Sorteo in XElement.Load("Sorteos.xml").Elements("Sorteo")
                where Sorteo.Element("Año").Value == pAño.ToString()
                select new BESorteo
                {
                    Ganador = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Sorteo.Element("Ganador").Value.ToString())),
                    Fecha_Sorteo = Convert.ToDateTime(Sorteo.Element("Fecha").Value.ToString()),
                    Mes = Convert.ToString(Sorteo.Element("Mes").Value),
                    Año = Convert.ToInt32(Sorteo.Element("Año").Value),

                };

            List<BESorteo> Lista_Sorteos = consulta.ToList<BESorteo>();
            return Lista_Sorteos;
        }

        public List<BESorteo> Listar_Sorteos_x_Mes_Año(string pMes, int pAño)
        {
            MPPCliente oMPPCliente = new MPPCliente();

            var consulta =
                from Sorteo in XElement.Load("Sorteos.xml").Elements("Sorteo")
                where Sorteo.Element("Año").Value == pAño.ToString() && 
                Sorteo.Element("Mes").Value == pMes
                select new BESorteo
                {
                    Ganador = oMPPCliente.Seleccionar_Cliente(Convert.ToInt32(Sorteo.Element("Ganador").Value.ToString())),
                    Fecha_Sorteo = Convert.ToDateTime(Sorteo.Element("Fecha").Value.ToString()),
                    Mes = Convert.ToString(Sorteo.Element("Mes").Value),
                    Año = Convert.ToInt32(Sorteo.Element("Año").Value),

                };

            List<BESorteo> Lista_Sorteos = consulta.ToList<BESorteo>();
            return Lista_Sorteos;
        }
    }
}
