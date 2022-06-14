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
using Capa_Encriptacion;

namespace UI.Forms
{
    public partial class frmModificarContraseña : Form
    {
        #region Campos

        BLLJefe oBLLJefe;
        BEJefe oBEJefe;

        BLLAtencionAlPublico oBLLAtencionAlPublico;
        BEAtencionAlPublico oBEAtencionAlPublico;

        BLLEncargado_Produccion oBLLEncargadoProduccion;
        BEEncargadoProduccion oBEEncargadoProduccion;

        #endregion

        public frmModificarContraseña()
        {
            InitializeComponent();
        }

        #region Funciones privadas

        private void borrar()
        {
            txtDNI.Text = "";
            txtUsuario.Text = "";
            txtNuevaContraseña.Text = "";
            txtRepetirContraseña.Text = "";
        }

        private bool Verificar_Campos()
        {
            if(txtDNI.Text == "" || txtUsuario.Text == "" || txtNuevaContraseña.Text == "" || txtRepetirContraseña.Text == "")
            {
                return true;
            }
            else
            {
                if(txtNuevaContraseña.Text == txtRepetirContraseña.Text)
                {
                    return false;
                }
                else { return true; }
            }
        }

        #endregion

        private void btnAaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Verificar_Campos() == false)
                {
                    if(cbJefe.Checked == true)
                    {
                        oBLLJefe = new BLLJefe();
                        string contraseña = CESeguridad.Encriptar(txtNuevaContraseña.Text);
                        if(oBLLJefe.Modificar_Contraseña(txtDNI.Text, txtUsuario.Text, contraseña) == true)
                        {
                            MessageBox.Show("Contraseña modificada exitosamente", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            borrar();
                            this.Close();
                        }
                        else { MessageBox.Show("Error al modificar la contraseña. Revise los datos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else if(cbAtencionAlPublico.Checked == true)
                    {
                        oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                        string contraseña = CESeguridad.Encriptar(txtNuevaContraseña.Text);
                        if (oBLLAtencionAlPublico.Modificar_Contraseña(txtDNI.Text, txtUsuario.Text, contraseña) == true)
                        {
                            MessageBox.Show("Contraseña modificada exitosamente", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            borrar();
                            this.Close();
                        }
                        else { MessageBox.Show("Error al modificar la contraseña. Revise los datos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else 
                    {
                        oBLLEncargadoProduccion = new BLLEncargado_Produccion();
                        string contraseña = CESeguridad.Encriptar(txtNuevaContraseña.Text);
                        if (oBLLEncargadoProduccion.Modificar_Contraseña(txtDNI.Text, txtUsuario.Text, contraseña) == true)
                        {
                            MessageBox.Show("Contraseña modificada exitosamente", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            borrar();
                            this.Close();
                        }
                        else { MessageBox.Show("Error al modificar la contraseña. Revise los datos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                }
                else
                {
                    MessageBox.Show("Verifique que todos los campos esten completos y las contraseñas sean iguales", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void cbJefe_Click(object sender, EventArgs e)
        {
            try
            {
                cbJefe.Checked = true;
                cbAtencionAlPublico.Checked = false;
                cbEncargadoProduccion.Checked = false;
            }
            catch (Exception ex) { throw ex; }
        }

        private void cbAtencionAlPublico_Click(object sender, EventArgs e)
        {
            try
            {
                cbJefe.Checked = false;
                cbAtencionAlPublico.Checked = true;
                cbEncargadoProduccion.Checked = false;
            }
            catch (Exception ex) { throw ex; }
        }

        private void cbEncargadoProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                cbJefe.Checked = false;
                cbAtencionAlPublico.Checked = false;
                cbEncargadoProduccion.Checked = true;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
