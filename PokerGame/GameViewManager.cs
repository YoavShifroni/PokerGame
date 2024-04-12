using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PokerGame
{
    public class GameViewManager
    {
        private ConnectionWithServer connectionWithServer;

        private static GameViewManager instance = null;

        public static GameViewManager getInstance(string ipAddress)
        {
            if(GameViewManager.instance != null)
            {
                return GameViewManager.instance;
            }
            if(ipAddress == null)
            {
                throw new ArgumentNullException("ip address cannot be null");
            }
            GameViewManager.instance = new GameViewManager(ipAddress);
            return GameViewManager.instance;
        }

        public void ProcessLogin(string username, string password)
        {
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.LOGIN;
            message.username = username;
            message.password = password;
            this.connectionWithServer.SendMessage(message.generate());
        }

        public void ProcessRegister(string username, string password, string firstName, string lastName, string email, string city, string gender)
        {
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.REGISTRATION;
            message.username = username;
            message.password = password;
            message.firstName = firstName;
            message.lastName = lastName;
            message.email = email;
            message.city = city;
            message.gender = gender;
            this.connectionWithServer.SendMessage(message.generate());
        }

        private GameViewManager(string ipAddress) {
            this.connectionWithServer = ConnectionWithServer.getInstance(ipAddress);
        }

        public void MoveToWaitingRoom(string username)
        {
            GameFormsHolder.getInstance().loginForm.Visible = false;
            GameFormsHolder.getInstance().registerForm.Visible = false;
            GameFormsHolder.getInstance().waitingRoom.Visible = true;
            GameFormsHolder.getInstance().gameBoard.username = username;
        }

        public void MoveToGameBoard(ClientServerProtocol clientServerProtocol)
        {
            GameFormsHolder.getInstance().gameBoard.playerMoney = clientServerProtocol.playerMoney;
            GameFormsHolder.getInstance().gameBoard.allTimeProfit = clientServerProtocol.allTimeProfit;
            GameFormsHolder.getInstance().gameBoard.playerIndex = clientServerProtocol.playerIndex;
            GameFormsHolder.getInstance().gameBoard.dealerIndex = clientServerProtocol.dealerIndex;
            GameFormsHolder.getInstance().gameBoard.smallBlindUsername = clientServerProtocol.smallBlindUsername;
            GameFormsHolder.getInstance().gameBoard.bigBlindUsername = clientServerProtocol.bigBlindUsername;
            GameFormsHolder.getInstance().gameBoard.playersNumber = clientServerProtocol.playersNumber;
            GameFormsHolder.getInstance().gameBoard.usernamsAndTheirMoney = new List<Tuple<string, int>>();
            string[] details = clientServerProtocol.allUserDetails.Split(',');
            for (int i = 0; i < details.Length; i = i + 2)
            {
                string username = details[i];
                int money = Convert.ToInt32(details[i + 1]);
                GameFormsHolder.getInstance().gameBoard.usernamsAndTheirMoney.Add(Tuple.Create(username, money));
            }

            GameFormsHolder.getInstance().waitingRoom.Visible = false;
            GameFormsHolder.getInstance().gameBoard.Visible = true;
            GameFormsHolder.getInstance().gameBoard.SetPlayerMoney();
        }

        public void CommandOpenCard(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.drawCrads(cards)));
        }

        public void CommandSuccess(string username)
        {
           GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToWaitingRoom(username)));
        }

        public void CommandUsernameOfConnectedPlayers(string AllUsernames)
        {
            GameFormsHolder.getInstance().waitingRoom.Invoke(new Action(() => GameFormsHolder.getInstance().waitingRoom.ShowValues(AllUsernames)));  
        }

        public void CommandStartGame(ClientServerProtocol clientServerProtocol)
        {
            GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToGameBoard(clientServerProtocol)));
        }

        public void CommandSendCardToPlayers(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.DrawPlayerCards(cards)));
        }

        public void CommandUpdateBetMoney(int betMoney, string username, string raiseType)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.sumBetMoney(
                    betMoney,username,raiseType)));
        }

        public void CommandYourTurn(int minimumBet)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.MyTurn(minimumBet)));
        }

        public void CommandTellEveryOneWhoWon(string username, string allPlayerAndCards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.TheWinnerIs(username, allPlayerAndCards)));
        }
    }
}
