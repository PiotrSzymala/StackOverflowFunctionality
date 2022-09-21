namespace StackOverflowFunctionality.Entities
{
    public abstract class DateAndPoints
    {
        public int Points { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
