using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class GameBoard : Form
    {
        private bool clickedForTheSecondTime = false;
        private bool isDargging = false;
        public int playerMoney;
        public int allTimeProfit;
        private int seconds;
        private int totalBetMoney =0;
        public string username = "";
        private int minimumBet;

        public GameBoard()
        {
            InitializeComponent();
        }


        private void GameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            RegistrationLoginForm form1 = new RegistrationLoginForm();
            form1.Visible = true;
        }

        private void raiseButton_Click(object sender, EventArgs e)
        {
            if (clickedForTheSecondTime)
            {
                this.trackBar1.Visible = false;
                this.valueTextBox.Visible = false;
                this.addButton.Visible = false;
                this.reduceButton.Visible = false;
                this.betButton.Visible = false;
                clickedForTheSecondTime = false;
            }
            else
            {
                this.trackBar1.Visible = true;
                this.valueTextBox.Visible = true;
                this.addButton.Visible = true;
                this.reduceButton.Visible = true;
                this.betButton.Visible = true;
                clickedForTheSecondTime = true;
            }
            this.trackBar1.Maximum = this.playerMoney;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol();
            clientServerProtocol.command = Command.CHECK;
            ConnectionWithServer.getOpenInstance().SendMessage(clientServerProtocol.generate());
            this.AfterMyTurn();

        }

        

        private void foldButton_Click(object sender, EventArgs e)
        {
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol();
            clientServerProtocol.command = Command.FOLD;
            ConnectionWithServer.getOpenInstance().SendMessage(clientServerProtocol.generate());
            this.AfterMyTurn();
            this.nameAndBetLabel.Text += this.username + ": " + "Quit" + Environment.NewLine;
            this.raiseButton.BackColor = Color.White;
            this.foldButton.BackColor = Color.White;
            this.checkButton.BackColor = Color.White;



        }

        public  void drawCrads(string[] cards)
        {
            if (cards[0] != null && cards[0].Length > 0)
            {
                this.firstCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[0]);
                this.firstCardPictureBox.Refresh();
                this.firstCardPictureBox.Visible = true;
            }
            if (cards[1] != null && cards[1].Length > 0)
            {
                this.secondCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[1]);
                this.secondCardPictureBox.Refresh();
                this.secondCardPictureBox.Visible = true;
            }
            if (cards[2] != null && cards[2].Length > 0)
            {
                this.thirdCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[2]);
                this.thirdCardPictureBox.Refresh();
                this.thirdCardPictureBox.Visible = true;
            }
            if (cards[3] != null && cards[3].Length > 0)
            {
                this.forthCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[3]);
                this.forthCardPictureBox.Refresh();
                this.forthCardPictureBox.Visible = true;
            }
            if (cards[4] != null && cards[4].Length > 0)
            {
                this.fifthCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[4]);
                this.fifthCardPictureBox.Refresh();
                this.fifthCardPictureBox.Visible = true;
            }


        }

        public void DrawPlayerCards(string[] cards)
        {
            this.playerFirstCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[0]);
            this.playerSecondCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[1]);
            this.playerFirstCardPictureBox.Refresh();
            this.playerSecondCardPictureBox.Refresh();
            this.playerFirstCardPictureBox.Visible= true;
            this.playerSecondCardPictureBox.Visible = true;
        }

        

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (isDargging)
            {
                this.valueTextBox.Text = this.trackBar1.Value.ToString();
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            isDargging = false;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            isDargging = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int valueOfLabel = Convert.ToInt32(this.valueTextBox.Text);
            if (this.trackBar1.Value <= this.playerMoney-10)
            {
                this.trackBar1.Value += 10;
                valueOfLabel += 10;
            }
            else
            {
                valueOfLabel = this.playerMoney;
                this.trackBar1.Value = this.playerMoney;
            }
            this.valueTextBox.Text = valueOfLabel.ToString();
        }
        private void reduceButton_Click(object sender, EventArgs e)
        {
            int valueOfLabel = Convert.ToInt32(this.valueTextBox.Text);
            if (this.trackBar1.Value >= 10)
            {
                this.trackBar1.Value -= 10;
                valueOfLabel -= 10;
            }
            else
            {
                valueOfLabel = 0;
                this.trackBar1.Value = 0;
            }
            this.valueTextBox.Text = valueOfLabel.ToString();

        }

        public void SetPlayerMoney()
        {
            this.MoneyTheClientHaveLabel.Text = "Current Money: " +  this.playerMoney.ToString();
            this.allTimeProfitLabel.Text = "All Time Profit: " + this.allTimeProfit.ToString();
         }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (valueTextBox.Text.Length > 0)
            {
                try
                {
                    Convert.ToInt32(valueTextBox.Text);
                }
                catch (Exception exception)
                {
                    valueTextBox.Text = "0";
                    valueTextBox.SelectionStart = valueTextBox.Text.Length;
                    valueTextBox.SelectionLength = 0;
                    this.trackBar1.Value = 0;
                }
                if (this.valueTextBox.Text.Contains("."))
                {
                    MessageBox.Show("You can't bet on decimal number, please don't do this again :)");
                    this.valueTextBox.Text = "0";
                    this.trackBar1.Value = 0;
                    return;
                }
                if(valueTextBox.Text.Length >= 2)
                {
                    while (valueTextBox.Text.StartsWith("0"))
                    {
                        valueTextBox.Text = valueTextBox.Text.Substring(1);
                        return;

                    }
                }
                int value = Convert.ToInt32(valueTextBox.Text);
                if (value > this.playerMoney)
                {
                    MessageBox.Show("You can't bet with money that you don't have...");
                    this.valueTextBox.Text = this.playerMoney.ToString();
                    this.trackBar1.Value = this.playerMoney;
                    return;
                }
                this.trackBar1.Value = value;
            }
        }


        private void betButton_Click(object sender, EventArgs e)
        {

            int moneyToBet = Convert.ToInt32(this.valueTextBox.Text);
            if(this.minimumBet > this.playerMoney && moneyToBet != this.playerMoney) 
            {
                MessageBox.Show("The minimum bet that you can bet right now is all in, that in your case is: " + this.playerMoney.ToString());
                this.valueTextBox.Text = "0";
                this.trackBar1.Value = 0;
                return;
            }
            if (moneyToBet < this.minimumBet && this.minimumBet <= this.playerMoney)
            {
                MessageBox.Show("The minimum bet that you can bet right now is: " + this.minimumBet.ToString());
                this.valueTextBox.Text = "0";
                this.trackBar1.Value = 0;
                return;
            }
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol();
            clientServerProtocol.command = Command.RAISE;
            clientServerProtocol.betMoney = moneyToBet;
            ConnectionWithServer.getOpenInstance().SendMessage(clientServerProtocol.generate());
            this.AfterMyTurn();
        }
        

        public void sumBetMoney(int betMoney, string username)
        {
            this.totalBetMoney += betMoney; 
            this.totalMoneyLabel.Text = this.totalBetMoney.ToString();
            this.nameAndBetLabel.Text += username + ": " + betMoney.ToString() + Environment.NewLine;
            if(this.username.Equals(username))
            {
                this.playerMoney -= betMoney;
                this.SetPlayerMoney();

            }
        }

        public void MyTurn(int minimumBet)
        {
            this.minimumBet = minimumBet;
            this.raiseButton.Enabled = true;
            this.checkButton.Enabled = true;
            this.foldButton.Enabled = true;
            this.playerTurnLabel.Text = "Now it's your turn";
            this.playerTurnLabel.BackColor = Color.Green;
            this.turnTimeLabel.Visible = true;
            this.seconds = 40;
            this.countDownTimer.Start();
        }

        private void AfterMyTurn()
        {
            this.trackBar1.Visible = false;
            this.valueTextBox.Visible = false;
            this.addButton.Visible = false;
            this.reduceButton.Visible = false;
            this.betButton.Visible = false;
            clickedForTheSecondTime = false;
            this.raiseButton.Enabled = false;
            this.checkButton.Enabled = false;
            this.foldButton.Enabled = false;
            this.valueTextBox.Text = "0";
            this.playerTurnLabel.Text = "It's not your turn right now";
            this.playerTurnLabel.BackColor = Color.Red;
            this.turnTimeLabel.Visible = false;
            this.turnTimeLabel.Text = "";
        }

        public void TheWinnerIs(string username)
        {
            this.theWinnerIsLabel.Text += Environment.NewLine + username;
            this.theWinnerIsLabel.Visible = true;

        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            this.turnTimeLabel.Text = this.seconds--.ToString();
            if (this.seconds < 0)
            {
                this.foldButton_Click(null,null);
                this.countDownTimer.Stop();
            }
        }
    }
}
