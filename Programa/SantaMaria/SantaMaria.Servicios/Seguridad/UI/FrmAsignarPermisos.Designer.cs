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
            this.BtnElegir = new MetroFramework.Controls.MetroButton();
            this.CmbxPermisosPersonalizados = new MetroFramework.Controls.MetroComboBox();
            this.BtnBuscar = new MetroFramework.Controls.MetroButton();
            this.BtnCancelar = new MetroFramework.Controls.MetroButton();
            this.PnlAsignar = new MetroFramework.Controls.MetroPanel();
            this.LblNombre = new MetroFramework.Controls.MetroLabel();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPageUsuario = new MetroFramework.Controls.MetroTabPage();
            this.tabPagePermisoPersonalizado = new MetroFramework.Controls.MetroTabPage();
            this.PnlAsignar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageUsuario.SuspendLayout();
            this.tabPagePermisoPersonalizado.SuspendLayout();
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
            this.BtnAsignar.Location = new System.Drawing.Point(4, 31);
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
            this.LblUsuario.Location = new System.Drawing.Point(2, 22);
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
            this.TxbxUsuario.Location = new System.Drawing.Point(96, 20);
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
            // BtnElegir
            // 
            this.BtnElegir.Location = new System.Drawing.Point(239, 20);
            this.BtnElegir.Name = "BtnElegir";
            this.BtnElegir.Size = new System.Drawing.Size(73, 23);
            this.BtnElegir.TabIndex = 8;
            this.BtnElegir.Text = "<BtnElegir>";
            this.BtnElegir.UseSelectable = true;
            this.BtnElegir.Click += new System.EventHandler(this.BtnElegir_Click);
            // 
            // CmbxPermisosPersonalizados
            // 
            this.CmbxPermisosPersonalizados.FormattingEnabled = true;
            this.CmbxPermisosPersonalizados.ItemHeight = 23;
            this.CmbxPermisosPersonalizados.Location = new System.Drawing.Point(0, 17);
            this.CmbxPermisosPersonalizados.Name = "CmbxPermisosPersonalizados";
            this.CmbxPermisosPersonalizados.Size = new System.Drawing.Size(233, 29);
            this.CmbxPermisosPersonalizados.TabIndex = 7;
            this.CmbxPermisosPersonalizados.UseSelectable = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(241, 20);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(71, 23);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "<BtnBuscar>";
            this.BtnBuscar.UseSelectable = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(104, 31);
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
            this.PnlAsignar.Controls.Add(this.BtnCancelar);
            this.PnlAsignar.Controls.Add(this.BtnAsignar);
            this.PnlAsignar.HorizontalScrollbarBarColor = true;
            this.PnlAsignar.HorizontalScrollbarHighlightOnWheel = false;
            this.PnlAsignar.HorizontalScrollbarSize = 10;
            this.PnlAsignar.Location = new System.Drawing.Point(312, 165);
            this.PnlAsignar.Name = "PnlAsignar";
            this.PnlAsignar.Size = new System.Drawing.Size(320, 238);
            this.PnlAsignar.TabIndex = 6;
            this.PnlAsignar.VerticalScrollbarBarColor = true;
            this.PnlAsignar.VerticalScrollbarHighlightOnWheel = false;
            this.PnlAsignar.VerticalScrollbarSize = 10;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUsuario);
            this.tabControl1.Controls.Add(this.tabPagePermisoPersonalizado);
            this.tabControl1.Location = new System.Drawing.Point(312, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 100);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.UseSelectable = true;
            // 
            // tabPageUsuario
            // 
            this.tabPageUsuario.Controls.Add(this.TxbxUsuario);
            this.tabPageUsuario.Controls.Add(this.LblUsuario);
            this.tabPageUsuario.Controls.Add(this.BtnBuscar);
            this.tabPageUsuario.HorizontalScrollbarBarColor = true;
            this.tabPageUsuario.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageUsuario.HorizontalScrollbarSize = 10;
            this.tabPageUsuario.Location = new System.Drawing.Point(4, 38);
            this.tabPageUsuario.Name = "tabPageUsuario";
            this.tabPageUsuario.Size = new System.Drawing.Size(312, 58);
            this.tabPageUsuario.TabIndex = 0;
            this.tabPageUsuario.Text = "<FrmUsuarios>";
            this.tabPageUsuario.VerticalScrollbarBarColor = true;
            this.tabPageUsuario.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageUsuario.VerticalScrollbarSize = 10;
            // 
            // tabPagePermisoPersonalizado
            // 
            this.tabPagePermisoPersonalizado.Controls.Add(this.BtnElegir);
            this.tabPagePermisoPersonalizado.Controls.Add(this.CmbxPermisosPersonalizados);
            this.tabPagePermisoPersonalizado.HorizontalScrollbarBarColor = true;
            this.tabPagePermisoPersonalizado.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPagePermisoPersonalizado.HorizontalScrollbarSize = 10;
            this.tabPagePermisoPersonalizado.Location = new System.Drawing.Point(4, 38);
            this.tabPagePermisoPersonalizado.Name = "tabPagePermisoPersonalizado";
            this.tabPagePermisoPersonalizado.Size = new System.Drawing.Size(312, 58);
            this.tabPagePermisoPersonalizado.TabIndex = 1;
            this.tabPagePermisoPersonalizado.Text = "<LblPermisos>";
            this.tabPagePermisoPersonalizado.VerticalScrollbarBarColor = true;
            this.tabPagePermisoPersonalizado.VerticalScrollbarHighlightOnWheel = false;
            this.tabPagePermisoPersonalizado.VerticalScrollbarSize = 10;
            // 
            // FrmAsignarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 426);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PnlAsignar);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmAsignarPermisos";
            this.Text = "<FrmAsignarPermisos>";
            this.Load += new System.EventHandler(this.FrmAsignarPermisos_Load);
            this.PnlAsignar.ResumeLayout(false);
            this.PnlAsignar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsuario.ResumeLayout(false);
            this.tabPageUsuario.PerformLayout();
            this.tabPagePermisoPersonalizado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroButton BtnAsignar;
        private MetroFramework.Controls.MetroLabel LblUsuario;
        private MetroFramework.Controls.MetroTextBox TxbxUsuario;
        private MetroFramework.Controls.MetroButton BtnBuscar;
        private MetroFramework.Controls.MetroButton BtnCancelar;
        private MetroFramework.Controls.MetroPanel PnlAsignar;
        private MetroFramework.Controls.MetroButton BtnElegir;
        private MetroFramework.Controls.MetroComboBox CmbxPermisosPersonalizados;
        private MetroFramework.Controls.MetroLabel LblNombre;
        private MetroFramework.Controls.MetroTabControl tabControl1;
        private MetroFramework.Controls.MetroTabPage tabPageUsuario;
        private MetroFramework.Controls.MetroTabPage tabPagePermisoPersonalizado;
    }
}