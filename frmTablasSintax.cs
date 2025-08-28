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
	public partial class frmTablasSintax : Form
	{
		public frmTablasSintax()
		{
			InitializeComponent();
		}

		private void frmTablasSintax_Load(object sender, EventArgs e)
		{
			listBox1.DataSource = Compilador.static_err_sintax;
		}

		private void frmTablasSintax_FormClosing(object sender, FormClosingEventArgs e)
		{
			listBox1.DataSource = null;
		}
	}
}
