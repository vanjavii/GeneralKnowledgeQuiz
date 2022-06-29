using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Quiz
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public string Winner { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public List<Question> Questions { get; set; }


        public override string ToString()
        {
            return QuizName; 
        }
    }
}
