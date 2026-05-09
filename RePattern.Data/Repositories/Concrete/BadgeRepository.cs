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
        public async Task<List<Badge>> GetCategoryTrackingBadgesByRuleAsync(int categoryId, BadgeRuleTypeEnum ruleType, CancellationToken cancellationToken)
        {
            return await _dbContext.Badges
                .Include(b => b.BadgeRule)
                .Where(b =>
                    b.BadgeGroup.IsTrackingGroup &&
                    b.BadgeGroup.CategoryId == categoryId &&
                    b.BadgeRule.RuleType == ruleType)
                .ToListAsync(cancellationToken);
        }
    }
}
