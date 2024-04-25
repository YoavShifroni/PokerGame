using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class ForgotPasswordForm : Form
    {
        private string username;

        /// <summary>
        /// the constructor calls the InitializeComponent that create the ForgotPassword form
        /// and its controls
        /// </summary>
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when someone click the checkButton this function is called and check that the code is similar to the code
        /// that the player got in his email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkButton_Click(object sender, EventArgs e)
        {
            if (!GameViewManager.getInstance(null).code.Equals(this.codeTextBox.Text))
            {
                MessageBox.Show("check the code that you entered, it's not similer to the code that you recived in the email");
                return;
            }
            this.checkButton.Enabled = false;
            this.passwordLabel.Visible = true;
            this.passwordTextBox.Visible = true;
            this.confirmPasswordLabel.Visible = true;
            this.confirmPasswordTextBox.Visible = true;
            this.showPasswordCheckBox.Visible = true;
            this.loginButton.Visible = true;
            this.clearButton.Visible = true;
        }

        /// <summary>
        /// when someone click the showPassword checkBox it shows/ hide the passwordTextBox and the confirmPassowordTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                this.passwordTextBox.PasswordChar = '\0';
                this.confirmPasswordTextBox.PasswordChar= '\0';
            }
            else
            {
                this.passwordTextBox.PasswordChar = '•';
                this.confirmPasswordTextBox.PasswordChar = '•';
            }
        }


        /// <summary>
        /// when someone click the login button this function is called and if all things ae ok the function send message to the server with
        /// the command UPDATE_PASSWORD, the username and the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!this.passwordTextBox.Text.Equals(this.confirmPasswordTextBox.Text))
            {
                MessageBox.Show("the passwords that you wrote aren't the same, please check again :)");
                return;
            }
            if (!RegisterForm.IsValidPassword(this.passwordTextBox.Text))
            {
                MessageBox.Show("fix your password that it will contain at least one capital leater, one small letter, one digit and one sign");
                return;
            }
            ClientServerProtocol message = new ClientServerProtocol();
            message.command = Command.UPDATE_PASSWORD;
            message.username = GameViewManager.getInstance(null).username;
            message.newPassword = this.passwordTextBox.Text;
            GameViewManager.getInstance(null).connectionWithServer.SendMessage(message.generate());
            this.Visible = false;


        }

        /// <summary>
        /// this function called when someone is closing the GameBoardForm, when someone is closing the GameBoardForm 
        /// it will open the login form again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForgotPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            GameFormsHolder.getInstance().loginForm.Visible = true;
        }
    }
}
