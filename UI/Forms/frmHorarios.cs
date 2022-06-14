using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI.Forms
{
    public partial class frmHorarios : Form
    {

        #region Campos
        
        BEAtencionAlPublico oBEAtencionAlPublico;
        BLLAtencionAlPublico oBLLAtencionAlPublico;
        BLLHorario oBLLHorario;

        BEHorario oBEHorario;
        BEDetalleHorario oBEDetalleHorario;
        BEEncargadoProduccion oBEEncargadoDeProduccion;
        BLLEncargado_Produccion oBLLEncargadoDeProduccion;

        Dictionary<BEPersona, string> Empleados;

        #endregion

        public frmHorarios()
        {
            InitializeComponent();

            Empleados = new Dictionary<BEPersona, string>();
        }

        #region Funciones privadas

        private void Borrar()
        {
            try
            {
                txtCantidadEmpleados.Text = "1";
                grdEmpleados.DataSource = null;
                txtHoraInicio.Text = "12:00";
                txtHoraFin.Text = "13:00";
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_Empleado_Atencion_Al_Publico()
        {
            try
            {
                oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                grdAtencionAlPublico.DataSource = null;
                grdAtencionAlPublico.DataSource = oBLLAtencionAlPublico.Listar_Atencion_Al_Publico();

                if(grdAtencionAlPublico.Rows.Count > 0)
                {
                    grdAtencionAlPublico.Columns["Codigo"].Visible = false;
                    grdAtencionAlPublico.Columns["DNI"].Visible = false;
                    grdAtencionAlPublico.Columns["Usuario"].Visible = false;
                    grdAtencionAlPublico.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Grilla_Empleado_Encargado_Produccion()
        {
            try
            {
                oBLLEncargadoDeProduccion = new BLLEncargado_Produccion();
                grdEmpleadoDeProduccion.DataSource = null;
                grdEmpleadoDeProduccion.DataSource = oBLLEncargadoDeProduccion.Listar_Encargados_Produccion();
            
                if(grdEmpleadoDeProduccion.Rows.Count > 0)
                {
                    grdEmpleadoDeProduccion.Columns["Codigo"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["DNI"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["Usuario"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Listar_Empleados_Seleccionados()
        {
            try
            {
                List<BEPersona> Lista_Empleados = new List<BEPersona>();
                foreach(var Empleado in Empleados.Keys)
                {
                    Lista_Empleados.Add(Empleado);
                }
                grdEmpleados.DataSource = null;
                grdEmpleados.DataSource = Lista_Empleados;

                if(grdEmpleados.Rows.Count > 0)
                {
                    grdEmpleados.Columns["Codigo"].Visible = false;
                    grdEmpleados.Columns["DNI"].Visible = false;
                    grdEmpleados.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Verificar_Fecha()
        {
            try
            {
                if(dtpFecha.Value > DateTime.Now)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Encargados_Produccion()
        {
            try
            {
                oBLLEncargadoDeProduccion = new BLLEncargado_Produccion();
                grdEmpleadoDeProduccion.DataSource = null;
                grdEmpleadoDeProduccion.DataSource = oBLLEncargadoDeProduccion.Buscar_Encargado_Produccion(txtBusquedaEmpleadoProduccion.Text);

                if (grdEmpleadoDeProduccion.Rows.Count > 0)
                {
                    grdEmpleadoDeProduccion.Columns["Codigo"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["DNI"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["Usuario"].Visible = false;
                    grdEmpleadoDeProduccion.Columns["Contraseña"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Encargados_Atencion()
        {
            try
            {
                oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                grdAtencionAlPublico.DataSource = null;
                grdAtencionAlPublico.DataSource = oBLLAtencionAlPublico.Buscar_Encargado_Atencion(txtBusquedaEmpleadoAtencion.Text);

                if (grdAtencionAlPublico.Rows.Count > 0)
                {
                    grdAtencionAlPublico.Columns["Codigo"].Visible = false;
                    grdAtencionAlPublico.Columns["DNI"].Visible = false;
                    grdAtencionAlPublico.Columns["Usuario"].Visible = false;
                    grdAtencionAlPublico.Columns["Contraseña"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar()
        {
            try
            {
                oBEHorario = new BEHorario();

                oBEHorario.Codigo = oBLLHorario.Crear_Codigo_Nuevo();
                oBEHorario.Fecha = Convert.ToDateTime(dtpFecha.Text);
                oBEHorario.Hora_Inicio = txtHoraInicio.Text;
                oBEHorario.Hora_Fin = txtHoraFin.Text;
                oBEHorario.Cantidad_Empleados = Convert.ToInt32(txtCantidadEmpleados.Text);

                oBEHorario.Detalle_Horario = new BEDetalleHorario(Empleados);

            }
            catch (Exception ex) { throw ex; }
        }

        private bool Verificar_Empleado(BEPersona pPersona, string pRol)
        {
            string value = pRol;
            bool result = Empleados.TryGetValue(pPersona, out value);
            if(result)
            { return true; }
            else { return false; }
        }

        #endregion

        private void frmHorarios_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla_Empleado_Atencion_Al_Publico();
                Cargar_Grilla_Empleado_Encargado_Produccion();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLHorario = new BLLHorario();

                if(Verificar_Fecha() == true)
                {
                    if(oBLLHorario.Validar_Hora(txtHoraInicio.Text) == true && oBLLHorario.Validar_Hora(txtHoraFin.Text) == true)
                    {
                        if (Convert.ToInt32(txtCantidadEmpleados.Text) == Empleados.Count)
                        {
                            if (oBLLHorario.Verificar_Horario(Convert.ToDateTime(dtpFecha.Text), txtHoraInicio.Text, txtHoraFin.Text) != true)
                            {
                                Asignar();
                                oBLLHorario.Agregar_Nuevo_Horario(oBEHorario);
                                oBLLHorario.Agregar_Empleados_Horarios(oBEHorario);
                                Borrar();
                            }
                            else { MessageBox.Show("Ya existe un horario creado con los parametros ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }
                        else { MessageBox.Show("La cantidad de empleados indicados debe ser igual a la cantidad seleccionada", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else { MessageBox.Show("La hora ingresada no tiene el formato correcto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                }
                else { MessageBox.Show("La fecha seleccionada no puede ser menor a la fecha actual", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSeleccionarAtencionAlPulbico_Click(object sender, EventArgs e)
        {
            try
            {
                if(Empleados.Count < Convert.ToInt32(txtCantidadEmpleados.Text))
                {
                    oBEAtencionAlPublico = (BEAtencionAlPublico)grdAtencionAlPublico.CurrentRow.DataBoundItem;
                    if (Verificar_Empleado(oBEAtencionAlPublico, "Encargado atencion") != true)
                    {
                        Empleados.Add(oBEAtencionAlPublico, "Encargado atencion");

                        Listar_Empleados_Seleccionados();
                    }
                    else { MessageBox.Show("El empleado seleccionado ya fue agregado a la lista", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("La cantidad de empleados seleccionados no puede ser mayor a lo establecido", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSeleccionarEncargadoProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if(Empleados.Count  < Convert.ToInt32(txtCantidadEmpleados.Text))
                {
                    oBEEncargadoDeProduccion = (BEEncargadoProduccion)grdEmpleadoDeProduccion.CurrentRow.DataBoundItem;

                    if (Verificar_Empleado(oBEEncargadoDeProduccion, "Encargado produccion") != true)
                    {

                        Empleados.Add(oBEEncargadoDeProduccion, "Encargado produccion");

                        Listar_Empleados_Seleccionados();
                    }
                    else { MessageBox.Show("El empleado seleccionado ya fue agregado a la lista", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("La cantidad de empleados seleccionados no puede ser mayor a lo establecido", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Borrar();
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBusquedaEmpleadoAtencion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBusquedaEmpleadoAtencion.TextLength > 0)
                { Buscar_Encargados_Atencion(); }
                else { Cargar_Grilla_Empleado_Atencion_Al_Publico(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBusquedaEmpleadoProduccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBusquedaEmpleadoProduccion.TextLength > 0)
                { Buscar_Encargados_Produccion(); }
                else { Cargar_Grilla_Empleado_Encargado_Produccion(); }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
