using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PtesteMetodos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionou o copiar");
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecionou o colar");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exercício2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExercicio2 FRM2 = new frmExercicio2();
            FRM2.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM2.WindowState = FormWindowState.Maximized; // deixa maximizada tela dentro do form principal
            FRM2.Show();
        }

        private void exercício3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExercicio3 FRM3 = new frmExercicio3();
            FRM3.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM3.WindowState = FormWindowState.Maximized; 
            FRM3.Show();
        }

        private void exercício4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExercicio4 FRM4 = new frmExercicio4();
            FRM4.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM4.WindowState = FormWindowState.Maximized;
            FRM4.Show();
        }

        private void exercício5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExercicio5 FRM5 = new frmExercicio5();
            FRM5.MdiParent = this; //para deixar o formulário preso dentro do form principal
            FRM5.WindowState = FormWindowState.Maximized;
            FRM5.Show();
        }
    }
}
