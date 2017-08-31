namespace SantaMaria.UI
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AsignarpermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearusuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearPermisoPersonalizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmbxIdioma = new MetroFramework.Controls.MetroComboBox();
            this.LblIdioma = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personaToolStripMenuItem,
            this.ServiciosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personaToolStripMenuItem
            // 
            this.personaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            this.personaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.personaToolStripMenuItem.Text = "Persona";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // ServiciosToolStripMenuItem
            // 
            this.ServiciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackupToolStripMenuItem,
            this.SeguridadToolStripMenuItem,
            this.BitacoraToolStripMenuItem});
            this.ServiciosToolStripMenuItem.Name = "ServiciosToolStripMenuItem";
            this.ServiciosToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.ServiciosToolStripMenuItem.Text = "<LblServicios>";
            // 
            // BackupToolStripMenuItem
            // 
            this.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem";
            this.BackupToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.BackupToolStripMenuItem.Text = "<FrmBackup>";
            this.BackupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // SeguridadToolStripMenuItem
            // 
            this.SeguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AsignarpermisosToolStripMenuItem,
            this.CrearusuariosToolStripMenuItem,
            this.CrearPermisoPersonalizadoToolStripMenuItem,
            this.VerUsuariosToolStripMenuItem});
            this.SeguridadToolStripMenuItem.Name = "SeguridadToolStripMenuItem";
            this.SeguridadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SeguridadToolStripMenuItem.Text = "<LblSeguridad>";
            // 
            // AsignarpermisosToolStripMenuItem
            // 
            this.AsignarpermisosToolStripMenuItem.Name = "AsignarpermisosToolStripMenuItem";
            this.AsignarpermisosToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.AsignarpermisosToolStripMenuItem.Text = "<FrmAsignarPermisos>";
            this.AsignarpermisosToolStripMenuItem.Click += new System.EventHandler(this.asignarPermisosToolStripMenuItem_Click);
            // 
            // CrearusuariosToolStripMenuItem
            // 
            this.CrearusuariosToolStripMenuItem.Name = "CrearusuariosToolStripMenuItem";
            this.CrearusuariosToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.CrearusuariosToolStripMenuItem.Text = "<FrmCrearUsuario>";
            this.CrearusuariosToolStripMenuItem.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem_Click);
            // 
            // CrearPermisoPersonalizadoToolStripMenuItem
            // 
            this.CrearPermisoPersonalizadoToolStripMenuItem.Name = "CrearPermisoPersonalizadoToolStripMenuItem";
            this.CrearPermisoPersonalizadoToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.CrearPermisoPersonalizadoToolStripMenuItem.Text = "<FrmCrearPermisosPersonalizados>";
            this.CrearPermisoPersonalizadoToolStripMenuItem.Click += new System.EventHandler(this.crearPermisoPersonalizadoToolStripMenuItem_Click);
            // 
            // VerUsuariosToolStripMenuItem
            // 
            this.VerUsuariosToolStripMenuItem.Name = "VerUsuariosToolStripMenuItem";
            this.VerUsuariosToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.VerUsuariosToolStripMenuItem.Text = "<FrmUsuarios>";
            this.VerUsuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // BitacoraToolStripMenuItem
            // 
            this.BitacoraToolStripMenuItem.Name = "BitacoraToolStripMenuItem";
            this.BitacoraToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.BitacoraToolStripMenuItem.Text = "<FrmBitacora>";
            this.BitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // CmbxIdioma
            // 
            this.CmbxIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbxIdioma.FormattingEnabled = true;
            this.CmbxIdioma.ItemHeight = 23;
            this.CmbxIdioma.Location = new System.Drawing.Point(600, 321);
            this.CmbxIdioma.Name = "CmbxIdioma";
            this.CmbxIdioma.Size = new System.Drawing.Size(151, 29);
            this.CmbxIdioma.TabIndex = 1;
            this.CmbxIdioma.UseSelectable = true;
            this.CmbxIdioma.SelectedIndexChanged += new System.EventHandler(this.CmbxIdioma_SelectedIndexChanged);
            // 
            // LblIdioma
            // 
            this.LblIdioma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIdioma.AutoSize = true;
            this.LblIdioma.Location = new System.Drawing.Point(502, 326);
            this.LblIdioma.Name = "LblIdioma";
            this.LblIdioma.Size = new System.Drawing.Size(85, 19);
            this.LblIdioma.TabIndex = 2;
            this.LblIdioma.Text = "<LblIdioma>";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 373);
            this.Controls.Add(this.LblIdioma);
            this.Controls.Add(this.CmbxIdioma);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "<FrmPrincipal>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServiciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SeguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AsignarpermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearusuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearPermisoPersonalizadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VerUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BitacoraToolStripMenuItem;
        private MetroFramework.Controls.MetroComboBox CmbxIdioma;
        private MetroFramework.Controls.MetroLabel LblIdioma;
    }
}