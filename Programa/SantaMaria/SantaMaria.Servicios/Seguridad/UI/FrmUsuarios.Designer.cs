namespace SantaMaria.Servicios.Seguridad.UI
{
    partial class FrmUsuarios
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
            this.BtnGuardar = new MetroFramework.Controls.MetroButton();
            this.LblDeshabilitado = new MetroFramework.Controls.MetroLabel();
            this.LblHabilitado = new MetroFramework.Controls.MetroLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.BtnDelete = new MetroFramework.Controls.MetroButton();
            this.BtnDeshabilitar = new MetroFramework.Controls.MetroButton();
            this.BtnHabilitar = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.Location = new System.Drawing.Point(469, 353);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(121, 23);
            this.BtnGuardar.TabIndex = 23;
            this.BtnGuardar.Text = "<BtnGuardar>";
            this.BtnGuardar.UseSelectable = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LblDeshabilitado
            // 
            this.LblDeshabilitado.AutoSize = true;
            this.LblDeshabilitado.ForeColor = System.Drawing.Color.Gray;
            this.LblDeshabilitado.Location = new System.Drawing.Point(467, 176);
            this.LblDeshabilitado.Name = "LblDeshabilitado";
            this.LblDeshabilitado.Size = new System.Drawing.Size(123, 19);
            this.LblDeshabilitado.TabIndex = 6;
            this.LblDeshabilitado.Text = "<LblDeshabilitado>";
            this.LblDeshabilitado.UseCustomForeColor = true;
            // 
            // LblHabilitado
            // 
            this.LblHabilitado.AutoSize = true;
            this.LblHabilitado.ForeColor = System.Drawing.Color.Black;
            this.LblHabilitado.Location = new System.Drawing.Point(469, 157);
            this.LblHabilitado.Name = "LblHabilitado";
            this.LblHabilitado.Size = new System.Drawing.Size(104, 19);
            this.LblHabilitado.TabIndex = 5;
            this.LblHabilitado.Text = "<LblHabilitado>";
            this.LblHabilitado.UseCustomForeColor = true;
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(23, 63);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(440, 313);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(469, 121);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(121, 23);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "<BtnDelete>";
            this.BtnDelete.UseSelectable = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnDeshabilitar
            // 
            this.BtnDeshabilitar.Location = new System.Drawing.Point(469, 92);
            this.BtnDeshabilitar.Name = "BtnDeshabilitar";
            this.BtnDeshabilitar.Size = new System.Drawing.Size(121, 23);
            this.BtnDeshabilitar.TabIndex = 2;
            this.BtnDeshabilitar.Text = "<BtnDeshabilitar>";
            this.BtnDeshabilitar.UseSelectable = true;
            this.BtnDeshabilitar.Click += new System.EventHandler(this.BtnDesHabilitar_Click);
            // 
            // BtnHabilitar
            // 
            this.BtnHabilitar.Location = new System.Drawing.Point(469, 63);
            this.BtnHabilitar.Name = "BtnHabilitar";
            this.BtnHabilitar.Size = new System.Drawing.Size(121, 23);
            this.BtnHabilitar.TabIndex = 1;
            this.BtnHabilitar.Text = "<BtnHabilitar>";
            this.BtnHabilitar.UseSelectable = true;
            this.BtnHabilitar.Click += new System.EventHandler(this.BtnHabilitar_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 399);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblDeshabilitado);
            this.Controls.Add(this.LblHabilitado);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnDeshabilitar);
            this.Controls.Add(this.BtnHabilitar);
            this.Name = "FrmUsuarios";
            this.Text = "<FrmUsuarios>";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton BtnHabilitar;
        private MetroFramework.Controls.MetroButton BtnDeshabilitar;
        private MetroFramework.Controls.MetroButton BtnDelete;
        private System.Windows.Forms.ListView listView1;
        private MetroFramework.Controls.MetroLabel LblHabilitado;
        private MetroFramework.Controls.MetroLabel LblDeshabilitado;
        private MetroFramework.Controls.MetroButton BtnGuardar;
    }
}