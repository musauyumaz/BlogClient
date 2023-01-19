using BlogClient.Contracts;
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

        public async Task<BaseContract<Category>> AddCategory(CreateCategory addCategory)
            => (await _httpClientService.PostAsync<CreateCategory, BaseContract<Category>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Create" }, addCategory));

        public async Task<BaseContract<Category>> DeleteCategory(int id)
            => await _httpClientService.DeleteAsync<BaseContract<Category>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Delete" }, id.ToString());

        public async Task<BaseContract<Category>> GetCategoryById(int id)
            => await _httpClientService.GetAsync<BaseContract<Category>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetById" }, id.ToString());

        public async Task<BaseContract<ListCategoryData>> GetCategoryList(int page, int size)
        {
            var data = (await _httpClientService.GetAsync<BaseContract<ListCategoryData>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetAll", QueryString = $"page={page}&size={size}" }));
            return data;
        }

        public async Task<BaseContract<GetCategoryWithHeadings>> GetCategoryWithHeadings(int id)
            => await _httpClientService.GetAsync<BaseContract<GetCategoryWithHeadings>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "GetCategoryHeadingsByCategoryId" }, id.ToString());

        public async Task<BaseContract<Category>> UpdateCategory(CategoryUpdateRoot updateCategory)
            => await _httpClientService.PutAsync<CategoryUpdateRoot, BaseContract<Category>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Categories", Action = "Update" }, updateCategory);
    }
}
