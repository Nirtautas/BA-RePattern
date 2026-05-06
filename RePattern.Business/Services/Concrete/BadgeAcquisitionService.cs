using AutoMapper;
using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Business.Services.Concrete
{
    public class BadgeAcquisitionService(IUnitOfWork unitOfWork, IMapper mapper) : IBadgeAcquisitionService
    {
        public async Task<List<BadgeWithCategoryResponse>> GetHighestAcquiredBadgeFromEachBadgeGroupAsync(int userId, CancellationToken cancellationToken)
        {
            var receivedBadges = await unitOfWork.BadgeAcquisitionRepository.GetHighestAcquiredBadgesPerGroupAsync(userId, cancellationToken);
            var badgeResponse = mapper.Map<List<BadgeWithCategoryResponse>>(receivedBadges);

            return badgeResponse;
        }

        public async Task<List<BadgeWithCategoryResponse>> GetLowestUnacquiredBadgesPerGroupAsync(int userId, CancellationToken cancellationToken)
        {
            var unreceivedBadges = await unitOfWork.BadgeAcquisitionRepository.GetLowestUnacquiredBadgesPerGroupAsync(userId, cancellationToken);
            var badgeResponse = mapper.Map<List<BadgeWithCategoryResponse>>(unreceivedBadges);

            return badgeResponse;
        }

        public async Task<BadgeResponse> AcquireCategoryCompleteTrackingBadgeAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            var categoryCompleteBadge = await unitOfWork.BadgeRepository.GetCategoryCompleteTrackingBadgeAsync(categoryId, cancellationToken)
                ?? throw new NotFoundException($"Tracking badge for category {categoryId} completion was not found!");

            var userAcquiredBadges = await unitOfWork.BadgeAcquisitionRepository.GetAllByExpressionAsync((b) => b.UserId == userId);
            var completeBadgeAlreadyAcquired = userAcquiredBadges.Any((b) => b.BadgeId == categoryCompleteBadge.Id);

            if (!completeBadgeAlreadyAcquired)
            {
                await unitOfWork.BadgeAcquisitionRepository.CreateAsync(new BadgeAcquisition
                {
                    UserId = userId,
                    BadgeId = categoryCompleteBadge.Id,
                    AcquiredAt = DateTime.UtcNow
                }, cancellationToken);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var badgeResponse = mapper.Map<BadgeResponse>(categoryCompleteBadge);
            return badgeResponse;
        }

        public async Task<List<BadgeResponse>> GetAcquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            var trackingBadges = await unitOfWork.BadgeAcquisitionRepository.GetAcquiredTrackingBadgesByCategoryAsync(userId, categoryId, cancellationToken);
            var trackingBadgesResponse = mapper.Map<List<BadgeResponse>>(trackingBadges);

            return trackingBadgesResponse;
        }

        public async Task<List<BadgeResponse>> GetUnacquiredTrackingBadgesByCategoryAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            var trackingBadges = await unitOfWork.BadgeAcquisitionRepository.GetUnacquiredTrackingBadgesByCategoryAsync(userId, categoryId, cancellationToken);
            var trackingBadgesResponse = mapper.Map<List<BadgeResponse>>(trackingBadges);

            return trackingBadgesResponse;
        }
    }
}
