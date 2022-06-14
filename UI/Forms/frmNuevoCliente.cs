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
    public partial class frmNuevoCliente : Form
    {

        #region Campos

        BECliente oBECliente;
        BLLCliente oBLLCliente;

        BLLPersona oBLLPersona;

        BLLContacto oBLLContacto;
        BEContacto oBEContacto;
        List<BEContacto> lista_contactos;

        #endregion

        public frmNuevoCliente()
        {
            InitializeComponent();

        }

        #region Propiedades

        public int DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }
        #endregion

        #region Funciones privadas

        private void Borrar()
        {
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtApellido.Text = "";
            txtContacto.Text = "";
            grdContactos.DataSource = null;
        }

        private void Asignar()
        {
            oBLLCliente = new BLLCliente();

            oBECliente.Codigo = oBLLCliente.Crear_Codigo_Cliente();

            
            oBECliente.DNI = Convert.ToInt32(txtDNI.Text);
            oBECliente.Nombre = txtNombre.Text;
            oBECliente.Apellido = txtApellido.Text;

            foreach (BEContacto contacto in lista_contactos)
            {
                contacto.Persona = oBECliente;
                contacto.Descripcion_Persona = "Cliente";
            }
        }

        private bool Verificar_Campos()
        {
            if(txtNombre.Text != "" && txtApellido.Text != "" && txtDNI.Text != "")
            { return true; }
            else { return false; }
        }

        private bool Validar_Campos()
        {
            try
            {
                oBLLPersona = new BLLPersona();

                if(oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) == true && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) == true && oBLLPersona.Validar_DNI(txtDNI.Text) == true)
                { return true; }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Verificar_Contacto(BEContacto Contacto)
        {
            try
            {
                foreach (BEContacto contacto in lista_contactos)
                {
                    if (contacto.Contacto == Contacto.Contacto)
                    { return true; }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Verificar_Campos() == true)
                {
                    if(Validar_Campos() == true)
                    {
                        if(lista_contactos.Count > 0)
                        {
                            oBECliente = new BECliente();
                            Asignar();
                            oBLLCliente = new BLLCliente();

                            oBLLCliente.Operacion(oBECliente, 1);
                            oBLLContacto = new BLLContacto();
                            oBLLContacto.Agregar_Contacto(lista_contactos);

                            Borrar();
                            this.Close();
                        }
                        else { MessageBox.Show("Debe ingresar un contacto como minimo", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                    }
                    else { MessageBox.Show("El nombre y/o apellido solo puede contener letras", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar todos los campos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Borrar();
                this.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContacto.Text != "")
                {
                    oBEContacto = new BEContacto();
                    oBEContacto.Contacto = txtContacto.Text;
                    oBEContacto.Descripcion_Persona = "Jefe";

                    if (Verificar_Contacto(oBEContacto) == false)
                    {
                        lista_contactos.Add(oBEContacto);
                        grdContactos.DataSource = null;
                        grdContactos.DataSource = lista_contactos;

                        if (grdContactos.Rows.Count > 0)
                        {
                            grdContactos.Columns["Codigo"].Visible = false;
                            grdContactos.Columns["Persona"].Visible = false;
                            grdContactos.Columns["Descripcion_Persona"].Visible = false;
                        }

                        txtContacto.Text = "";
                    }
                    else { MessageBox.Show("Ya se agregó el contacto ingresado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnQuitarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                oBEContacto = (BEContacto)grdContactos.CurrentRow.DataBoundItem;
                lista_contactos.Remove(oBEContacto);
                grdContactos.DataSource = null;
                grdContactos.DataSource = lista_contactos;

                if (grdContactos.Rows.Count > 0)
                {
                    grdContactos.Columns["Codigo"].Visible = false;
                    grdContactos.Columns["Persona"].Visible = false;
                    grdContactos.Columns["Descripcion_Persona"].Visible = false;
                }
                else { grdContactos.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                lista_contactos = new List<BEContacto>();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
