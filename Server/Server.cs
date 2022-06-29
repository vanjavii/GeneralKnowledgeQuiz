using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Domain;

namespace Server
{
    public class Server
    {
        private Socket listeningSocket;
        private List<ClientHandler> players = new List<ClientHandler>();
        public List<ClientHandler> Players { get => players; set => players = value; }

        public Server()
        {
            listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listeningSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            listeningSocket.Listen(5);
        }

        public bool StartGame(Quiz selectedQuiz, int numOfPlayers)
        {            
            while (numOfPlayers > 0)
            {
                Socket playerSocket = listeningSocket.Accept();
                ClientHandler player = new ClientHandler(playerSocket,players);
                
                if (player.LogPlayer())
                {
                    players.Add(player);
                    numOfPlayers--; 
                }
            }            
            selectedQuiz.Questions = Controller.Controller.Instance.getAllQuestionsForSelectedQuiz(selectedQuiz);
            List<Thread> threadList = new List<Thread>();
            foreach(ClientHandler ch in players)
            {
                Thread thread = new Thread(() => { ch.StartQuizForPlayer(selectedQuiz); });
                threadList.Add(thread);
                thread.Start();
            }
            foreach(Thread t in threadList)
            {
                t.Join();
            }

            AnnounceWinner();
            return true;
        }

        private void AnnounceWinner()
        {
            players = players.OrderByDescending(p => p.Total).ToList();
            ClientHandler winner = players.First();
            foreach(ClientHandler ch in players)
            {
                ch.AnnounceWinnerToAllParticipants(winner.PlayerUsername, winner.Total);
            }

        }
    }
}
