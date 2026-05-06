using RePattern.Data.Repositories.Base;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Interfaces
{
    public interface IBadgeRepository : IRepository<Badge>
    {
        Task<Badge?> GetCategoryCompleteTrackingBadgeAsync(int categoryId, CancellationToken cancellationToken);
    }
}
