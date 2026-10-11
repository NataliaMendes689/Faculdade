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

namespace PAtividade09
{
    public partial class frmAtividade5 : Form
    {
        public frmAtividade5()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            double[,] notas = new double[20, 3];
            int i, j;
            string aux = "", saida = "";
            double media;

            for(i=0;i<20;i++)
            {
                media = 0;
                for (j=0;j<3;j++)
                {
                    aux = Interaction.InputBox("Informe a "+ (j + 1).ToString() +"º nota do(a) aluno(a) "
                        + (i + 1).ToString() + ":", "Entrada de notas");

                    if(!double.TryParse(aux, out notas[i,j]) || notas[i,j] < 0 || notas[i,j] > 10 || aux == "")
                    {
                        MessageBox.Show("Dado inválido. Informe números entre 0 e 10.");
                        j--;
                    }
                    else
                    {
                        media += notas[i, j];
                    }
                }
                media = media / 3;
                saida = saida +"\n" + "Aluno(a) "+ (i+1) + ": "+ media.ToString("N1");
            }
            MessageBox.Show(saida, "Média dos Alunos");
        }
    }
}
