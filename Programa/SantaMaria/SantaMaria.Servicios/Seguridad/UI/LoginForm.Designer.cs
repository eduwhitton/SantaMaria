namespace SantaMaria.Servicios.Seguridad
{
    partial class LoginForm
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
            this.TxbxUsuario = new MetroFramework.Controls.MetroTextBox();
            this.TxbxContraseña = new MetroFramework.Controls.MetroTextBox();
            this.LblUsuario = new MetroFramework.Controls.MetroLabel();
            this.LblContraseña = new MetroFramework.Controls.MetroLabel();
            this.BtnLogIn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // TxbxUsuario
            // 
            // 
            // 
            // 
            this.TxbxUsuario.CustomButton.Image = null;
            this.TxbxUsuario.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.TxbxUsuario.CustomButton.Name = "";
            this.TxbxUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxUsuario.CustomButton.TabIndex = 1;
            this.TxbxUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxUsuario.CustomButton.UseSelectable = true;
            this.TxbxUsuario.CustomButton.Visible = false;
            this.TxbxUsuario.Lines = new string[0];
            this.TxbxUsuario.Location = new System.Drawing.Point(134, 25);
            this.TxbxUsuario.MaxLength = 32767;
            this.TxbxUsuario.Name = "TxbxUsuario";
            this.TxbxUsuario.PasswordChar = '\0';
            this.TxbxUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxUsuario.SelectedText = "";
            this.TxbxUsuario.SelectionLength = 0;
            this.TxbxUsuario.SelectionStart = 0;
            this.TxbxUsuario.ShortcutsEnabled = true;
            this.TxbxUsuario.Size = new System.Drawing.Size(133, 23);
            this.TxbxUsuario.TabIndex = 5;
            this.TxbxUsuario.UseSelectable = true;
            this.TxbxUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxbxContraseña
            // 
            // 
            // 
            // 
            this.TxbxContraseña.CustomButton.Image = null;
            this.TxbxContraseña.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.TxbxContraseña.CustomButton.Name = "";
            this.TxbxContraseña.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxContraseña.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxContraseña.CustomButton.TabIndex = 1;
            this.TxbxContraseña.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxContraseña.CustomButton.UseSelectable = true;
            this.TxbxContraseña.CustomButton.Visible = false;
            this.TxbxContraseña.Lines = new string[0];
            this.TxbxContraseña.Location = new System.Drawing.Point(134, 54);
            this.TxbxContraseña.MaxLength = 32767;
            this.TxbxContraseña.Name = "TxbxContraseña";
            this.TxbxContraseña.PasswordChar = '●';
            this.TxbxContraseña.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxContraseña.SelectedText = "";
            this.TxbxContraseña.SelectionLength = 0;
            this.TxbxContraseña.SelectionStart = 0;
            this.TxbxContraseña.ShortcutsEnabled = true;
            this.TxbxContraseña.Size = new System.Drawing.Size(133, 23);
            this.TxbxContraseña.TabIndex = 6;
            this.TxbxContraseña.UseSelectable = true;
            this.TxbxContraseña.UseSystemPasswordChar = true;
            this.TxbxContraseña.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxContraseña.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(15, 27);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(88, 19);
            this.LblUsuario.TabIndex = 7;
            this.LblUsuario.Text = "<LblUsuario>";
            // 
            // LblContraseña
            // 
            this.LblContraseña.AutoSize = true;
            this.LblContraseña.Location = new System.Drawing.Point(15, 56);
            this.LblContraseña.Name = "LblContraseña";
            this.LblContraseña.Size = new System.Drawing.Size(110, 19);
            this.LblContraseña.TabIndex = 8;
            this.LblContraseña.Text = "<LblContraseña>";
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.Location = new System.Drawing.Point(104, 94);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(75, 23);
            this.BtnLogIn.TabIndex = 9;
            this.BtnLogIn.Text = "<BtnLogIn>";
            this.BtnLogIn.UseSelectable = true;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.BtnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 140);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.LblContraseña);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.TxbxContraseña);
            this.Controls.Add(this.TxbxUsuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TxbxUsuario;
        private MetroFramework.Controls.MetroTextBox TxbxContraseña;
        private MetroFramework.Controls.MetroLabel LblUsuario;
        private MetroFramework.Controls.MetroLabel LblContraseña;
        private MetroFramework.Controls.MetroButton BtnLogIn;

    }
}