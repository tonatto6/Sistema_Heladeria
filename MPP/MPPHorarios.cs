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
    public class MPPHorarios
    {
        public List<BEHorario> Listar_Horarios(string pFecha)
        {
            var consulta =
                from Horario in XElement.Load("Horarios.xml").Elements("Horario")
                where Horario.Element("Fecha").Value == pFecha
                select new BEHorario
                {
                    Codigo = Convert.ToInt32(Horario.Attribute("Codigo").Value),
                    Fecha = Convert.ToDateTime(Horario.Element("Fecha").Value),
                    Hora_Inicio = Horario.Element("Hora_Inicio").Value,
                    Hora_Fin = Horario.Element("Hora_Fin").Value,
                    Cantidad_Empleados = Convert.ToInt32(Horario.Element("Cantidad_Empleados").Value)
                };

            List<BEHorario> Lista_Horarios = consulta.ToList<BEHorario>();
            return Lista_Horarios;
        }

        public IReadOnlyCollection<BEPersona> Listar_Empleados(BEHorario pHorario)
        {
            List<BEPersona> Lista_Empleados = new List<BEPersona>();
            MPPAtencionAlPublico oMPPAtencionAlPublico = new MPPAtencionAlPublico();
            MPPEncargadoDeProduccion oMPPEncargadoProduccion = new MPPEncargadoDeProduccion();

            XDocument xmlDoc = XDocument.Load("Detalle_Horarios.xml", LoadOptions.None);
            XElement Lista_Horarios = xmlDoc.Element("Detalle_Horario");
            IEnumerable<XElement> Detalle_Horarios = xmlDoc.Descendants("Detalle_Horario");

            foreach(XElement Detalle in Detalle_Horarios)
            {
                if(Detalle.Attribute("Codigo").Value == pHorario.Codigo.ToString())
                {
                    if(Detalle.Element("Rol").Value == "Encargado atencion")
                    { Lista_Empleados.Add(oMPPAtencionAlPublico.Seleccionar_Encargado(Convert.ToInt32(Detalle.Element("Codigo_Empleado").Value))); }
                    else { Lista_Empleados.Add(oMPPEncargadoProduccion.Seleccionar_Encargado_Produccion(Convert.ToInt32(Detalle.Element("Codigo_Empleado").Value))); }
                }
            }

            return Lista_Empleados.AsReadOnly();
        }

        public bool Verificar_Horario(DateTime pFecha, string pHoraInicio, string pHoraFin)
        {
            XDocument xmlDoc = XDocument.Load("Horarios.xml", LoadOptions.None);

            XElement Lista_Horarios = xmlDoc.Element("Horarios");

            IEnumerable<XElement> Horarios = xmlDoc.Descendants("Horario");

            bool r = false;

            foreach (XElement Horario in Horarios)
            {
                if(Horario.Element("Fecha").Value == pFecha.ToShortDateString() && Horario.Element("Hora_Inicio").Value == pHoraInicio && Horario.Element("Hora_Fin").Value == pHoraFin)
                {
                    r = true;
                    break;
                }
            }

            return r;
        }

        public int Crear_Codigo_Nuevo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Horarios.xml");

            XmlNodeList Horario = xmlDoc.GetElementsByTagName("Horarios");
            XmlNodeList lista = ((XmlElement)Horario[0]).GetElementsByTagName("Horario");

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

        public void Agregar_Nuevo_Horario(BEHorario oBEHorario)
        {
            XDocument xmlDoc = XDocument.Load("Horarios.xml");
            xmlDoc.Element("Horarios").Add(new XElement("Horario",
                new XAttribute("Codigo", oBEHorario.Codigo),
                new XElement("Fecha", oBEHorario.Fecha.ToShortDateString()),
                new XElement("Hora_Inicio", oBEHorario.Hora_Inicio),
                new XElement("Hora_Fin", oBEHorario.Hora_Fin),
                new XElement("Cantidad_Empleados", oBEHorario.Cantidad_Empleados)));

            xmlDoc.Save("Horarios.xml");
        }
    
        public void Agregar_Empleados_Horario(BEHorario oBEHorario)
        {
            XDocument xmlDoc = XDocument.Load("Detalle_Horarios.xml");

            foreach(var Empleado in oBEHorario.Detalle_Horario.Lista_Empleados)
            {
                xmlDoc.Element("Detalle_Horarios").Add(new XElement("Detalle_Horario",
                    new XAttribute("Codigo", oBEHorario.Codigo),
                    new XElement("Codigo_Empleado", Empleado.Key.Codigo),
                    new XElement("Rol", Empleado.Value)));

                xmlDoc.Save("Detalle_Horarios.xml");
            }
        }
    }
}
