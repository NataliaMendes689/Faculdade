using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCalcDesconto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxFilhos.SelectedIndex = 0;//para trazer a primeira posição da lista
        }

        private void txtNome_Validated(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (txtNome.Text.Length <= 7))
            {
                MessageBox.Show("Nome inválido. Informe o nome completo.");
                txtNome.Focus();
            }
        }

        private void mskbxBruto_Validated(object sender, EventArgs e)
        {
            double salBruto;
            if((mskbxBruto.Text == "") || (mskbxBruto.Text=="0"))
            {
                MessageBox.Show("Informe o valor do salário.");
                mskbxBruto.Focus();
            }

            if (!(double.TryParse(mskbxBruto.Text, out salBruto)))
            {
                MessageBox.Show("Informe números!");
                mskbxBruto.Focus();
            }
           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            double salBruto;
            double descontoINSS, descontoIR, bolsaFamilia, salLiquido;

            if(double.TryParse(mskbxBruto.Text, out salBruto))
            {
                //CALCULO DO INSS
                if (salBruto <= 800.47)
                {
                    mskbxAliquotaINSS.Text = "7.65%";
                    descontoINSS = 0.0765 * salBruto;
                }
                else if (salBruto <= 1050)
                {
                    mskbxAliquotaINSS.Text = "8.65%";
                    descontoINSS = 0.0865 * salBruto;
                }
                else if (salBruto <= 1400.77)
                {
                    mskbxAliquotaINSS.Text = "9.00%";
                    descontoINSS = 0.09 * salBruto;
                }
                else if (salBruto <= 2801.56)
                {
                    mskbxAliquotaINSS.Text = "11.00%";
                    descontoINSS = 0.11 * salBruto;
                }
                else
                {
                    mskbxAliquotaINSS.Text = "Teto";
                    descontoINSS = 308.17;
                }
                if (descontoINSS >= 100)
                    mskbxDescINSS.Text = descontoINSS.ToString("N2");
                else
                    mskbxDescINSS.Text = "0"+descontoINSS.ToString("N2");

                //CALCULO DO IR
                if(salBruto<=1257.12)
                {
                    mskbxAliquotaIR.Text = "00.0";
                    descontoIR = 000.000;
                }
                else if(salBruto<=2512.08)
                {
                    mskbxAliquotaIR.Text = "15.0";
                    descontoIR = 0.15 * salBruto;
                }
                else
                {
                    mskbxAliquotaIR.Text = "27.5";
                    descontoIR = 0.275 * salBruto;
                }
                if (descontoIR >= 100)
                    mskbxDescIR.Text = descontoIR.ToString("N2");
                else
                    mskbxDescIR.Text = "0" + descontoIR.ToString("N2");

                //CALCULO BOLSA FAMILIA
                if (salBruto <= 435.52)
                {
                    bolsaFamilia = 22.33 * Convert.ToDouble(cbxFilhos.SelectedItem.ToString());
                }
                else if (salBruto <= 654.61)
                {
                    bolsaFamilia = 15.74 * Convert.ToDouble(cbxFilhos.SelectedItem.ToString());
                }
                else
                {
                    bolsaFamilia = 000.000;
                }
                if (bolsaFamilia >= 100.00)
                    mskbxFamilia.Text = bolsaFamilia.ToString("N2");
                else
                    mskbxFamilia.Text = "0"+bolsaFamilia.ToString("N2");

                //CALCULO SALARIO LIQUIDO
                salLiquido = salBruto - descontoINSS - descontoIR + bolsaFamilia;
                if (salLiquido >= 10000)
                    mskbxLiquido.Text = salLiquido.ToString("N2");
                else if (salLiquido >= 1000)
                    mskbxLiquido.Text = "0" + salLiquido.ToString("N2");
                else if (salLiquido >= 100)
                    mskbxLiquido.Text = "00" + salLiquido.ToString("N2");
                else if (salLiquido >= 10)
                    mskbxLiquido.Text = "000" + salLiquido.ToString("N2");

                //MENSAGEM
                lblMensagem.Visible = true;

                if (txtNomeSocial.Text == "")
                    txtNomeSocial.Text = txtNome.Text;

                lblMensagem.Text = "Os descontos do salário ";
                if (rbtnElaDela.Checked)
                {
                    lblMensagem.Text = lblMensagem.Text + "da Sra. " + txtNomeSocial.Text;
                    if (rbtnCasado.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", casada, ";
                    else if (rbtnSolteiro.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", solteira, ";
                    else if (rbtnDivorciado.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", divorciada, ";
                    else
                        lblMensagem.Text = lblMensagem.Text + ", viúva, ";
                }
                else
                {
                    lblMensagem.Text = lblMensagem.Text + "do Sr. " + txtNomeSocial.Text;
                    if (rbtnCasado.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", casado, ";
                    else if (rbtnSolteiro.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", solteiro, ";
                    else if (rbtnDivorciado.Checked)
                        lblMensagem.Text = lblMensagem.Text + ", divorciado, ";
                    else
                        lblMensagem.Text = lblMensagem.Text + ", viúvo, ";
                }

                if(cbxFilhos.SelectedItem.ToString()=="0")
                    lblMensagem.Text = lblMensagem.Text + "sem filhos, são conforme mostra abaixo:";
                else
                    lblMensagem.Text = lblMensagem.Text + "e que tem " + cbxFilhos.SelectedItem.ToString() + " filho(s), são conforme mostra abaixo:";
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtNomeSocial.Clear();
            mskbxBruto.Clear();
            cbxFilhos.SelectedIndex = 0;
            mskbxAliquotaINSS.Clear();
            mskbxAliquotaIR.Clear();
            mskbxDescINSS.Clear();
            mskbxDescIR.Clear();
            mskbxFamilia.Clear();
            mskbxLiquido.Clear();
        }
    }
}
