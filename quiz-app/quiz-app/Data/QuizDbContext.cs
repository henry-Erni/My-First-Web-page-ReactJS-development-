using Microsoft.EntityFrameworkCore;
using quiz_app.Entities;

namespace quiz_app.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
    }
}
