using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{

    public class GameFormsHolder
    {
        public LoginForm loginForm;
        public RegisterForm registerForm;
        public WaitingRoom waitingRoom;
        public GameBoard gameBoard;
        private static GameFormsHolder instance;

        public static GameFormsHolder getInstance()
        {
            if(GameFormsHolder.instance == null)
            {
                GameFormsHolder.instance = new GameFormsHolder();
            }
            return GameFormsHolder.instance;

        }

        private GameFormsHolder()
        {
            this.loginForm = new LoginForm();
            this.registerForm = new RegisterForm();
            this.waitingRoom = new WaitingRoom();
            this.gameBoard = new GameBoard();
        }


    }
}
