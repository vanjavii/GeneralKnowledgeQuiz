using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Question
    {
        public int QuizID { get; set; }
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public int NumOfPoints { get; set; }
        public bool IsAnswered { get; set; }
        public string WhoAnswered { get; set; }
    }
}
