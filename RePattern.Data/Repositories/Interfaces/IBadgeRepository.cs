using RePattern.Common.Enums;
using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface IBadgeRepository : IRepository<Badge>
    {
        Task<List<Badge>> GetCategoryTrackingBadgesByRuleAsync(int categoryId, BadgeRuleTypeEnum ruleType, CancellationToken cancellationToken);
    }
}
