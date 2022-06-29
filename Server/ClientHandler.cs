using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        NetworkStream stream;
        BinaryFormatter formatter;
        private readonly Socket socket;
        private readonly List<ClientHandler> players;
        private string playerUsername;
        private double total = 0;
        
        public string PlayerUsername { get; private set; }
        public int NumOfCorrect { get; set; }
        public int NumOfIncorrect { get; set; }
        public double Total { get; private set; }

        public ClientHandler(Socket socket, List<ClientHandler> players)
        {
            this.socket = socket;
            this.players = players;
            stream = new NetworkStream(socket);
            formatter = new BinaryFormatter();             
        }

        public bool LogPlayer()
        {
            Request request = (Request)formatter.Deserialize(stream);
            Response response = new Response();

            foreach (ClientHandler ch in players)
            {
                if (ch.PlayerUsername == request.Username)
                {
                    response.UsernameSignal = Signal.UsernameAlreadyTaken;
                    formatter.Serialize(stream, response);
                    return false;
                }
            }
            response.UsernameSignal = Signal.OK;
            formatter.Serialize(stream, response);
            PlayerUsername = request.Username;
            return true;
        }

        public void StartQuizForPlayer(Quiz quiz)
        {
            try
            {
                foreach (Question q in quiz.Questions)
                {
                    Response newQuestion = new Response();
                    newQuestion.Question = q.QuestionText;
                    formatter.Serialize(stream, newQuestion);

                    Request request = (Request)formatter.Deserialize(stream);

                    Response numOfPoints = GetPoints(q, request.Answer.ToUpper());
                    formatter.Serialize(stream, numOfPoints);
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Some of the players closed the form!", "Error message", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                //throw;
            }
        }

        private Response GetPoints(Question q, string answer)
        {
            Response response = new Response();
            if (q.CorrectAnswer == answer && !q.IsAnswered)
            {
                q.IsAnswered = true;
                q.WhoAnswered = PlayerUsername;
                response.Points = q.NumOfPoints;
                response.PorukaOdServera = "CORRECT!";
                NumOfCorrect++;
            }
            else if (q.CorrectAnswer == answer && q.IsAnswered)
            {
                response.Points = 0;
                response.PorukaOdServera = $"CORRECT, BUT '{q.WhoAnswered.ToUpper()}' ALREADY ANSWERED CORRECTLY!";
                NumOfCorrect++;
            }
            else
            {
                response.Points = -0.1 * q.NumOfPoints;
                response.PorukaOdServera = "INCORRECT!";
                NumOfIncorrect++;
            }
            Total += response.Points;
            return response;
        }


        internal void AnnounceWinnerToAllParticipants(string winnerUsername, double totalPoints)
        {
            try
            {
                Response winner = new Response();
                winner.Winner = winnerUsername;
                winner.Points = totalPoints;
                winner.Question = $"THE WINNER IS : {winner.Winner.ToUpper()} ({winner.Points} POINTS)!";
                formatter.Serialize(stream, winner);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Some of the players closed the form!", "Error message", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //throw;
            }
        }
    }
}
