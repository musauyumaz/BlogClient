using BlogClient.Contracts;
using BlogClient.Contracts.Heading;
using BlogClient.Services.Models.Abstract;

namespace BlogClient.Services.Models.Concrete
{
    public class HeadingService : IHeadingService
    {
        private readonly IHttpClientService _httpClientService;

        public HeadingService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<BaseContract<Heading>> AddHeading(CreateHeading createHeading)
            => (await _httpClientService.PostAsync<CreateHeading, BaseContract<Heading>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Headings", Action = "Create" }, createHeading));

        public async Task<BaseContract<Heading>> DeleteHeading(int id)
            => (await _httpClientService.DeleteAsync<BaseContract<Heading>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Headings", Action = "Delete" }, id.ToString()));

        public async Task<BaseContract<Heading>> GetHeadingById(int id)
            => (await _httpClientService.GetAsync<BaseContract<Heading>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Headings", Action = "GetById" }, id.ToString()));

        public async Task<BaseContract<ListHeading.ListHeadingRoot>> GetHeadingList(int page, int size)
            => (await _httpClientService.GetAsync<BaseContract<ListHeading.ListHeadingRoot>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Headings", Action = "GetAll", QueryString = $"page={page}&size={size}" }));

        public async Task<BaseContract<Heading>> UpdateHeading(UpdateHeading updateHeading)
            => (await _httpClientService.PutAsync<UpdateHeading, BaseContract<Heading>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Headings", Action = "GetById" }, updateHeading));
    }
}
