using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class Comment : Date
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public Question Question { get; set; }
        public int QuestionCommentId { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
