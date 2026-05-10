using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface ITestExecutionRepository : IRepository<TestExecution>
    {
        Task<TestExecution?> GetLatestCategoryByUserIdAndCategoryIdAsync(int userId, int categoryId, CancellationToken cancellationToken);
        Task<TestExecution?> GetLatestPeriodicByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task<TestExecution?> GetExecutionReviewAsync(int executionId, CancellationToken cancellationToken);
    }
}
