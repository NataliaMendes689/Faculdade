using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace P30482113007
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            double[,] vVendas = new double[7,4]; //RA: 30482113007 -> usado último digito = 7
            double tVendMes, tGeral = 0;
            string aux = "";
            int i = 0, j=0;

            lstbxSaida.Items.Clear();

            while (i < 7)
            {
                tVendMes = 0;
                lstbxSaida.Items.Add("---------- Mês " + (i + 1)+ " ----------");
                for (j = 0; j < 4; j++)
                {
                    aux = Interaction.InputBox("Informe o valor total vendido na semana " + (j + 1) + " do mês " + (i + 1), "Entrada de Dados");
                    if (!double.TryParse(aux, out vVendas[i, j]) || vVendas[i, j] < 0 || aux == "")
                    {
                        MessageBox.Show("Dados inválidos. Informe novamente.", "Erro");
                        j--;
                    }
                    else
                    {
                        tVendMes += vVendas[i, j];
                        lstbxSaida.Items.Add("Total de vendas da semana " + (j + 1) + ": " + string.Format("{0:C2}", vVendas[i,j]));
                    }
                }

                tGeral += tVendMes;
                lstbxSaida.Items.Add("► Total de vendas do mês " + (i+1) + ": " + string.Format("{0:C2}", tVendMes));
                lstbxSaida.Items.Add("");
                i++;
            }
            
            lstbxSaida.Items.Add("------------------------------------");
            lstbxSaida.Items.Add(">>Total geral vendido: " + string.Format("{0:C2}", tGeral));
            lstbxSaida.Items.Add("");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
