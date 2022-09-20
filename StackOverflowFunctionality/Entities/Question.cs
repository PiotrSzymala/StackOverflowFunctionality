using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class Question : Date
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
      
        public List<Comment> Comments { get; set; } = new List<Comment>();
       
        public User User { get; set; }
        public Guid QuestionAuthorId { get; set; }

        public List<Answer> Answers { get; set; }

        public Rating Rating { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
