using RePattern.Business.Dtos.BadgeAcquisition;

namespace RePattern.Business.Services.Interfaces
{
    public interface IBadgeAcquisitionService
    {
        Task<List<BadgeWithCategoryResponse>> GetHighestReceivedBadgeFromEachBadgeGroup(int userId, CancellationToken cancellationToken);
    }
}
