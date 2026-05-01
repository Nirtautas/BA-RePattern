using RePattern.Business.Dtos.BadgeAcquisition;

namespace RePattern.Business.Services.Interfaces
{
    public interface IBadgeAcquisitionService
    {
        Task<List<BadgeWithCategoryResponse>> GetHighestReceivedBadgeFromEachBadgeGroupAsync(int userId, CancellationToken cancellationToken);
        Task<List<BadgeWithCategoryResponse>> GetLowestUnreceivedBadgesPerGroupAsync(int userId, CancellationToken cancellationToken);
    }
}
