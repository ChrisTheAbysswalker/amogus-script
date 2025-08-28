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
    public partial class frmSemanticoTab : Form
    {
        public frmSemanticoTab()
        {
            InitializeComponent();
        }

        private void frmSemanticoTab_Load(object sender, EventArgs e)
        {
            tablaErroresSemantico.DataSource = Compilador.static_variablesSemantico;
        }
    }
}
