using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PAtividade09
{
    public partial class frmAtividade4 : Form
    {
        public frmAtividade4()
        {
            InitializeComponent();
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            ArrayList Alunos = new ArrayList (new string[]{ "Ana", "André", "Débora", 
                "Fátima", "João", "Janete", "Otávio", "Marcelo", "Pedro", "Thais"});
            string aux = "";

            foreach (string item in Alunos)
                aux += "• " + item.ToString() + "\n";
            MessageBox.Show("Nome dos alunos: \n"+aux,"Entrada de Dados");

            Alunos.Remove("Otávio");

            aux = "";
            foreach (string item in Alunos)
                aux += "• " + item.ToString() + "\n";

            MessageBox.Show("Nome dos alunos (sem Otávio): \n"+aux, "Saída dos Dados");
        }
    }
}
