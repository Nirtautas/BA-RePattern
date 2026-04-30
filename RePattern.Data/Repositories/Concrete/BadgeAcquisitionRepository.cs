using Microsoft.EntityFrameworkCore;
using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Data.Repositories.JoinQueryEntities;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class BadgeAcquisitionRepository(ApplicationDbContext dbContext) : Repository<BadgeAcquisition>(dbContext), IBadgeAcquisitionRepository
    {
        public async Task<List<BadgeWithCategoryInfo>> GetHighestAcquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.BadgeAcquisitions
                .Where(x => x.UserId == userId)
                .GroupBy(x => x.Badge.BadgeGroupId)
                .Select(g => g
                    .OrderByDescending(x => x.Badge.Tier)
                    .Select(x => new BadgeWithCategoryInfo
                    {
                        Badge = x.Badge,
                        CategoryId = x.Badge.BadgeGroup.CategoryId,
                        IsTrackingGroup = x.Badge.BadgeGroup.IsTrackingGroup,
                        AcquiredAt = x.AcquiredAt
                    })
                    .First())
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
