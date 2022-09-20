using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class Answer : Date
    {
        public int Id { get; set; }
        public string Reply { get; set; }
        
        public User User { get; set; }
        public Guid AnswerAuthorId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public Rating Rating { get; set; }
    }
}
