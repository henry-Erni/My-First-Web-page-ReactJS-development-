using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Repositories.QuizInterface
{
    public interface IQuizRepository
    {
        //Task<Quiz> GetQuizAsync(Guid quizId);
        Task<Quiz> CreateQuizAsync(QuizDTO data);
      
        //Task<Quiz> UpdateQuizAsync(Guid quizId, QuizDTO quiz);
        //Task<Quiz> DeleteQuizAsync(Guid quizId);
    }
}
