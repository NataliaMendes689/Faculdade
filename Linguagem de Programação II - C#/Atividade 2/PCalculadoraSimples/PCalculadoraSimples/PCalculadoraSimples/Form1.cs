using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCalculadoraSimples
{
    public partial class Form1 : Form
    {
        double num1, num2, resultado;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNum1.Clear();
            txtNum2.Clear();
            txtResult.Clear();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            //double.TryParse(txtNum1.Text, out num1);
            //double.TryParse(txtNum2.Text, out num2);
            resultado = num1 - num2;
            txtResult.Text = resultado.ToString("N2");
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            //double.TryParse(txtNum1.Text, out num1);
            //double.TryParse(txtNum2.Text, out num2);
            resultado = num1 * num2;
            txtResult.Text = resultado.ToString("N2");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            //double.TryParse(txtNum1.Text, out num1);
            //double.TryParse(txtNum2.Text, out num2);
            if (txtNum2.Text == "0" || txtNum2.Text == "0,0" || txtNum2.Text == "0,00")
            {
                MessageBox.Show("Não é possível dividir por 0!");
                txtNum2.Focus();
            }
            else
            {
                resultado = num1 / num2;
                txtResult.Text = resultado.ToString("N2");
            }
        }

        private void txtNum1_Validated(object sender, EventArgs e)
        {
            if (!(double.TryParse(txtNum1.Text, out num1)))
            {
                MessageBox.Show("Informe números!");
                txtNum1.Focus();
            }
        }

        private void txtNum2_Validated(object sender, EventArgs e)
        {
            if (!(double.TryParse(txtNum2.Text, out num2)))
            {
                MessageBox.Show("Informe números!");
                txtNum2.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            //double.TryParse(txtNum1.Text, out num1);
            //double.TryParse(txtNum2.Text, out num2);
            resultado = num1 + num2;
            txtResult.Text = resultado.ToString("N2");
        }
    }
}
