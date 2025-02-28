namespace quiz_app.DTO
{
    public class QuizDTO
    {
        public required Guid QuizRecordId { get; set; }
        public required string Question { get; set; }

        public required string[] Options { get; set; }

        public int CorrectOption { get; set; }

        public int Points { get; set; }
    }
}
