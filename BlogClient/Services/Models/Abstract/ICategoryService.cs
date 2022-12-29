using BlogClient.Contracts.Category;

namespace BlogClient.Services.Models.Abstract
{
    public interface ICategoryService
    {
        Task<(List<ListCategory> listCategories, int totalCategoryCount)> GetCategoryList(int page, int size);
        Task<CategoryResponse> GetCategoryById(int id);
        Task<GetCategoryWithHeadings> GetCategoryWithHeadings(int id);
        Task<CategoryResponse> AddCategory(CreateCategory addCategory);
        Task<CategoryResponse> DeleteCategory(int id);
        Task<CategoryResponse> UpdateCategory(CategoryUpdateRoot updateCategory);
    }
}
