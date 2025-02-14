namespace quiz_app.DTO
{
    public class QuizResponseDTO
    {
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public string? CreatedBy { get; set; }
    }
}
