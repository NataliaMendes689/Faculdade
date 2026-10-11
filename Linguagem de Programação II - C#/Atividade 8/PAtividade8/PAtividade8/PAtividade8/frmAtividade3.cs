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
    public partial class frmAtividade3 : Form
    {
        public frmAtividade3()
        {
            InitializeComponent();
        }

        private void btnPalindromo_Click(object sender, EventArgs e)
        {
            char[] vTexto = txtFrase.Text.ToCharArray();
            string invertTexto = "", nTexto = txtFrase.Text.ToUpper();

            if (txtFrase.Text == "")
            {
                MessageBox.Show("Informe uma palavra ou texto.");
            }
            else if (txtFrase.Text.Length > 50)
            {
                MessageBox.Show("Texto excedeu o máximo permitido. Informe novamente.");
            }
            else
            {
                Array.Reverse(vTexto);

                foreach(char c in vTexto)
                {
                    invertTexto = invertTexto + c.ToString();
                }

                invertTexto = invertTexto.ToUpper();
                invertTexto = invertTexto.Replace(" ", "");
                
                if (invertTexto == nTexto.Replace(" ",""))
                    MessageBox.Show("O texto digitado é um palíndromo.");
                else
                    MessageBox.Show("O texto digitado não é um palíndromo.");
            }
        }
    }
}
