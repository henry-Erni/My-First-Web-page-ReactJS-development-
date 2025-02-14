using System.ComponentModel.DataAnnotations;

namespace quiz_app.Entities
{
    public class Quizzes
    {
        [Key]
        public Guid QuizId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
