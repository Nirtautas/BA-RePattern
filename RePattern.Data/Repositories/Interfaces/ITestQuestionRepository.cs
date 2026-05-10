using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
        Task<List<TestQuestion>> GetQuestionsWithAnswersByIdsAsync(List<int> questionIds, CancellationToken cancellationToken);
    }
}
