using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface ITestExecutionRepository : IRepository<TestExecution>
    {
        Task<TestExecution?> GetLatestByUserIdAndCategoryIdAsync(int userId, int categoryId, CancellationToken cancellationToken);
    }
}
