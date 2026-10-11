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
    public partial class frmExercicio2 : Form
    {
        public frmExercicio2()
        {
            InitializeComponent();
        }

        private void btnVerifica_Click(object sender, EventArgs e)
        {
            if(String.Compare(txtPalavra1.Text, txtPalavra2.Text, true)==0)
                MessageBox.Show("São iguais");
            else
                MessageBox.Show("São diferentes");
        }

        private void btnInsere1_Click(object sender, EventArgs e)
        {
            int metade = txtPalavra2.Text.Length / 2;
            txtPalavra2.Text = txtPalavra2.Text.Substring(0, metade) +
                txtPalavra1.Text + txtPalavra2.Text.Substring(metade, txtPalavra2.Text.Length - metade);
                //Substring=onde eu começo e quantos caracteres eu tenho que pegar
        }

        private void btnInsere2_Click(object sender, EventArgs e)
        {
            int metade = txtPalavra1.Text.Length / 2;
            txtPalavra2.Text = txtPalavra1.Text.Insert(metade, "**");
        }
    }
}
