using Microsoft.EntityFrameworkCore;
using RePattern.Common.Enums;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class BadgeRepository(ApplicationDbContext dbContext) : Repository<Badge>(dbContext), IBadgeRepository
    {
        public async Task<Badge?> GetCategoryCompleteTrackingBadgeAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Badges
                .Where(b =>
                    b.BadgeGroup.IsTrackingGroup &&
                    b.BadgeGroup.CategoryId == categoryId &&
                    b.BadgeRule.RuleType == BadgeRuleTypeEnum.CATEGORY_COMPLETE)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
