using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    /// <summary>
    /// This singlton class holds all the forms of the client, so we can get easy access to a single
    /// instance of each form
    /// </summary>
    public class GameFormsHolder
    {
        public LoginForm loginForm;
        public RegisterForm registerForm;
        public RulesForm rulesForm;
        public ForgotPasswordForm forgotPasswordForm;
        public WaitingRoom waitingRoom;
        public GameBoard gameBoard;
        
        private static GameFormsHolder instance;
        /// <summary>
        /// Static getInstance method, as in Singleton patterns
        /// </summary>
        /// <returns></returns>
        public static GameFormsHolder getInstance()
        {
            if(GameFormsHolder.instance == null)
            {
                GameFormsHolder.instance = new GameFormsHolder();
            }
            return GameFormsHolder.instance;

        }

        /// <summary>
        /// the private constructor create all the forms that needed for the game
        /// </summary>
        private GameFormsHolder()
        {
            this.loginForm = new LoginForm();
            this.registerForm = new RegisterForm();
            this.rulesForm = new RulesForm();
            this.forgotPasswordForm = new ForgotPasswordForm();
            this.waitingRoom = new WaitingRoom();
            this.gameBoard = new GameBoard();
        }
    }
}
