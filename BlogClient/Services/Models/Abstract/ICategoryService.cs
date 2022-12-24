using BlogClient.Contracts.Category;

namespace BlogClient.Services.Models.Abstract
{
    public interface ICategoryService
    {
        Task<List<ListCategory>> GetCategoryList();
    }
}
