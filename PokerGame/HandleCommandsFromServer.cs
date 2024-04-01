using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    internal class HandleCommandsFromServer
    {
        private RegistrationLoginForm registrationLoginForm;
        public HandleCommandsFromServer(RegistrationLoginForm registrationLoginForm) 
        {
            this.registrationLoginForm = registrationLoginForm;
        }

        public void handleCommand(string command)
        {
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol(command);
            if (clientServerProtocol.command.Equals(Command.OPEN_CARDS))
            {
                this.registrationLoginForm.gameBoard.Invoke(new Action(() => this.registrationLoginForm.gameBoard.drawCrads(clientServerProtocol.cards)));
            }
            if (clientServerProtocol.command.Equals(Command.SUCCES))
            {
                this.registrationLoginForm.Invoke(new Action(() => this.registrationLoginForm.MoveToWaitingRoom(clientServerProtocol.username)));
            }
            if (clientServerProtocol.command.Equals(Command.USERNAME_OF_CONNECTED_PLAYERS))
            {
                this.registrationLoginForm.waitingRoom.Invoke(new Action(() => this.registrationLoginForm.waitingRoom.ShowValues(clientServerProtocol.AllUsernames)));
            }
            if (clientServerProtocol.command.Equals(Command.START_GAME))
            {
                this.registrationLoginForm.Invoke(new Action(() => this.registrationLoginForm.MoveToGameBoard(clientServerProtocol)));
            }
            if(clientServerProtocol.command.Equals(Command.SEND_STARTING_CARDS_TO_PLAYER))
            {
                this.registrationLoginForm.gameBoard.Invoke(new Action(() => this.registrationLoginForm.gameBoard.DrawPlayerCards(clientServerProtocol.cards)));
            }
            if(clientServerProtocol.command.Equals(Command.UPDATE_BET_MONEY))
            {
                this.registrationLoginForm.gameBoard.Invoke(new Action(() => this.registrationLoginForm.gameBoard.sumBetMoney(
                    clientServerProtocol.betMoney, 
                    clientServerProtocol.username, 
                    clientServerProtocol.raiseType)));
            }
            if (clientServerProtocol.command.Equals(Command.YOUR_TURN))
            {
                this.registrationLoginForm.gameBoard.Invoke(new Action(() => this.registrationLoginForm.gameBoard.MyTurn(clientServerProtocol.minimumBet)));
            }
            if (clientServerProtocol.command.Equals(Command.TELL_EVERYONE_WHO_WON))
            {
                this.registrationLoginForm.gameBoard.Invoke(new Action(() => this.registrationLoginForm.gameBoard.TheWinnerIs(clientServerProtocol.username)));
            }


        }
    }
}
