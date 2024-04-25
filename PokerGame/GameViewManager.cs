using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PokerGame
{
    public class GameViewManager
    {
        private ConnectionWithServer connectionWithServer;

        private static GameViewManager instance = null;
        
        
        public static void Destroy()
        {
            GameViewManager.instance = null;
            ConnectionWithServer.Destroy();
        }

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

        /// <summary>
        /// the function is called when the player clicked the login button and will send to the server
        /// the Command LOGIN with the right parameters
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void ProcessLogin(string username, string password)
        {
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.LOGIN;
            message.username = username;
            message.password = password;
            this.connectionWithServer.SendMessage(message.generate());
        }

        /// <summary>
        /// the function is called when the player clicked the register button and will send to the server
        /// the Command REGISTER with the right parameters
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="city"></param>
        /// <param name="gender"></param>
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

        /// <summary>
        /// the function is called when the player clicked the forgotPasswordButton button and will send
        /// to the server the Command FORGOT_PASSWORD with the right parameters
        /// </summary>
        /// <param name="username"></param>
        public void ProcessForgotPassword(string username)
        {
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.FORGOT_PASSWORD;
            message.username = username;
            this.connectionWithServer.SendMessage(message.generate());
        }

        /// <summary>
        /// the constructor create the connection with the server
        /// </summary>
        /// <param name="ipAddress"></param>
        private GameViewManager(string ipAddress) {
            this.connectionWithServer = ConnectionWithServer.getInstance(ipAddress);
        }

        /// <summary>
        /// the function is called when someone succesfly login/ register and will move him
        /// to the WaitingRoom form
        /// </summary>
        /// <param name="username"></param>
        public void MoveToWaitingRoom(string username)
        {
            GameFormsHolder.getInstance().loginForm.Visible = false;
            GameFormsHolder.getInstance().registerForm.Visible = false;
            GameFormsHolder.getInstance().waitingRoom.Visible = true;
            GameFormsHolder.getInstance().gameBoard.username = username;
        }

        /// <summary>
        /// the function is called when someone succesfly press the StartButton and will move the client
        /// to the GameBoard form and fill the nececery information for the player
        /// </summary>
        /// <param name="clientServerProtocol"></param>
        public void MoveToGameBoard(ClientServerProtocol clientServerProtocol)
        {
            GameFormsHolder.getInstance().gameBoard.playerMoney = clientServerProtocol.playerMoney;
            GameFormsHolder.getInstance().gameBoard.allTimeProfit = clientServerProtocol.allTimeProfit;
            GameFormsHolder.getInstance().gameBoard.dealerUsername = clientServerProtocol.dealerName;
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
            GameFormsHolder.getInstance().gameBoard.CreatePicturesForPlayers();
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command OPEN_CARDS
        /// and will call the function drawCards
        /// </summary>
        /// <param name="cards"></param>
        public void CommandOpenCard(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.drawCrads(cards)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command SUCCESS
        /// and will call the function MoveToWaitingRoom
        /// </summary>
        /// <param name="username"></param>
        public void CommandSuccess(string username)
        {
           GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToWaitingRoom(username)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command
        /// USERNAME_OF_CONNECTED_PLAYERS, and will call the function ShowValues
        /// </summary>
        /// <param name="AllUsernames"></param>
        public void CommandUsernameOfConnectedPlayers(string AllUsernames)
        {
            GameFormsHolder.getInstance().waitingRoom.Invoke(new Action(() => GameFormsHolder.getInstance().waitingRoom.ShowValues(AllUsernames)));  
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command START_GAME
        /// and will call the function MoveToGameBoard
        /// </summary>
        /// <param name="clientServerProtocol"></param>
        public void CommandStartGame(ClientServerProtocol clientServerProtocol)
        {
            GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToGameBoard(clientServerProtocol)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command
        /// SEND_STARTING_CARD_TO_PLAYER, and will call the function DrawPlayerCards
        /// </summary>
        /// <param name="cards"></param>
        public void CommandSendCardToPlayers(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.DrawPlayerCards(cards)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command
        /// UPDATE_BET_MONEY, and will call the function sumBetMoney
        /// </summary>
        /// <param name="betMoney"></param>
        /// <param name="username"></param>
        /// <param name="raiseType"></param>
        public void CommandUpdateBetMoney(int betMoney, string username, string raiseType)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.sumBetMoney(
                    betMoney,username,raiseType)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command YOUR_TURN
        /// and will call the function MyTurn
        /// </summary>
        /// <param name="minimumBet"></param>
        public void CommandYourTurn(int minimumBet)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.MyTurn(minimumBet)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command
        /// TELL_EVERYONE_WHO_WON, and will call the function TheWinnerIs
        /// </summary>
        /// <param name="username"></param>
        /// <param name="allPlayerAndCards"></param>
        /// <param name="oneWinnerName"></param>
        public void CommandTellEveryOneWhoWon(string username, string allPlayerAndCards, string oneWinnerName)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.TheWinnerIs(username, allPlayerAndCards, oneWinnerName)));
        }

        /// <summary>
        /// the function is called when the client recive from the server the Command NOTIFY_TURN,
        /// and will call the function NotifyTurn
        /// </summary>
        /// <param name="username"></param>
        public void CommandNotifyTurn(string username)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.NotifyTurn(username)));

        }

        /// <summary>
        /// the function is called when you don't have any money the continue to the next round,
        /// the function will close the board window and will open the login window
        /// </summary>
        public void StopGame()
        {
            MessageBox.Show("you are out of money. bye bye");
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.GameBoard_FormClosing(null,null)));
            GameViewManager.Destroy();
        }

        /// <summary>
        /// the function is called when you are the only player that have money in the game,
        /// the function will close the board wndpow and will open the login window
        /// </summary>
        public void CommandFinalWinner()
        {
            MessageBox.Show("you are the final winner congratulations, you can login to the game again if you want to");
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.GameBoard_FormClosing(null, null)));
            GameViewManager.Destroy();
        }
    }
}
