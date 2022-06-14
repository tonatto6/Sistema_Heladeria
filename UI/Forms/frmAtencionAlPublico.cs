using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using BE;
using Capa_Encriptacion;

namespace UI.Forms
{
    public partial class frmAtencionAlPublico : Form
    {

        #region Campos

        BEAtencionAlPublico oBEAtencionAlPublico;
        BLLAtencionAlPublico oBLLAtencionAlPublico;

        BLLPersona oBLLPersona;

        BLLContacto oBLLContacto;
        BEContacto oBEContacto;
        List<BEContacto> lista_contactos;

        BLLUsuario oBLLUsuario;

        #endregion

        public frmAtencionAlPublico(BEAtencionAlPublico oAtencion_Publico)
        {
            InitializeComponent();
            Atencion_Publico = oAtencion_Publico;
            lista_contactos = new List<BEContacto>();
        }

        #region Propiedades

        public BEAtencionAlPublico Atencion_Publico { get; set; }

        public int Operacion { get; set; }

        #endregion

        #region Funciones privadas

        private void Borrar()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContacto.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            cboRol.Text = "Seleccionar";
        }

        private void Asignar()
        {
            try
            {
                oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                oBLLUsuario = new BLLUsuario();

                if (Atencion_Publico.Codigo == 0)
                {
                    oBEAtencionAlPublico.Codigo = oBLLAtencionAlPublico.Crear_Codigo_Atencion_Al_Publico();
                }
                else
                {
                    oBEAtencionAlPublico.Codigo = Atencion_Publico.Codigo;
                }

                oBEAtencionAlPublico.DNI = Convert.ToInt32(txtDNI.Text);
                oBEAtencionAlPublico.Nombre = txtNombre.Text;
                oBEAtencionAlPublico.Apellido = txtApellido.Text;
                if(Operacion == 1)
                {
                    BEUsuario oBEUsuario = new BEUsuario();
                    oBEUsuario.Codigo = oBLLUsuario.Crear_Codigo_Usuario();
                    oBEUsuario.Nombre_Usuario = txtUsuario.Text;
                    oBEUsuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                    oBEAtencionAlPublico.Usuario = oBEUsuario;
                }
                else if(Operacion == 3)
                {
                    oBEAtencionAlPublico.Usuario = (BEUsuario)Atencion_Publico.Usuario;
                    oBEAtencionAlPublico.Usuario.Nombre_Usuario = txtUsuario.Text;
                    oBEAtencionAlPublico.Usuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                }

                oBEAtencionAlPublico.Rol = new BERol();

                if(cboRol.Text == "Administrador")
                { oBEAtencionAlPublico.Rol.Codigo = 1; }
                else { oBEAtencionAlPublico.Rol.Codigo = 2; }

            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar_Contacto()
        {
            try
            {
                foreach (BEContacto contacto in lista_contactos)
                {
                    contacto.Persona = oBEAtencionAlPublico;
                    contacto.Descripcion_Persona = "Encargado_Atencion";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Verificar_Campos()
        {
            if(txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "" || cboRol.Text == "Seleccionar")
            { return true; }
            else { return false; }
        }

        private bool Validar_Campos()
        {
            try
            {
                oBLLPersona = new BLLPersona();

                if (oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) == true && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) == true && oBLLPersona.Validar_DNI(txtDNI.Text) == true)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Usuario_Existe()
        {
            try
            {
                oBLLUsuario = new BLLUsuario();

                if (oBLLUsuario.Verificar_Usuario_Existe(txtUsuario.Text) == true)
                { return true; }
                else { return false; }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Nombre_Apellido_Encargado()
        {
            try
            {
                oBLLPersona = new BLLPersona();

                if (oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) == true && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) == true && oBLLPersona.Validar_DNI(txtDNI.Text) == true)
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
                oBLLContacto = new BLLContacto();

                foreach (BEContacto contacto in lista_contactos)
                {
                    if (contacto.Contacto == Contacto.Contacto)
                    { return true; }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        private bool Validar_Existencia_Contacto(BEContacto Contacto)
        {
            try
            {
                if(lista_contactos.Count > 0)
                {
                    foreach (BEContacto contacto in lista_contactos)
                    {
                        if (oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == true)
                        { return true; }
                    }
                }
                else 
                {
                    if (oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == true)
                    { return true; }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void frmAtencionAlPublico_Load(object sender, EventArgs e)
        {
            try
            {
                if(Operacion == 3)
                {
                    txtDNI.Text = Atencion_Publico.DNI.ToString();
                    txtNombre.Text = Atencion_Publico.Nombre;
                    txtApellido.Text = Atencion_Publico.Apellido;
                    //txtContacto.Text = Atencion_Publico.Telefono;
                    
                    txtUsuario.Text = Atencion_Publico.Usuario.Nombre_Usuario;
                    txtContraseña.Text = Capa_Encriptacion.CESeguridad.Desencriptar(Atencion_Publico.Usuario.Contraseña);
                    cboRol.SelectedItem = Atencion_Publico.Rol;
                    cboRol.Text = Atencion_Publico.Rol.Nombre;

                    btnAgregarContacto.Enabled = false;
                    btnQuitarContacto.Enabled = false;
                }
                else
                {
                    btnAgregarContacto.Enabled = true;
                    btnQuitarContacto.Enabled = true;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verificar_Campos() == false)
                {
                    if (Validar_Nombre_Apellido_Encargado() == true)
                    {
                        oBEAtencionAlPublico = new BEAtencionAlPublico();
                        oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                        oBLLUsuario = new BLLUsuario();
                        Asignar();

                        if (Operacion == 1)
                        {
                            if (lista_contactos.Count > 0)
                            {
                                Asignar_Contacto();
                                if (Validar_Usuario_Existe() != true)
                                {
                                    if (oBLLAtencionAlPublico.Operacion(oBEAtencionAlPublico, Operacion) == true)
                                    {
                                        oBLLUsuario.Agregar_Usuario(oBEAtencionAlPublico.Usuario);
                                        if (Operacion == 1)
                                        {
                                            oBLLContacto = new BLLContacto();
                                            oBLLContacto.Agregar_Contacto(lista_contactos);
                                        }
                                        MessageBox.Show("Empleado agregado correctamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Borrar();

                                        DialogResult result = MessageBox.Show("¿Desea agregar otro empleado? Si presiona no, la ventana se cerrará", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                        if (result == DialogResult.No)
                                        { this.Close(); }
                                    }
                                }
                                else { MessageBox.Show("El usuario ingresado ya esta registrado. Por favor, ingrese uno distinto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                            }
                            else { MessageBox.Show("Debe ingresar un contacto minimanete", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        }
                        else
                        {
                            //Modificar
                            if (oBLLAtencionAlPublico.Operacion(oBEAtencionAlPublico, Operacion) == true)
                            {
                                oBLLUsuario.Modificar_Usuario(oBEAtencionAlPublico.Usuario);
                                MessageBox.Show("Se modifico el empleado correctamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Borrar();
                                this.Close();
                            }
                        }
                    }
                    else { MessageBox.Show("El nombre y/o apellido solo puede contener letras", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContacto.Text != "")
                {
                    oBEContacto = new BEContacto();
                    oBEContacto.Contacto = txtContacto.Text;
                    oBEContacto.Descripcion_Persona = "Jefe";

                    if (Verificar_Contacto(oBEContacto) == false && Validar_Existencia_Contacto(oBEContacto) == false)
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
    }
}
