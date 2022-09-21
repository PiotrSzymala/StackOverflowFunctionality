namespace StackOverflowFunctionality.Entities
{
    public class Answer : DateAndPoints
    {
        public int Id { get; set; }
        public string Reply { get; set; }
        
        public User User { get; set; }
        public Guid AnswerAuthorId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
