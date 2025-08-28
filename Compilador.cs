using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Compilador
{
    public partial class Compilador : Form
    {
        public static DataTable static_tokens;
        public static DataTable static_errores;
        public Compilador()
        {
            InitializeComponent();
            detalleTexto.Text = "Ln: " + "1" + " Col: " + "1";
        }
        #region Controles
        /*Metodo para crear un nuevo documento*/
        private void nuevoTool_Click(object sender, EventArgs e)
        {
            if (richTexto.Visible == false)
            {
                richTexto.Text = "";
                richTexto.Visible = true;
            }
            richTexto.Focus();
        }
        /*Metodo para abrir un documento ya existente*/
        private void abrirTool_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = @"C:\Users\alexZ\Documents\Escuela\Lenguajes y Automatas\";
			string texto = "";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                texto = File.ReadAllText(abrir.FileName);
                richTexto.Text = texto;
            }
            richTexto.Visible = true;
        }
        /*Metodo para guardar un documento*/
        private void guardarTool_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog(); 
            guardar.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*";
            if (guardar.ShowDialog() == DialogResult.OK)
                richTexto.SaveFile(guardar.FileName, RichTextBoxStreamType.PlainText);
        }
        /*Metodo para cerrar el documento actual*/
        private void cerrarTool_Click(object sender, EventArgs e)
        {
            if (richTexto.Text != "")
            {
                switch (MessageBox.Show("Desea Guardar el Proyecto Antes de Cerrar?", "Hay un Proyecto en Desarrollo", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Yes:
                        guardarTool_Click(sender, e);
                        richTexto.Text = "";
                        richTexto.Visible = false;
                        break;
                    case DialogResult.No:
                        richTexto.Text = "";
                        richTexto.Visible = false;
                        break;
                }
            }
            else 
            {
                richTexto.Text = "";
                richTexto.Visible = false;
            }
        }
        /*Metodo para salir de la aplicacion*/
        private void salirTool_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*Metodo para deshacer ultimo texto*/
        private void deshacerTool_Click(object sender, EventArgs e)
        {
            richTexto.Undo();
        }
        /*Metodo para rehacer ultimo texto*/
        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTexto.Redo();
        }
        /*Metodo para copiar ultimo texto*/
        private void copiarTool_Click(object sender, EventArgs e)
        {
            richTexto.SelectAll();
            richTexto.Copy();
        }
        /*Metodo para cortar ultimo texto*/
        private void cortarTool_Click(object sender, EventArgs e)
        {
            richTexto.Select();
            richTexto.Cut();
        }
        /*Metodo para pegar ultimo texto*/
        private void pegarTool_Click(object sender, EventArgs e)
        {
            richTexto.Paste();
        }
        /*Metodo para cambiar fuente del texto*/
        private void fuenteTool_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            var fuente = font.ShowDialog();
            if (fuente == DialogResult.OK)
                richTexto.Font = font.Font;
        }
        /*Metodo para mostrar datos del programa*/
        private void ayudaTool_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Christian Alejandro Zamora Cervantes \nLenguajes y Automatas 1 \nVersion 1.0");
        }
        /*Metodo para ejecutar acciones con el teclado*/
        private void Compilador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                nuevoTool_Click(sender, e);
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                guardarTool_Click(sender, e);
            else if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
                richTexto.Undo();
            else if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
                richTexto.Redo();
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
                lexicoTool_Click(sender, e);
            else if (e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
                tablaTokensToolStripMenuItem_Click(sender, e);
        }
		private void tablaTokensToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmTablas tablasLex = new frmTablas();
            tablasLex.Show();
		}

        private void richTexto_TextChanged(object sender, EventArgs e)
        {
            Pic_NumLn.Refresh();
            if (richTexto.Text.Length > 0)
            {
                try
                {
                    sintacticoTool_Click(sender, e);
                    //semanticoToolStripMenuItem_Click(sender, e);
                    lstErrores.DataSource = static_err_sintax;
                    //lstErroresSemanticos.DataSource = static_errSemantico;
                }
                catch (Exception)
                {
                }
            }
            else
                lstErrores.DataSource = null;
        }

        private void richTexto_KeyUp(object sender, KeyEventArgs e)
        {
            int cursorPosition = richTexto.SelectionStart;
            int lineNumber = richTexto.GetLineFromCharIndex(cursorPosition);
            int columnIndex = cursorPosition - richTexto.GetFirstCharIndexFromLine(lineNumber);

            detalleTexto.Text = $"Ln {lineNumber + 1}, Col {columnIndex + 1}";
        }

        private void Pic_NumLn_Paint(object sender, PaintEventArgs e)
        {
            int caracter = 0;
            int altura = richTexto.GetPositionFromCharIndex(0).Y;
            if (richTexto.Lines.Count() > 0)
            {
                for (int i = 0; i < richTexto.Lines.Length; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), richTexto.Font, Brushes.White, Pic_NumLn.Width - (e.Graphics.MeasureString((i + 1).ToString(),
                        richTexto.Font).Width + 10), altura);
                    caracter += richTexto.Lines[i].Length + 1;
                    altura = richTexto.GetPositionFromCharIndex(caracter).Y;
                }
            }
            else
                e.Graphics.DrawString("1", richTexto.Font, Brushes.White, Pic_NumLn.Width - (e.Graphics.MeasureString("1", richTexto.Font).Width + 10), altura);
        }

        private async void Compilador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\b')
            {
                await Task.Run(() =>
                {
                    Pic_NumLn.Invoke((MethodInvoker)(() => Pic_NumLn.Refresh()));
                });
            }

        }

        private void richTexto_HScroll(object sender, EventArgs e)
        {
            Pic_NumLn.Refresh();
        }

        private void richTexto_VScroll(object sender, EventArgs e)
        {
            Pic_NumLn.Refresh();
        }

        private void Compilador_Load(object sender, EventArgs e)
        {
            richTexto.Text = "";
        }

        #endregion
        #region lexico
        private void lexicoTool_Click(object sender, EventArgs e)
        {
            Lexico objLex = new Lexico();
            objLex.AnalisisLex(richTexto.Text);
            static_tokens = objLex.TablaTokens();
            static_errores = objLex.TablaErrores();
            static_err_lex = objLex.GetErrLex();
            //tablaTokensToolStripMenuItem_Click(sender, e);
        }
        #endregion
        #region sintactico
        static List<string> lista_tokens = new List<string>();
        static List<string> lista_Palabras = new List<string>();
        public static List<string> static_err_sintax = new List<string>();
        public static List<string> static_err_lex = new List<string>();
		private void sintacticoTool_Click(object sender, EventArgs e)
		{

            lstErrores.ForeColor = Color.Red;
            lexicoTool_Click(sender, e);
            int ln = richTexto.GetLineFromCharIndex(richTexto.SelectionStart) + 1;
            Sintactico sintax = new Sintactico();
            sintax.GetTokens(ref static_tokens);
            sintax.AnalisisSintactico();
            static_err_sintax = sintax.GetErrores();
            lista_tokens = sintax.GetTokens();
            lista_Palabras = sintax.GetPalabras();
            //tablasSintaxToolStripMenuItem_Click(sender, e);
		}
		private void tablasSintaxToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmTablasSintax sintax = new frmTablasSintax();
            sintax.Show();
		}
        #endregion
        #region semantico
        public static DataTable static_variablesSemantico;
        static List<string> static_errSemantico = new List<string>();
        string str = "";

        private void semanticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstErrores.DataSource = null;
            lstErrores.ForeColor = Color.Yellow;
            //sintacticoTool_Click(sender, e);
            Semantico sem = new Semantico(static_tokens);
            sem.EvaluarVariables(ref str);
            var tupla = sem.TuplaListas();
            variable = tupla.Item1;
            tokens_codigo = tupla.Item2;
            contenido_codigo = tupla.Item3;
            lineas_codigo = tupla.Item4;
            tokens_variable = tupla.Item5;
            contenido_variable = tupla.Item6;
            lstErrores.DataSource = sem.getErroresSem();
            static_variablesSemantico = sem.getDatatable();
        }


        private void tablaSemanticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSemanticoTab frm = new frmSemanticoTab();
            frm.Show();
        }
        #endregion
        //Codigo Intermedio
        #region CodigoIntermedio
        private bool HayErrores()
        {
            analisis_Lexico = static_errores == null ? true : false;
            analisis_Sintactico = !static_err_sintax.Any() ? true : false;
            analisis_Semantico = !static_errSemantico.Any() ? true : false;
            return analisis_Lexico && analisis_Semantico && analisis_Sintactico;
        }

        public static string assembly_Code = "";
        List<string> tokens_variable = new List<string>();
        List<string> variable = new List<string>();
        List<string> contenido_variable = new List<string>();
        List<string> tokens_codigo = new List<string>();
        List<string> contenido_codigo = new List<string>();
        List<string> lineas_codigo = new List<string>();
        bool analisis_Lexico, analisis_Sintactico, analisis_Semantico;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripProgressCompliacion.Value = 0;
                semanticoToolStripMenuItem_Click(sender, e);
                frmCode frm = new frmCode();
                if (str == "")
                {
                    Asm assembly = new Asm(variable, tokens_codigo, contenido_codigo, lineas_codigo, tokens_variable, contenido_variable);
                    assembly_Code = assembly.Codigo_ASM();
                    for (int i = 0; i < 10; i++)
                    {
                        toolStripProgressCompliacion.Value += 10;
                        Thread.Sleep(50);
                    }
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(str, "Error de Compilacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            str = "";
        }
        #endregion

    }
}
