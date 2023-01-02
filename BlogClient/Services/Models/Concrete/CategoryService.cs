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
            => (await _httpClientService.PostAsync<CreateCategory, CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Create" }, addCategory));

        public async Task<CategoryResponse> DeleteCategory(int id)
            => await _httpClientService.DeleteAsync<CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Delete" }, id.ToString());

        public async Task<CategoryResponse> GetCategoryById(int id)
            => await _httpClientService.GetAsync<CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetById" }, id.ToString());

        public async Task<(List<ListCategory> listCategories, int totalCategoryCount)> GetCategoryList(int page, int size)
        {
            var data = (await _httpClientService.GetAsync<Root>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetAll", QueryString = $"page={page}&size={size}" }));
            return (data.Categories, data.TotalCategoryCount);
        }

        public async Task<GetCategoryWithHeadings> GetCategoryWithHeadings(int id)
            => await _httpClientService.GetAsync<GetCategoryWithHeadings>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetCategoryHeadingsByCategoryId" }, id.ToString());

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRoot updateCategory)
            => await _httpClientService.PutAsync<CategoryUpdateRoot, CategoryResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Update" }, updateCategory);
    }
}
