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
    public partial class frmVerHorarios : Form
    {

        #region Campos

        BLLHorario oBLLHorario;
        BEHorario oBEHorario;
        
        #endregion

        public frmVerHorarios()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private void Borrar()
        {
            grdEmpleados.DataSource = null;
            grdHorarios.DataSource = null;
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void Listar_Horarios()
        {
            try
            {
                grdHorarios.DataSource = null;
                oBLLHorario = new BLLHorario();
                grdHorarios.DataSource = oBLLHorario.Listar_Horarios(dtpFecha.Text);

                grdHorarios.Columns["Codigo"].Visible = false;
                grdHorarios.Columns["Fecha"].Visible = false;
                grdHorarios.Columns["Detalle_Horario"].Visible = false;
                grdHorarios.Columns["Cantidad_Empleados"].HeaderText = "Empleados";
                grdHorarios.Columns["Hora_Inicio"].HeaderText = "Hora inicio";
                grdHorarios.Columns["Hora_Fin"].HeaderText = "Hora fin";

                if (grdHorarios.Rows.Count <= 0)
                {
                    MessageBox.Show("No se encontraron datos en la fecha indicada", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex) { throw ex; }
        }

        private void Ver_Empleados_Horario()
        {
            try
            {
                oBEHorario = (BEHorario)grdHorarios.CurrentRow.DataBoundItem;
                grdEmpleados.DataSource = null;
                oBLLHorario = new BLLHorario();
                grdEmpleados.DataSource = oBLLHorario.Listar_Empleados(oBEHorario);

                if(grdEmpleados.Rows.Count > 0)
                {
                    grdEmpleados.Columns["Codigo"].Visible = false;
                    grdEmpleados.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Listar_Horarios();
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmVerHorarios_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdHorarios.Rows.Count > 0)
                {
                    Ver_Empleados_Horario();
                }
                else { MessageBox.Show("No hay ningún horario seleccionado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
