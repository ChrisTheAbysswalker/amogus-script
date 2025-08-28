namespace Compilador
{
    partial class Compilador
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
            this.archivoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirTool = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTool = new System.Windows.Forms.ToolStripMenuItem();
            this.edicionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerTool = new System.Windows.Forms.ToolStripMenuItem();
            this.rehacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarTool = new System.Windows.Forms.ToolStripMenuItem();
            this.fuenteTool = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.sintacticoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.semanticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasSintaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaSemanticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.detalleTexto = new System.Windows.Forms.ToolStripStatusLabel();
            this.Pic_NumLn = new System.Windows.Forms.PictureBox();
            this.richTexto = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstErroresSemanticos = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.toolStripProgressCompliacion = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_NumLn)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoMenu,
            this.edicionMenu,
            this.compilarMenu,
            this.tablaTokensToolStripMenuItem,
            this.tablasSintaxToolStripMenuItem,
            this.tablaSemanticoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ayudaTool});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1269, 40);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoMenu
            // 
            this.archivoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTool,
            this.abrirTool,
            this.guardarTool,
            this.cerrarTool,
            this.salirTool});
            this.archivoMenu.Name = "archivoMenu";
            this.archivoMenu.Size = new System.Drawing.Size(89, 34);
            this.archivoMenu.Text = "Archivo";
            // 
            // nuevoTool
            // 
            this.nuevoTool.Name = "nuevoTool";
            this.nuevoTool.Size = new System.Drawing.Size(161, 26);
            this.nuevoTool.Text = "Nuevo";
            this.nuevoTool.Click += new System.EventHandler(this.nuevoTool_Click);
            // 
            // abrirTool
            // 
            this.abrirTool.Name = "abrirTool";
            this.abrirTool.Size = new System.Drawing.Size(161, 26);
            this.abrirTool.Text = "Abrir";
            this.abrirTool.Click += new System.EventHandler(this.abrirTool_Click);
            // 
            // guardarTool
            // 
            this.guardarTool.Name = "guardarTool";
            this.guardarTool.Size = new System.Drawing.Size(161, 26);
            this.guardarTool.Text = "Guardar";
            this.guardarTool.Click += new System.EventHandler(this.guardarTool_Click);
            // 
            // cerrarTool
            // 
            this.cerrarTool.Name = "cerrarTool";
            this.cerrarTool.Size = new System.Drawing.Size(161, 26);
            this.cerrarTool.Text = "Cerrar";
            this.cerrarTool.Click += new System.EventHandler(this.cerrarTool_Click);
            // 
            // salirTool
            // 
            this.salirTool.Name = "salirTool";
            this.salirTool.Size = new System.Drawing.Size(161, 26);
            this.salirTool.Text = "Salir";
            this.salirTool.Click += new System.EventHandler(this.salirTool_Click);
            // 
            // edicionMenu
            // 
            this.edicionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerTool,
            this.rehacerToolStripMenuItem,
            this.copiarTool,
            this.cortarTool,
            this.pegarTool,
            this.fuenteTool});
            this.edicionMenu.Name = "edicionMenu";
            this.edicionMenu.Size = new System.Drawing.Size(88, 34);
            this.edicionMenu.Text = "Edicion";
            // 
            // deshacerTool
            // 
            this.deshacerTool.Name = "deshacerTool";
            this.deshacerTool.Size = new System.Drawing.Size(168, 26);
            this.deshacerTool.Text = "Deshacer";
            this.deshacerTool.Click += new System.EventHandler(this.deshacerTool_Click);
            // 
            // rehacerToolStripMenuItem
            // 
            this.rehacerToolStripMenuItem.Name = "rehacerToolStripMenuItem";
            this.rehacerToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.rehacerToolStripMenuItem.Text = "Rehacer";
            this.rehacerToolStripMenuItem.Click += new System.EventHandler(this.rehacerToolStripMenuItem_Click);
            // 
            // copiarTool
            // 
            this.copiarTool.Name = "copiarTool";
            this.copiarTool.Size = new System.Drawing.Size(168, 26);
            this.copiarTool.Text = "Copiar";
            this.copiarTool.Click += new System.EventHandler(this.copiarTool_Click);
            // 
            // cortarTool
            // 
            this.cortarTool.Name = "cortarTool";
            this.cortarTool.Size = new System.Drawing.Size(168, 26);
            this.cortarTool.Text = "Cortar";
            this.cortarTool.Click += new System.EventHandler(this.cortarTool_Click);
            // 
            // pegarTool
            // 
            this.pegarTool.Name = "pegarTool";
            this.pegarTool.Size = new System.Drawing.Size(168, 26);
            this.pegarTool.Text = "Pegar";
            this.pegarTool.Click += new System.EventHandler(this.pegarTool_Click);
            // 
            // fuenteTool
            // 
            this.fuenteTool.Name = "fuenteTool";
            this.fuenteTool.Size = new System.Drawing.Size(168, 26);
            this.fuenteTool.Text = "Fuente";
            this.fuenteTool.Click += new System.EventHandler(this.fuenteTool_Click);
            // 
            // compilarMenu
            // 
            this.compilarMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicoTool,
            this.sintacticoTool,
            this.semanticoToolStripMenuItem});
            this.compilarMenu.Name = "compilarMenu";
            this.compilarMenu.Size = new System.Drawing.Size(98, 34);
            this.compilarMenu.Text = "Compilar";
            // 
            // lexicoTool
            // 
            this.lexicoTool.Name = "lexicoTool";
            this.lexicoTool.Size = new System.Drawing.Size(177, 26);
            this.lexicoTool.Text = "Lexico";
            this.lexicoTool.Click += new System.EventHandler(this.lexicoTool_Click);
            // 
            // sintacticoTool
            // 
            this.sintacticoTool.Name = "sintacticoTool";
            this.sintacticoTool.Size = new System.Drawing.Size(177, 26);
            this.sintacticoTool.Text = "Sintactico";
            this.sintacticoTool.Click += new System.EventHandler(this.sintacticoTool_Click);
            // 
            // semanticoToolStripMenuItem
            // 
            this.semanticoToolStripMenuItem.Name = "semanticoToolStripMenuItem";
            this.semanticoToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.semanticoToolStripMenuItem.Text = "Semantico";
            this.semanticoToolStripMenuItem.Click += new System.EventHandler(this.semanticoToolStripMenuItem_Click);
            // 
            // tablaTokensToolStripMenuItem
            // 
            this.tablaTokensToolStripMenuItem.Name = "tablaTokensToolStripMenuItem";
            this.tablaTokensToolStripMenuItem.Size = new System.Drawing.Size(113, 34);
            this.tablaTokensToolStripMenuItem.Text = "Tablas Lex";
            this.tablaTokensToolStripMenuItem.Click += new System.EventHandler(this.tablaTokensToolStripMenuItem_Click);
            // 
            // tablasSintaxToolStripMenuItem
            // 
            this.tablasSintaxToolStripMenuItem.Name = "tablasSintaxToolStripMenuItem";
            this.tablasSintaxToolStripMenuItem.Size = new System.Drawing.Size(134, 34);
            this.tablasSintaxToolStripMenuItem.Text = "Tablas Sintax";
            this.tablasSintaxToolStripMenuItem.Click += new System.EventHandler(this.tablasSintaxToolStripMenuItem_Click);
            // 
            // tablaSemanticoToolStripMenuItem
            // 
            this.tablaSemanticoToolStripMenuItem.Name = "tablaSemanticoToolStripMenuItem";
            this.tablaSemanticoToolStripMenuItem.Size = new System.Drawing.Size(157, 34);
            this.tablaSemanticoToolStripMenuItem.Text = "Tabla Semantico";
            this.tablaSemanticoToolStripMenuItem.Click += new System.EventHandler(this.tablaSemanticoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Lime;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 34);
            this.toolStripMenuItem1.Text = "▶ Start";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ayudaTool
            // 
            this.ayudaTool.Name = "ayudaTool";
            this.ayudaTool.Size = new System.Drawing.Size(32, 34);
            this.ayudaTool.Text = "?";
            this.ayudaTool.Click += new System.EventHandler(this.ayudaTool_Click);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalleTexto,
            this.toolStripStatusLabel1,
            this.toolStripProgressCompliacion});
            this.status.Location = new System.Drawing.Point(0, 656);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1269, 26);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // detalleTexto
            // 
            this.detalleTexto.BackColor = System.Drawing.Color.White;
            this.detalleTexto.ForeColor = System.Drawing.Color.Black;
            this.detalleTexto.Name = "detalleTexto";
            this.detalleTexto.Size = new System.Drawing.Size(80, 20);
            this.detalleTexto.Text = "Ln: 0 Col: 0";
            // 
            // Pic_NumLn
            // 
            this.Pic_NumLn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pic_NumLn.Location = new System.Drawing.Point(3, 3);
            this.Pic_NumLn.Name = "Pic_NumLn";
            this.Pic_NumLn.Size = new System.Drawing.Size(39, 449);
            this.Pic_NumLn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_NumLn.TabIndex = 7;
            this.Pic_NumLn.TabStop = false;
            this.Pic_NumLn.Paint += new System.Windows.Forms.PaintEventHandler(this.Pic_NumLn_Paint);
            // 
            // richTexto
            // 
            this.richTexto.BackColor = System.Drawing.Color.Black;
            this.richTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTexto.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(201)))), ((int)(((byte)(32)))));
            this.richTexto.Location = new System.Drawing.Point(49, 4);
            this.richTexto.Margin = new System.Windows.Forms.Padding(4);
            this.richTexto.Name = "richTexto";
            this.richTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTexto.Size = new System.Drawing.Size(1216, 447);
            this.richTexto.TabIndex = 4;
            this.richTexto.Text = "\n";
            this.richTexto.WordWrap = false;
            this.richTexto.HScroll += new System.EventHandler(this.richTexto_HScroll);
            this.richTexto.VScroll += new System.EventHandler(this.richTexto_VScroll);
            this.richTexto.TextChanged += new System.EventHandler(this.richTexto_TextChanged);
            this.richTexto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTexto_KeyUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.556993F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.44301F));
            this.tableLayoutPanel1.Controls.Add(this.richTexto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Pic_NumLn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.95834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.04167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 616);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(48, 458);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1218, 155);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstErrores);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1210, 120);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Error List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstErrores
            // 
            this.lstErrores.BackColor = System.Drawing.Color.Black;
            this.lstErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErrores.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstErrores.ForeColor = System.Drawing.Color.Red;
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.ItemHeight = 27;
            this.lstErrores.Location = new System.Drawing.Point(3, 3);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(1204, 114);
            this.lstErrores.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstErroresSemanticos);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1210, 120);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Error List Sem";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstErroresSemanticos
            // 
            this.lstErroresSemanticos.BackColor = System.Drawing.Color.Black;
            this.lstErroresSemanticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErroresSemanticos.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstErroresSemanticos.ForeColor = System.Drawing.Color.Red;
            this.lstErroresSemanticos.FormattingEnabled = true;
            this.lstErroresSemanticos.ItemHeight = 27;
            this.lstErroresSemanticos.Location = new System.Drawing.Point(3, 3);
            this.lstErroresSemanticos.Name = "lstErroresSemanticos";
            this.lstErroresSemanticos.Size = new System.Drawing.Size(1204, 114);
            this.lstErroresSemanticos.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstOutput);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1210, 120);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Terminal";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstOutput
            // 
            this.lstOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.lstOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOutput.ForeColor = System.Drawing.Color.LightGray;
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 23;
            this.lstOutput.Location = new System.Drawing.Point(3, 3);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(1204, 114);
            this.lstOutput.TabIndex = 1;
            // 
            // toolStripProgressCompliacion
            // 
            this.toolStripProgressCompliacion.BackColor = System.Drawing.Color.Lime;
            this.toolStripProgressCompliacion.Name = "toolStripProgressCompliacion";
            this.toolStripProgressCompliacion.Size = new System.Drawing.Size(1000, 18);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(166, 20);
            this.toolStripStatusLabel1.Text = "Estado de Compilacion:";
            // 
            // Compilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1269, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Compilador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Compilador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Compilador_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Compilador_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_NumLn)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoMenu;
        private System.Windows.Forms.ToolStripMenuItem nuevoTool;
        private System.Windows.Forms.ToolStripMenuItem abrirTool;
        private System.Windows.Forms.ToolStripMenuItem guardarTool;
        private System.Windows.Forms.ToolStripMenuItem cerrarTool;
        private System.Windows.Forms.ToolStripMenuItem salirTool;
        private System.Windows.Forms.ToolStripMenuItem edicionMenu;
        private System.Windows.Forms.ToolStripMenuItem deshacerTool;
        private System.Windows.Forms.ToolStripMenuItem copiarTool;
        private System.Windows.Forms.ToolStripMenuItem cortarTool;
        private System.Windows.Forms.ToolStripMenuItem pegarTool;
        private System.Windows.Forms.ToolStripMenuItem fuenteTool;
        private System.Windows.Forms.ToolStripMenuItem compilarMenu;
        private System.Windows.Forms.ToolStripMenuItem lexicoTool;
        private System.Windows.Forms.ToolStripMenuItem sintacticoTool;
        private System.Windows.Forms.ToolStripMenuItem ayudaTool;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripMenuItem rehacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel detalleTexto;
        private System.Windows.Forms.ToolStripMenuItem tablaTokensToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tablasSintaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semanticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaSemanticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox Pic_NumLn;
        private System.Windows.Forms.RichTextBox richTexto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstErroresSemanticos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressCompliacion;
    }
}

