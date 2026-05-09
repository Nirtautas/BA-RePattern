using Microsoft.EntityFrameworkCore;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class TestExecutionRepository(ApplicationDbContext dbContext) : Repository<TestExecution>(dbContext), ITestExecutionRepository
    {
        public async Task<TestExecution?> GetLatestByUserIdAndCategoryIdAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.TestExecutions
                .Where(te => te.UserId == userId && te.Test.CategoryId == categoryId)
                .OrderByDescending(te => te.CompletedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
