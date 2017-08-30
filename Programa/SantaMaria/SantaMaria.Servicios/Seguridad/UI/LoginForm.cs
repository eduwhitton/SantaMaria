using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SantaMaria.Servicios.Seguridad.Entidades;
using SantaMaria.Servicios.Seguridad;
using SantaMaria.Servicios.Bitacora;
using SantaMaria.Servicios.UI;
using System.Globalization;
using SantaMaria.Servicios.Excepciones;

namespace SantaMaria.Servicios.Seguridad
{
    public partial class LoginForm : FormBase
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            MultiIdiioma.MultiIdioma.TraducirForm(this);
            this.Activate();
            TxbxUsuario.Focus();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.usuario = TxbxUsuario.Text;
            usuario.contraseña = TxbxContraseña.Text;

            if (Autorizacion.VerificarUsuarioContraseña(usuario))
            {
                Contexto.NuevoUsuario(usuario);
                Bitacora.Bitacora.Instance.LogActividad("Login de " + usuario.usuario, "Success");
                this.Close();
            }
            else
            {
                Bitacora.Bitacora.Instance.LogActividad("Login de " + usuario.usuario, "Fail");
                FormMensaje.CrearError("<ErrLoginCredencialesMalas>", "<ErrLoginTitulo>");
            }
        }
    }
}
