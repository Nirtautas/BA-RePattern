using AutoMapper;
using RePattern.Business.Dtos.Category;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
    {
        public async Task<List<CategoryResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
            var categoryResponse = mapper.Map<List<CategoryResponse>>(categories);

            return categoryResponse;
        }

        public async Task<CategoryResponse> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException($"Category with id {id} not found");
            var categoryResponse = mapper.Map<CategoryResponse>(category);

            return categoryResponse;
        }

        public async Task<CategoryResponse> GetCategoryByUniquePathFragmentAsync(string pathFragment, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetByExpressionAsync(c => String.Equals(c.UniquePathFragment, pathFragment), cancellationToken)
                ?? throw new NotFoundException($"Category with unique path fragment {pathFragment} not found");
            var categoryResponse = mapper.Map<CategoryResponse>(category);

            return categoryResponse;
        }
    }
}
