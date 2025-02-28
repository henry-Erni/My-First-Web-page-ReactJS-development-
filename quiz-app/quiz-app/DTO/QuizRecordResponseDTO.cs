namespace quiz_app.DTO
{
    public class QuizRecordResponseDTO
    {
        public required Guid UserId { get; set; }
        public required Guid QuizRecordId { get; set; }
        public required string QuizRecordName { get; set; }
    }
}
