using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAtividade8
{
    public partial class frmAtividade2 : Form
    {
        public frmAtividade2()
        {
            InitializeComponent();
        }

        private void btnGerarNum_Click(object sender, EventArgs e)
        {
            double num, varH=0, i, soma;
            if(double.TryParse(txtNum.Text, out num) && num>0)
            {
                for(i=1;i<=num;i++)
                {
                    soma = 1 / i;
                    varH = soma + varH;
                }

                MessageBox.Show("O valor de H é "+varH.ToString());
            }
            else
            {
                MessageBox.Show("Informe apenas números maiores que 0. Tente novamente.");
                txtNum.Focus();
            }
        }
    }
}
