namespace PokerGame
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.startLabel = new System.Windows.Forms.Label();
            this.goToRegisterLabel = new System.Windows.Forms.Label();
            this.goToLoginLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.startLabel.Location = new System.Drawing.Point(142, 48);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(289, 48);
            this.startLabel.TabIndex = 6;
            this.startLabel.Text = "Poker Rules ";
            // 
            // goToRegisterLabel
            // 
            this.goToRegisterLabel.AutoSize = true;
            this.goToRegisterLabel.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToRegisterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.goToRegisterLabel.Location = new System.Drawing.Point(478, 806);
            this.goToRegisterLabel.Name = "goToRegisterLabel";
            this.goToRegisterLabel.Size = new System.Drawing.Size(155, 30);
            this.goToRegisterLabel.TabIndex = 24;
            this.goToRegisterLabel.Text = "Go To Register";
            this.goToRegisterLabel.Click += new System.EventHandler(this.goToRegisterLabel_Click);
            // 
            // goToLoginLabel
            // 
            this.goToLoginLabel.AutoSize = true;
            this.goToLoginLabel.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.goToLoginLabel.Location = new System.Drawing.Point(38, 806);
            this.goToLoginLabel.Name = "goToLoginLabel";
            this.goToLoginLabel.Size = new System.Drawing.Size(132, 30);
            this.goToLoginLabel.TabIndex = 25;
            this.goToLoginLabel.Text = "Go To Login";
            this.goToLoginLabel.Click += new System.EventHandler(this.goToLoginLabel_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 640);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 0);
            this.label1.MaximumSize = new System.Drawing.Size(580, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 850);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 856);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.goToLoginLabel);
            this.Controls.Add(this.goToRegisterLabel);
            this.Controls.Add(this.startLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RulesForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label goToRegisterLabel;
        private System.Windows.Forms.Label goToLoginLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}