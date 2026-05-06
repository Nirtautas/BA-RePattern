using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.JoinQueryEntities;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface IBadgeAcquisitionRepository : IRepository<BadgeAcquisition>
    {
        Task<List<BadgeWithCategoryInfo>> GetHighestAcquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken);
        Task<List<BadgeWithCategoryInfo>> GetLowestUnacquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken);
        Task<List<Badge>> GetAcquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken);
        Task<List<Badge>> GetUnacquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken);
    }
}
