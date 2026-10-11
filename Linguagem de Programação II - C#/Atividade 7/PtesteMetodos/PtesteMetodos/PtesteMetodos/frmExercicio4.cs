using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PtesteMetodos
{
    public partial class frmExercicio4 : Form
    {
        public frmExercicio4()
        {
            InitializeComponent();
        }

        private void btnNumerico_Click(object sender, EventArgs e)
        {
            int i, contNum=0, tamanho = rchtextPalavra.Text.Length;
            char[] vTexto = rchtextPalavra.Text.ToCharArray();

            for(i=0;i<tamanho;i++)
            {
                if (char.IsNumber(vTexto[i]))
                {
                    contNum++;
                }
            }
            MessageBox.Show("O texto tem "+ contNum.ToString()+" números.");
        }

        private void btnEmBranco_Click(object sender, EventArgs e)
        {
            char[] vTexto = rchtextPalavra.Text.ToCharArray();
            int i = 0;

            while(char.IsWhiteSpace(vTexto[i]) == false)
            {
                i++;
            }
            MessageBox.Show("O primeiro espaço em branco está na posição " + (i+1).ToString() + " do texto.");
        }

        private void btnAlfabetico_Click(object sender, EventArgs e)
        {
            int contNum = 0;
            char[] vTexto = rchtextPalavra.Text.ToCharArray();

            foreach (char c in vTexto)
            {
                if (char.IsLetter(c))
                {
                    contNum++;
                }
            }
            MessageBox.Show("O texto tem " + contNum.ToString() + " caracteres alfabéticos.");
        }
    }
}
