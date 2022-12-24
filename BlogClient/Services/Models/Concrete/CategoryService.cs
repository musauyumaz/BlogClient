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

        public async Task<List<ListCategory>> GetCategoryList()
            => (await _httpClientService.Get<Root>(new() { Controller = "Categories", Action = "GetAll" })).Categories;
        
    }
}
