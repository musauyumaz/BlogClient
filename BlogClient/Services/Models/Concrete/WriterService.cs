using BlogClient.Contracts.Writer;
using BlogClient.Services.Models.Abstract;

namespace BlogClient.Services.Models.Concrete
{
    public class WriterService : IWriterService
    {
        private readonly IHttpClientService _httpClientService;

        public WriterService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<WriterResponse> AddWriter(CreateWriter createWriter)
         => await _httpClientService.PostAsync<CreateWriter, WriterResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Create" }, createWriter);

        public async Task<WriterResponse> DeleteWriter(int id)
            => await _httpClientService.DeleteAsync<WriterResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Delete" }, id.ToString());

        public async Task<GetHeadingsByWriterId> GetHeadingsByWriterId(int writerId)
            => await _httpClientService.GetAsync<GetHeadingsByWriterId>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetHeadingsByWriterId" }, writerId.ToString());

        public async Task<WriterResponse> GetWriterById(int id)
            => await _httpClientService.GetAsync<WriterResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetById" }, id.ToString());

        public async Task<ListWriterResponse> GetWriterList(int page, int size)
            => await _httpClientService.GetAsync<ListWriterResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetAll" ,QueryString = $"page={page}&size={size}" });

        public async Task<WriterResponse> UpdateWriter(UpdateWriter updateWriter)
            => await _httpClientService.PutAsync<UpdateWriter, WriterResponse>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Update" }, updateWriter);
    }
}
