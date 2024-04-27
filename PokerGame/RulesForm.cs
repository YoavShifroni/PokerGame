using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    public partial class RulesForm : Form
    {
        /// <summary>
        /// the constructor is call the InitializeComponent that create the Rules form
        /// and his controls
        /// </summary>
        public RulesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if someone clicks the goToRegisterLabel this function will send him to the Register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToRegisterLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GameFormsHolder.getInstance().registerForm.Visible = true;
        }

        /// <summary>
        /// if someone clicks the goToLoginLabel this function will send him to the Login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToLoginLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GameFormsHolder.getInstance().loginForm.Visible = true;
        }
    }
}
