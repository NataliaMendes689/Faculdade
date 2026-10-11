using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCalcIMC
{
    public partial class Form1 : Form
    {
        double altura, peso, IMC;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mskboxPeso_Validated(object sender, EventArgs e)
        {
            if (!(double.TryParse(mskboxPeso.Text, out peso)))
            {
                MessageBox.Show("Oi Raio de Sol! Você não informou um número, tenta de novo.");
                mskboxPeso.Focus();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            IMC = peso / Math.Pow(altura, 2);
            IMC = Math.Round(IMC, 1);
            txtIMC.Text = IMC.ToString("N1");

            if (altura < 0.01 || peso < 0.01)         
                MessageBox.Show("Amadx, você informou valores zero, tenta de novo.");
            else
                if(IMC < 18.5)
                    MessageBox.Show("Meninx do céu! Você está muito magrx!!!" + "\n" + "Bora começar uma dieta mais reforçada?");
                else if(IMC >= 18.5 && IMC <= 24.9)
                    MessageBox.Show("Seu peso está normal!"+"\n"+"Brilha, flor me maracujá!");
                else if(IMC >= 25.0 && IMC <= 29.9)
                    MessageBox.Show("Sobrepeso!"+"\n"+"Bora começar a mudar os hábitos alimentares, flor do dia?");
                else if(IMC >= 30.0 && IMC <= 39.9)
                    MessageBox.Show("Eita, amigx, você tá obesx!"+"\n"+"Tá na hora de procurar um nutricinista, vamos juntxs?");
                else
                MessageBox.Show("ATENÇÃO TOTAL: você está com obesidade grave!"+"\n"+"Bora mudar! Pega seu celular e já agenda um nutricionista para ontem!");
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskboxPeso.Clear();
            mskbxAltura.Clear();
            txtIMC.Clear();
        }

        private void mskbxAltura_Validated(object sender, EventArgs e)
        {
            if(!(double.TryParse(mskbxAltura.Text, out altura)))
            {
                MessageBox.Show("Oi queridx! Você não informou um número, tenta de novo.");
                mskbxAltura.Focus();
            }
        }
    }
}
