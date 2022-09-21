namespace StackOverflowFunctionality.Entities
{
    public class Comment : DateAndPoints
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public Question Question { get; set; }
        public int QuestionCommentId { get; set; }
    }
}
