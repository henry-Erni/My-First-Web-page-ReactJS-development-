using Microsoft.EntityFrameworkCore;
using quiz_app.Entities;

namespace quiz_app.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<QuizRecord> QuizRecords { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizRecord>()
                .HasOne(qr => qr.User)
                .WithMany(u => u.QuizRecords)
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.QuizRecord)
                .WithMany(qr => qr.Quizzes)
                .HasForeignKey(q => q.QuizRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
