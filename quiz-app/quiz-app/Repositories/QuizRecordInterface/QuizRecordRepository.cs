using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories.QuizRecordInterface
{
    public class QuizRecordRepository(QuizDbContext context) : IQuizRecordRepository
    {

        private readonly QuizDbContext _context = context;

        public async Task<QuizRecord> CreateQuizRecordAsync(QuizRecordDTO data)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == data.UserId) ?? throw new InvalidOperationException("Invalid User");
            var existingRecord = await _context.QuizRecords.FirstOrDefaultAsync(qr => qr.QuizRecordName == data.QuizRecordName && qr.UserId == data.UserId);

            if (existingRecord != null)
            {
                throw new InvalidOperationException("Quiz Record Name already exist");
            }

            var quizRecord = new QuizRecord
            {
                QuizRecordId = Guid.NewGuid(),
                QuizRecordName = data.QuizRecordName,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                UserId = data.UserId,
                User = user,
                Quizzes = [],
                
            };

            await _context.QuizRecords.AddAsync(quizRecord);
            await _context.SaveChangesAsync();

            return quizRecord;
            
        }

        
        public async Task<Guid> DeleteQuizRecordAsync(Guid recordId)
        {
            var quizRecord = await _context.QuizRecords
                .FirstOrDefaultAsync(qr => qr.QuizRecordId == recordId) ?? throw new KeyNotFoundException("Quiz record not found or you do not have permission to delete this record.");
            _context.QuizRecords.Remove(quizRecord);
            await _context.SaveChangesAsync();

            return quizRecord.QuizRecordId;
        }
        public async Task<List<QuizRecord>> GetQuizRecordsAsync(UserQuizRecordsDTO data)
        {
            
            var response = await _context.QuizRecords.Where(qr => qr.UserId == data.UserId).ToListAsync();
        


            return response;
        }
    }
}
