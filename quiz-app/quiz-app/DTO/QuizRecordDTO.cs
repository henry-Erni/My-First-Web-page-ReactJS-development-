namespace quiz_app.DTO
{
    public class QuizRecordDTO
    {
        public required Guid UserId { get; set; }
        public required string QuizRecordName { get; set; }
    }
}
