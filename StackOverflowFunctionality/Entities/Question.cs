namespace StackOverflowFunctionality.Entities
{
    public class Question : DateAndPoints
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
      
        public List<Comment> Comments { get; set; } = new List<Comment>();
       
        public User User { get; set; }
        public Guid QuestionAuthorId { get; set; }

        public List<Answer> Answers { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
