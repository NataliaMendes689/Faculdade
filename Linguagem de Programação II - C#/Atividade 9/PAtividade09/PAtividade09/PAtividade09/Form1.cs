using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAtividade09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void atividade1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade1 FRM1 = new frmAtividade1();
            FRM1.MdiParent = this;
            FRM1.WindowState = FormWindowState.Maximized;
            FRM1.Show();
        }

        private void atividade2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade2 FRM2 = new frmAtividade2();
            FRM2.MdiParent = this;
            FRM2.WindowState = FormWindowState.Maximized;
            FRM2.Show();
        }

        private void atividade3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade3 FRM3 = new frmAtividade3();
            FRM3.MdiParent = this;
            FRM3.WindowState = FormWindowState.Maximized;
            FRM3.Show();
        }

        private void atividade4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade4 FRM4 =new frmAtividade4();
            FRM4.MdiParent = this;
            FRM4.WindowState = FormWindowState.Maximized;
            FRM4.Show();
        }

        private void atividade5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade5 FRM5 = new frmAtividade5();
            FRM5.MdiParent = this;
            FRM5.WindowState = FormWindowState.Maximized;
            FRM5.Show();
        }

        private void atividade6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade6 FRM6 = new frmAtividade6();
            FRM6.MdiParent = this;
            FRM6.WindowState = FormWindowState.Maximized;
            FRM6.Show();
        }
    }
}
