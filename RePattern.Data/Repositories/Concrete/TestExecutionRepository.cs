using Microsoft.EntityFrameworkCore;
using RePattern.Common.Enums;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class TestExecutionRepository(ApplicationDbContext dbContext) : Repository<TestExecution>(dbContext), ITestExecutionRepository
    {
        public async Task<TestExecution?> GetLatestCategoryByUserIdAndCategoryIdAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.TestExecutions
                .Where(te => te.UserId == userId && te.Test.CategoryId == categoryId)
                .OrderByDescending(te => te.CompletedAt)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TestExecution?> GetLatestPeriodicByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.TestExecutions
                .Where(te => te.UserId == userId && te.Test.CategoryId == null && te.Test.Type == TestTypeEnum.SPACED)
                .OrderByDescending(te => te.CompletedAt)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TestExecution?> GetExecutionReviewAsync(int executionId, CancellationToken cancellationToken)
        {
            return await _dbContext.TestExecutions
                .Include(x => x.QuestionAttempts)
                    .ThenInclude(x => x.TestQuestion)
                        .ThenInclude(x => x.Answers)
                .Include(x => x.QuestionAttempts)
                    .ThenInclude(x => x.SelectedAnswers)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == executionId, cancellationToken);
        }
    }
}
