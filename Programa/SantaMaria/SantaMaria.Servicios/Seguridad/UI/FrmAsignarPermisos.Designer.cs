namespace SantaMaria.Servicios.Seguridad.UI
{
    partial class FrmAsignarPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.BtnAsignar = new MetroFramework.Controls.MetroButton();
            this.LblUsuario = new MetroFramework.Controls.MetroLabel();
            this.TxbxUsuario = new MetroFramework.Controls.MetroTextBox();
            this.PnlBuscar = new MetroFramework.Controls.MetroPanel();
            this.LblO = new MetroFramework.Controls.MetroLabel();
            this.BtnBuscar = new MetroFramework.Controls.MetroButton();
            this.BtnCancelar = new MetroFramework.Controls.MetroButton();
            this.PnlAsignar = new MetroFramework.Controls.MetroPanel();
            this.CmbxPermisosPersonalizados = new MetroFramework.Controls.MetroComboBox();
            this.BtnElegir = new MetroFramework.Controls.MetroButton();
            this.BtnCargarPermisosActuales = new MetroFramework.Controls.MetroButton();
            this.LblNombre = new MetroFramework.Controls.MetroLabel();
            this.PnlBuscar.SuspendLayout();
            this.PnlAsignar.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(23, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(283, 340);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Location = new System.Drawing.Point(121, 208);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(94, 23);
            this.BtnAsignar.TabIndex = 1;
            this.BtnAsignar.Text = "<BtnAsignar>";
            this.BtnAsignar.UseSelectable = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(3, 9);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(88, 19);
            this.LblUsuario.TabIndex = 2;
            this.LblUsuario.Text = "<LblUsuario>";
            // 
            // TxbxUsuario
            // 
            // 
            // 
            // 
            this.TxbxUsuario.CustomButton.Image = null;
            this.TxbxUsuario.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.TxbxUsuario.CustomButton.Name = "";
            this.TxbxUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxUsuario.CustomButton.TabIndex = 1;
            this.TxbxUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxUsuario.CustomButton.UseSelectable = true;
            this.TxbxUsuario.CustomButton.Visible = false;
            this.TxbxUsuario.Lines = new string[0];
            this.TxbxUsuario.Location = new System.Drawing.Point(97, 7);
            this.TxbxUsuario.MaxLength = 32767;
            this.TxbxUsuario.Name = "TxbxUsuario";
            this.TxbxUsuario.PasswordChar = '\0';
            this.TxbxUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxUsuario.SelectedText = "";
            this.TxbxUsuario.SelectionLength = 0;
            this.TxbxUsuario.SelectionStart = 0;
            this.TxbxUsuario.ShortcutsEnabled = true;
            this.TxbxUsuario.Size = new System.Drawing.Size(138, 23);
            this.TxbxUsuario.TabIndex = 3;
            this.TxbxUsuario.UseSelectable = true;
            this.TxbxUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PnlBuscar
            // 
            this.PnlBuscar.Controls.Add(this.BtnElegir);
            this.PnlBuscar.Controls.Add(this.CmbxPermisosPersonalizados);
            this.PnlBuscar.Controls.Add(this.LblO);
            this.PnlBuscar.Controls.Add(this.BtnBuscar);
            this.PnlBuscar.Controls.Add(this.TxbxUsuario);
            this.PnlBuscar.Controls.Add(this.LblUsuario);
            this.PnlBuscar.HorizontalScrollbarBarColor = true;
            this.PnlBuscar.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlBuscar.HorizontalScrollbarSize = 10;
            this.PnlBuscar.Location = new System.Drawing.Point(312, 63);
            this.PnlBuscar.Name = "PnlBuscar";
            this.PnlBuscar.Size = new System.Drawing.Size(320, 90);
            this.PnlBuscar.TabIndex = 4;
            this.PnlBuscar.VerticalScrollbarBarColor = true;
            this.PnlBuscar.VerticalScrollbarHighlightOnWheel = false;
            this.PnlBuscar.VerticalScrollbarSize = 10;
            // 
            // LblO
            // 
            this.LblO.AutoSize = true;
            this.LblO.Location = new System.Drawing.Point(43, 33);
            this.LblO.Name = "LblO";
            this.LblO.Size = new System.Drawing.Size(260, 19);
            this.LblO.TabIndex = 5;
            this.LblO.Text = "<LblOSeleccioneUnPermisoPersonalizado>";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(242, 7);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "<BtnBuscar>";
            this.BtnBuscar.UseSelectable = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(221, 208);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(94, 23);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "<BtnCancelar>";
            this.BtnCancelar.UseSelectable = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // PnlAsignar
            // 
            this.PnlAsignar.Controls.Add(this.LblNombre);
            this.PnlAsignar.Controls.Add(this.BtnCargarPermisosActuales);
            this.PnlAsignar.Controls.Add(this.BtnCancelar);
            this.PnlAsignar.Controls.Add(this.BtnAsignar);
            this.PnlAsignar.HorizontalScrollbarBarColor = true;
            this.PnlAsignar.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlAsignar.HorizontalScrollbarSize = 10;
            this.PnlAsignar.Location = new System.Drawing.Point(312, 159);
            this.PnlAsignar.Name = "PnlAsignar";
            this.PnlAsignar.Size = new System.Drawing.Size(320, 244);
            this.PnlAsignar.TabIndex = 6;
            this.PnlAsignar.VerticalScrollbarBarColor = true;
            this.PnlAsignar.VerticalScrollbarHighlightOnWheel = false;
            this.PnlAsignar.VerticalScrollbarSize = 10;
            // 
            // CmbxPermisosPersonalizados
            // 
            this.CmbxPermisosPersonalizados.FormattingEnabled = true;
            this.CmbxPermisosPersonalizados.ItemHeight = 23;
            this.CmbxPermisosPersonalizados.Location = new System.Drawing.Point(3, 55);
            this.CmbxPermisosPersonalizados.Name = "CmbxPermisosPersonalizados";
            this.CmbxPermisosPersonalizados.Size = new System.Drawing.Size(233, 29);
            this.CmbxPermisosPersonalizados.TabIndex = 7;
            this.CmbxPermisosPersonalizados.UseSelectable = true;
            // 
            // BtnElegir
            // 
            this.BtnElegir.Location = new System.Drawing.Point(242, 58);
            this.BtnElegir.Name = "BtnElegir";
            this.BtnElegir.Size = new System.Drawing.Size(75, 23);
            this.BtnElegir.TabIndex = 8;
            this.BtnElegir.Text = "<BtnElegir>";
            this.BtnElegir.UseSelectable = true;
            this.BtnElegir.Click += new System.EventHandler(this.BtnElegir_Click);
            // 
            // BtnCargarPermisosActuales
            // 
            this.BtnCargarPermisosActuales.Location = new System.Drawing.Point(3, 31);
            this.BtnCargarPermisosActuales.Name = "BtnCargarPermisosActuales";
            this.BtnCargarPermisosActuales.Size = new System.Drawing.Size(184, 23);
            this.BtnCargarPermisosActuales.TabIndex = 6;
            this.BtnCargarPermisosActuales.Text = "<BtnCargarPermisosActuales>";
            this.BtnCargarPermisosActuales.UseSelectable = true;
            this.BtnCargarPermisosActuales.Click += new System.EventHandler(this.BtnCargarPermisosActuales_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(3, 9);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(129, 19);
            this.LblNombre.TabIndex = 7;
            this.LblNombre.Text = "Lblnombredelobjeto";
            // 
            // FrmAsignarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 426);
            this.Controls.Add(this.PnlAsignar);
            this.Controls.Add(this.PnlBuscar);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmAsignarPermisos";
            this.Text = "<FrmAsignarPermisos>";
            this.Load += new System.EventHandler(this.FrmAsignarPermisos_Load);
            this.PnlBuscar.ResumeLayout(false);
            this.PnlBuscar.PerformLayout();
            this.PnlAsignar.ResumeLayout(false);
            this.PnlAsignar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroButton BtnAsignar;
        private MetroFramework.Controls.MetroLabel LblUsuario;
        private MetroFramework.Controls.MetroTextBox TxbxUsuario;
        private MetroFramework.Controls.MetroPanel PnlBuscar;
        private MetroFramework.Controls.MetroButton BtnBuscar;
        private MetroFramework.Controls.MetroButton BtnCancelar;
        private MetroFramework.Controls.MetroPanel PnlAsignar;
        private MetroFramework.Controls.MetroLabel LblO;
        private MetroFramework.Controls.MetroButton BtnElegir;
        private MetroFramework.Controls.MetroComboBox CmbxPermisosPersonalizados;
        private MetroFramework.Controls.MetroLabel LblNombre;
        private MetroFramework.Controls.MetroButton BtnCargarPermisosActuales;
    }
}