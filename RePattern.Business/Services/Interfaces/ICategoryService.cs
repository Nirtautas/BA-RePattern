using RePattern.Business.Dtos.Category;

namespace RePattern.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryResponse> GetCategoryByIdAsync(int id, CancellationToken cancellationToken);
        Task<CategoryResponse> GetCategoryByUniquePathFragmentAsync(string pathFragment, CancellationToken cancellationToken);
    }
}
