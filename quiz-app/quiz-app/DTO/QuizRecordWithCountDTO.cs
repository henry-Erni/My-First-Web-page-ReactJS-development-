namespace quiz_app.DTO
{
    public class QuizRecordWithCountDTO
    {
        public Guid QuizRecordId { get; set; }
        public required string QuizRecordName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public int QuizCount { get; set; } 
    }
}
