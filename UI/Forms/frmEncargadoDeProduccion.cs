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
    public partial class frmEncargadoDeProduccion : Form
    {

        #region Campos

        BEEncargadoProduccion oBEEncargadoProduccion;
        BLLEncargado_Produccion oBLLEncargadoProduccion;

        BLLPersona oBLLPersona;

        BLLUsuario oBLLUsuario;
        BLLContacto oBLLContacto;
        BEContacto oBEContacto;
        List<BEContacto> lista_contactos;

        #endregion

        public frmEncargadoDeProduccion(BEEncargadoProduccion encargado_produccion)
        {
            InitializeComponent();
            Encargado_Produccion = encargado_produccion;
            lista_contactos = new List<BEContacto>();
        }

        #region Propiedades

        public BEEncargadoProduccion Encargado_Produccion { get; set; }

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
        }

        private void Asignar()
        {
            try
            {
                oBLLEncargadoProduccion = new BLLEncargado_Produccion();

                if (Encargado_Produccion.Codigo == 0)
                {
                    oBEEncargadoProduccion.Codigo = oBLLEncargadoProduccion.Crear_Codigo_Encargado_Produccion();
                }
                else
                {
                    oBEEncargadoProduccion.Codigo = Encargado_Produccion.Codigo;
                }

                oBEEncargadoProduccion.DNI = Convert.ToInt32(txtDNI.Text);
                oBEEncargadoProduccion.Nombre = txtNombre.Text;
                oBEEncargadoProduccion.Apellido = txtApellido.Text;
                if (Operacion == 1)
                {
                    BEUsuario oBEUsuario = new BEUsuario();
                    oBEUsuario.Codigo = oBLLUsuario.Crear_Codigo_Usuario();
                    oBEUsuario.Nombre_Usuario = txtUsuario.Text;
                    oBEUsuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                    oBEEncargadoProduccion.Usuario = oBEUsuario;
                }
                else if (Operacion == 3)
                {
                    oBEEncargadoProduccion.Usuario = (BEUsuario)Encargado_Produccion.Usuario;
                    oBEEncargadoProduccion.Usuario.Nombre_Usuario = txtUsuario.Text;
                    oBEEncargadoProduccion.Usuario.Contraseña = CESeguridad.Encriptar(txtContraseña.Text);
                }
                oBEEncargadoProduccion.Rol = new BERol();

                if (cboRol.Text == "Administrador")
                { oBEEncargadoProduccion.Rol.Codigo = 1; }
                else { oBEEncargadoProduccion.Rol.Codigo = 2; }

            }
            catch (Exception ex) { throw ex; }
        }

        private void Asignar_Contacto()
        {
            try
            {
                foreach (BEContacto contacto in lista_contactos)
                {
                    contacto.Persona = oBEEncargadoProduccion;
                    contacto.Descripcion_Persona = "Encargado_Produccion";
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

                if(oBLLPersona.Validar_Nombre_Apellido(txtNombre.Text) == true && oBLLPersona.Validar_Nombre_Apellido(txtApellido.Text) == true && oBLLPersona.Validar_DNI(txtDNI.Text) == true)
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

        private bool Validar_Existencia_Contacto(BEContacto Contacto)
        {
            try
            {
                oBLLContacto = new BLLContacto();

                if (lista_contactos.Count > 0)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verificar_Campos() == false)
                {
                    if (Validar_Nombre_Apellido_Encargado() == true)
                    {
                        oBEEncargadoProduccion = new BEEncargadoProduccion();
                        oBLLEncargadoProduccion = new BLLEncargado_Produccion();
                        oBLLUsuario = new BLLUsuario();
                        Asignar();

                        if(Operacion == 1)
                        {
                            if(lista_contactos.Count > 0)
                            {
                                Asignar_Contacto();
                                if(Validar_Usuario_Existe() != true)
                                {
                                    if(oBLLEncargadoProduccion.Operacion(oBEEncargadoProduccion, Operacion) == true)
                                    {
                                        oBLLUsuario.Agregar_Usuario(oBEEncargadoProduccion.Usuario);
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
                            if (oBLLEncargadoProduccion.Operacion(oBEEncargadoProduccion, Operacion) == true)
                            {
                                oBLLUsuario.Modificar_Usuario(oBEEncargadoProduccion.Usuario);
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
                if (Operacion == 1)
                {
                    Borrar();
                }
                else { Borrar(); this.Close(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmEncargadoDeProduccion_Load(object sender, EventArgs e)
        {
            try
            {
                if(Operacion == 3)
                {
                    txtDNI.Text = Encargado_Produccion.DNI.ToString();
                    txtNombre.Text = Encargado_Produccion.Nombre;
                    txtApellido.Text = Encargado_Produccion.Apellido;
                    txtUsuario.Text = Encargado_Produccion.Usuario.Nombre_Usuario;
                    txtContraseña.Text = Capa_Encriptacion.CESeguridad.Desencriptar(Encargado_Produccion.Usuario.Contraseña);
                    cboRol.SelectedItem = Encargado_Produccion.Rol;
                    cboRol.Text = Encargado_Produccion.Rol.Nombre;

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
