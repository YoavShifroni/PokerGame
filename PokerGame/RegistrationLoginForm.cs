using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class RegistrationLoginForm : Form
    {
        private ConnectionWithServer connectionWithServer;
        public GameBoard gameBoard {  get; set; }
        public WaitingRoom waitingRoom { get; set; }
        public RegistrationLoginForm()
        {
            this.waitingRoom = new WaitingRoom(this);
            this.gameBoard = new GameBoard();
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (this.isFilled())
            {
                connectionWithServer = ConnectionWithServer.getInstance(IpTextBox.Text, this);
                ClientServerProtocol protocol = new ClientServerProtocol();
                protocol.command = Command.REGISTRATION;
                protocol.username = userTextBox.Text;
                protocol.password = passwordTextBox.Text;
                protocol.firstName = firstNTextBox.Text;
                protocol.lastName = lastNTextBox.Text;
                protocol.email = emailTextBox.Text;
                protocol.city = cityComboBox.Text;
                protocol.gender = genderComboBox.Text;
                connectionWithServer.SendMessage(protocol.generate());
            }
            else
            {
                MessageBox.Show("some fields are missing/ not filled correctly!!");
            }

        }

        public void MoveToWaitingRoom(string username)
        {
            this.Visible = false;
            this.waitingRoom.Visible = true;
            this.gameBoard.username = username;
        }

        public void MoveToGameBoard(ClientServerProtocol clientServerProtocol)
        {
            this.gameBoard.playerMoney = clientServerProtocol.playerMoney;
            this.gameBoard.allTimeProfit = clientServerProtocol.allTimeProfit;
            this.gameBoard.playerIndex = clientServerProtocol.playerIndex;
            this.gameBoard.dealerIndex = clientServerProtocol.dealerIndex;
            this.gameBoard.smallBlindIndex = clientServerProtocol.smallBlindIndex;
            this.gameBoard.bigBlindIndex = clientServerProtocol.bigBlindIndex;
            this.gameBoard.playersNumber = clientServerProtocol.playersNumber;
            this.gameBoard.usernamsAndTheirMoney = new List<Tuple<string, int>>();
            string[] details = clientServerProtocol.allUserDetails.Split(',');
            for (int i = 0; i < details.Length; i = i + 2)
            {
                string username = details[i];
                int money = Convert.ToInt32(details[i + 1]);
                this.gameBoard.usernamsAndTheirMoney.Add(Tuple.Create(username, money));
            }

            this.waitingRoom.Visible = false;
            this.gameBoard.Visible = true;

            this.gameBoard.SetPlayerMoney();
        }



        private void loginButton_Click(object sender, EventArgs e)
        {

            if(userTextBox2.Text.Length > 1 && passwordTextBox2.Text.Length > 1)
            {
                connectionWithServer = ConnectionWithServer.getInstance(IpTextBox.Text, this);
                ClientServerProtocol protocol = new ClientServerProtocol();
                protocol.command = Command.LOGIN;
                protocol.username = userTextBox2.Text;
                protocol.password = passwordTextBox2.Text;
                connectionWithServer.SendMessage(protocol.generate());
            }
            else
            {
                MessageBox.Show("your username/ password is to short!");
            }
        }

        public bool isFilled()
        {
            if(userTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix name");
                return false;
            }
            if(!this.IsValidPassword(passwordTextBox.Text))
            {
                MessageBox.Show("fix password");
                return false;

            }
            if (firstNTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix firstName");
                return false;
            }
            if (lastNTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix lastName");
                return false;
            }
            if (!this.IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("fix email");
                return false;
            }
            if (cityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("fix city");
                return false;
            }
            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("fix gender");
                return false;
            }
            MessageBox.Show("nice!");
            return true;
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPassword(string password) 
        {
            string s = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$";
            Regex regex = new Regex(s);
            if(regex.IsMatch(password))
            {
                return true;
            }
            return false;

        }

       
    }
}
