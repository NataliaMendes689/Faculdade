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
using System.Collections;

namespace PProva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            int n = 9;
            int x;
            string notaTemp;
            double[] media = new double[n];
            double[,] notas = new double[n, 3];
            double somaNota = 0;
            double mediaGeral = 0;

            for (int i = 0; i < 9 ; i++)
            {
                for (x = 0; x < 3; x++)
                {
                    notaTemp = Interaction.InputBox("Digite a nota " + (x + 1) + " do Aluno " + (i + 1), "Entrada de Notas");
                    if (double.TryParse(notaTemp, out notas[i, x]))
                    {
                        if ((notas[i, x] > -1) && (notas[i, x] < 11))
                        {
                            notas[i, x] = Convert.ToDouble(notaTemp);
                            somaNota += notas[i, x];
                        }
                        else
                        {
                            MessageBox.Show("Digite uma nota válida");
                            x--;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Insira um valor válido.");
                        x--;
                    }

                    media[i] = (somaNota / 3);
                    mediaGeral += media[i] / n;
                }
                lstBxAlunos.Items.Add("Aluno " + (i + 1) + " Nota Professor1: " + notas[i, 0] + " Nota Professor2: " + notas[i, 1] + " Notas Professor3: " + notas[i, 2] + " Média: " + media[i].ToString("N2"));
                somaNota = 0;
            }
            mediaGeral = mediaGeral / n;
            lstBxAlunos.Items.Add("--------------------------------------------------------------------------------------------------");
            lstBxAlunos.Items.Add("Média Geral Alunos: " + mediaGeral.ToString("N2"));
        }
    }
}
