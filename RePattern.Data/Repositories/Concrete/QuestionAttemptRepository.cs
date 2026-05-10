using Microsoft.EntityFrameworkCore;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class QuestionAttemptRepository(ApplicationDbContext dbContext) : Repository<QuestionAttempt>(dbContext), IQuestionAttemptRepository
    {
        public async Task<List<QuestionAttempt>> GetLatestUserQuestionAttemptsAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.QuestionAttempts
                .Include(qa => qa.TestExecution)
                .Include(qa => qa.TestQuestion)
                    .ThenInclude(t => t.Answers)
                .Where(qa => qa.TestExecution.UserId == userId)
                .GroupBy(qa => qa.TestQuestionId)
                .Select(g => g
                    .OrderByDescending(x => x.TestExecution.CompletedAt)
                    .First())
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
