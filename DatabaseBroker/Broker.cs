using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {        
        SQLiteConnection connection;

        public Broker()
        {    
            connection = new SQLiteConnection(@"Data Source = \.\QuizDB.sqlite3;Version=3");            
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {            
            connection.Close();
        }

        public List<Quiz> GetAllQuizzes()
        {
            List<Quiz> quizzes = new List<Quiz>();            
            SQLiteCommand command = new SQLiteCommand("", connection);
            command.CommandText = "select * from quiz";
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Quiz q = new Quiz()
                {
                    QuizID = reader.GetInt32(0),
                    QuizName = reader.GetString(1)
                };
                quizzes.Add(q);                
            }
            return quizzes;
        }

        public List<Question> getAllQuestionsForSelectedQuiz(Quiz quiz)
        {
            List<Question> questions = new List<Question>();            
            SQLiteCommand command = new SQLiteCommand("", connection);
            command.CommandText = $"select * from question where quizid={quiz.QuizID}";
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Question q = new Question
                {
                    QuizID=reader.GetInt32(0),
                    QuestionID=reader.GetInt32(1),
                    QuestionText=reader.GetString(2),
                    CorrectAnswer=reader.GetString(3),
                    NumOfPoints=reader.GetInt32(4)
                };
                questions.Add(q);
            }
            return questions;
        }

    }
}
