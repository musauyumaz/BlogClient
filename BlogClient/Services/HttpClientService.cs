using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlogClient.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        private string Url(RequestParameter requestParameter)
        {
            string url = $"{(!String.IsNullOrEmpty(requestParameter.BaseUrl) ? requestParameter.BaseUrl : _configuration["BaseUrl"])}/" +
                $"{requestParameter.Controller}" +
                $"{(!String.IsNullOrEmpty(requestParameter
                .Action) ? "/" + requestParameter.Action : "")}";
            return url;
        }
        public async Task<T> Get<T>(RequestParameter requestParameter, string id = null)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            string url = String.Empty;
            if (!String.IsNullOrEmpty(requestParameter.FullEndpoint))
                url = requestParameter.FullEndpoint;
            else
                url = $"{Url(requestParameter)}{(!String.IsNullOrEmpty(id) ? "/" + id : "")}";

            return await _httpClient.GetFromJsonAsync<T>(url, options);
        }
    }
    public class RequestParameter
    {
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public HttpHeaders? Headers { get; set; }
        public string? BaseUrl { get; set; }
        public string? FullEndpoint { get; set; }
    }
}
