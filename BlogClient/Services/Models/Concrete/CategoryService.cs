using BlogClient.Contracts.Category;
using BlogClient.Services.Models.Abstract;

namespace BlogClient.Services.Models.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientService _httpClientService;

        public CategoryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<CategoryResponse> AddCategory(CreateCategory addCategory)
            => (await _httpClientService.Post<CreateCategory, CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Create" }, addCategory));

        public async Task<CategoryResponse> DeleteCategory(int id)
            => await _httpClientService.Delete<CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Delete" }, id.ToString());

        public async Task<CategoryResponse> GetCategoryById(int id)
            => await _httpClientService.Get<CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetById" }, id.ToString());

        public async Task<(List<ListCategory> listCategories, int totalCategoryCount)> GetCategoryList(int page, int size)
        {
            var data = (await _httpClientService.Get<Root>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetAll", QueryString = $"page={page}&size={size}" }));
            return (data.Categories, data.TotalCategoryCount);
        }

        public async Task<GetCategoryWithHeadings> GetCategoryWithHeadings(int id)
            => await _httpClientService.Get<GetCategoryWithHeadings>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetCategoryHeadingsByCategoryId" }, id.ToString());

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRoot updateCategory)
            => await _httpClientService.Put<CategoryUpdateRoot, CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Update" }, updateCategory);
    }
}
