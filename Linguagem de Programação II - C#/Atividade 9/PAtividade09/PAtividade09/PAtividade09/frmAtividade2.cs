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
    public partial class frmAtividade2 : Form
    {
        public frmAtividade2()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            double[] vQuant = new double[10];
            double[] vPreco = new double[10];
            int i = 0;
            double fatur = 0;
            string auxQ = "", auxP = "";

            while(i<10)
            {
                auxQ = Interaction.InputBox("Informe a quantidade vendida da mercadoria "
                    + (i+1).ToString() + ": ", "Quantidade Vendida");
                if (!double.TryParse(auxQ, out vQuant[i]) || auxQ == "" || vQuant[i] <= 0)
                    MessageBox.Show("Dados inválidos. Informe novamente!");

                else 
                {
                    while (true)
                    {
                        auxP = Interaction.InputBox("Informe o preço da mercadoria " +
                         (i + 1).ToString() + ": ", "Preço da Venda");
                        if (!double.TryParse(auxP, out vPreco[i]) || auxP == "" || vPreco[i] <= 0)
                            MessageBox.Show("Dados inválidos. Informe novamente!");
                        else
                            break;
                    }
                    i++;
                }
            }
            
            for(int c = 0; c<10; c++)
                fatur = fatur+ (vQuant[c] * vPreco[c]);
            
            MessageBox.Show("O faturamento mensal é de: R$ "+fatur.ToString("N2"), "Faturamento Mensal");

        }
    }
}
