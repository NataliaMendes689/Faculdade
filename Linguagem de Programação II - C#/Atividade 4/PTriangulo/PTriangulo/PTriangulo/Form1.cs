using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTriangulo
{
    public partial class Form1 : Form
    {
        double ladoA, ladoB, ladoC;        

        private void txtLadoB_Validated(object sender, EventArgs e)
        {
            if(!(double.TryParse(txtLadoB.Text, out ladoB)))
            {
                MessageBox.Show("Dear, informe um número!");
                txtLadoB.Focus();
            }
        }

        private void txtLadoC_TextChanged(object sender, EventArgs e)
        {
            if(!(double.TryParse(txtLadoC.Text, out ladoC)))
            {
                MessageBox.Show("Amore, você precisa informar números.");
                txtLadoC.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLadoA.Clear();
            txtLadoB.Clear();
            txtLadoC.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (ladoA < (ladoB + ladoC) && ladoA > Math.Abs(ladoB - ladoC) &&
                ladoB < (ladoA + ladoC) && ladoB > Math.Abs(ladoA - ladoC) && 
                ladoC < (ladoA + ladoB) && ladoC > Math.Abs(ladoA - ladoB))
            {
                if(ladoA==ladoB && ladoB==ladoC)
                    MessageBox.Show("Raio da manhã, é um triângulo e equilátero!");
                else if (ladoA==ladoB || ladoA==ladoC || ladoB==ladoC)
                    MessageBox.Show("Flor de maracujá, esse é um triângulo e isósceles!");
                else
                    MessageBox.Show("Gota de Orvalho, esse é um triângulo e escaleno!");
            }
            else
                MessageBox.Show("Hello! Esse não é um triângulo.");

        }

        private void txtLadoA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }

        private void txtLadoB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }

        private void txtLadoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}{ENTER}");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void txtLadoA_Validated(object sender, EventArgs e)
        {
            if(!(double.TryParse(txtLadoA.Text, out ladoA)))
            {
                MessageBox.Show("Olá! Você não informou um número, tente novamente.");
                txtLadoA.Focus();
            }    
        }
    }
}
