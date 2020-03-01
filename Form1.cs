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
    public partial class MainPrincipal : Form
    {
        int X = 0;
        int O = 0;
        int drawGame = 0;
        int rouns = 0;
        bool turn = true;
        int buttonid = 0;
        string[] stringArray = new string [9];
        string cXis = "X";
        string cBola = "O";
        bool campeao = false;
        Button btn;

        public MainPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
           
            btn = (Button)sender;
            buttonid = btn.TabIndex;
            if (btn.Text == "" && !campeao)
            {
                if (turn)
                {
                    btn.Text = cXis;
                    btn.ForeColor = Color.Red;
                    stringArray[buttonid] = cXis;
                    getwins(1);
                    lblturno.Text = cXis;
                    lblturno.ForeColor = Color.Red;
                    rouns++;
                    turn = !turn;
                }
                else
                {
                    btn.Text = cBola;
                    btn.ForeColor = Color.Blue;
                    stringArray[buttonid] = cBola;
                    getwins(2);
                    lblturno.Text = cBola;
                    lblturno.ForeColor = Color.Blue;
                    rouns++;
                    turn = !turn;
                }
            }
            if (rouns == 9 && !campeao)
            {
                drawGame++;
                frmAtencao objfrmAtencao = new frmAtencao();
                objfrmAtencao.msg = "EMPATE!";
                objfrmAtencao.StartPosition = FormStartPosition.CenterScreen;
                objfrmAtencao.Show();
                btnLimpar_Click(null, null);
                lvlEmpates.Text = drawGame.ToString();
                return;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmNovo objFrmNovo = new FrmNovo();
            objFrmNovo.StartPosition = FormStartPosition.CenterScreen;
            objFrmNovo.ShowDialog();
            lblplayer1.Text = objFrmNovo.player1;
            lblPlayer2.Text = objFrmNovo.player2;
            if (lblplayer1.Text != "" || lblPlayer2.Text != "")
            {
                panel2.Enabled = true;
                lblInstrução.Visible = false;


            }
            

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (panelcontrolPlacar.Visible)
                {
                    panelcontrolPlacar.Visible = false;
                    this.Size = new Size(500, this.Size.Height);

                }
                else
                {
                    panelcontrolPlacar.Visible = true;
                  //  MainPrincipal.Size.Width = 765;
                  //  MainPrincipal.Size.Height = 568;
                    this.Size = new Size(800, this.Size.Height);
                }
               
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panelcontrolPlacar.Visible = false;
            lblVencedor.Visible = false;
            panel2.Enabled = false;
            this.Size = new Size(500, this.Size.Height);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getwins(int players)
        {
            

            string verificar = string.Empty;
            if (players == 1)
            {
                verificar = cXis;
            }
            else
            {
                verificar = cBola;
            }
            //verificando na horizontal
            for (int hori = 0; hori < 8; hori += 3)
            {
                if (verificar == stringArray[hori])
                {
                    if (stringArray[hori] == stringArray[hori + 1] && stringArray[hori] == stringArray[hori + 2])
                    {
                        lblVencedor.Visible = true;
                        lblVencedor.Text = "Wins...!!!!" + verificar + "horizontal";
                        getcampeao(players);
                        return;
                    }
                }
            }
            //vertical
            for (int vert = 0; vert < 3; vert++)
            {
                if (verificar == stringArray[vert])
                {
                    if (stringArray[vert] == stringArray[vert + 3] && stringArray[vert] == stringArray[vert + 6])
                    {
                        lblVencedor.Visible = true;
                        lblVencedor.Text = "Wins...!!!!" + verificar + "vertical";
                        getcampeao(players);
                        
                        return;
                    }
                }
            }
            //diagonal
            if (stringArray[0] == verificar)
            {
                if (stringArray[0] == stringArray[4] && stringArray[0] == stringArray[8])
                {
                    lblVencedor.Visible = true;
                    lblVencedor.Text = "Wins...!!!!" + verificar + "Diagonal 1";
                    getcampeao(players);
                    
                    return;
                }
            }

            if (stringArray[2] == verificar)
            {
                if (stringArray[2] == stringArray[4] && stringArray[2] == stringArray[6])
                {
                    lblVencedor.Visible = true;
                    lblVencedor.Text = "Wins...!!!!" + verificar + "Diagonal 2";
                    getcampeao(players);
                    return;
                }
            }
         

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar todos botos;
            btn.Text = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
            lblVencedor.Text = null;
            for (int i = 0; i < 9; i++)
            {
                stringArray[i] = "";
            }
            campeao = false;
            rouns = 0;
        }

        private void getcampeao(int player)
        {
            campeao = true;
            if (player == 1)
            {
                turn = true;
                X++;
                lblPontosPlayer1.Text = X.ToString();
            }
            else
            {
                turn = false;
                O++;
                lblPontosPlayer2.Text = O.ToString();
            }
        }
    }
}
