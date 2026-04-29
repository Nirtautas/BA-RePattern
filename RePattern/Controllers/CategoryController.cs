using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RePattern.Business.Services.Interfaces;

namespace RePattern.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var response = await categoryService.GetAllCategoriesAsync(cancellationToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var response = await categoryService.GetCategoryByIdAsync(categoryId, cancellationToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("by-path/{uniqueCategoryFragment}")]
        public async Task<IActionResult> GetCategoryByUniquePathFragmentAsync(string uniqueCategoryFragment, CancellationToken cancellationToken)
        {
            var response = await categoryService.GetAllCategoriesAsync(cancellationToken);
            return Ok(response);
        }
    }
}
