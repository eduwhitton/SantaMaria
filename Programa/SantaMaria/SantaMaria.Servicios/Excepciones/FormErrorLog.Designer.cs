namespace SantaMaria.Servicios.Excepciones
{
    partial class FrmErrorLog
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
            this.BtnFiltrar = new MetroFramework.Controls.MetroButton();
            this.TxbxExcepcion = new MetroFramework.Controls.MetroTextBox();
            this.LblExcepcion = new MetroFramework.Controls.MetroLabel();
            this.TxBxMensaje = new MetroFramework.Controls.MetroTextBox();
            this.LblMensaje = new MetroFramework.Controls.MetroLabel();
            this.LblFechaHasta = new MetroFramework.Controls.MetroLabel();
            this.DateTimeHasta = new MetroFramework.Controls.MetroDateTime();
            this.LblFechaDesde = new MetroFramework.Controls.MetroLabel();
            this.DateTimeDesde = new MetroFramework.Controls.MetroDateTime();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.BtnGuardar = new MetroFramework.Controls.MetroButton();
            this.LogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFiltrar.Location = new System.Drawing.Point(647, 291);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(114, 23);
            this.BtnFiltrar.TabIndex = 21;
            this.BtnFiltrar.Text = "<BtnFiltrar>";
            this.BtnFiltrar.UseSelectable = true;
            // 
            // TxbxExcepcion
            // 
            this.TxbxExcepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TxbxExcepcion.CustomButton.Image = null;
            this.TxbxExcepcion.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxbxExcepcion.CustomButton.Name = "";
            this.TxbxExcepcion.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxbxExcepcion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxbxExcepcion.CustomButton.TabIndex = 1;
            this.TxbxExcepcion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxbxExcepcion.CustomButton.UseSelectable = true;
            this.TxbxExcepcion.CustomButton.Visible = false;
            this.TxbxExcepcion.Lines = new string[0];
            this.TxbxExcepcion.Location = new System.Drawing.Point(647, 253);
            this.TxbxExcepcion.MaxLength = 32767;
            this.TxbxExcepcion.Name = "TxbxExcepcion";
            this.TxbxExcepcion.PasswordChar = '\0';
            this.TxbxExcepcion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxbxExcepcion.SelectedText = "";
            this.TxbxExcepcion.SelectionLength = 0;
            this.TxbxExcepcion.SelectionStart = 0;
            this.TxbxExcepcion.ShortcutsEnabled = true;
            this.TxbxExcepcion.Size = new System.Drawing.Size(114, 23);
            this.TxbxExcepcion.TabIndex = 20;
            this.TxbxExcepcion.UseSelectable = true;
            this.TxbxExcepcion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxbxExcepcion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LblExcepcion
            // 
            this.LblExcepcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblExcepcion.AutoSize = true;
            this.LblExcepcion.Location = new System.Drawing.Point(647, 231);
            this.LblExcepcion.Name = "LblExcepcion";
            this.LblExcepcion.Size = new System.Drawing.Size(102, 19);
            this.LblExcepcion.TabIndex = 19;
            this.LblExcepcion.Text = "<LblExcepcion>";
            // 
            // TxBxMensaje
            // 
            this.TxBxMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TxBxMensaje.CustomButton.Image = null;
            this.TxBxMensaje.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxBxMensaje.CustomButton.Name = "";
            this.TxBxMensaje.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxBxMensaje.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxBxMensaje.CustomButton.TabIndex = 1;
            this.TxBxMensaje.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxBxMensaje.CustomButton.UseSelectable = true;
            this.TxBxMensaje.CustomButton.Visible = false;
            this.TxBxMensaje.Lines = new string[0];
            this.TxBxMensaje.Location = new System.Drawing.Point(647, 202);
            this.TxBxMensaje.MaxLength = 32767;
            this.TxBxMensaje.Name = "TxBxMensaje";
            this.TxBxMensaje.PasswordChar = '\0';
            this.TxBxMensaje.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxBxMensaje.SelectedText = "";
            this.TxBxMensaje.SelectionLength = 0;
            this.TxBxMensaje.SelectionStart = 0;
            this.TxBxMensaje.ShortcutsEnabled = true;
            this.TxBxMensaje.Size = new System.Drawing.Size(114, 23);
            this.TxBxMensaje.TabIndex = 18;
            this.TxBxMensaje.UseSelectable = true;
            this.TxBxMensaje.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxBxMensaje.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMensaje.AutoSize = true;
            this.LblMensaje.Location = new System.Drawing.Point(647, 180);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(92, 19);
            this.LblMensaje.TabIndex = 17;
            this.LblMensaje.Text = "<LblMensaje>";
            // 
            // LblFechaHasta
            // 
            this.LblFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaHasta.AutoSize = true;
            this.LblFechaHasta.Location = new System.Drawing.Point(647, 122);
            this.LblFechaHasta.Name = "LblFechaHasta";
            this.LblFechaHasta.Size = new System.Drawing.Size(110, 19);
            this.LblFechaHasta.TabIndex = 16;
            this.LblFechaHasta.Text = "<LblFechaHasta>";
            // 
            // DateTimeHasta
            // 
            this.DateTimeHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeHasta.Location = new System.Drawing.Point(647, 144);
            this.DateTimeHasta.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeHasta.Name = "DateTimeHasta";
            this.DateTimeHasta.Size = new System.Drawing.Size(114, 29);
            this.DateTimeHasta.TabIndex = 15;
            this.DateTimeHasta.Value = new System.DateTime(2017, 8, 29, 11, 58, 21, 0);
            // 
            // LblFechaDesde
            // 
            this.LblFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaDesde.AutoSize = true;
            this.LblFechaDesde.Location = new System.Drawing.Point(647, 63);
            this.LblFechaDesde.Name = "LblFechaDesde";
            this.LblFechaDesde.Size = new System.Drawing.Size(114, 19);
            this.LblFechaDesde.TabIndex = 14;
            this.LblFechaDesde.Text = "<LblFechaDesde>";
            // 
            // DateTimeDesde
            // 
            this.DateTimeDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeDesde.Location = new System.Drawing.Point(647, 85);
            this.DateTimeDesde.MinimumSize = new System.Drawing.Size(0, 29);
            this.DateTimeDesde.Name = "DateTimeDesde";
            this.DateTimeDesde.Size = new System.Drawing.Size(114, 29);
            this.DateTimeDesde.TabIndex = 13;
            this.DateTimeDesde.Value = new System.DateTime(2016, 7, 9, 0, 0, 0, 0);
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
            this.Message,
            this.Exception,
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
            this.metroGrid1.Location = new System.Drawing.Point(23, 63);
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
            this.metroGrid1.Size = new System.Drawing.Size(618, 308);
            this.metroGrid1.TabIndex = 12;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.Location = new System.Drawing.Point(647, 348);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(114, 23);
            this.BtnGuardar.TabIndex = 22;
            this.BtnGuardar.Text = "<BtnGuardar>";
            this.BtnGuardar.UseSelectable = true;
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
            // Message
            // 
            this.Message.HeaderText = "Mensaje";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // Exception
            // 
            this.Exception.HeaderText = "Excepcion";
            this.Exception.Name = "Exception";
            this.Exception.ReadOnly = true;
            // 
            // IpAddress
            // 
            this.IpAddress.HeaderText = "Direccion IP";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            // 
            // FrmErrorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 395);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.TxbxExcepcion);
            this.Controls.Add(this.LblExcepcion);
            this.Controls.Add(this.TxBxMensaje);
            this.Controls.Add(this.LblMensaje);
            this.Controls.Add(this.LblFechaHasta);
            this.Controls.Add(this.DateTimeHasta);
            this.Controls.Add(this.LblFechaDesde);
            this.Controls.Add(this.DateTimeDesde);
            this.Controls.Add(this.metroGrid1);
            this.Name = "FrmErrorLog";
            this.Text = "<FrmErrorLog>";
            this.Load += new System.EventHandler(this.FormErrorLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton BtnFiltrar;
        private MetroFramework.Controls.MetroTextBox TxbxExcepcion;
        private MetroFramework.Controls.MetroLabel LblExcepcion;
        private MetroFramework.Controls.MetroTextBox TxBxMensaje;
        private MetroFramework.Controls.MetroLabel LblMensaje;
        private MetroFramework.Controls.MetroLabel LblFechaHasta;
        private MetroFramework.Controls.MetroDateTime DateTimeHasta;
        private MetroFramework.Controls.MetroLabel LblFechaDesde;
        private MetroFramework.Controls.MetroDateTime DateTimeDesde;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroButton BtnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exception;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
    }
}