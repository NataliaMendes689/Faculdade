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
    public partial class frmAtividade6 : Form
    {
        public frmAtividade6()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            string[] nomeCompleto = new string[7]; //RA: 0030482113007 -> usado último digito = 7
            string aux = "";
            int[] numC = new int[7];
            int i = 0;

            while(i<nomeCompleto.Length)
            {
                nomeCompleto[i] = Interaction.InputBox("Informe o nome completo da " + (i + 1) + "º pessoa:", "Entrada de Dados");
                if(nomeCompleto[i] == "" || nomeCompleto[i].Length < 10)
                {
                    MessageBox.Show("Dados inválidos. Informe novamente.");
                }
                else
                {
                    aux = nomeCompleto[i].Replace(" ", "");
                    numC[i] = aux.Length;
                    i++;
                }
            }

            i = 0;
            foreach(string c in nomeCompleto)
            {
                lstbxSaida.Items.Add("• O nome " + c + " tem " + numC[i] + " caracteres.");
                i++;
            }
        }
    }
}
