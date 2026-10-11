using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAtividade8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void atividade1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade1 FRM1 = new frmAtividade1();
            FRM1.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM1.WindowState = FormWindowState.Maximized; // deixa maximizada tela dentro do form principal
            FRM1.Show();
        }

        private void atividade2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade2 FRM2 = new frmAtividade2();
            FRM2.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM2.WindowState = FormWindowState.Maximized; // deixa maximizada tela dentro do form principal
            FRM2.Show();
        }

        private void atividade3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade3 FRM3 = new frmAtividade3();
            FRM3.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM3.WindowState = FormWindowState.Maximized; // deixa maximizada tela dentro do form principal
            FRM3.Show();
        }

        private void atividade4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtividade4 FRM4= new frmAtividade4();
            FRM4.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM4.WindowState = FormWindowState.Maximized; // deixa maximizada tela dentro do form principal
            FRM4.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
