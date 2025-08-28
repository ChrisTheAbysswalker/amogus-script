namespace Compilador
{
    partial class frmCode
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
            this.richCodigo = new System.Windows.Forms.RichTextBox();
            this.btnGuardarCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richCodigo
            // 
            this.richCodigo.BackColor = System.Drawing.Color.Black;
            this.richCodigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.richCodigo.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(201)))), ((int)(((byte)(32)))));
            this.richCodigo.Location = new System.Drawing.Point(0, 0);
            this.richCodigo.Name = "richCodigo";
            this.richCodigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richCodigo.Size = new System.Drawing.Size(590, 702);
            this.richCodigo.TabIndex = 0;
            this.richCodigo.Text = "";
            // 
            // btnGuardarCode
            // 
            this.btnGuardarCode.BackColor = System.Drawing.Color.Black;
            this.btnGuardarCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardarCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarCode.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCode.ForeColor = System.Drawing.Color.Lime;
            this.btnGuardarCode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarCode.Location = new System.Drawing.Point(0, 708);
            this.btnGuardarCode.Name = "btnGuardarCode";
            this.btnGuardarCode.Size = new System.Drawing.Size(590, 51);
            this.btnGuardarCode.TabIndex = 1;
            this.btnGuardarCode.Text = "Guardar Codigo";
            this.btnGuardarCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarCode.UseVisualStyleBackColor = false;
            this.btnGuardarCode.Click += new System.EventHandler(this.btnGuardarCode_Click);
            // 
            // frmCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(590, 759);
            this.Controls.Add(this.btnGuardarCode);
            this.Controls.Add(this.richCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codigo Ensamblador";
            this.Load += new System.EventHandler(this.frmCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richCodigo;
        private System.Windows.Forms.Button btnGuardarCode;
    }
}