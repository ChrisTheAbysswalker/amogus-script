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
    public partial class frmTablas : Form
    {
        public frmTablas()
        {
            InitializeComponent();
        }

		private void frmTablas_Load(object sender, EventArgs e)
		{
            LlenarTablas();
		}
        private void LlenarTablas()
        {
            dtgErrores.DataSource = Compilador.static_errores;
            dtgTokens.DataSource = Compilador.static_tokens;
        }
	}
}
