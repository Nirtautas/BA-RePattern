using AutoMapper;
using RePattern.Business.Dtos.TestExecution;
using RePattern.Business.Services.Interfaces;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class TestExecutionService(IUnitOfWork unitOfWork, IMapper mapper) : ITestExecutionService
    {
        public async Task<TestExecutionResponse> GetLatestCategoryTestExecutionAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            var testExecution = await unitOfWork.TestExecutionRepository.GetLatestByUserIdAndCategoryIdAsync(userId, categoryId, cancellationToken);
            var testExecutionResponse = mapper.Map<TestExecutionResponse>(testExecution);

            return testExecutionResponse;
        }
    }
}
