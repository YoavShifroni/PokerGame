namespace PokerGame
{
    partial class GameBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.playerFirstCardPictureBox = new System.Windows.Forms.PictureBox();
            this.raiseButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.foldButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.playerSecondCardPictureBox = new System.Windows.Forms.PictureBox();
            this.firstCardPictureBox = new System.Windows.Forms.PictureBox();
            this.secondCardPictureBox = new System.Windows.Forms.PictureBox();
            this.thirdCardPictureBox = new System.Windows.Forms.PictureBox();
            this.forthCardPictureBox = new System.Windows.Forms.PictureBox();
            this.fifthCardPictureBox = new System.Windows.Forms.PictureBox();
            this.MoneyTheClientHaveLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.reduceButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.betButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.theWinnerIsLabel = new System.Windows.Forms.Label();
            this.playerTurnLabel = new System.Windows.Forms.Label();
            this.totalMoneyLabel = new System.Windows.Forms.Label();
            this.allTimeProfitLabel = new System.Windows.Forms.Label();
            this.countDownTimer = new System.Windows.Forms.Timer(this.components);
            this.timerForNextGameLabel = new System.Windows.Forms.Label();
            this.nextGameTimer = new System.Windows.Forms.Timer(this.components);
            this.myNameLabel = new System.Windows.Forms.Label();
            this.youAreTheDealerLabel = new PokerGame.LabelCircle();
            this.turnTimeLabel = new PokerGame.LabelCircle();
            ((System.ComponentModel.ISupportInitialize)(this.playerFirstCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSecondCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forthCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fifthCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playerFirstCardPictureBox
            // 
            this.playerFirstCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.playerFirstCardPictureBox.Location = new System.Drawing.Point(858, 745);
            this.playerFirstCardPictureBox.Name = "playerFirstCardPictureBox";
            this.playerFirstCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.playerFirstCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerFirstCardPictureBox.TabIndex = 1;
            this.playerFirstCardPictureBox.TabStop = false;
            this.playerFirstCardPictureBox.Visible = false;
            // 
            // raiseButton
            // 
            this.raiseButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.raiseButton.Enabled = false;
            this.raiseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raiseButton.Location = new System.Drawing.Point(1240, 966);
            this.raiseButton.Name = "raiseButton";
            this.raiseButton.Size = new System.Drawing.Size(236, 165);
            this.raiseButton.TabIndex = 2;
            this.raiseButton.Text = "Raise";
            this.raiseButton.UseVisualStyleBackColor = false;
            this.raiseButton.Click += new System.EventHandler(this.raiseButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.checkButton.Enabled = false;
            this.checkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton.Location = new System.Drawing.Point(918, 966);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(236, 165);
            this.checkButton.TabIndex = 3;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = false;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // foldButton
            // 
            this.foldButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.foldButton.Enabled = false;
            this.foldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foldButton.Location = new System.Drawing.Point(600, 966);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(236, 165);
            this.foldButton.TabIndex = 4;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = false;
            this.foldButton.Click += new System.EventHandler(this.foldButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(1528, 981);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(292, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // playerSecondCardPictureBox
            // 
            this.playerSecondCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.playerSecondCardPictureBox.Location = new System.Drawing.Point(1055, 745);
            this.playerSecondCardPictureBox.Name = "playerSecondCardPictureBox";
            this.playerSecondCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.playerSecondCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerSecondCardPictureBox.TabIndex = 6;
            this.playerSecondCardPictureBox.TabStop = false;
            this.playerSecondCardPictureBox.Visible = false;
            // 
            // firstCardPictureBox
            // 
            this.firstCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.firstCardPictureBox.Location = new System.Drawing.Point(1482, 430);
            this.firstCardPictureBox.Name = "firstCardPictureBox";
            this.firstCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.firstCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstCardPictureBox.TabIndex = 7;
            this.firstCardPictureBox.TabStop = false;
            this.firstCardPictureBox.Visible = false;
            // 
            // secondCardPictureBox
            // 
            this.secondCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.secondCardPictureBox.Location = new System.Drawing.Point(1227, 430);
            this.secondCardPictureBox.Name = "secondCardPictureBox";
            this.secondCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.secondCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secondCardPictureBox.TabIndex = 8;
            this.secondCardPictureBox.TabStop = false;
            this.secondCardPictureBox.Visible = false;
            // 
            // thirdCardPictureBox
            // 
            this.thirdCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.thirdCardPictureBox.Location = new System.Drawing.Point(965, 430);
            this.thirdCardPictureBox.Name = "thirdCardPictureBox";
            this.thirdCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.thirdCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thirdCardPictureBox.TabIndex = 9;
            this.thirdCardPictureBox.TabStop = false;
            this.thirdCardPictureBox.Visible = false;
            // 
            // forthCardPictureBox
            // 
            this.forthCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.forthCardPictureBox.Location = new System.Drawing.Point(698, 430);
            this.forthCardPictureBox.Name = "forthCardPictureBox";
            this.forthCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.forthCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.forthCardPictureBox.TabIndex = 10;
            this.forthCardPictureBox.TabStop = false;
            this.forthCardPictureBox.Visible = false;
            // 
            // fifthCardPictureBox
            // 
            this.fifthCardPictureBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.fifthCardPictureBox.Location = new System.Drawing.Point(433, 430);
            this.fifthCardPictureBox.Name = "fifthCardPictureBox";
            this.fifthCardPictureBox.Size = new System.Drawing.Size(138, 178);
            this.fifthCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fifthCardPictureBox.TabIndex = 11;
            this.fifthCardPictureBox.TabStop = false;
            this.fifthCardPictureBox.Visible = false;
            // 
            // MoneyTheClientHaveLabel
            // 
            this.MoneyTheClientHaveLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoneyTheClientHaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneyTheClientHaveLabel.Location = new System.Drawing.Point(25, 943);
            this.MoneyTheClientHaveLabel.Name = "MoneyTheClientHaveLabel";
            this.MoneyTheClientHaveLabel.Size = new System.Drawing.Size(423, 59);
            this.MoneyTheClientHaveLabel.TabIndex = 13;
            this.MoneyTheClientHaveLabel.Text = "Current Money: ";
            this.MoneyTheClientHaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.Info;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(1528, 1057);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 61);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Add 10";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // reduceButton
            // 
            this.reduceButton.BackColor = System.Drawing.SystemColors.Info;
            this.reduceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reduceButton.Location = new System.Drawing.Point(1682, 1057);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(138, 61);
            this.reduceButton.TabIndex = 16;
            this.reduceButton.Text = "Reduce 10";
            this.reduceButton.UseVisualStyleBackColor = false;
            this.reduceButton.Visible = false;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // valueTextBox
            // 
            this.valueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueTextBox.Location = new System.Drawing.Point(1858, 981);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(177, 45);
            this.valueTextBox.TabIndex = 17;
            this.valueTextBox.Text = "0";
            this.valueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.valueTextBox.Visible = false;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // betButton
            // 
            this.betButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.betButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.betButton.Location = new System.Drawing.Point(1858, 1057);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(177, 61);
            this.betButton.TabIndex = 18;
            this.betButton.Text = "Bet";
            this.betButton.UseVisualStyleBackColor = false;
            this.betButton.Visible = false;
            this.betButton.Click += new System.EventHandler(this.betButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(634, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 92);
            this.label1.TabIndex = 20;
            this.label1.Text = "money on the table: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // theWinnerIsLabel
            // 
            this.theWinnerIsLabel.BackColor = System.Drawing.Color.White;
            this.theWinnerIsLabel.Font = new System.Drawing.Font("David", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theWinnerIsLabel.ForeColor = System.Drawing.Color.Black;
            this.theWinnerIsLabel.Location = new System.Drawing.Point(3, 9);
            this.theWinnerIsLabel.Name = "theWinnerIsLabel";
            this.theWinnerIsLabel.Size = new System.Drawing.Size(467, 171);
            this.theWinnerIsLabel.TabIndex = 23;
            this.theWinnerIsLabel.Text = "And The Winner Is 🥁🥁🥁: ";
            this.theWinnerIsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.theWinnerIsLabel.Visible = false;
            // 
            // playerTurnLabel
            // 
            this.playerTurnLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerTurnLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playerTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTurnLabel.ForeColor = System.Drawing.Color.White;
            this.playerTurnLabel.Location = new System.Drawing.Point(1753, 13);
            this.playerTurnLabel.Name = "playerTurnLabel";
            this.playerTurnLabel.Size = new System.Drawing.Size(317, 91);
            this.playerTurnLabel.TabIndex = 24;
            this.playerTurnLabel.Text = "It\'s not your turn right now";
            this.playerTurnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalMoneyLabel
            // 
            this.totalMoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMoneyLabel.Location = new System.Drawing.Point(1126, 333);
            this.totalMoneyLabel.Name = "totalMoneyLabel";
            this.totalMoneyLabel.Size = new System.Drawing.Size(250, 40);
            this.totalMoneyLabel.TabIndex = 26;
            this.totalMoneyLabel.Text = "0";
            this.totalMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // allTimeProfitLabel
            // 
            this.allTimeProfitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allTimeProfitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allTimeProfitLabel.Location = new System.Drawing.Point(25, 1022);
            this.allTimeProfitLabel.Name = "allTimeProfitLabel";
            this.allTimeProfitLabel.Size = new System.Drawing.Size(423, 59);
            this.allTimeProfitLabel.TabIndex = 27;
            this.allTimeProfitLabel.Text = "All time profit: ";
            this.allTimeProfitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countDownTimer
            // 
            this.countDownTimer.Interval = 1000;
            this.countDownTimer.Tick += new System.EventHandler(this.countDownTimer_Tick);
            // 
            // timerForNextGameLabel
            // 
            this.timerForNextGameLabel.Font = new System.Drawing.Font("Segoe UI Variable Display", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerForNextGameLabel.Location = new System.Drawing.Point(594, 966);
            this.timerForNextGameLabel.Name = "timerForNextGameLabel";
            this.timerForNextGameLabel.Size = new System.Drawing.Size(882, 165);
            this.timerForNextGameLabel.TabIndex = 31;
            this.timerForNextGameLabel.Text = "Next Game Will Start In:  ";
            this.timerForNextGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timerForNextGameLabel.Visible = false;
            // 
            // nextGameTimer
            // 
            this.nextGameTimer.Interval = 1000;
            this.nextGameTimer.Tick += new System.EventHandler(this.nextGameTimer_Tick);
            // 
            // myNameLabel
            // 
            this.myNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myNameLabel.Location = new System.Drawing.Point(25, 1100);
            this.myNameLabel.Name = "myNameLabel";
            this.myNameLabel.Size = new System.Drawing.Size(423, 59);
            this.myNameLabel.TabIndex = 32;
            this.myNameLabel.Text = "Name:";
            this.myNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // youAreTheDealerLabel
            // 
            this.youAreTheDealerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.youAreTheDealerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youAreTheDealerLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.youAreTheDealerLabel.Location = new System.Drawing.Point(1431, 714);
            this.youAreTheDealerLabel.Name = "youAreTheDealerLabel";
            this.youAreTheDealerLabel.Size = new System.Drawing.Size(177, 157);
            this.youAreTheDealerLabel.TabIndex = 30;
            this.youAreTheDealerLabel.Text = "Dealer";
            this.youAreTheDealerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.youAreTheDealerLabel.Visible = false;
            // 
            // turnTimeLabel
            // 
            this.turnTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.turnTimeLabel.Location = new System.Drawing.Point(1906, 129);
            this.turnTimeLabel.Name = "turnTimeLabel";
            this.turnTimeLabel.Size = new System.Drawing.Size(164, 123);
            this.turnTimeLabel.TabIndex = 29;
            this.turnTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.turnTimeLabel.Visible = false;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2082, 1168);
            this.Controls.Add(this.myNameLabel);
            this.Controls.Add(this.timerForNextGameLabel);
            this.Controls.Add(this.youAreTheDealerLabel);
            this.Controls.Add(this.turnTimeLabel);
            this.Controls.Add(this.allTimeProfitLabel);
            this.Controls.Add(this.totalMoneyLabel);
            this.Controls.Add(this.playerTurnLabel);
            this.Controls.Add(this.theWinnerIsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.betButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.MoneyTheClientHaveLabel);
            this.Controls.Add(this.fifthCardPictureBox);
            this.Controls.Add(this.forthCardPictureBox);
            this.Controls.Add(this.thirdCardPictureBox);
            this.Controls.Add(this.secondCardPictureBox);
            this.Controls.Add(this.firstCardPictureBox);
            this.Controls.Add(this.playerSecondCardPictureBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.foldButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.raiseButton);
            this.Controls.Add(this.playerFirstCardPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameBoard_FormClosing);
            this.Load += new System.EventHandler(this.GameBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerFirstCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSecondCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forthCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fifthCardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox playerFirstCardPictureBox;
        private System.Windows.Forms.Button raiseButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button foldButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox playerSecondCardPictureBox;
        private System.Windows.Forms.PictureBox firstCardPictureBox;
        private System.Windows.Forms.PictureBox secondCardPictureBox;
        private System.Windows.Forms.PictureBox thirdCardPictureBox;
        private System.Windows.Forms.PictureBox forthCardPictureBox;
        private System.Windows.Forms.PictureBox fifthCardPictureBox;
        private System.Windows.Forms.Label MoneyTheClientHaveLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button reduceButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button betButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label theWinnerIsLabel;
        private System.Windows.Forms.Label playerTurnLabel;
        private System.Windows.Forms.Label totalMoneyLabel;
        private System.Windows.Forms.Label allTimeProfitLabel;
        private System.Windows.Forms.Timer countDownTimer;
        private LabelCircle turnTimeLabel;
        private LabelCircle youAreTheDealerLabel;
        private System.Windows.Forms.Label timerForNextGameLabel;
        private System.Windows.Forms.Timer nextGameTimer;
        private System.Windows.Forms.Label myNameLabel;
    }
}