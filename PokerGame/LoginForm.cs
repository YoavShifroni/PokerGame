using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PokerGame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string checkIp = this.serverIpTextBox.Text;
            string[] check = checkIp.Split('.');
            if(check.Length != 4)
            {
                MessageBox.Show("check the server Ip");
                return;
            }
            if (usernameTextBox.Text.Length > 1 && passwordTextBox.Text.Length > 1)
            {
                GameViewManager.getInstance(serverIpTextBox.Text).ProcessLogin(usernameTextBox.Text, passwordTextBox.Text);
            }
            else
            {
                MessageBox.Show("your username/ password is to short!");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
            this.passwordTextBox.Text = "";
            this.serverIpTextBox.Text = "";
            this.serverIpTextBox.Focus();
            
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(showPasswordCheckBox.Checked)
            {   
                this.passwordTextBox.PasswordChar = '\0';
            }
            else
            {
                this.passwordTextBox.PasswordChar = '•';
            }
        }

        private void backToLoginLabel_Click(object sender, EventArgs e)
        {
            GameFormsHolder.getInstance().registerForm.Visible = true;
            this.Visible = false;
        }

        private void changePasswordLabel_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text.Length <= 1)
            {
                MessageBox.Show("please fill your username first");
                return;
            }
            GameViewManager.getInstance(serverIpTextBox.Text).ProcessForgotPassword(usernameTextBox.Text);
            MessageBox.Show("email with a new password was sent to you right now, check your email and login");

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
