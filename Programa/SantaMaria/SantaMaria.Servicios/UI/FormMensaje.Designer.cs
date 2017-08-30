namespace SantaMaria.Servicios.UI
{
    partial class FormMensaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMensaje));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnOk = new MetroFramework.Controls.MetroButton();
            this.LblMensaje = new MetroFramework.Controls.MetroLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.BtnCancelar = new MetroFramework.Controls.MetroButton();
            this.BtnNo = new MetroFramework.Controls.MetroButton();
            this.BtnSi = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(221, 104);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "<BtnOk>";
            this.BtnOk.UseSelectable = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblMensaje
            // 
            this.LblMensaje.AutoSize = true;
            this.LblMensaje.Location = new System.Drawing.Point(61, 70);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Size = new System.Drawing.Size(92, 19);
            this.LblMensaje.TabIndex = 4;
            this.LblMensaje.Text = "Texto de error";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(302, 104);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "<BtnCancelar>";
            this.BtnCancelar.UseSelectable = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(104, 104);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(75, 23);
            this.BtnNo.TabIndex = 7;
            this.BtnNo.Text = "<BtnNo>";
            this.BtnNo.UseSelectable = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // BtnSi
            // 
            this.BtnSi.Location = new System.Drawing.Point(23, 104);
            this.BtnSi.Name = "BtnSi";
            this.BtnSi.Size = new System.Drawing.Size(75, 23);
            this.BtnSi.TabIndex = 6;
            this.BtnSi.Text = "<BtnSi>";
            this.BtnSi.UseSelectable = true;
            this.BtnSi.Click += new System.EventHandler(this.BtnSi_Click);
            // 
            // FormMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnSi);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.LblMensaje);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormMensaje";
            this.Text = "<FrmError>";
            this.Load += new System.EventHandler(this.FormError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton BtnOk;
        private MetroFramework.Controls.MetroLabel LblMensaje;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private MetroFramework.Controls.MetroButton BtnCancelar;
        private MetroFramework.Controls.MetroButton BtnNo;
        private MetroFramework.Controls.MetroButton BtnSi;
    }
}