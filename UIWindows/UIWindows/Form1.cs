using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja.UIWindows
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente obj = new frmCliente();
            obj.TopLevel = false;
            obj.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //obj.Size = this.Size;
            obj.BringToFront();
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.MdiParent = this;
            obj.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
