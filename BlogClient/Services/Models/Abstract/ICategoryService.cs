using BlogClient.Contracts;
using BlogClient.Contracts.Category;

namespace BlogClient.Services.Models.Abstract
{
    public interface ICategoryService
    {
        Task<BaseContract<ListCategoryData>> GetCategoryList(int page, int size);
        Task<BaseContract<Category>> GetCategoryById(int id);
        Task<BaseContract<GetCategoryWithHeadings>> GetCategoryWithHeadings(int id);
        Task<BaseContract<Category>> AddCategory(CreateCategory addCategory);
        Task<BaseContract<Category>> DeleteCategory(int id);
        Task<BaseContract<Category>> UpdateCategory(CategoryUpdateRoot updateCategory);
    }
}
