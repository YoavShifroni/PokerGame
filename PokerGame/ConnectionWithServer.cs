using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
     public class ConnectionWithServer
     {
        /// <summary>
        /// the port number
        /// </summary>
        private const int portNo = 500;
        /// <summary>
        /// actual TCP connection between the client and the server
        /// </summary>
        private TcpClient client;
        /// <summary>
        /// the memory we allocate to recive things from the server and sending things to the server
        /// </summary>
        private byte[] data;
        /// <summary>
        /// HandleCommandFromServer object
        /// </summary>
        private HandleCommandsFromServer handleCommandsFromServer;
        /// <summary>
        /// the instance of this class per singleton design pattern
        /// </summary>
        private static ConnectionWithServer instance = null;

        /// <summary>
        /// This function cleans up the class by removing the static instance
        /// </summary>
        public static void Destroy()
        {
            ConnectionWithServer.instance = null;
        }
        /// <summary>
        /// SingleTon pattern - we need to have only 1 instance of this class in the client
        /// </summary>
        /// <param name="ipAddress">The IP address of the server</param>
        /// <returns></returns>
        public static ConnectionWithServer getInstance(string ipAddress)
        {
            if(instance == null)
            {
                if(ipAddress == null)
                {
                    throw new ArgumentNullException("ip address cannot be null when instance is null");
                }
                instance = new ConnectionWithServer(ipAddress);
            }
            return instance;
        }
        
        /// <summary>
        /// Private constructor of the class, as per Singleton pattern
        /// </summary>
        /// <param name="ipAddress"></param>
        private ConnectionWithServer(string ipAddress)
        {
            this.handleCommandsFromServer = new HandleCommandsFromServer();
            client = new TcpClient();
            client.Connect(ipAddress, portNo);
            data = new byte[client.ReceiveBufferSize];
            client.GetStream().BeginRead(data,
                                                 0,
                                                 System.Convert.ToInt32(client.ReceiveBufferSize),
                                                 ReceiveMessage,
                                                 null);
        }
        /// <summary>
        /// This function sends a message (string) to the server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// This function is the endless loop of reading messages that the server sends to the client
        /// In case the TCP connection is disconnected, it will show a message box with an error
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    MessageBox.Show("You are disconnected");
                    GameViewManager.getInstance(null).StopGame();
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string textFromServer = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] lines = textFromServer.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < lines.Length; j++)
                    {
                        handleCommandsFromServer.handleCommand(lines[j]);

                    }
                }

                // continue reading
                client.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(client.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // ignore the error... fired when the user loggs off

            }
        }
    }
}
