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
    public partial class frmExercicio5 : Form
    {
        public frmExercicio5()
        {
            InitializeComponent();
        }

        private void btnSorteio_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if(int.TryParse(txtNumero1.Text, out num1) && int.TryParse(txtNumero2.Text, out num2))
            {
                if (num1 < num2)
                {
                    Random random = new Random();
                    double sorteio = random.Next(num1, num2);
                    MessageBox.Show("Número sorteado: "+sorteio.ToString());
                }
                else
                {
                    MessageBox.Show("O número inicial deve ser maior que o número final. Infome novamente.");
                    txtNumero1.Focus();
                }
            }
            else
                MessageBox.Show("Você precisa informar números.");
                txtNumero1.Focus();
        }
    }
}
