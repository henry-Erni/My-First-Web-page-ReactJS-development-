using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories.QuizRecordInterface
{
    public interface IQuizRecordRepository
    {
        Task<QuizRecord> CreateQuizRecordAsync(QuizRecordDTO data);
        Task<List<QuizRecord>> GetQuizRecordsAsync(UserQuizRecordsDTO data);

        Task<Guid> DeleteQuizRecordAsync(Guid userId);
    }
}
