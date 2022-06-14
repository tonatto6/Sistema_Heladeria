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
    public partial class frmPersonal : Form
    {

        #region Campos

        BEAtencionAlPublico oBEAtencionAlPublico;
        BLLAtencionAlPublico oBLLAtencionAlPublico;

        BEEncargadoProduccion oBEEncargadoProduccion;
        BLLEncargado_Produccion oBLLEncargado_Produccion;


        BLLContacto oBLLContacto;
        BEContacto oBEContacto;

        BLLUsuario oBLLUsuario;

        #endregion

        public frmPersonal()
        {
            InitializeComponent();
        }

        #region Propiedades

        public BEPersona Persona { get; set; }

        public string Descripcion_Persona { get; set; }

        #endregion

        #region Funciones privadas

        private void Cargar_Grilla_Atencion_Al_Publico()
        {
            oBLLAtencionAlPublico = new BLLAtencionAlPublico();
            grdAtencionAlPublico.DataSource = null;
            grdAtencionAlPublico.DataSource = oBLLAtencionAlPublico.Listar_Atencion_Al_Publico();

            if(grdAtencionAlPublico.Rows.Count > 0)
            {
                grdAtencionAlPublico.Columns["Codigo"].Visible = false;
                grdAtencionAlPublico.Columns["Usuario"].Visible = false;
                grdAtencionAlPublico.Columns["Rol"].Visible = false;
            }
        }

        private void Cargar_Grilla_Encargados_Produccion()
        {
            try
            {
                oBLLEncargado_Produccion = new BLLEncargado_Produccion();
                grdEncargadoProduccion.DataSource = null;
                grdEncargadoProduccion.DataSource = oBLLEncargado_Produccion.Listar_Encargados_Produccion();

                if (grdEncargadoProduccion.Rows.Count > 0)
                {
                    grdEncargadoProduccion.Columns["Codigo"].Visible = false;
                    grdEncargadoProduccion.Columns["Usuario"].Visible = false;
                    grdEncargadoProduccion.Columns["Rol"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Buscar_Encargados_Produccion()
        {
            try
            {
                oBLLEncargado_Produccion = new BLLEncargado_Produccion();
                grdEncargadoProduccion.DataSource = null;
                grdEncargadoProduccion.DataSource = oBLLEncargado_Produccion.Buscar_Encargado_Produccion(txtBusquedaEncargadoProduccion.Text);
                
                if(grdEncargadoProduccion.Rows.Count > 0)
                {
                    grdEncargadoProduccion.Columns["Usuario"].Visible = false;
                    grdEncargadoProduccion.Columns["Contraseña"].Visible = false;
                }
            }
            catch (Exception ex){ throw ex; }
        }

        private void Buscar_Encargados_Atencion()
        {
            try
            {
                oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                grdAtencionAlPublico.DataSource = null;
                grdAtencionAlPublico.DataSource = oBLLAtencionAlPublico.Buscar_Encargado_Atencion(txtBusquedaAtencionAlPublico.Text);

                if (grdAtencionAlPublico.Rows.Count > 0)
                {
                    grdAtencionAlPublico.Columns["Usuario"].Visible = false;
                    grdAtencionAlPublico.Columns["Contraseña"].Visible = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Cargar_Contactos(DataGridView grilla, BEPersona oBEPersona, string pDescripcion_Person)
        {
            try
            {
                //oBEJefe = (BEJefe)grdJefe.CurrentRow.DataBoundItem;

                oBLLContacto = new BLLContacto();
                grilla.DataSource = null;
                grilla.DataSource = oBLLContacto.Listar_Contactos(oBEPersona, pDescripcion_Person);

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

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Grilla_Atencion_Al_Publico();
                Cargar_Grilla_Encargados_Produccion();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificarAtencionAlPublico_Click(object sender, EventArgs e)
        {
            try
            {
                BEAtencionAlPublico oBEAtencionAlPublico = (BEAtencionAlPublico)grdAtencionAlPublico.CurrentRow.DataBoundItem;
                frmAtencionAlPublico atencionAlPublico = new frmAtencionAlPublico(oBEAtencionAlPublico);
                atencionAlPublico.Operacion = 3;
                atencionAlPublico.ShowDialog();

                Cargar_Grilla_Atencion_Al_Publico();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminarAtencionAlPublico_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el empleado seleccionado?", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {

                    oBLLAtencionAlPublico = new BLLAtencionAlPublico();
                    oBEAtencionAlPublico = (BEAtencionAlPublico)grdAtencionAlPublico.CurrentRow.DataBoundItem;

                    if(oBLLAtencionAlPublico.Verificar_Encargado_Atencion_Pedido(oBEAtencionAlPublico) != true)
                    {
                        if (oBLLAtencionAlPublico.Operacion(oBEAtencionAlPublico, 2) == true)
                        {
                            oBLLUsuario = new BLLUsuario();
                            oBLLUsuario.Eliminar_Usuario(oBEAtencionAlPublico.Usuario);
                            oBLLContacto = new BLLContacto();
                            oBLLContacto.Eliminar_Contactos(oBEAtencionAlPublico, "Encargado_Atencion");
                            grdVerContactosAtencion.DataSource = null;

                            MessageBox.Show("El empleado se eliminó correctamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar_Grilla_Atencion_Al_Publico();
                        }
                        else { MessageBox.Show("Error al eliminar el empleado. Intente nuevamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else { MessageBox.Show("No se puede eliminar el encargago porque es parte de uno o varios pedidos", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnEliminarEncargadoProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el empleado seleccionado?", "Heladeria Lila", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    oBLLEncargado_Produccion = new BLLEncargado_Produccion();
                    oBEEncargadoProduccion = (BEEncargadoProduccion)grdEncargadoProduccion.CurrentRow.DataBoundItem;

                    if(oBLLEncargado_Produccion.Verificar_Encargado_Atencion_Pedido(oBEEncargadoProduccion) != true)
                    {
                        if (oBLLEncargado_Produccion.Operacion(oBEEncargadoProduccion, 2) == true)
                        {
                            oBLLUsuario = new BLLUsuario();
                            oBLLUsuario.Eliminar_Usuario(oBEEncargadoProduccion.Usuario);
                            oBLLContacto = new BLLContacto();
                            oBLLContacto.Eliminar_Contactos(oBEEncargadoProduccion, "Encargado_Produccion");
                            grdVerContactosProduccion.DataSource = null;

                            MessageBox.Show("Empleado eliminado correctamente", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar_Grilla_Encargados_Produccion();
                        }
                        else { MessageBox.Show("Error al eliminar el empleado", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                    else { MessageBox.Show("No se puede eliminar el encargago porque es parte de uno o varios pedidos", "Heladeria Lila", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregarAtencionAlPublico_Click(object sender, EventArgs e)
        {
            try
            {
                BEAtencionAlPublico oBEAtencionAlPublico = new BEAtencionAlPublico();
                oBEAtencionAlPublico.Codigo = 0;
                frmAtencionAlPublico atencionAlPublico = new frmAtencionAlPublico(oBEAtencionAlPublico);
                atencionAlPublico.Operacion = 1;
                atencionAlPublico.ShowDialog();

                Cargar_Grilla_Atencion_Al_Publico();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificarEncargadoProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                oBEEncargadoProduccion = (BEEncargadoProduccion)grdEncargadoProduccion.CurrentRow.DataBoundItem;

                frmEncargadoDeProduccion encargado_produccion = new frmEncargadoDeProduccion(oBEEncargadoProduccion);
                encargado_produccion.Operacion = 3;

                encargado_produccion.ShowDialog();

                Cargar_Grilla_Encargados_Produccion();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnAgregarEncargadoProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                oBEEncargadoProduccion = new BEEncargadoProduccion();
                oBEEncargadoProduccion.Codigo = 0;
                frmEncargadoDeProduccion frmEncargadoDeProduccion = new frmEncargadoDeProduccion(oBEEncargadoProduccion);
                frmEncargadoDeProduccion.Operacion = 1;
                frmEncargadoDeProduccion.ShowDialog();

                Cargar_Grilla_Encargados_Produccion();
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBusquedaEncargadoProduccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBusquedaEncargadoProduccion.TextLength > 0)
                {
                    Buscar_Encargados_Produccion();
                }
                else { Cargar_Grilla_Encargados_Produccion(); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void txtBusquedaAtencionAlPublico_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtBusquedaAtencionAlPublico.TextLength > 0)
                {
                    Buscar_Encargados_Atencion();
                }
                else { Cargar_Grilla_Atencion_Al_Publico(); }
            }
            catch (Exception ex){ throw ex; }
        }

        private void grdAtencionAlPublico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBEAtencionAlPublico = (BEAtencionAlPublico)grdAtencionAlPublico.CurrentRow.DataBoundItem;

                oBLLContacto = new BLLContacto();
                grdVerContactosAtencion.DataSource = null;
                grdVerContactosAtencion.DataSource = oBLLContacto.Listar_Contactos(oBEAtencionAlPublico, "Encargado_Atencion");

                if (grdVerContactosAtencion.Rows.Count > 0)
                {
                    grdVerContactosAtencion.Columns["Codigo"].Visible = false;
                    grdVerContactosAtencion.Columns["Persona"].Visible = false;
                    grdVerContactosAtencion.Columns["Descripcion_Persona"].Visible = false;
                }
                else { grdVerContactosAtencion.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void grdEncargadoProduccion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBEEncargadoProduccion = (BEEncargadoProduccion)grdEncargadoProduccion.CurrentRow.DataBoundItem;

                oBLLContacto = new BLLContacto();
                grdVerContactosProduccion.DataSource = null;
                grdVerContactosProduccion.DataSource = oBLLContacto.Listar_Contactos(oBEEncargadoProduccion, "Encargado_Produccion");

                if (grdVerContactosProduccion.Rows.Count > 0)
                {
                    grdVerContactosProduccion.Columns["Codigo"].Visible = false;
                    grdVerContactosProduccion.Columns["Persona"].Visible = false;
                    grdVerContactosProduccion.Columns["Descripcion_Persona"].Visible = false;
                }
                else { grdVerContactosProduccion.DataSource = null; }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnContactosProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox5.Visible = true;
                oBEEncargadoProduccion = (BEEncargadoProduccion)grdEncargadoProduccion.CurrentRow.DataBoundItem;
                Persona = oBEEncargadoProduccion; Descripcion_Persona = "Encargado_Produccion";
                Cargar_Contactos(grdModificarContactos, Persona, Descripcion_Persona);
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
                    oBEContacto.Persona = Persona;
                    oBEContacto.Descripcion_Persona = Descripcion_Persona;

                    if(oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == false)
                    {
                        oBLLContacto.Agregar_Un_Contacto(oBEContacto);
                        txtModificarContacto.Text = "";
                        Cargar_Contactos(grdModificarContactos, Persona, Descripcion_Persona);
                        if (Descripcion_Persona == "Encargado_Produccion")
                        { Cargar_Contactos(grdVerContactosProduccion, Persona, Descripcion_Persona); }
                        else { Cargar_Contactos(grdVerContactosAtencion, Persona, Descripcion_Persona); }
                    }
                    else { MessageBox.Show("Ya existe un contacto con los datos ingresados", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Debe completar el campo contacto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnContactosAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox5.Visible = true;
                oBEAtencionAlPublico = (BEAtencionAlPublico)grdAtencionAlPublico.CurrentRow.DataBoundItem;
                Persona = oBEAtencionAlPublico; Descripcion_Persona = "Atencion_Publico";
                Cargar_Contactos(grdModificarContactos, Persona, Descripcion_Persona);
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnModificarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModificarContacto.Text != "")
                {
                    oBEContacto.Contacto = txtModificarContacto.Text;
                    oBLLContacto = new BLLContacto();
                    if(oBLLContacto.Verificar_Contacto_Existe(oBEContacto) == false)
                    {
                        oBLLContacto.Modificar_Contacto(oBEContacto);
                        txtModificarContacto.Text = "";
                        Cargar_Contactos(grdModificarContactos, Persona, Descripcion_Persona);
                        if (Descripcion_Persona == "Encargado_Produccion")
                        { Cargar_Contactos(grdVerContactosProduccion, Persona, Descripcion_Persona); }
                        else { Cargar_Contactos(grdVerContactosAtencion, Persona, Descripcion_Persona); }
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

                if (oBEContacto != null)
                {
                    oBLLContacto = new BLLContacto();
                    oBLLContacto.Eliminar_Contacto(oBEContacto);
                    txtModificarContacto.Text = "";
                    Cargar_Contactos(grdModificarContactos, Persona, Descripcion_Persona);
                    if(Descripcion_Persona == "Encargado_Produccion")
                    { Cargar_Contactos(grdVerContactosProduccion, Persona, Descripcion_Persona); }
                    else { Cargar_Contactos(grdVerContactosAtencion, Persona, Descripcion_Persona); }
                }
                else { MessageBox.Show("Debe seleccionar un contacto", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            try
            {
                grdModificarContactos.DataSource = null;
                txtModificarContacto.Text = "";
                groupBox5.Visible = false;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}


