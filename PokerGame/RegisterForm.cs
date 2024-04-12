using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PokerGame
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string checkIp = this.serverIpTextBox.Text;
            string[] check = checkIp.Split('.');
            if (check.Length != 4)
            {
                MessageBox.Show("check the server Ip");
                return;
            }
            if (this.isFilled())
            {
                ClientServerProtocol protocol = new ClientServerProtocol();
                protocol.command = Command.REGISTRATION;
                protocol.username = usernameTextBox.Text;
                protocol.password = passwordTextBox.Text;
                protocol.firstName = firstNameTextBox.Text;
                protocol.lastName = lastNameTextBox.Text;
                protocol.email = emailTextBox.Text;
                protocol.city = cityComboBox.Text;
                protocol.gender = genderComboBox.Text;
                GameViewManager.getInstance(this.serverIpTextBox.Text).ProcessRegister(usernameTextBox.Text, passwordTextBox.Text,
                    firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, cityComboBox.Text, genderComboBox.Text);        
            }
        }

       

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
            this.passwordTextBox.Text = "";
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.emailTextBox.Text = "";
            this.serverIpTextBox.Text = "";
            this.cityComboBox.SelectedIndex = -1;
            this.genderComboBox.SelectedIndex = -1;

        }

        private void backToLoginLabel_Click(object sender, EventArgs e)
        {
            GameFormsHolder.getInstance().loginForm.Visible = true;
            this.Visible = false;
        }

        private bool isFilled()
        {
            if (usernameTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix name, Registration Failed");
                return false;
            }
            if (!this.IsValidPassword(passwordTextBox.Text))
            {
                MessageBox.Show("fix password, Registration Failed");
                return false;

            }
            if (firstNameTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix firstName, Registration Failed");
                return false;
            }
            if (lastNameTextBox.Text.Length <= 1)
            {
                MessageBox.Show("fix lastName, Registration Failed");
                return false;
            }
            if (!this.IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("fix email, Registration Failed");
                return false;
            }
            if (cityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("choose city, Registration Failed");
                return false;
            }
            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("choose gender, Registration Failed");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            string s = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$";
            Regex regex = new Regex(s);
            if (regex.IsMatch(password))
            {
                return true;
            }
            return false;

        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                this.passwordTextBox.PasswordChar = '\0';
            }
            else
            {
                this.passwordTextBox.PasswordChar = '•';
            }
        }
    }
}
