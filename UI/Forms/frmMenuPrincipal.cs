using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmMenuPrincipal : Form
    {

        #region Campos

        BLLMenu oBLLMenu = new BLLMenu();
        BEMenu oBEMenu;

        List<BEPermiso> lista_Permisos = new List<BEPermiso>();
        List<BEMenu> lista_Menu = new List<BEMenu>();

        #endregion

        public frmMenuPrincipal()
        {
            InitializeComponent();
            Cargar_Lista_Menu();
            Cargar_Lista_Permisos();
        }

        #region Funciones privadas

        private void Cargar_Lista_Menu()
        {
            lista_Menu = oBLLMenu.Listar_Menu();
        }

        private void Cargar_Lista_Permisos()
        {
            oBLLMenu = new BLLMenu();
            lista_Permisos = oBLLMenu.Listar_Permisos(Program.Logueado.Rol.Codigo);
        }

        private int Verificar_Permiso(BEMenu oBEMenu)
        {
            foreach (BEPermiso permiso in lista_Permisos)
            {
                if (permiso.Menu.codigo == oBEMenu.codigo)
                {
                    return permiso.Activo;
                }
            }

            return 0;
        }

        private void AbrirForm(Form pObj)
        {
            if(this.pnlContenedor.Controls.Count > 0)
            { this.pnlContenedor.Controls.RemoveAt(0); }

            Form fh = pObj;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.WindowState = FormWindowState.Maximized;
            fh.StartPosition = FormStartPosition.CenterScreen;
            pnlContenedor.Controls.Add(fh);
            pnlContenedor.Tag = fh;
            fh.Show();
        }

        private BEMenu Seleccionar_Menu(string pMenu)
        {
            oBEMenu = new BEMenu();
            foreach (BEMenu menu in lista_Menu)
            {
                if (menu.Nombre == pMenu)
                {
                    oBEMenu = menu;
                }
            }

            return oBEMenu;
        }

        #endregion

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Personal");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmPersonal());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }   
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Productos");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmProducto());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Precios");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmPrecios());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Ventas");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmVenta());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnJefes_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Jefes");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmJefe());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Horarios");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmHorarios());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnMetodoDePago_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Metodos de pago");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmMetodosDePago());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Clientes");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmClientes());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnInformeVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Informe ventas");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmInformeVentas());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnSorteos_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Sorteos");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmSorteo());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnVerHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                Seleccionar_Menu("Ver horarios");

                if (Verificar_Permiso(oBEMenu) == 1)
                {
                    AbrirForm(new frmVerHorarios());
                }
                else { MessageBox.Show("El acceso a este apartado esta restringido para el usuario logueado", "Heladeria", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult logout = MessageBox.Show("¿Desea cerrar la sesion?", "Heladeria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(logout == DialogResult.Yes)
                {
                    Program.Logout = true;
                    this.Close();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                AbrirForm(new frmVenta());
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
