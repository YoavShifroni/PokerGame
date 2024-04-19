namespace PokerGame
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.dontHaveAnAccountLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.backToLoginLabel = new System.Windows.Forms.Label();
            this.serverIpTextBox = new System.Windows.Forms.TextBox();
            this.serverIpLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("David", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(34, 289);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.Size = new System.Drawing.Size(216, 25);
            this.passwordTextBox.TabIndex = 9;
            this.passwordTextBox.Text = "Yh123!";
            this.passwordTextBox.WordWrap = false;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(31, 269);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(66, 17);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.Font = new System.Drawing.Font("David", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(34, 214);
            this.usernameTextBox.Multiline = true;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(216, 25);
            this.usernameTextBox.TabIndex = 7;
            this.usernameTextBox.Text = "yoav";
            this.usernameTextBox.WordWrap = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(31, 195);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(69, 17);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.startLabel.Location = new System.Drawing.Point(29, 65);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(155, 27);
            this.startLabel.TabIndex = 5;
            this.startLabel.Text = "Get Started";
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(131, 320);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(119, 21);
            this.showPasswordCheckBox.TabIndex = 10;
            this.showPasswordCheckBox.Text = "Show Password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.showPasswordCheckBox_CheckedChanged);
            // 
            // dontHaveAnAccountLabel
            // 
            this.dontHaveAnAccountLabel.AutoSize = true;
            this.dontHaveAnAccountLabel.Location = new System.Drawing.Point(67, 513);
            this.dontHaveAnAccountLabel.Name = "dontHaveAnAccountLabel";
            this.dontHaveAnAccountLabel.Size = new System.Drawing.Size(147, 17);
            this.dontHaveAnAccountLabel.TabIndex = 22;
            this.dontHaveAnAccountLabel.Text = "Dont Have an Account";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.clearButton.Location = new System.Drawing.Point(34, 452);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(216, 35);
            this.clearButton.TabIndex = 21;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(34, 398);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(216, 35);
            this.loginButton.TabIndex = 20;
            this.loginButton.Text = "LOGIN";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // backToLoginLabel
            // 
            this.backToLoginLabel.AutoSize = true;
            this.backToLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.backToLoginLabel.Location = new System.Drawing.Point(96, 541);
            this.backToLoginLabel.Name = "backToLoginLabel";
            this.backToLoginLabel.Size = new System.Drawing.Size(76, 17);
            this.backToLoginLabel.TabIndex = 23;
            this.backToLoginLabel.Text = "Create One";
            this.backToLoginLabel.Click += new System.EventHandler(this.backToLoginLabel_Click);
            // 
            // serverIpTextBox
            // 
            this.serverIpTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.serverIpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverIpTextBox.Font = new System.Drawing.Font("David", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIpTextBox.Location = new System.Drawing.Point(34, 146);
            this.serverIpTextBox.Multiline = true;
            this.serverIpTextBox.Name = "serverIpTextBox";
            this.serverIpTextBox.Size = new System.Drawing.Size(216, 25);
            this.serverIpTextBox.TabIndex = 25;
            this.serverIpTextBox.Text = "127.0.0.1";
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Location = new System.Drawing.Point(31, 126);
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(63, 17);
            this.serverIpLabel.TabIndex = 24;
            this.serverIpLabel.Text = "Server Ip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Forgot your password -";
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.AutoSize = true;
            this.changePasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.changePasswordLabel.Location = new System.Drawing.Point(178, 356);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(70, 17);
            this.changePasswordLabel.TabIndex = 27;
            this.changePasswordLabel.Text = "Click Here";
            this.changePasswordLabel.Click += new System.EventHandler(this.changePasswordLabel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 602);
            this.Controls.Add(this.changePasswordLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverIpTextBox);
            this.Controls.Add(this.serverIpLabel);
            this.Controls.Add(this.backToLoginLabel);
            this.Controls.Add(this.dontHaveAnAccountLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.startLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
        private System.Windows.Forms.Label dontHaveAnAccountLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label backToLoginLabel;
        private System.Windows.Forms.TextBox serverIpTextBox;
        private System.Windows.Forms.Label serverIpLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label changePasswordLabel;
    }
}