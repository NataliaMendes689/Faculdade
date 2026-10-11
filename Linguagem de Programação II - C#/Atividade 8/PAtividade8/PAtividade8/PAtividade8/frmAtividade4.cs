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
    public partial class frmAtividade4 : Form
    {
        public frmAtividade4()
        {
            InitializeComponent();
        }

        private void btnCalcSalBruto_Click(object sender, EventArgs e)
        {
            double salBruto, salario, gratif;
            int producao, b, c, d;

            if(txtNome.Text != "" && txtCargo.Text != "" && txtGratificacao.Text != "" 
                && txtMatricula.Text != "" && txtProducao.Text != "" && txtSalario.Text != "")
            {
                if(double.TryParse(txtSalario.Text, out salario))
                {
                    if (double.TryParse(txtGratificacao.Text, out gratif))
                    {
                        if (int.TryParse(txtProducao.Text, out producao))
                        {
                            if (producao >= 100)
                                b = 1;
                            else
                                b = 0;
                            if (producao >= 120)
                                c = 1;
                            else
                                c = 0;
                            if (producao >= 150)
                                d = 1;
                            else
                                d = 0;

                            salBruto = salario + salario * (0.05 * b + 0.1 * c + 0.1 * d) + gratif;

                            if(salBruto>7000 && producao >=150)
                            {
                                txtSalBruto.Text = "R$ " + salBruto.ToString("N2");
                            }
                            else if(salBruto>7000 && producao <150)
                            {
                                txtSalBruto.Text = "R$ 7000,00";
                            }
                            else
                            {
                                txtSalBruto.Text = salBruto.ToString("N2");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por gentileza, informe números no campo de Produção.");
                            txtProducao.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por gentileza, informe números no campo de gratificações.");
                        txtGratificacao.Focus();
                    }    
                }
                else
                {
                    MessageBox.Show("Por gentileza, informe números no campo de salário.");
                    txtSalario.Focus();
                }
            }
            else
                MessageBox.Show("Existem campos que não foram preenchidos. Por gentileza, preencha todos os campos.");
        }
    }
}
