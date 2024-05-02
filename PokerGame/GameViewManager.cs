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
    /// <summary>
    /// This class manages the game - passes the view from one form to another and handles all commands from the server
    /// </summary>
    public class GameViewManager
    {
        /// <summary>
        /// ConnectionWithServer object
        /// </summary>
        public ConnectionWithServer connectionWithServer;
        /// <summary>
        /// the code that sent to the client email
        /// </summary>
        public string code;
        /// <summary>
        /// the username of the client that forgot his password
        /// </summary>
        public string username;
        /// <summary>
        /// the instance of this class per singleton design pattern
        /// </summary>
        private static GameViewManager instance = null;
        
        /// <summary>
        /// Destroy the instance when we're done playing
        /// </summary>
        public static void Destroy()
        {
            GameViewManager.instance = null;
            ConnectionWithServer.Destroy();
        }

        /// <summary>
        /// Singleton pattern - we need a single instance of this class as it creates a TCP connection with the server and 
        /// each client needs to hold only 1 TCP connection
        /// </summary>
        /// <param name="ipAddress">IP address of the server</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        [MethodImpl(MethodImplOptions.Synchronized)]
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
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
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
        /// <param name="username">The new username</param>
        /// <param name="password">The new password</param>
        /// <param name="firstName">The new First name</param>
        /// <param name="lastName">The new Last name</param>
        /// <param name="email">The new email address</param>
        /// <param name="city">The new city</param>
        /// <param name="gender">The new gender</param>
        public void ProcessRegister(string username, string password, string firstName, string lastName, string email
            , string city,string gender)
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
        /// <param name="username">Username that forget their password</param>
        public void ProcessForgotPassword(string username)
        {
            this.code = this.randomCode();
            this.username = username;
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.FORGOT_PASSWORD;
            message.username = username;
            message.code = this.code;
            this.connectionWithServer.SendMessage(message.generate());
        }

        /// <summary>
        /// the function return random password (code) that contains at least one capital letter
        /// , one small letter, one digit and one specific sign
        /// </summary>
        /// <returns>The random code to verify with the user</returns>
        public string randomCode()
        {
            var charsALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz#?!@$%^&*-";
            var randomIns = new Random();
            var rndChars = Enumerable.Range(0, 6)
                            .Select(_ => charsALL[randomIns.Next(charsALL.Length)])
                            .ToArray();
            return new string(rndChars);
        }


        /// <summary>
        /// the private constructor create the connection with the server
        /// </summary>
        /// <param name="ipAddress">The IP address of the server</param>
        private GameViewManager(string ipAddress)
        {
            this.connectionWithServer = ConnectionWithServer.getInstance(ipAddress);
        }

        /// <summary>
        /// the function is called when someone succesfly login/ register and will move them
        /// to the WaitingRoom form
        /// </summary>
        /// <param name="username">The username</param>
        public void MoveToWaitingRoom(string username)
        {
            GameFormsHolder.getInstance().loginForm.Visible = false;
            GameFormsHolder.getInstance().registerForm.Visible = false;
            GameFormsHolder.getInstance().waitingRoom.Visible = true;
            GameFormsHolder.getInstance().gameBoard.username = username;
        }

        /// <summary>
        /// the function is called when someone successfuly press the StartButton and will move the client
        /// to the GameBoard form and fill the nececery information for the player
        /// </summary>
        /// <param name="clientServerProtocol">The ClientServerProtocol received from the server</param>
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
            GameFormsHolder.getInstance().gameBoard.SetPlayerMoney();
            GameFormsHolder.getInstance().gameBoard.CreatePicturesForPlayers();
            GameFormsHolder.getInstance().gameBoard.ResetBoard();
            GameFormsHolder.getInstance().waitingRoom.Visible = false;
            GameFormsHolder.getInstance().gameBoard.Visible = true;
            if(GameFormsHolder.getInstance().gameBoard.isFirstGame == false)
            {
                GameFormsHolder.getInstance().gameBoard.GameBoard_Load(null,null);
            }
            
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command OPEN_CARDS
        /// and will call the function drawCards
        /// </summary>
        /// <param name="cards">The cards to show</param>
        public void CommandOpenCard(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.drawCrads(cards)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command SUCCESS
        /// and will call the function MoveToWaitingRoom
        /// </summary>
        /// <param name="username">The username</param>
        public void CommandSuccess(string username)
        {
           GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToWaitingRoom(username)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command
        /// USERNAME_OF_CONNECTED_PLAYERS, and will call the function ShowValues
        /// </summary>
        /// <param name="AllUsernames">All the usernames that are playing</param>
        public void CommandUsernameOfConnectedPlayers(string AllUsernames)
        {
            GameFormsHolder.getInstance().waitingRoom.Invoke(new Action(() => GameFormsHolder.getInstance().waitingRoom.ShowValues(AllUsernames)));  
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command START_GAME
        /// and will call the function MoveToGameBoard
        /// </summary>
        /// <param name="clientServerProtocol">The ClientServerProtocol received from the server</param>
        public void CommandStartGame(ClientServerProtocol clientServerProtocol)
        {
            GameFormsHolder.getInstance().loginForm.Invoke(new Action(() => this.MoveToGameBoard(clientServerProtocol)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command
        /// SEND_STARTING_CARD_TO_PLAYER, and will call the function DrawPlayerCards
        /// </summary>
        /// <param name="cards">The cards that the user has</param>
        public void CommandSendCardToPlayers(string[] cards)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.DrawPlayerCards(cards)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command
        /// UPDATE_BET_MONEY, and will call the function sumBetMoney
        /// </summary>
        /// <param name="betMoney">The new bet money</param>
        /// <param name="username">The username that made that bet</param>
        /// <param name="raiseType">The type of that raise that the user did</param>
        public void CommandUpdateBetMoney(int betMoney, string username, string raiseType)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.sumBetMoney(
                    betMoney,username,raiseType)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command YOUR_TURN
        /// and will call the function MyTurn
        /// </summary>
        /// <param name="minimumBet">The minimal bet value</param>
        public void CommandYourTurn(int minimumBet)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.MyTurn(minimumBet)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command
        /// TELL_EVERYONE_WHO_WON, and will call the function TheWinnerIs
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="allPlayerAndCards">All users with their cards</param>
        /// <param name="oneWinnerName">The username of the winner</param>
        public void CommandTellEveryOneWhoWon(string username, string allPlayerAndCards, string oneWinnerName)
        {
            GameFormsHolder.getInstance().gameBoard.Invoke(new Action(() => GameFormsHolder.getInstance().gameBoard.TheWinnerIs(username, allPlayerAndCards, oneWinnerName)));
        }

        /// <summary>
        /// the function is called when the client receives from the server the Command NOTIFY_TURN,
        /// and will call the function NotifyTurn
        /// </summary>
        /// <param name="username">The username</param>
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
