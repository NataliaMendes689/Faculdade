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
    public partial class frmAtividade1 : Form
    {
        public frmAtividade1()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            int[] num = new int[20];
            string auxiliar = "", saida = "";
            int i=0;

            while (i < 20)
            {
                auxiliar = Interaction.InputBox("Informe o " + (i + 1).ToString() + "º número: ", "Entrada de Dados");

                if (!int.TryParse(auxiliar, out num[i]) || auxiliar=="")
                {
                    MessageBox.Show("Dado inválido. Informe um número!", "Entrada inválida");
                }

                else
                {
                    saida = num[i] + "\n" + saida;
                    i++;
                }
            }
            MessageBox.Show(saida,"Dados na ordem inversa");
        }
    }
}
