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

namespace SantaMaria.Servicios.UI
{
    public partial class FormMensaje : FormBase
    {
        string _mensaje;
        string _titulo;

        public static DialogResult CrearError(string mensaje, string titulo = "<FrmError>", MessageBoxButtons botones = MessageBoxButtons.OK)
        {
            FormMensaje form = new FormMensaje(mensaje,titulo);
            form.pictureBox1.Image = Servicios.UI.IconsBig.cross_circle;
            form.ResolverBotones(botones);
            return form.ShowDialog();
        }
        
        public static DialogResult CrearAdvertencia(string mensaje, string titulo = "<FrmAdvertencia>", MessageBoxButtons botones = MessageBoxButtons.OK)
        {
            FormMensaje form = new FormMensaje(mensaje, titulo);
            form.BackColor = MetroFramework.MetroColors.Orange;
            form.pictureBox1.Image = Servicios.UI.IconsBig.exclamation;
            form.ResolverBotones(botones);
            return form.ShowDialog();
        }

        public static DialogResult CrearConfirmación(string mensaje = "<LblEstaSeguro?>", string titulo = "<LblEstaSeguro?>", MessageBoxButtons botones = MessageBoxButtons.YesNo)
        {
            FormMensaje form = new FormMensaje(mensaje, titulo);
            form.BackColor = MetroFramework.MetroColors.Orange;
            form.pictureBox1.Image = Servicios.UI.IconsBig.question;
            form.ResolverBotones(botones);
            return form.ShowDialog();
        }

        public static DialogResult CrearExito(string mensaje, string titulo = "<FrmExito>", MessageBoxButtons botones = MessageBoxButtons.OK)
        {
            FormMensaje form = new FormMensaje(mensaje, titulo);
            form.BackColor = MetroFramework.MetroColors.Orange;
            form.pictureBox1.Image = Servicios.UI.IconsBig.tick;
            form.ResolverBotones(botones);
            return form.ShowDialog();
        }

        private FormMensaje()
        {
        }

        private FormMensaje(string mensaje, string titulo = "<FrmError>", MessageBoxButtons botones = MessageBoxButtons.OK)
        {
            InitializeComponent();
            ResolverBotones(botones);
            _mensaje = mensaje;
            _titulo = titulo;
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LblMensaje.Text = _mensaje;
            this.Text = _titulo;
            MultiIdioma.TraducirForm(this);
            this.BringToFront();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ResolverBotones(MessageBoxButtons botones)
        {
            BtnCancelar.Visible = false;
            BtnOk.Visible = false;
            BtnSi.Visible = false;
            BtnNo.Visible = false;
            if (botones == MessageBoxButtons.OK || botones == MessageBoxButtons.OKCancel)
            {
                BtnOk.Visible = true;
            }
            if (botones == MessageBoxButtons.OKCancel || botones == MessageBoxButtons.YesNoCancel)
            {
                BtnCancelar.Visible = true;
            }
            if (botones == MessageBoxButtons.YesNo)
            {
                BtnSi.Visible = true;
                BtnNo.Visible = true;
            }
        }

        private void BtnSi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
