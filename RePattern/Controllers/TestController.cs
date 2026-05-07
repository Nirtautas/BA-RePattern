using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestController(ITestService testService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetCategoryTest(int categoryId, CancellationToken cancellationToken)
        {
            var response = await testService.GetCategoryTestAsync(categoryId, cancellationToken);
            return Ok(response);
        }
    }
}
