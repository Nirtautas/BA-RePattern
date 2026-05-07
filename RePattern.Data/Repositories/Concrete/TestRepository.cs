using Microsoft.EntityFrameworkCore;
using RePattern.Common.Enums;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class TestRepository(ApplicationDbContext dbContext) : Repository<Test>(dbContext), ITestRepository
    {
        public async Task<Test?> GetCategoryTestWithQuestionsAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Tests
                .Include(t => t.TestQuestions)
                    .ThenInclude(q => q.Answers)
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    t => t.CategoryId == categoryId && t.Type == TestTypeEnum.CATEGORY,
                    cancellationToken
                );
        }
    }
}
