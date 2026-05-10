using RePattern.Business.Dtos.Test;

namespace RePattern.Business.Services.Interfaces
{
    public interface ITestService
    {
        Task<TestTakingResponse?> GetCategoryTestAsync(int categoryId, CancellationToken cancellationToken);
        Task<TestTakingResponse> GetPeriodicTestAsync(int userId, CancellationToken cancellationToken);
        Task<TestCompletionResponse> HandleTestCompletion(int testId, int? userId, CompleteTestRequest completeTestRequest, CancellationToken cancellationToken);
        Task<PeriodicTestAvailabilityResponse> GetPeriodicTestAvailabilityAsync(int userId, CancellationToken cancellationToken);
    }
}
