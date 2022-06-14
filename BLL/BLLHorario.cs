using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLHorario
    {
        MPPHorarios oMPPHorario;

        public List<BEHorario> Listar_Horarios(string pFecha)
        {
            oMPPHorario = new MPPHorarios();
            return oMPPHorario.Listar_Horarios(pFecha);
        }

        public IReadOnlyCollection<BEPersona> Listar_Empleados(BEHorario pHorario)
        {
            oMPPHorario = new MPPHorarios();
            return oMPPHorario.Listar_Empleados(pHorario);
        }

        public bool Verificar_Horario(DateTime pFecha, string pHoraInicio, string pHoraFin)
        {
            oMPPHorario = new MPPHorarios();
            return oMPPHorario.Verificar_Horario(pFecha, pHoraInicio, pHoraFin);
        }

        public int Crear_Codigo_Nuevo()
        {
            oMPPHorario = new MPPHorarios();
            return oMPPHorario.Crear_Codigo_Nuevo();
        }

        public void Agregar_Nuevo_Horario(BEHorario oBEHorario)
        {
            oMPPHorario = new MPPHorarios();
            oMPPHorario.Agregar_Nuevo_Horario(oBEHorario);
        }

        public void Agregar_Empleados_Horarios(BEHorario oBEHorario)
        {
            oMPPHorario = new MPPHorarios();
            oMPPHorario.Agregar_Empleados_Horario(oBEHorario);
        }

        public bool Validar_Hora(string cadena)
        {
            Regex re = new Regex(@"^([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?$");
            if (!re.IsMatch(cadena))
            {
                return false;
            }
            else { return true; }
        }

    }
}
