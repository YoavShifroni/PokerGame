namespace PokerGame
{
    partial class WaitingRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingRoom));
            this.StartButton = new System.Windows.Forms.Button();
            this.NumberOfConnectedPlayersLabel = new System.Windows.Forms.Label();
            this.UsernamesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.StartButton.Enabled = false;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(567, 690);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(361, 160);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NumberOfConnectedPlayersLabel
            // 
            this.NumberOfConnectedPlayersLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumberOfConnectedPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfConnectedPlayersLabel.ForeColor = System.Drawing.Color.White;
            this.NumberOfConnectedPlayersLabel.Location = new System.Drawing.Point(1042, 9);
            this.NumberOfConnectedPlayersLabel.Name = "NumberOfConnectedPlayersLabel";
            this.NumberOfConnectedPlayersLabel.Size = new System.Drawing.Size(414, 349);
            this.NumberOfConnectedPlayersLabel.TabIndex = 1;
            this.NumberOfConnectedPlayersLabel.Text = "Number Of Players Connected:  ";
            this.NumberOfConnectedPlayersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernamesLabel
            // 
            this.UsernamesLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernamesLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.UsernamesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernamesLabel.ForeColor = System.Drawing.Color.White;
            this.UsernamesLabel.Location = new System.Drawing.Point(0, 0);
            this.UsernamesLabel.Name = "UsernamesLabel";
            this.UsernamesLabel.Size = new System.Drawing.Size(458, 881);
            this.UsernamesLabel.TabIndex = 2;
            this.UsernamesLabel.Text = "Connected Players Username:";
            this.UsernamesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.UsernamesLabel);
            this.Controls.Add(this.NumberOfConnectedPlayersLabel);
            this.Controls.Add(this.StartButton);
            this.DoubleBuffered = true;
            this.Name = "WaitingRoom";
            this.Text = "WaitingRoom";
            this.Load += new System.EventHandler(this.WaitingRoom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label NumberOfConnectedPlayersLabel;
        private System.Windows.Forms.Label UsernamesLabel;
    }
}