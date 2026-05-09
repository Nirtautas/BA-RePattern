using RePattern.Business.Dtos.TestExecution;

namespace RePattern.Business.Services.Interfaces
{
    public interface ITestExecutionService
    {
        Task<TestExecutionResponse> GetLatestCategoryTestExecutionAsync(int userId, int categoryId, CancellationToken cancellationToken);
    }
}
