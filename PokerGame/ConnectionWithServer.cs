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
        private const int portNo = 500;
        private TcpClient client;
        private byte[] data;
        private HandleCommandsFromServer handleCommandsFromServer;
        private static ConnectionWithServer instance = null;

        public static ConnectionWithServer getInstance(string ipAddress)
        {
            if(instance == null)
            {
                instance = new ConnectionWithServer(ipAddress);
            }
            return instance;
        }

        public static ConnectionWithServer getOpenInstance()
        {
            return instance;
        }

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
                // ignor the error... fired when the user loggs off

            }
        }
    }
}
