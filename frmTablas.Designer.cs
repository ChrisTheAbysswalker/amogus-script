namespace Compilador
{
    partial class frmTablas
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
			this.dtgTokens = new System.Windows.Forms.DataGridView();
			this.dtgErrores = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgTokens
			// 
			this.dtgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgTokens.Location = new System.Drawing.Point(12, 12);
			this.dtgTokens.Name = "dtgTokens";
			this.dtgTokens.RowHeadersWidth = 51;
			this.dtgTokens.RowTemplate.Height = 24;
			this.dtgTokens.Size = new System.Drawing.Size(436, 501);
			this.dtgTokens.TabIndex = 0;
			// 
			// dtgErrores
			// 
			this.dtgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgErrores.Location = new System.Drawing.Point(454, 12);
			this.dtgErrores.Name = "dtgErrores";
			this.dtgErrores.RowHeadersWidth = 51;
			this.dtgErrores.Size = new System.Drawing.Size(436, 501);
			this.dtgErrores.TabIndex = 1;
			// 
			// frmTablas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(902, 525);
			this.Controls.Add(this.dtgErrores);
			this.Controls.Add(this.dtgTokens);
			this.Name = "frmTablas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Analisis Lexico";
			this.Load += new System.EventHandler(this.frmTablas_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgErrores)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.DataGridView dtgTokens;
		private System.Windows.Forms.DataGridView dtgErrores;
	}
}