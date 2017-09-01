using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.MultiIdiioma;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.UI
{
    public partial class FrmPrincipal : Servicios.UI.FormBase
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            MultiIdioma.TraducirForm(this);

            StyleInicio();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

            
            CmbxIdioma.Items.AddRange(MultiIdioma.ListarIdiomas().ToArray());
            try
            {
                SantaMaria.Servicios.Seguridad.CheckSum.CompararTodosConDB();
            }
            catch (BLLException exep)
            {
                Servicios.UI.FormMensaje.CrearError(exep.Message);
            }

            new SantaMaria.Servicios.Seguridad.LoginForm().ShowDialog();
            if (SantaMaria.Servicios.Contexto.UsuarioActual == null)
            {
                Application.Exit();
                return;
            }

            AutorizacionMenu();
        }

        private void AutorizacionMenu()
        {
            VerificarItemDelMenu("Asignar permisos");
            VerificarItemDelMenu("Crear usuarios");
            VerificarItemDelMenu("Backup");
            VerificarItemDelMenu("Bitacora");
            VerificarItemDelMenu("Crear Permiso Personalizado");
            VerificarItemDelMenu("Ver Usuarios");
            VerificarItemDelMenu("Log de Errores");
            
            
        }
        private void VerificarItemDelMenu(string permiso)
        {
            if (!Servicios.Seguridad.Autorizacion.VerificarPermiso(permiso))
                menuStrip1.Items.Find(permiso.Replace(" ","") + "ToolStripMenuItem",true)[0].Enabled = false;

        }

        void StyleInicio()
        {
            menuStrip1.Font = MetroFramework.MetroFonts.Default(12);
            menuStrip1.BackColor = MetroFramework.MetroColors.White;
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SantaMaria.Servicios.Backup.FrmBackup().Show();
        }

        private void puesborrarestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void asignarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Seguridad.UI.FrmAsignarPermisos().Show();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Seguridad.UI.FrmCrearUsuario().Show();
        }

        private void crearPermisoPersonalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Seguridad.UI.FrmCrearPermisosPersonalizados().Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Seguridad.UI.FrmUsuarios().Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Bitacora.FrmBitacora().Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void CmbxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiIdioma.CambiarIdioma(new System.Globalization.CultureInfo(((ComboBox)sender).SelectedItem.ToString()));
            Size tam = this.Size;
            this.Size = new Size(0,0);
            this.Size = tam;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SantaMaria.Servicios.Contexto.UsuarioActual == null) return;
            DialogResult dialogo = SantaMaria.Servicios.UI.FormMensaje.CrearConfirmación("<LblDeseaSalir?>");
                
            e.Cancel = (dialogo == DialogResult.No);
        }

        private void logDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Servicios.Excepciones.FrmErrorLog().Show();
        }
    }
}
