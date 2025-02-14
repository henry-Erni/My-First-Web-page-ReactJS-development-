using System.ComponentModel.DataAnnotations;

namespace quiz_app.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Quiz>? Quizzes { get; set; }
    }
}
