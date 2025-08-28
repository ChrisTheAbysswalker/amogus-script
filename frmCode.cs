using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class frmCode : Form
    {
        public frmCode()
        {
            InitializeComponent();
        }

        private void frmCode_Load(object sender, EventArgs e)
        {
            richCodigo.Text = Compilador.assembly_Code;
        }
        private void btnGuardarCode_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Assembly (*.asm)|*.asm|Todos los Archivos (*.*)|*.*";
            if (guardar.ShowDialog() == DialogResult.OK)
                richCodigo.SaveFile(guardar.FileName, RichTextBoxStreamType.PlainText);
        }
    }
}
