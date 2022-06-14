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
    public partial class frmSorteo : Form
    {

        #region Campos

        BESorteo oBESorteo;
        BLLSorteo oBLLSorteo;

        BLLCliente oBLLCliente;
        BECliente oBECliente;
        BECliente Cliente_Ganador;

        List<BECliente> Lista_Clientes = new List<BECliente>();

        #endregion

        public frmSorteo()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private string Seleccionar_Mes()
        {
            try
            {
                switch(cboMes.Text)
                {
                    case "Enero":
                        return "1";

                    case "Febrero":
                        return "2";

                    case "Marzo":
                        return "3";

                    case "Abril":
                        return "4";

                    case "Mayo":
                        return "5";

                    case "Junio":
                        return "6";

                    case "Julio":
                        return "7";

                    case "Agosto":
                        return "8";

                    case "Septiembre":
                        return "9";

                    case "Octubre":
                        return "10";

                    case "Noviembre":
                        return "11";

                    case "Diciembre":
                        return "12";

                    default:
                        return DateTime.Now.Month.ToString();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Sortear()
        {
            try
            {
                int numero = 0;

                Random _random = new Random();
                numero = _random.Next(0, Lista_Clientes.Count);

                Cliente_Ganador = (BECliente)Lista_Clientes[numero];

                lblGanador.Text = Cliente_Ganador.Nombre + " " + Cliente_Ganador.Apellido;
            }
            catch (Exception ex) {throw ex; }
        }

        private void Registrar_Sorteo()
        {
            try
            {
                oBESorteo = new BESorteo();
                oBESorteo.Ganador = Cliente_Ganador;
                oBESorteo.Fecha_Sorteo = DateTime.Now;
                oBESorteo.Mes = cboMes.Text;
                oBESorteo.Año = Convert.ToInt32(txtAño.Text);

                oBLLSorteo = new BLLSorteo();
                oBLLSorteo.Registrar_Sorteo(oBESorteo);
            }
            catch (Exception ex) { throw ex; }
        }

        private void Borrar()
        {
            cboMes.Text = "Seleccionar";
            txtAño.Text = DateTime.Now.Year.ToString();
            grdParticipantes.DataSource = null;
            lblGanador.Text = "";
            lblTelefono.Text = "";
        }

        #endregion

        private void frmSorteo_Load(object sender, EventArgs e)
        {
            try
            {
                txtAño.Text = DateTime.Now.Year.ToString();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnListarParticipantes_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboMes.Text != "Seleccionar")
                {
                    if(txtAño.Text != "")
                    {
                        oBLLCliente = new BLLCliente();
                        grdParticipantes.DataSource = null;

                        Lista_Clientes = oBLLCliente.Listar_Clientes_X_Mes(Seleccionar_Mes(), txtAño.Text);

                        grdParticipantes.DataSource = Lista_Clientes;

                        if (grdParticipantes.Rows.Count > 0)
                        {
                            grdParticipantes.Columns["Codigo"].Visible = false;
                            //grdParticipantes.Columns["DNI"].Visible = false;
                            grdParticipantes.Columns["Rol"].Visible = false;
                        }   
                        else
                        {
                            grdParticipantes.DataSource = null;
                            MessageBox.Show("No se encontraron registros con los datos ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else { MessageBox.Show("Debe ingresar un año", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe seleccionar un mes", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLSorteo = new BLLSorteo();
                if(oBLLSorteo.Verificar_Sorteo(cboMes.Text, Convert.ToInt32(txtAño.Text)) == true)
                {
                    DialogResult result = MessageBox.Show("Ya se realizó un sorteo para el mes y año indicado. ¿Desea realizar otro?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                    if(result == DialogResult.Yes)
                    {
                        Sortear();
                        Registrar_Sorteo();
                    }
                    else { Borrar(); }
                }
                else
                {
                    Sortear();
                    Registrar_Sorteo();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Borrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerSorteos verSorteos = new frmVerSorteos();
                verSorteos.ShowDialog();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
