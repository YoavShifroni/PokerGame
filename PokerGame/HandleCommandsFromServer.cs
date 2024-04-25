using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public class HandleCommandsFromServer
    {

        public HandleCommandsFromServer() 
        {
            
        }

        /// <summary>
        /// when the client recive some new message frrom the server this function is called and
        /// check what is the Command that recived from the message and call to the right function
        /// </summary>
        /// <param name="command"></param>
        public void handleCommand(string command)
        {
            Console.WriteLine(command);
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol(command);
            if (clientServerProtocol.command.Equals(Command.OPEN_CARDS)) 
            {
                GameViewManager.getInstance(null).CommandOpenCard(clientServerProtocol.cards);
            }
            if (clientServerProtocol.command.Equals(Command.SUCCES))
            {
                GameViewManager.getInstance(null).CommandSuccess(clientServerProtocol.username);
            }
            if (clientServerProtocol.command.Equals(Command.USERNAME_OF_CONNECTED_PLAYERS))
            {
                GameViewManager.getInstance(null).CommandUsernameOfConnectedPlayers(clientServerProtocol.AllUsernames);
            }
            if (clientServerProtocol.command.Equals(Command.START_GAME))
            {
                GameViewManager.getInstance(null).CommandStartGame(clientServerProtocol);
            }
            if (clientServerProtocol.command.Equals(Command.SEND_STARTING_CARDS_TO_PLAYER))
            {
                GameViewManager.getInstance(null).CommandSendCardToPlayers(clientServerProtocol.cards);
            }
            if(clientServerProtocol.command.Equals(Command.UPDATE_BET_MONEY))
            {
                GameViewManager.getInstance(null).CommandUpdateBetMoney(clientServerProtocol.betMoney,
                    clientServerProtocol.username,
                    clientServerProtocol.raiseType);
            }
            if (clientServerProtocol.command.Equals(Command.YOUR_TURN))
            {
                GameViewManager.getInstance(null).CommandYourTurn(clientServerProtocol.minimumBet);
            }
            if (clientServerProtocol.command.Equals(Command.NOTIFY_TURN))
            {
                GameViewManager.getInstance(null).CommandNotifyTurn(clientServerProtocol.username);
            }
            if (clientServerProtocol.command.Equals(Command.TELL_EVERYONE_WHO_WON))
            {
                GameViewManager.getInstance(null).CommandTellEveryOneWhoWon(clientServerProtocol.username
                    , clientServerProtocol.allPlayersAndCards, clientServerProtocol.oneWinnerName);
            }
            if (clientServerProtocol.command.Equals(Command.ERROR))
            {
                MessageBox.Show(clientServerProtocol.message);
            }
            if (clientServerProtocol.command.Equals(Command.FINAL_WINNER))
            {
                GameViewManager.getInstance(null).CommandFinalWinner();
            }


        }
    }
}
