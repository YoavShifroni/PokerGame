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
    public partial class WaitingRoom : Form
    {

        public WaitingRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when someone click the StartButton or someone call this function, the function send to the server the command StartGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void StartButton_Click(object sender, EventArgs e)
        {
            ClientServerProtocol clientServerProtocol = new ClientServerProtocol();
            clientServerProtocol.command = Command.START_GAME;
            ConnectionWithServer.getOpenInstance().SendMessage(clientServerProtocol.generate());
        }

        /// <summary>
        /// this function add to the UsernamesLabel the usernames of all the connected players and change the number that
        /// the NumberOfConnectedPlayersLabel show to the number of connected players that are right now in the Waiting room.
        /// the function also change the Enable of the StartButton to be true only if there are bettwen 2 to 8 connected player 
        /// </summary>
        /// <param name="connectedUsernames"></param>
        public void ShowValues(string connectedUsernames)
        {
            string[] answer = connectedUsernames.Split(',');
            int count = 0;
            this.UsernamesLabel.Text = "Connected Players Username:";
            for (int i = 0; i<answer.Length; i++)
            {
                count++;
                this.UsernamesLabel.Text += Environment.NewLine + answer[i]  ;
            }
            if(this.NumberOfConnectedPlayersLabel.Text.Length > 29)
            {
                string onlyTheNumber = this.NumberOfConnectedPlayersLabel.Text.Substring(29);
                int numberOfConnectedPlayers = 0;
                if (onlyTheNumber.Length>1)
                {
                    numberOfConnectedPlayers = Convert.ToInt32(onlyTheNumber);
                }
                numberOfConnectedPlayers += count;
                this.NumberOfConnectedPlayersLabel.Text = "Number Of Players Connected: " + numberOfConnectedPlayers.ToString();
            }

            if(count>=2 && count<=8)
            {
                this.StartButton.Enabled = true;
            }
            else 
            {
                this.StartButton.Enabled = false;
            }
        }

        /// <summary>
        /// this function change the size of the WaitingRoom Form if the resolution of your screen is to small to show all 
        /// the WaitingRoom form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitingRoom_Load(object sender, EventArgs e)
        {
           
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                double ratio = this.Width / this.Height;
                int newWidth = (int) (resolutionRect.Width * 0.8);
                int newHeight = (int) (resolutionRect.Height * 0.8 * ratio);
                double ratioWidth = (double) newWidth / (double) this.Width;
                double ratioHeight = (double) newHeight / (double) this.Height;
                this.Width = newWidth;
                this.Height = newHeight;
                foreach (Control control in this.Controls)
                {
                    control.Width =  (int) (control.Width * ratioWidth);
                    control.Height = (int)(control.Height * ratioHeight);
                    control.Left = (int) (control.Left * ratioWidth);
                    control.Top = (int) (control.Top * ratioHeight);
                }


            }
        }

        
    }
}
