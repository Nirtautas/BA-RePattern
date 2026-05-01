using AutoMapper;
using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Business.Services.Interfaces;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class BadgeAcquisitionService(IUnitOfWork unitOfWork, IMapper mapper) : IBadgeAcquisitionService
    {
        public async Task<List<BadgeWithCategoryResponse>> GetHighestReceivedBadgeFromEachBadgeGroupAsync(int userId, CancellationToken cancellationToken)
        {
            var receivedBadges = await unitOfWork.BadgeAcquisitionRepository.GetHighestAcquiredBadgesPerGroupAsync(userId, cancellationToken);
            var badgeResponse = mapper.Map<List<BadgeWithCategoryResponse>>(receivedBadges);

            return badgeResponse;
        }

        public async Task<List<BadgeWithCategoryResponse>> GetLowestUnreceivedBadgesPerGroupAsync(int userId, CancellationToken cancellationToken)
        {
            var unreceivedBadges = await unitOfWork.BadgeAcquisitionRepository.GetLowestUnacquiredBadgesPerGroupAsync(userId, cancellationToken);
            var badgeResponse = mapper.Map<List<BadgeWithCategoryResponse>>(unreceivedBadges);

            return badgeResponse;
        }
    }
}
