using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/test-executions")]
    [ApiController]
    public class TestExecutionController(ITestExecutionService testExecutionService, IUserService userService) : ControllerBase
    {
        [Route("me/category/{categoryId:int}/latest")]
        [Authorize]
        public async Task<IActionResult> GetLatestCategoryTestExecution(int categoryId, CancellationToken cancellationToken)
        {
            var user = await userService.GetCurrentUserAsync(User, cancellationToken);
            var execution = await testExecutionService.GetLatestCategoryTestExecutionAsync(user.Id, categoryId, cancellationToken);

            return Ok(execution);
        }
    }
}
