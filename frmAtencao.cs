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
    public partial class frmAtencao : Form
    {
        public string msg = string.Empty;
        public frmAtencao()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAtencao_Load(object sender, EventArgs e)
        {
            lblmensagem.Text = msg;             
            int x = (panel1.Size.Width - lblmensagem.Size.Width) / 2;
            lblmensagem.Location = new Point(x, lblmensagem.Location.Y);
        }
    }
}
