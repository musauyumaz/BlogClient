using BlogClient.Contracts;
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

        public async Task<BaseContract<Writer>> AddWriter(CreateWriter createWriter)
         => await _httpClientService.PostAsync<CreateWriter, BaseContract<Writer>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Create" }, createWriter);

        public async Task<BaseContract<Writer>> DeleteWriter(int id)
            => await _httpClientService.DeleteAsync<BaseContract<Writer>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Delete" }, id.ToString());

        public async Task<BaseContract<GetHeadingsByWriterId>> GetHeadingsByWriterId(int writerId)
            => await _httpClientService.GetAsync<BaseContract<GetHeadingsByWriterId>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetHeadingsByWriterId" }, writerId.ToString());

        public async Task<BaseContract<Writer>> GetWriterById(int id)
            => await _httpClientService.GetAsync<BaseContract<Writer>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetById" }, id.ToString());

        public async Task<BaseContract<ListWriterResponse>> GetWriterList(int page, int size)
            => await _httpClientService.GetAsync<BaseContract<ListWriterResponse>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "GetAll" ,QueryString = $"page={page}&size={size}" });

        public async Task<BaseContract<Writer>> UpdateWriter(UpdateWriter updateWriter)
            => await _httpClientService.PutAsync<UpdateWriter, BaseContract<Writer>>(new() { BaseUrl = "http://localhost:5058/api", Controller = "Writers", Action = "Update" }, updateWriter);
    }
}
