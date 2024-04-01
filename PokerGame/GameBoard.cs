using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private int cardsSeconds;
        private int totalBetMoney =0;
        public string username = "";
        public int minimumBet;
        public int playerIndex;
        public int dealerIndex;
        public int smallBlindIndex;
        public int bigBlindIndex;
        public int playersNumber;
        public List<Tuple<string,int>> usernamsAndTheirMoney;
        private List<Tuple<Point, Point>>[] points;


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
                for(int i=  1; i<this.playersNumber; i++)
                {
                    ((Label)Controls.Find("showAction_" + i.ToString(), true)[0]).Visible = false;
                }
            }



            if (cards[3] != null && cards[3].Length > 0)
            {
                this.forthCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[3]);
                this.forthCardPictureBox.Refresh();
                this.forthCardPictureBox.Visible = true;
                for (int i = 1; i < this.playersNumber ; i++)
                {
                    ((Label)Controls.Find("showAction_" + i.ToString(), true)[0]).Visible = false;
                }
            }

            if (cards[4] != null && cards[4].Length > 0)
            {
                this.fifthCardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[4]);
                this.fifthCardPictureBox.Refresh();
                this.fifthCardPictureBox.Visible = true;
                for (int i = 1; i < this.playersNumber ; i++)
                {
                    ((Label)Controls.Find("showAction_" + i.ToString(), true)[0]).Visible = false;
                }
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

            if(this.playerIndex == this.dealerIndex)
            {
                this.youAreTheDealerLabel.Visible = true;
            }
            if (this.playerIndex == this.smallBlindIndex)
            {
                
            }
            if (this.playerIndex == this.bigBlindIndex)
            {

            }
            // visible to number of players -1
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
        

        public void sumBetMoney(int betMoney, string username, string raiseType)
        {
            this.totalBetMoney += betMoney; 
            this.totalMoneyLabel.Text = this.totalBetMoney.ToString();
            this.nameAndBetLabel.Text += username + ": " + betMoney.ToString() + Environment.NewLine;
            if(this.username.Equals(username))
            {
                this.playerMoney -= betMoney;
                this.SetPlayerMoney();
            }
            else
            {
                string name = "";
                foreach(Control control in Controls)
                {
                    if (control is Label)
                    {
                        Label lbl = (Label)control;
                        if (lbl.Text.Equals(username))
                        {
                            name = lbl.Name;
                            break;
                        }

                    }
                }
                string userId = name.Substring(name.Length - 1);
                string nameOfActionLabel = "showAction_" + userId;
                string nameOfMoneyLabel = "showMoney_" + userId;
                ((Label)this.Controls.Find(nameOfActionLabel, true)[0]).Visible = true;
                if (raiseType.Equals("Raise"))
                {
                    ((Label)this.Controls.Find(nameOfActionLabel, true)[0]).Text = raiseType +" " + betMoney.ToString() + "$";
                }
                if (raiseType.Equals("Check"))
                {
                    ((Label)this.Controls.Find(nameOfActionLabel, true)[0]).Text = raiseType;
                }
                if (raiseType.Equals("Fold"))
                {
                    ((Label)this.Controls.Find(nameOfActionLabel, true)[0]).Text = "Quit";
                }
                int oldMoney = Convert.ToInt32(((Label)this.Controls.Find(nameOfMoneyLabel, true)[0]).Text);
                int newMoney = oldMoney - betMoney;
                ((Label)this.Controls.Find(nameOfMoneyLabel, true)[0]).Text = newMoney.ToString();

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

        private void initiliazeMainPictureBoxLocation()
        {
            this.points = new List<Tuple<Point, Point>>[7];
            for(int i =0; i<points.Length; i++)
            {
                this.points[i] = new List<Tuple<Point, Point>>();      
            }
            this.points[0].Add(Tuple.Create(new Point(969, 13), new Point(1152,13)));
            this.points[1].Add(Tuple.Create(new Point(143, 232), new Point(326,232)));
            this.points[1].Add((Tuple.Create(new Point(1762, 232), new Point(1579, 232))));
            this.points[2].Add(Tuple.Create(new Point(969, 13), new Point(1152, 13)));  
            this.points[2].Add(Tuple.Create(new Point(143, 232), new Point(326, 232)));
            this.points[2].Add(Tuple.Create(new Point(1762, 232), new Point(1579, 232)));
            this.points[3].Add(Tuple.Create(new Point(143, 232), new Point(326, 232)));
            this.points[3].Add(Tuple.Create(new Point(1762, 232), new Point(1579, 232)));
            this.points[3].Add(Tuple.Create(new Point(1335, 25), new Point(1518, 25)));
            this.points[3].Add(Tuple.Create(new Point(613, 25), new Point(796, 25)));
            this.points[4].Add(Tuple.Create(new Point(969, 13), new Point(152, 13)));
            this.points[4].Add(Tuple.Create(new Point(1762, 232), new Point(1579, 232)));
            this.points[4].Add(Tuple.Create(new Point(143, 232), new Point(326, 232)));
            this.points[4].Add(Tuple.Create(new Point(1848, 576), new Point(1665, 576)));
            this.points[4].Add(Tuple.Create(new Point(100, 576), new Point(270, 576)));
            this.points[5].Add(Tuple.Create(new Point(1762, 232), new Point(1579, 232)));
            this.points[5].Add(Tuple.Create(new Point(143, 232), new Point(326, 232)));
            this.points[5].Add(Tuple.Create(new Point(1848, 576), new Point(1665, 576)));
            this.points[5].Add(Tuple.Create(new Point(100, 576), new Point(270, 576)));
            this.points[5].Add(Tuple.Create(new Point(1335, 25), new Point(1518, 25)));
            this.points[5].Add(Tuple.Create(new Point(613, 25), new Point(796, 25)));
            this.points[6].Add(Tuple.Create(new Point(1762, 232), new Point(1579, 232)));
            this.points[6].Add(Tuple.Create(new Point(143, 232), new Point(326, 232)));
            this.points[6].Add(Tuple.Create(new Point(1848, 576), new Point(1665, 576)));
            this.points[6].Add(Tuple.Create(new Point(100, 576), new Point(270, 576)));
            this.points[6].Add(Tuple.Create(new Point(1335, 25), new Point(1518, 25)));
            this.points[6].Add(Tuple.Create(new Point(613, 25), new Point(430, 25)));
            this.points[6].Add(Tuple.Create(new Point(906, 25), new Point(1089, 25)));

        }

        private void CreatePicturesForPlayers()
        {
            this.initiliazeMainPictureBoxLocation();
            for(int i = 0;i<this.playersNumber-1; i++)
            {
                Point mainLocation = this.points[this.playersNumber-2].ElementAt(i).Item1;
                Point secondLocation = this.points[this.playersNumber - 2].ElementAt(i).Item2;
                int index = 1;

                PictureBox playerCard = new PictureBox();
                playerCard.Name = "playerCard_" + index.ToString();
                ((System.ComponentModel.ISupportInitialize)(playerCard)).BeginInit();
                playerCard.Size = new System.Drawing.Size(140, 180);
                playerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                playerCard.Image = (Image)Properties.Resources.ResourceManager.GetObject("playersCards");
                playerCard.BackColor = Color.Transparent;
                playerCard.Location = mainLocation;
                playerCard.Refresh();
                this.Controls.Add(playerCard);


                PictureBox playerCard2 = new PictureBox();
                playerCard2.Name = "playerCard2_" + index.ToString();
                ((System.ComponentModel.ISupportInitialize)(playerCard2)).BeginInit();
                playerCard2.Size = new System.Drawing.Size(140, 180);
                playerCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                playerCard2.BackColor = Color.Transparent;
                playerCard2.Location = secondLocation;
                playerCard2.Refresh();
                this.Controls.Add(playerCard2);


                Label showMoney = new Label();
                showMoney.Name = "showMoney_" + index.ToString();
                showMoney.Font = new System.Drawing.Font
                    ("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showMoney.Size = new System.Drawing.Size(140, 45);
                showMoney.Location = new System.Drawing.Point(mainLocation.X,mainLocation.Y+127);
                showMoney.Text = this.usernamsAndTheirMoney.ElementAt(i).Item2.ToString();
                showMoney.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(showMoney);


                Label showName = new Label();
                showName.Name = "showName_" + index.ToString();
                showName.Font = new System.Drawing.Font
                    ("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showName.Size = new System.Drawing.Size(187, 45);
                showName.Location = new System.Drawing.Point(mainLocation.X-24, mainLocation.Y + 172);
                showName.Text = this.usernamsAndTheirMoney.ElementAt(i).Item1;
                showName.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(showName);


                Label showAction = new Label();
                showAction.Name = "showAction_" + index.ToString();
                showAction.Font = new System.Drawing.Font
                    ("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                showAction.Size = new System.Drawing.Size(187, 40);
                showAction.Location = new System.Drawing.Point(mainLocation.X-24, mainLocation.Y + 232);
                showAction.Visible = false;
                showAction.Text = "";
                showAction.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(showAction);

                showMoney.BringToFront();
                showName.BringToFront();
                index++;

            }


        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            this.CreatePicturesForPlayers();
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                double ratio = this.Width / this.Height;
                int newWidth = (int)(resolutionRect.Width * 0.7);
                int newHeight = (int)(resolutionRect.Height * 0.7 * ratio);
                double ratioWidth = (double)newWidth / (double)this.Width;
                double ratioHeight = (double)newHeight / (double)this.Height;
                this.Width = newWidth;
                this.Height = newHeight;
                foreach (Control control in this.Controls)
                {
                    control.Width = (int)(control.Width * ratioWidth);
                    control.Height = (int)(control.Height * ratioHeight);
                    control.Left = (int)(control.Left * ratioWidth);
                    control.Top = (int)(control.Top * ratioHeight);
                    float fontSize = (float)(control.Font.Size * 0.7);
                    control.Font = new Font(control.Font.Name, fontSize);
                }
                

            }
        }
    }

}
