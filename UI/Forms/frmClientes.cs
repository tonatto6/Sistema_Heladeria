using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI.Forms
{
    public partial class frmClientes : Form
    {

        #region Campos

        BECliente oBECliente;
        BLLCliente oBLLCliente;

        BLLPersona oBLLPersona;

        BLLContacto oBLLContacto;
        BEContacto oBEContacto;
        List<BEContacto> lista_contactos;

        #endregion

        public frmClientes()
        {
            InitializeComponent();
        }

        #region Propiedades
        
        public int Accion { get; set; }

        #endregion

        #region Funciones privadas

        private void Borrar()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContacto.Text = "";
            grdClientes.DataSource = null;
            Cargar_Grilla();
            groupBox1.Visible = false;
        }

        private void Cargar_Grilla()
        {
            try
            {
                oBLLCliente = new BLLCliente();
                grdClientes.DataSource = null;
                grdClientes.DataSource = oBLLCliente.Listar_Clientes();
                if(grdClientes.Rows.Count > 0)
                {
                    grdClientes.Columns["Codigo"].Visible = false;
                    grdClientes.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar()
        {
            if(oBECliente.Codigo.ToString() == "")
            { oBLLCliente = new BLLCliente(); oBECliente.Codigo = oBLLCliente.Crear_Codigo_Cliente(); }

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
            if(txtDNI.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                return true;
            }
            else { return false; }
        }

        private void Buscar_Clientes()
        {
            try
            {
                oBLLCliente = new BLLCliente();
                grdClientes.DataSource = null;
                grdClientes.DataSource = oBLLCliente.Buscar_Clientes(txtBuscarCliente.Text);
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Campos()
        {
            try
            {
                oBLLPersona = new BLLPersona();

                if(oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) && oBLLPersona.Validar_DNI(txtDNI.Text))
                {
                    return true;
                }
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

        private void Cargar_Contactos()
        {
            oBECliente = (BECliente)grdClientes.CurrentRow.DataBoundItem;

            oBLLContacto = new BLLContacto();
            grdContactos.DataSource = null;
            grdContactos.DataSource = oBLLContacto.Listar_Contactos(oBECliente, "Cliente");

            if (grdContactos.Rows.Count > 0)
            {
                grdContactos.Columns["Codigo"].Visible = false;
                grdContactos.Columns["Persona"].Visible = false;
                grdContactos.Columns["Descripcion_Persona"].Visible = false;
            }
            else { grdContactos.DataSource = null; }
        }

        #endregion

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Accion = 2;

                DialogResult result = MessageBox.Show("¿Desea eliminar el cliente seleccionado?", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
                if(result == DialogResult.Yes)
                {
                    oBLLCliente = new BLLCliente();
                    oBECliente = (BECliente)grdClientes.CurrentRow.DataBoundItem;

                    if(oBLLCliente.Verificar_Eliminacion_Cliente(oBECliente) == false)
                    {
                        oBLLCliente.Operacion(oBECliente, Accion);
                        oBLLContacto = new BLLContacto();
                        oBLLContacto.Eliminar_Contactos(oBECliente, "Cliente");

                        MessageBox.Show("Cliente eliminado exitosamente", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        Cargar_Grilla();
                    }
                    else { MessageBox.Show("El cliente no se puede eliminar porque esta sujeto a otros datos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Accion = 3;

                oBECliente = (BECliente)grdClientes.CurrentRow.DataBoundItem;

                txtDNI.Text = oBECliente.DNI.ToString();
                txtNombre.Text = oBECliente.Nombre;
                txtApellido.Text = oBECliente.Apellido;

                groupBox1.Visible = true;
                btnAgregarContacto.Enabled = false;
                btnQuitarContacto.Enabled = false;
                //Cargar_Contactos();
            }
            catch (Exception ex) { throw ex; }
        }

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
                            //oBECliente = new BECliente();

                            Asignar();

                            oBLLCliente = new BLLCliente();
                            oBLLCliente.Operacion(oBECliente, Accion);

                            if (Accion == 1)
                            {
                                oBLLContacto = new BLLContacto();
                                oBLLContacto.Agregar_Contacto(lista_contactos);
                            }

                            Cargar_Grilla();
                            Borrar();
                            groupBox1.Visible = false;
                        }
                        else { MessageBox.Show("Debe ingresar un contacto minimo", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else { MessageBox.Show("Los datos de uno o varios campos son incorrectos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar todos los campos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Accion = 1;
                groupBox1.Visible = true;
                lista_contactos = new List<BEContacto>();
                oBECliente = new BECliente();
                btnAgregarContacto.Enabled = true;
                btnQuitarContacto.Enabled = true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBuscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarCliente.TextLength > 0)
                { Buscar_Clientes(); }
                else { Cargar_Grilla(); }
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

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContacto.Text != "")
                {
                    oBEContacto = new BEContacto();
                    oBEContacto.Contacto = txtContacto.Text;

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

        private void grdClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            oBECliente = (BECliente)grdClientes.CurrentRow.DataBoundItem;

            oBLLContacto = new BLLContacto();
            grdVerContactos.DataSource = null;
            grdVerContactos.DataSource = oBLLContacto.Listar_Contactos(oBECliente, "Cliente");

            if (grdVerContactos.Rows.Count > 0)
            {
                grdVerContactos.Columns["Codigo"].Visible = false;
                grdVerContactos.Columns["Persona"].Visible = false;
                grdVerContactos.Columns["Descripcion_Persona"].Visible = false;
            }
            else { grdVerContactos.DataSource = null; }
        }
    }
}


