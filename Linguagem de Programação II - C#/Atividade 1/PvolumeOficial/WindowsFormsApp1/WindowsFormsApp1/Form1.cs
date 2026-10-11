using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double raio, altura, volume; /* globais*/
        public Form1()
        {
            InitializeComponent();
        }

        private void TxtAltura_Validated(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAltura.Text, out altura))
            {
                MessageBox.Show("Altura inválida");
                // textBox2.Focus();
            }
            else
            {
                    if (altura<=0)
                    {
                    MessageBox.Show("Altura não pode ser <=0");
                    //textBox2.Focus();
                    }
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((!double.TryParse(txtRaio.Text, out raio)) ||
                (!double.TryParse(txtAltura.Text, out altura)))
            {
                MessageBox.Show("Valores Inválidos");
            }
            else
            {
                if ((altura <= 0) || (raio <= 0))
                {
                    MessageBox.Show("Valores não podem ser <=0");
                }
                else
                {
                    volume = Math.PI * Math.Pow(raio, 2) * altura;
                    txtVolume.Text = volume.ToString("N2");
                }

            }
        }

        private void TxtRaio_Validated(object sender, EventArgs e)
        {
            if (!double.TryParse(txtRaio.Text, out raio))
            {
                MessageBox.Show("Raio inválido");
                // textBox1.Focus();
            }
            else
            {
                if (raio<=0)
                {
                    MessageBox.Show("Raio não pode ser <=0");
                    //textBox1.Focus();
                }
            }
        }
    }
}
