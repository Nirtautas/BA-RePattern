using AutoMapper;
using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Business.Services.Interfaces;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class BadgeAcquisitionService(IUnitOfWork unitOfWork, IMapper mapper) : IBadgeAcquisitionService
    {
        public async Task<List<BadgeWithCategoryResponse>> GetHighestReceivedBadgeFromEachBadgeGroup(int userId, CancellationToken cancellationToken)
        {
            var receivedBadges = await unitOfWork.BadgeAcquisitionRepository.GetHighestAcquiredBadgesPerGroupAsync(userId, cancellationToken);
            var categoryResponse = mapper.Map<List<BadgeWithCategoryResponse>>(receivedBadges);

            return categoryResponse;
        }
    }
}
