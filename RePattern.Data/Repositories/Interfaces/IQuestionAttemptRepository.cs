using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface IQuestionAttemptRepository : IRepository<QuestionAttempt>
    {
        Task<List<QuestionAttempt>> GetLatestUserQuestionAttemptsAsync(int userId, CancellationToken cancellationToken);
    }
}
