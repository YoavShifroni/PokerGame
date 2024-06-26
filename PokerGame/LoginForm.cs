﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PokerGame
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// the constructor call the InitializeComponent which create the Login form and his controls
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when someone clicks the login button this function check if the feilds for the logins are fill corectly and if there are fill
        /// corectly the functiuon send to the server the information to check if the user is in the system 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                GameViewManager.getInstance(serverIpTextBox.Text).isFromLogin = true ;

            }
            else
            {
                MessageBox.Show("your username/ password is to short!");
            }
        }

        /// <summary>
        /// when someone clicks the clear button the function clear all fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
            this.passwordTextBox.Text = "";
            this.serverIpTextBox.Text = "";
            this.serverIpTextBox.Focus();
            
        }

        /// <summary>
        /// when someone clicks the showPassword checkBox it shows/ hide the password text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// if someone clicks the goToRegister label this function will send him to the Register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToRegister_Click(object sender, EventArgs e)
        {
            GameFormsHolder.getInstance().registerForm.Visible = true;
            this.Visible = false;
        }

        /// <summary>
        /// if someone clicks the changePasswordLabel this function will send to the server the Command that will tell him 
        /// to send to this client email his new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePasswordLabel_Click(object sender, EventArgs e)
        {
            IPAddress iPAddress = null;
            if(usernameTextBox.Text.Length <= 1 || !IPAddress.TryParse(serverIpTextBox.Text, out iPAddress))
            {
                MessageBox.Show("please fill your username and server ip first");
                return;
            }
            GameViewManager.getInstance(serverIpTextBox.Text).ProcessForgotPassword(usernameTextBox.Text);
            MessageBox.Show("email with code was sent to you right now, check your email and enter the code in the right place");
            GameFormsHolder.getInstance().forgotPasswordForm.Visible = true;
            this.Visible = false;

        }


        /// <summary>
        /// if someone clicks the rulesBookPictureBox this function will send him to the Rules Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulesBookPictureBox_Click(object sender, EventArgs e)
        {
            GameFormsHolder.getInstance().rulesForm.Visible = true;
            this.Visible = false;
        }

        
    }
}
