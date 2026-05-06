using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/badge-acquisition")]
    [ApiController]
    public class BadgeAcquisitionController(IBadgeAcquisitionService badgeAcquisitionService, IUserService userService) : ControllerBase
    {
        [Authorize]
        [HttpGet("me/acquired-highest")]
        public async Task<IActionResult> GetAllHighestAcquiredBadges(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await badgeAcquisitionService.GetHighestAcquiredBadgeFromEachBadgeGroupAsync(user.Id, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/unacquired-lowest")]
        public async Task<IActionResult> GetAllLowestUnacquiredBadges(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await badgeAcquisitionService.GetLowestUnacquiredBadgesPerGroupAsync(user.Id, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("me/category/{categoryId:int}/category-complete-badge")]
        public async Task<IActionResult> AcquireCategoryCompleteTrackingBadge(int categoryId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);

            var response = await badgeAcquisitionService.AcquireCategoryCompleteTrackingBadgeAsync(
                user.Id,
                categoryId,
                cancellationToken
            );

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/category/{categoryId:int}/tracking/acquired-badges")]
        public async Task<IActionResult> GetAcquiredTrackingBadgesByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);

            var response = await badgeAcquisitionService.GetAcquiredTrackingBadgesByCategoryAsync(
                    user.Id,
                    categoryId,
                    cancellationToken
                );

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/category/{categoryId:int}/tracking/unacquired-badges")]
        public async Task<IActionResult> GetUnacquiredTrackingBadgesByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);

            var response = await badgeAcquisitionService.GetUnacquiredTrackingBadgesByCategoryAsync(
                    user.Id,
                    categoryId,
                    cancellationToken
                );

            return Ok(response);
        }
    }
}
