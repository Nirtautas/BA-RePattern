using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/test-executions")]
    [ApiController]
    public class TestExecutionController(ITestExecutionService testExecutionService, IUserService userService) : ControllerBase
    {
        [Authorize]
        [HttpGet("me/category/{categoryId:int}/latest")]
        public async Task<IActionResult> GetLatestCategoryTestExecution(int categoryId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var execution = await testExecutionService.GetLatestCategoryTestExecutionAsync(user.Id, categoryId, cancellationToken);

            return Ok(execution);
        }

        [Authorize]
        [HttpGet("me/periodic/latest")]
        public async Task<IActionResult> GetLatestCategoryTestExecution(CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var execution = await testExecutionService.GetLatestPeriodicTestExecutionAsync(user.Id, cancellationToken);

            return Ok(execution);
        }

        [AllowAnonymous]
        [HttpGet("{executionId:int}")]
        public async Task<IActionResult> GetExecutionReview(int executionId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var response = await testExecutionService.GetExecutionReviewAsync(executionId, user?.Id, cancellationToken);

            return Ok(response);
        }
    }
}
