namespace SantaMaria.Servicios.Bitacora
{
    partial class FrmBitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.LogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimeDesde = new MetroFramework.Controls.MetroDateTime();
            this.LblFechaDesde = new MetroFramework.Controls.MetroLabel();
            this.LblFechaHasta = new MetroFramework.Controls.MetroLabel();
            this.DateTimeHasta = new MetroFramework.Controls.MetroDateTime();
            this.LblUsuario = new MetroFramework.Controls.MetroLabel();
            this.TxBxUsuario = new MetroFramework.Controls.MetroTextBox();
            this.TxbxActividad = new MetroFramework.Controls.MetroTextBox();
            this.LblActividad = new MetroFramework.Controls.MetroLabel();
            this.BtnFiltrar = new MetroFramework.Controls.MetroButton();
            this.BtnGuardar = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogDate,
            this.Usuario,
            this.Activity,
            this.Result,
            this.IpAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(20, 60);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(654, 370);
            this.metroGrid1.TabIndex = 1;
            // 
            // LogDate
            // 
            this.LogDate.HeaderText = "Fecha";
            this.LogDate.Name = "LogDate";
            this.LogDate.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Actividad";
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.HeaderText = "Resultado";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "Direccion IP";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            // 
            // DateTimeDesde
            // 
            this.DateTimeDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeDesde.Location = new System.Drawing.Point(680, 82);
            this.DateTimeDesde.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeDesde.Name = "DateTimeDesde";
            this.DateTimeDesde.Size = new System.Drawing.Size(114, 29);
            this.DateTimeDesde.TabIndex = 2;
            this.DateTimeDesde.Value = new System.DateTime(2016, 7, 9, 0, 0, 0, 0);
            // 
            // LblFechaDesde
            // 
            this.LblFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaDesde.AutoSize = true;
            this.LblFechaDesde.Location = new System.Drawing.Point(680, 60);
            this.LblFechaDesde.Name = "LblFechaDesde";
            this.LblFechaDesde.Size = new System.Drawing.Size(114, 19);
            this.LblFechaDesde.TabIndex = 4;
            this.LblFechaDesde.Text = "<LblFechaDesde>";
            // 
            // LblFechaHasta
            // 
            this.LblFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaHasta.AutoSize = true;
            this.LblFechaHasta.Location = new System.Drawing.Point(680, 119);
            this.LblFechaHasta.Name = "LblFechaHasta";
            this.LblFechaHasta.Size = new System.Drawing.Size(110, 19);
            this.LblFechaHasta.TabIndex = 6;
            this.LblFechaHasta.Text = "<LblFechaHasta>";
            // 
            // DateTimeHasta
            // 
            this.DateTimeHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeHasta.Location = new System.Drawing.Point(680, 141);
            this.DateTimeHasta.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeHasta.Name = "DateTimeHasta";
            this.DateTimeHasta.Size = new System.Drawing.Size(114, 29);
            this.DateTimeHasta.TabIndex = 5;
            this.DateTimeHasta.Value = new System.DateTime(2017, 8, 29, 11, 58, 21, 0);
            // 
            // LblUsuario
            // 
            this.LblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(680, 177);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(88, 19);
            this.LblUsuario.TabIndex = 7;
            this.LblUsuario.Text = "<LblUsuario>";
            // 
            // TxBxUsuario
            // 
            this.TxBxUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TxBxUsuario.CustomButton.Image = null;
            this.TxBxUsuario.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxBxUsuario.CustomButton.Name = "";
            this.TxBxUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxBxUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxBxUsuario.CustomButton.TabIndex = 1;
            this.TxBxUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxBxUsuario.CustomButton.UseSelectable = true;
            this.TxBxUsuario.CustomButton.Visible = false;
            this.TxBxUsuario.Lines = new string[0];
            this.TxBxUsuario.Location = new System.Drawing.Point(680, 199);
            this.TxBxUsuario.MaxLength = 32767;
            this.TxBxUsuario.Name = "TxBxUsuario";
            this.TxBxUsuario.PasswordChar = '\0';
            this.TxBxUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxBxUsuario.SelectedText = "";
            this.TxBxUsuario.SelectionLength = 0;
            this.TxBxUsuario.SelectionStart = 0;
            this.TxBxUsuario.ShortcutsEnabled = true;
            this.TxBxUsuario.Size = new System.Drawing.Size(114, 23);
            this.TxBxUsuario.TabIndex = 8;
            this.TxBxUsuario.UseSelectable = true;
            this.TxBxUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxBxUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxbxActividad
            // 
            this.TxbxActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TxbxActividad.CustomButton.Image = null;
            this.TxbxActividad.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxbxActividad.CustomButton.Name = "";
            this.TxbxActividad.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxActividad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxActividad.CustomButton.TabIndex = 1;
            this.TxbxActividad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxActividad.CustomButton.UseSelectable = true;
            this.TxbxActividad.CustomButton.Visible = false;
            this.TxbxActividad.Lines = new string[0];
            this.TxbxActividad.Location = new System.Drawing.Point(680, 250);
            this.TxbxActividad.MaxLength = 32767;
            this.TxbxActividad.Name = "TxbxActividad";
            this.TxbxActividad.PasswordChar = '\0';
            this.TxbxActividad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxActividad.SelectedText = "";
            this.TxbxActividad.SelectionLength = 0;
            this.TxbxActividad.SelectionStart = 0;
            this.TxbxActividad.ShortcutsEnabled = true;
            this.TxbxActividad.Size = new System.Drawing.Size(114, 23);
            this.TxbxActividad.TabIndex = 10;
            this.TxbxActividad.UseSelectable = true;
            this.TxbxActividad.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxActividad.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LblActividad
            // 
            this.LblActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblActividad.AutoSize = true;
            this.LblActividad.Location = new System.Drawing.Point(680, 228);
            this.LblActividad.Name = "LblActividad";
            this.LblActividad.Size = new System.Drawing.Size(98, 19);
            this.LblActividad.TabIndex = 9;
            this.LblActividad.Text = "<LblActividad>";
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFiltrar.Location = new System.Drawing.Point(680, 288);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(114, 23);
            this.BtnFiltrar.TabIndex = 11;
            this.BtnFiltrar.Text = "<BtnFiltrar>";
            this.BtnFiltrar.UseSelectable = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.Location = new System.Drawing.Point(680, 396);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(114, 23);
            this.BtnGuardar.TabIndex = 12;
            this.BtnGuardar.Text = "<BtnGuardar>";
            this.BtnGuardar.UseSelectable = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 442);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxbxActividad);
            this.Controls.Add(this.LblActividad);
            this.Controls.Add(this.TxBxUsuario);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.LblFechaHasta);
            this.Controls.Add(this.DateTimeHasta);
            this.Controls.Add(this.LblFechaDesde);
            this.Controls.Add(this.DateTimeDesde);
            this.Controls.Add(this.metroGrid1);
            this.Name = "FrmBitacora";
            this.Text = "<FrmBitacora>";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private MetroFramework.Controls.MetroDateTime DateTimeDesde;
        private MetroFramework.Controls.MetroLabel LblFechaDesde;
        private MetroFramework.Controls.MetroLabel LblFechaHasta;
        private MetroFramework.Controls.MetroDateTime DateTimeHasta;
        private MetroFramework.Controls.MetroLabel LblUsuario;
        private MetroFramework.Controls.MetroTextBox TxBxUsuario;
        private MetroFramework.Controls.MetroTextBox TxbxActividad;
        private MetroFramework.Controls.MetroLabel LblActividad;
        private MetroFramework.Controls.MetroButton BtnFiltrar;
        private MetroFramework.Controls.MetroButton BtnGuardar;
    }
}