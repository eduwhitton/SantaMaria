namespace SantaMaria.Servicios.Seguridad.UI
{
    partial class FrmCrearPermisosPersonalizados
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
            this.BtnCancelar = new MetroFramework.Controls.MetroButton();
            this.LblNombre = new MetroFramework.Controls.MetroLabel();
            this.LblDescripcion = new MetroFramework.Controls.MetroLabel();
            this.TxbxNombre = new MetroFramework.Controls.MetroTextBox();
            this.TxbxDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(27, 247);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(105, 23);
            this.BtnGuardar.TabIndex = 0;
            this.BtnGuardar.Text = "<BtnGuardar>";
            this.BtnGuardar.UseSelectable = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(270, 247);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(105, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "<BtnCancelar>";
            this.BtnCancelar.UseSelectable = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(27, 65);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(94, 19);
            this.LblNombre.TabIndex = 2;
            this.LblNombre.Text = "<LblNombre>";
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(25, 127);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(111, 19);
            this.LblDescripcion.TabIndex = 3;
            this.LblDescripcion.Text = "<LblDescripcion>";
            // 
            // TxbxNombre
            // 
            // 
            // 
            // 
            this.TxbxNombre.CustomButton.Image = null;
            this.TxbxNombre.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.TxbxNombre.CustomButton.Name = "";
            this.TxbxNombre.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxNombre.CustomButton.TabIndex = 1;
            this.TxbxNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxNombre.CustomButton.UseSelectable = true;
            this.TxbxNombre.CustomButton.Visible = false;
            this.TxbxNombre.Lines = new string[0];
            this.TxbxNombre.Location = new System.Drawing.Point(178, 65);
            this.TxbxNombre.MaxLength = 32767;
            this.TxbxNombre.Name = "TxbxNombre";
            this.TxbxNombre.PasswordChar = '\0';
            this.TxbxNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxNombre.SelectedText = "";
            this.TxbxNombre.SelectionLength = 0;
            this.TxbxNombre.SelectionStart = 0;
            this.TxbxNombre.ShortcutsEnabled = true;
            this.TxbxNombre.Size = new System.Drawing.Size(197, 23);
            this.TxbxNombre.TabIndex = 4;
            this.TxbxNombre.UseSelectable = true;
            this.TxbxNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxbxDescripcion
            // 
            // 
            // 
            // 
            this.TxbxDescripcion.CustomButton.Image = null;
            this.TxbxDescripcion.CustomButton.Location = new System.Drawing.Point(125, 2);
            this.TxbxDescripcion.CustomButton.Name = "";
            this.TxbxDescripcion.CustomButton.Size = new System.Drawing.Size(69, 69);
            this.TxbxDescripcion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxDescripcion.CustomButton.TabIndex = 1;
            this.TxbxDescripcion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxDescripcion.CustomButton.UseSelectable = true;
            this.TxbxDescripcion.CustomButton.Visible = false;
            this.TxbxDescripcion.Lines = new string[0];
            this.TxbxDescripcion.Location = new System.Drawing.Point(178, 127);
            this.TxbxDescripcion.MaxLength = 32767;
            this.TxbxDescripcion.Multiline = true;
            this.TxbxDescripcion.Name = "TxbxDescripcion";
            this.TxbxDescripcion.PasswordChar = '\0';
            this.TxbxDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxDescripcion.SelectedText = "";
            this.TxbxDescripcion.SelectionLength = 0;
            this.TxbxDescripcion.SelectionStart = 0;
            this.TxbxDescripcion.ShortcutsEnabled = true;
            this.TxbxDescripcion.Size = new System.Drawing.Size(197, 74);
            this.TxbxDescripcion.TabIndex = 5;
            this.TxbxDescripcion.UseSelectable = true;
            this.TxbxDescripcion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxDescripcion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FrmCrearPermisosPersonalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 297);
            this.Controls.Add(this.TxbxDescripcion);
            this.Controls.Add(this.TxbxNombre);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Name = "FrmCrearPermisosPersonalizados";
            this.Text = "<FrmCrearPermisosPersonalizados>";
            this.Load += new System.EventHandler(this.FrmCrearPermisosPersonalizados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton BtnGuardar;
        private MetroFramework.Controls.MetroButton BtnCancelar;
        private MetroFramework.Controls.MetroLabel LblNombre;
        private MetroFramework.Controls.MetroLabel LblDescripcion;
        private MetroFramework.Controls.MetroTextBox TxbxNombre;
        private MetroFramework.Controls.MetroTextBox TxbxDescripcion;
    }
}