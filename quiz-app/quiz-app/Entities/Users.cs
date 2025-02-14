using System.ComponentModel.DataAnnotations;

namespace quiz_app.Entities
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }

        public required string Username { get; set; }

        public required string HashedPassword { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } 

    }
}
