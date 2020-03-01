using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogodaVelha
{
    public partial class FrmNovo : Form
    {
        public string player1 = "";
        public string player2 = "";
        public FrmNovo()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmAtencao objfrmAtencao = new frmAtencao();
            if (string.IsNullOrEmpty(txtplayer1.Text))
            {
                objfrmAtencao.msg = "Informe o Player 1";
                objfrmAtencao.ShowDialog();
                txtplayer1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtplayer2.Text))
            {
                objfrmAtencao.msg = "Informe o Player 2";
                objfrmAtencao.ShowDialog();
                txtplayer1.Focus();
                return;
            }

            player1 = txtplayer1.Text;
            player2 = txtplayer2.Text;
            this.Close();
        }
    }
}
