using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Dtos.Test;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestController(ITestService testService, IUserService userService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetCategoryTest(int categoryId, CancellationToken cancellationToken)
        {
            var response = await testService.GetCategoryTestAsync(categoryId, cancellationToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/periodic")]
        public async Task<IActionResult> GetPeriodicTest(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await testService.GetPeriodicTestAsync(user.Id, cancellationToken);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("{testId:int}/complete")]
        public async Task<IActionResult> CompleteTest(int testId, [FromBody] CompleteTestRequest completedTestRequest, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await testService.HandleTestCompletion(testId, user?.Id, completedTestRequest, cancellationToken);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("me/periodic/availability")]
        public async Task<IActionResult> GetPeriodicTestAvailability(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await testService.GetPeriodicTestAvailabilityAsync(user.Id, cancellationToken);

            return Ok(response);
        }
    }
}
