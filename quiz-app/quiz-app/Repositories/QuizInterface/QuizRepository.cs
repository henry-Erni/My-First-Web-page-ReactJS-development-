using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories.QuizInterface
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<Quiz> CreateQuizAsync(QuizDTO data)
        {
            var QuizRecord = await _context.QuizRecords.FirstOrDefaultAsync(qr => qr.QuizRecordId == data.QuizRecordId);

            if (QuizRecord == null)
            {
                throw new InvalidOperationException("Invalid Quiz Record");
            }

            var quiz = new Quiz
            {
                QuizRecordId = data.QuizRecordId,
                Question = data.Question,
                Options = data.Options,
                CorrectOption = data.CorrectOption,
                Points = data.Points,
                QuizRecord = QuizRecord,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();

            return quiz;
        }
    }
}
