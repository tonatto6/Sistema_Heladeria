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
using Capa_Encriptacion;

namespace UI.Forms
{
    public partial class frmJefe : Form
    {

        #region Campos

        BEJefe oBEJefe;
        BLLJefe oBLLJefe;

        BLLPersona oBLLPersona;
        BLLUsuario oBLLUsuario;

        BLLContacto oBLLContacto;
        BEContacto oBEContacto;
        List<BEContacto> lista_contactos;

        #endregion

        public frmJefe()
        {
            InitializeComponent();
        }

        #region Propiedades

        public int Accion { get; set; }

        public BEUsuario oUsuario { get; set; }

        #endregion

        #region Funciones privadas

        private void Cargar_Grilla()
        {
            try
            {
                oBLLJefe = new BLLJefe();
                grdJefe.DataSource = null;
                grdJefe.DataSource = oBLLJefe.Listar_Jefe();

                if(grdJefe.Rows.Count > 0)
                {
                    grdJefe.Columns["Codigo"].Visible = false;
                    grdJefe.Columns["Direccion"].Visible = false;
                    grdJefe.Columns["Fecha_Nacimiento"].Visible = false;
                    grdJefe.Columns["Usuario"].Visible = false;
                    grdJefe.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Borrar()
        {
            txtCodigo.Text = "";
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNac.Text = "";
            txtDireccion.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtContacto.Text = "";
            grdContactos.DataSource = null;

            groupBox1.Visible = false;
        }

        private void Asignar()
        {
            try
            {
                oBLLUsuario = new BLLUsuario();
                oBLLJefe = new BLLJefe();

                if(txtCodigo.Text != "")
                { oBEJefe.Codigo = Convert.ToInt32(txtCodigo.Text); }
                else { oBEJefe.Codigo = oBLLJefe.Crear_Codigo_Jefe(); }

                oBEJefe.DNI = Convert.ToInt32(txtDNI.Text);
                oBEJefe.Nombre = txtNombre.Text;
                oBEJefe.Apellido = txtApellido.Text;
                oBEJefe.Fecha_Nacimiento = Convert.ToDateTime(txtFechaNac.Text);
                oBEJefe.Direccion = txtDireccion.Text;

                if(Accion == 1)
                {
                    BEUsuario oBEUsuario = new BEUsuario();
                    oBEUsuario.Codigo = oBLLUsuario.Crear_Codigo_Usuario();
                    oBEUsuario.Nombre_Usuario = txtUsuario.Text;
                    oBEUsuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                    oBEJefe.Usuario = oBEUsuario;
                }
                else
                {
                    oBEJefe.Usuario = (BEUsuario)oUsuario;
                    oBEJefe.Usuario.Nombre_Usuario = txtUsuario.Text;
                    oBEJefe.Usuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                }

                oBEJefe.Rol = new BERol();

                if (cboRol.Text == "Administrador")
                { oBEJefe.Rol.Codigo = 1; }
                else { oBEJefe.Rol.Codigo = 2; }

                
            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar_Contacto()
        {
            try
            {
                foreach (BEContacto contacto in lista_contactos)
                {
                    contacto.Persona = oBEJefe;
                    contacto.Descripcion_Persona = "Jefe";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Verificar_Campos()
        {
            try
            {
                if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "" || txtFechaNac.Text == "" || txtDireccion.Text == "")
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Jefe()
        {
            try
            {
                oBLLJefe = new BLLJefe();
                grdJefe.DataSource = null;
                grdJefe.DataSource = oBLLJefe.Buscar_Jefes(txtBuscarJefe.Text);

                if (grdJefe.Rows.Count > 0)
                {
                    grdJefe.Columns["Direccion"].Visible = false;
                    grdJefe.Columns["Fecha_Nacimiento"].Visible = false;
                    grdJefe.Columns["CUIL"].Visible = false;
                    grdJefe.Columns["Contraseña"].Visible = false;
                    grdJefe.Columns["Usuario"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Campos()
        {
            try
            {
                oBLLPersona = new BLLPersona();

                if(oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) == true && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) == true && oBLLPersona.Validar_Fecha(txtFechaNac.Text) && oBLLPersona.Validar_DNI(txtDNI.Text))
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
                foreach(BEContacto contacto in lista_contactos)
                {
                    if(contacto.Contacto == Contacto.Contacto)
                    { return true; }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Contactos(DataGridView grilla)
        {
            try
            {
                oBEJefe = (BEJefe)grdJefe.CurrentRow.DataBoundItem;

                oBLLContacto = new BLLContacto();
                grilla.DataSource = null;
                grilla.DataSource = oBLLContacto.Listar_Contactos(oBEJefe, "Jefe");

                if (grilla.Rows.Count > 0)
                {
                    grilla.Columns["Codigo"].Visible = false;
                    grilla.Columns["Persona"].Visible = false;
                    grilla.Columns["Descripcion_Persona"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void frmJefe_Load(object sender, EventArgs e)
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
                DialogResult result = MessageBox.Show("¿Desea eliminar la persona seleccionada?", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    oBLLJefe = new BLLJefe();
                    oBEJefe = (BEJefe)grdJefe.CurrentRow.DataBoundItem;

                    if(oBLLJefe.Verificar_Jefe_Pedido(oBEJefe) != true)
                    {

                        oBLLJefe.Operacion(oBEJefe, 2);
                        oBLLContacto = new BLLContacto();
                        oBLLContacto.Eliminar_Contactos(oBEJefe, "Jefe");

                        Cargar_Grilla();
                        grdContactos.DataSource = null;
                    }
                    else { MessageBox.Show("No se puede eliminar el jefe porque pertenece a uno o varios pedidos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
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
                btnAgregarContacto.Enabled = true;
                btnQuitarContacto.Enabled = true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Accion = 3;
                groupBox1.Visible = true;
                oBEJefe = (BEJefe)grdJefe.CurrentRow.DataBoundItem;

                txtCodigo.Text = oBEJefe.Codigo.ToString();
                txtDNI.Text = oBEJefe.DNI.ToString();
                txtNombre.Text = oBEJefe.Nombre;
                txtApellido.Text = oBEJefe.Apellido;
                txtFechaNac.Text = oBEJefe.Fecha_Nacimiento.ToString();
                txtDireccion.Text = oBEJefe.Direccion;
                txtUsuario.Text = oBEJefe.Usuario.Nombre_Usuario;
                txtContraseña.Text = CESeguridad.Desencriptar(oBEJefe.Usuario.Contraseña);
                oUsuario = oBEJefe.Usuario;

                btnAgregarContacto.Enabled = false;
                btnQuitarContacto.Enabled = false;
            }
            catch (Exception ex) { throw ex; }
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oBLLJefe = new BLLJefe();
                oBEJefe = new BEJefe();

                if (Verificar_Campos() == false)
                {
                    if(Validar_Campos() == true)
                    {
                        if(Accion == 1)
                        {

                            BLLUsuario oBLLUsuario = new BLLUsuario();
                            BEUsuario oBEUsuario = new BEUsuario();
                            Asignar();
                            Asignar_Contacto();

                            if (lista_contactos != null)
                            {
                                if (oBLLUsuario.Verificar_Usuario_Existe(oBEUsuario.Nombre_Usuario) == false)
                                {
                                    oBLLJefe.Operacion(oBEJefe, Accion);
                                    oBLLUsuario.Agregar_Usuario(oBEJefe.Usuario);
                                    oBLLContacto = new BLLContacto();
                                    oBLLContacto.Agregar_Contacto(lista_contactos);

                                    Cargar_Grilla();
                                    Borrar();
                                }
                                else { MessageBox.Show("El usuario es invalido. Ya se utilizó", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else { MessageBox.Show("Debe ingresar un contacto como minimo", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }
                        else
                        {
                            Asignar();

                            oBLLJefe.Operacion(oBEJefe, Accion);
                            oBLLUsuario.Modificar_Usuario(oBEJefe.Usuario);
                            Cargar_Grilla();
                            Borrar();
                        }
                    }
                    else { MessageBox.Show("Los datos ingresados en uno o varios campos son incorrectos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar todos los campos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void txtBuscarJefe_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBuscarJefe.TextLength > 0)
                { Buscar_Jefe(); }
                else { Cargar_Grilla(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtContacto.Text != "")
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

        private void grdJefe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cargar_Contactos(grdVerContactos);
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox4.Visible = true;
                oBEJefe = (BEJefe)grdJefe.CurrentRow.DataBoundItem;
                Cargar_Contactos(grdModificarContactos);
            }
            catch (Exception ex) { throw ex; }
        }

        private void grdModificarContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBEContacto = (BEContacto)grdModificarContactos.CurrentRow.DataBoundItem;
                txtModificarContacto.Text = oBEContacto.Contacto;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtModificarContacto.Text != "")
                {
                    oBEContacto.Contacto = txtModificarContacto.Text;
                    oBLLContacto = new BLLContacto();

                    if(oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == false)
                    {
                        oBLLContacto.Modificar_Contacto(oBEContacto);
                        txtModificarContacto.Text = "";
                        Cargar_Contactos(grdModificarContactos);
                        Cargar_Contactos(grdVerContactos);
                    }
                    else { MessageBox.Show("Ya existe un contacto con los datos ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar el campo contacto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregarNuevoContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModificarContacto.Text != "")
                {
                    oBEContacto = new BEContacto();
                    oBLLContacto = new BLLContacto();

                    oBEContacto.Codigo = oBLLContacto.Crear_Codigo_Contacto();
                    oBEContacto.Contacto = txtModificarContacto.Text;
                    oBEContacto.Persona = oBEJefe;
                    oBEContacto.Descripcion_Persona = "Jefe";

                    if (oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == false)
                    {
                        oBLLContacto.Agregar_Un_Contacto(oBEContacto);
                        txtModificarContacto.Text = "";
                        Cargar_Contactos(grdModificarContactos);
                        Cargar_Contactos(grdVerContactos);
                    }
                    else { MessageBox.Show("Ya existe un contacto con los datos ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar el campo contacto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                oBEContacto = (BEContacto)grdModificarContactos.CurrentRow.DataBoundItem;

                if(oBEContacto != null)
                {
                    oBLLContacto = new BLLContacto();
                    oBLLContacto.Eliminar_Contacto(oBEContacto);
                    txtModificarContacto.Text = "";
                    Cargar_Contactos(grdModificarContactos);
                    Cargar_Contactos(grdVerContactos);
                }
                else { MessageBox.Show("Debe seleccionar un contacto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            try
            {
                grdModificarContactos.DataSource = null;
                txtModificarContacto.Text = "";
                groupBox4.Visible = false;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
