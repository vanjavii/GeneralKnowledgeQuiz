using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Controller
    {
        private Broker broker = new Broker();
        
        private static Controller instance;

        private Controller()
        {

        }

        public static Controller Instance
        {
            get{
                if (instance == null) instance = new Controller();
                return instance;
            }            
        }

        public List<Quiz> GetAllQuizzes()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllQuizzes();
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Question> getAllQuestionsForSelectedQuiz(Quiz q)
        {
            try
            {
                broker.OpenConnection();
                return broker.getAllQuestionsForSelectedQuiz(q);
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
