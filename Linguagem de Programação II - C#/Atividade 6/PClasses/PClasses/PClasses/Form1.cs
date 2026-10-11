using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PClasses
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnMensalista_Click(object sender, EventArgs e)
        {
            frmMensalista FrmMensalista = new frmMensalista(); // isso é uma instanciação
            //nome-da-classe nome-do-objeto = new nome-do-objeto
            FrmMensalista.Show();//mostra o formulário desejado
        }

        private void btnHorista_Click(object sender, EventArgs e)
        {
            frmHorista FrmHorista = new frmHorista();
            FrmHorista.Show();
        }
    }
}
