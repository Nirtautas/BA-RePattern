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
                .Where(aq => aq.UserId == userId)
                .GroupBy(aq => aq.Badge.BadgeGroupId)
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

        public async Task<List<BadgeWithCategoryInfo>> GetLowestUnacquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.Badges
                .Where(b => !b.BadgeAcquisitions.Any(a => a.UserId == userId))
                .GroupBy(b => b.BadgeGroupId)
                .Select(g => g
                    .OrderBy(b => b.Tier)
                    .Select(b => new BadgeWithCategoryInfo
                    {
                        Badge = b,
                        CategoryId = b.BadgeGroup.CategoryId,
                        IsTrackingGroup = b.BadgeGroup.IsTrackingGroup,
                        AcquiredAt = default
                    })
                    .First())
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Badge>> GetAcquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.BadgeAcquisitions
                .Where(aq =>
                    aq.UserId == userId &&
                    aq.Badge.BadgeGroup.IsTrackingGroup &&
                    aq.Badge.BadgeGroup.CategoryId == categoryId)
                .Select(aq => aq.Badge)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Badge>> GetUnacquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Badges
                .Where(b =>
                    b.BadgeGroup.IsTrackingGroup &&
                    b.BadgeGroup.CategoryId == categoryId &&
                    !b.BadgeAcquisitions.Any(a => a.UserId == userId))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
