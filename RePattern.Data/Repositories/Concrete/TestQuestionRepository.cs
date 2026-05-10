using Microsoft.EntityFrameworkCore;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class TestQuestionRepository(ApplicationDbContext dbContext) : Repository<TestQuestion>(dbContext), ITestQuestionRepository
    {
        public async Task<List<TestQuestion>> GetQuestionsWithAnswersByIdsAsync(List<int> questionIds, CancellationToken cancellationToken)
        {
            return await _dbContext.TestQuestions
                .Include(q => q.Answers)
                .Where(q => questionIds.Contains(q.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
