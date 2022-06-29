using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {
        private Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private static Communication instance;

        private Communication()
        {

        }

        public static Communication Instance
        {
            get
            {
                if (instance == null) instance = new Communication();
                return instance;
            }
        }

        public void Login(string username)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            stream = new NetworkStream(socket);
            formatter = new BinaryFormatter();
            Request request = new Request { Username = username };
            formatter.Serialize(stream, request);
            Response response = (Response)formatter.Deserialize(stream);
            if (response.UsernameSignal == Signal.OK)
            {
                System.Windows.Forms.MessageBox.Show("Successfully connected! Waiting...", "Quiz state", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                socket.Close();                
                throw new Exception("This username is already used! Try new username!");
            }
        }

        internal Response ReadMessageFromServer()
        {
            return (Response)formatter.Deserialize(stream);
        }

        internal void SendMessage(Request answer)
        {
            formatter.Serialize(stream, answer);
        }        
    }
}
