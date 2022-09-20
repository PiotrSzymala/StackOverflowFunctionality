using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Points { get; set; }

        public Answer Answer { get; set; }
        public int  AnswerRatingId { get; set; }

        public Question Question { get; set; }
        public int QuestionRatingId { get; set; }

    }
}
