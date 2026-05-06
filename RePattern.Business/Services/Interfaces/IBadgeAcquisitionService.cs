using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Domain.Entities;

namespace RePattern.Business.Services.Interfaces
{
    public interface IBadgeAcquisitionService
    {
        Task<List<BadgeWithCategoryResponse>> GetHighestAcquiredBadgeFromEachBadgeGroupAsync(int userId, CancellationToken cancellationToken);
        Task<List<BadgeWithCategoryResponse>> GetLowestUnacquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken);
        Task<BadgeResponse> AcquireCategoryCompleteTrackingBadgeAsync(int userId, int categoryId, CancellationToken cancellationToken);
        Task<List<BadgeResponse>> GetAcquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken);
        Task<List<BadgeResponse>> GetUnacquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken);
    }
}
