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
    public partial class frmAtividade1 : Form
    {
        public frmAtividade1()
        {
            InitializeComponent();
        }

        private void btnBrancos_Click(object sender, EventArgs e)
        {
            char[] vTexto = rchtxtFrase.Text.ToCharArray();
            int i = 0, brancos=0;

            if (rchtxtFrase.Text != "")
            {
                foreach (char c in vTexto)
                {
                    if (char.IsWhiteSpace(c) == true)
                    {
                        brancos++;
                    }
                }
                MessageBox.Show("Existem " + brancos.ToString() + " espaço(s) em branco na frase.");
            }
            else
            {
                MessageBox.Show("Informe um texto!");
                rchtxtFrase.Focus();
            }
        }


        private void btnR_Click(object sender, EventArgs e)
        {
            char[] vTexto = rchtxtFrase.Text.ToCharArray();
            int i=0, cont=0, tamanho = rchtxtFrase.Text.Length;

            if (rchtxtFrase.Text != "")
            {
                while (i < tamanho)
                {
                    if (char.ToUpper(vTexto[i]) == 'R')
                    {
                        cont++;
                        i++;
                    }
                    else
                        i++;
                }
                MessageBox.Show("A lera 'R' aparece " + cont.ToString() + " vezes no texto.");
            }
            else
            {
                MessageBox.Show("Informe um texto!");
                rchtxtFrase.Focus();
            }
        }



        private void btnParesLetras_Click(object sender, EventArgs e)
        {
            char[] vTexto = rchtxtFrase.Text.ToCharArray();
            int i, cont=0;

            if (rchtxtFrase.Text != "")
            {
                for (i = 1; i < rchtxtFrase.Text.Length; i++)
                {
                    if (vTexto[i].ToString() != "" && vTexto[i].ToString() == vTexto[i - 1].ToString())
                    {
                        cont++;
                    }
                }
                MessageBox.Show("O texto tem " + cont.ToString() + " pares de letras.");
            }
            else
            {
                MessageBox.Show("Informe um texto!");
                rchtxtFrase.Focus();
            }
        }
    }
}
