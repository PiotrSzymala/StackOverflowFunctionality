using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowFunctionality.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
