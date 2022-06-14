using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI.Forms
{
    public partial class frmVerSorteos : Form
    {

        #region Campos

        BLLSorteo oBLLSorteo;

        #endregion

        public frmVerSorteos()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private void Listar_Sorteos()
        {
            try
            {
                oBLLSorteo = new BLLSorteo();
                grdSorteos.DataSource = null;
                grdSorteos.DataSource = oBLLSorteo.Listar_Sorteos();
            }
            catch (Exception ex) { throw ex; }
        }

        private void Listar_Sorteo_X_Año()
        {
            try
            {
                oBLLSorteo = new BLLSorteo();
                grdSorteos.DataSource = null;
                grdSorteos.DataSource = oBLLSorteo.Listar_Sorteo_Año(Convert.ToInt32(txtAño.Text));
            }
            catch (Exception ex) { throw ex; }
        }

        private void Listar_Sorteo_Mes_Año()
        {
            try
            {
                oBLLSorteo = new BLLSorteo();
                grdSorteos.DataSource = null;
                grdSorteos.DataSource = oBLLSorteo.Listar_Sorteos_Mes_Año(Seleccionar_Mes(), Convert.ToInt32(txtAño.Text));
            }
            catch (Exception ex) { throw ex; }
        }

        private string Seleccionar_Mes()
        {
            try
            {
                switch (cboMes.Text)
                {
                    case "Enero":
                        return "Enero";

                    case "Febrero":
                        return "Febrero";

                    case "Marzo":
                        return "Marzo";

                    case "Abril":
                        return "Abril";

                    case "Mayo":
                        return "Mayo";

                    case "Junio":
                        return "Junio";

                    case "Julio":
                        return "Julio";

                    case "Agosto":
                        return "Agosto";

                    case "Septiembre":
                        return "Septiembre";

                    case "Octubre":
                        return "Octubre";

                    case "Noviembre":
                        return "Noviembre";

                    case "Diciembre":
                        return "Diciembre";

                    default:
                        return "Todos";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboMes.Text == "Seleccionar")
                {
                    MessageBox.Show("Para continuar debe seleccionar un mes", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(cboMes.Text == "Todos")
                { Listar_Sorteo_X_Año(); }
                else
                {
                    Listar_Sorteo_Mes_Año();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmVerSorteos_Load(object sender, EventArgs e)
        {
            try
            {
                Listar_Sorteos();
                txtAño.Text = DateTime.Now.Year.ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Listar_Sorteos();
        }
    }
}
