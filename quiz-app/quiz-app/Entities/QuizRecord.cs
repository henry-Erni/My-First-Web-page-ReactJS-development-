using System.ComponentModel.DataAnnotations;

namespace quiz_app.Entities
{
    public class QuizRecord
    {

        [Key]
        public Guid QuizRecordId { get; set; }

        public required string QuizRecordName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public required ICollection<Quiz> Quizzes { get; set; }

        public Guid UserId { get; set; }

        public required User User { get; set; }
    }
}
