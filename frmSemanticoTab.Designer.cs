namespace Compilador
{
    partial class frmSemanticoTab
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
            this.tablaErroresSemantico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaErroresSemantico)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaErroresSemantico
            // 
            this.tablaErroresSemantico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaErroresSemantico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaErroresSemantico.Location = new System.Drawing.Point(0, 0);
            this.tablaErroresSemantico.Name = "tablaErroresSemantico";
            this.tablaErroresSemantico.RowHeadersWidth = 51;
            this.tablaErroresSemantico.RowTemplate.Height = 24;
            this.tablaErroresSemantico.Size = new System.Drawing.Size(800, 450);
            this.tablaErroresSemantico.TabIndex = 0;
            // 
            // frmSemanticoTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tablaErroresSemantico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSemanticoTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSemanticoTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaErroresSemantico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaErroresSemantico;
    }
}