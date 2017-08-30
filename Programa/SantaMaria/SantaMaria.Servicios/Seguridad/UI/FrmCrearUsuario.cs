using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.UI;

namespace SantaMaria.Servicios.Seguridad.UI
{
    public partial class FrmCrearUsuario : FormBase
    {
        public FrmCrearUsuario()
        {
            InitializeComponent();
        }

        private void FrmCrearUsuario_Load(object sender, EventArgs e)
        {
            MultiIdiioma.MultiIdioma.TraducirForm(this);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificarTodosLosCamposLlenos())
            {
                Servicios.UI.FormMensaje.CrearAdvertencia("Es necesario llenar todos los campos antes de aceptar.");
                return;
            }
            BLL.BLLUsuario bll = new BLL.BLLUsuario();
            Entidades.Usuario usu = new Entidades.Usuario();
            usu.Nombre = TxbxNombre.Text;
            usu.DescripcionComponente = TxbxDescripcion.Text;
            usu.usuario = TxbxUsuario.Text;
            usu.contraseña = TxbxContraseña.Text;
            usu.dni = int.Parse(TxbxDNI.Text);
            usu.habilitado = true;
            try
            {
                bll.AgregarUsuario(usu);
                ClearTextboxs();
                Servicios.UI.FormMensaje.CrearExito("Usuario " + usu.Nombre + " creado con exito!");
            }
            catch (Excepciones.BLLException)
            {
                Servicios.UI.FormMensaje.CrearError("No se pudo crear el usuario");
            }
        }

        private void ClearTextboxs()
        {
            TxbxContraseña.Text = "";
            TxbxDescripcion.Text = "";
            TxbxDNI.Text = "";
            TxbxNombre.Text = "";
            TxbxUsuario.Text = "";
        }

        private bool VerificarTodosLosCamposLlenos()
        {
            if (TxbxNombre.Text == "" || TxbxDescripcion.Text == "" ||
                TxbxUsuario.Text == "" || TxbxContraseña.Text == "" ||
                TxbxDNI.Text == "") return false;
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxbxDNI_TextChanged(object sender, EventArgs e)
        {
            ///Se fija si son numeros los ingresados, y en caso contraro, los borra
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]+");
            TxbxDNI.Text = reg.Replace(TxbxDNI.Text, "");
            if (TxbxDNI.Text.Length > 9) TxbxDNI.Text = TxbxDNI.Text.Remove(9);
            if (TxbxDNI.Text != "")
            {
                TxbxDNI.SelectionStart = TxbxDNI.Text.Length;
                TxbxDNI.SelectionLength = 0;
            }
        }
    }
}
