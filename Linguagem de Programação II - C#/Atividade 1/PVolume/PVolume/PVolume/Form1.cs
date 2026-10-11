using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVolume
{
    public partial class Form1 : Form
    {
        double raio, altura;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtRaio_Validated(object sender, EventArgs e)
        {
            double raio;
            if (!(double.TryParse(txtRaio.Text, out raio)))
            {
                MessageBox.Show("Informe números!");
                txtRaio.Focus();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double volume;
            double.TryParse(txtRaio.Text, out raio);
            double.TryParse(txtAltura.Text, out altura);
            volume = Math.PI * Math.Pow(raio, 2) * altura;
            txtVolume.Text = volume.ToString("N2");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAltura.Clear();
            txtRaio.Clear();
            txtVolume.Clear();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAltura_Validated(object sender, EventArgs e)
        {
            double altura;
            if (!(double.TryParse(txtAltura.Text, out altura)))
            {
                MessageBox.Show("Informe números!");
                txtAltura.Focus();
            }
        }
    }
}
