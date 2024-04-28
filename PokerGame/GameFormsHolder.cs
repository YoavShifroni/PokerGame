using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// <summary>
        /// the login form
        /// </summary>
        public LoginForm loginForm;
        /// <summary>
        /// the register form
        /// </summary>
        public RegisterForm registerForm;
        /// <summary>
        /// the rules form
        /// </summary>
        public RulesForm rulesForm;
        /// <summary>
        /// the forgot password form
        /// </summary>
        public ForgotPasswordForm forgotPasswordForm;
        /// <summary>
        /// the waiting room form
        /// </summary>
        public WaitingRoom waitingRoom;
        /// <summary>
        /// the game board form
        /// </summary>
        public GameBoard gameBoard;
        /// <summary>
        /// the instance of this class per singleton design pattern
        /// </summary>
        private static GameFormsHolder instance;
        /// <summary>
        /// Static getInstance method, as in Singleton patterns
        /// </summary>
        /// <returns></returns>

        [MethodImpl(MethodImplOptions.Synchronized)]
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
