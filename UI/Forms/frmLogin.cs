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
    public partial class frmLogin : Form
    {
        #region Campos

        BEUsuario oBEUsuario;
        BLLUsuario oBLLUsuario;

        BLLJefe oBLLJefe;
        BEJefe jefe;

        BEEncargadoProduccion encargadoProduccion;
        BLLEncargado_Produccion oBLLEncargadoProduccion;

        BLLAtencionAlPublico oBLLAtencionAlPublico;
        BEAtencionAlPublico atencionAlPublico;

        private int segundos;
        private int intentos;

        #endregion

        public frmLogin()
        {
            InitializeComponent();
            intentos = 3;
            segundos = 30;
        }

        #region Funciones privadas

        private void Asignar()
        {
            try
            {
                oBEUsuario = new BEUsuario();
                oBEUsuario.Nombre_Usuario = txtUsuario.Text;
                oBEUsuario.Contraseña = txtContraseña.Text;
            }
            catch (Exception ex) { throw ex; }
        }

        private void Borrar()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void Controlar_Login()
        {
            try
            {
                if(intentos > 0)
                {
                    intentos--;
                    
                    if(intentos == 0)
                    {
                        MessageBox.Show("Completó los 3 intentos, deberá esperar 30 segundos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tmrLogin.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Le quedan " + intentos + " intentos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if(tmrLogin.Enabled == false)
                {
                    if (txtUsuario.Text != "" && txtContraseña.Text != "")
                    {
                        oBLLJefe = new BLLJefe();
                        Asignar();
                        oBLLUsuario = new BLLUsuario();

                        BEUsuario Usuario = (BEUsuario)oBLLUsuario.Seleccionar_Usuario(oBEUsuario.Nombre_Usuario);
                        
                        if(Usuario != null)
                        { 
                            Usuario.Contraseña = Capa_Encriptacion.CESeguridad.Desencriptar(Usuario.Contraseña);

                            if (Usuario.Nombre_Usuario == oBEUsuario.Nombre_Usuario && Usuario.Contraseña == oBEUsuario.Contraseña)
                            {
                                MessageBox.Show("Login exitoso", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Borrar();
                                Program.Login = true;
                                BEJefe oBEJefe = (BEJefe)oBLLJefe.Seleccionar_Jefe(Usuario);

                                if (oBEJefe != null)
                                {
                                    Program.Logueado = oBEJefe;
                                }
                                else
                                {
                                    oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                                    BEAtencionAlPublico Atencion_Publico = (BEAtencionAlPublico)oBLLAtencionAlPublico.Seleccionar_Encargado(Usuario);
                                    Program.Logueado = Atencion_Publico;

                                    if (Atencion_Publico == null)
                                    {
                                        oBLLEncargadoProduccion = new BLLEncargado_Produccion();
                                        BEEncargadoProduccion Encargado_Produccion = (BEEncargadoProduccion)oBLLEncargadoProduccion.Seleccionar_Encargado(Usuario);
                                        Program.Logueado = Encargado_Produccion;
                                    }
                                }
                                this.Close();
                            }
                            else { MessageBox.Show("Contraseña incorrecta", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); Controlar_Login(); }
                        }
                        else { MessageBox.Show("Usuario no encontrado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); Controlar_Login(); }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Demasiados intentos fallidos, debe esperar " + segundos + " segundos", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex) { throw ex; }
        }


        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtContraseña.UseSystemPasswordChar == true)
                { txtContraseña.UseSystemPasswordChar = false; }
                else { txtContraseña.UseSystemPasswordChar = true; }
            }
            catch (Exception ex) { throw ex; }
        }


        private void lblNuevaContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                frmModificarContraseña modificarContraseña = new frmModificarContraseña();
                modificarContraseña.ShowDialog();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Login = false;
            this.Close();
        }

        private void tmrLogin_Tick(object sender, EventArgs e)
        {
            segundos--;
            if(segundos == 0)
            {
                segundos = 30;
                tmrLogin.Enabled = false;
                intentos = 3;
            }
        }

    }
}
