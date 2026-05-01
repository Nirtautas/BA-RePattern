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
        [HttpGet("me")]
        public async Task<IActionResult> GetAllHighestReceivedBadges(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await badgeAcquisitionService.GetHighestReceivedBadgeFromEachBadgeGroupAsync(user.Id, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/unreceived")]
        public async Task<IActionResult> GetAllLowestUnreceivedBadges(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await badgeAcquisitionService.GetLowestUnreceivedBadgesPerGroupAsync(user.Id, cancellationToken);
            return Ok(response);
        }
    }
}
