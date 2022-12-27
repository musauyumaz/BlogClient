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

        public async Task<TResponse> Post<TRequest,TResponse>(RequestParameter requestParameter, TRequest body)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            string url = String.Empty;
            if (!String.IsNullOrEmpty(requestParameter.FullEndpoint))
                url = requestParameter.FullEndpoint;
            else
                url = $"{Url(requestParameter)}";

            using HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync<TRequest>(url, body,options);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> Put<TRequest, TResponse>(RequestParameter requestParameter, TRequest body)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            string url = String.Empty;
            if (!String.IsNullOrEmpty(requestParameter.FullEndpoint))
                url = requestParameter.FullEndpoint;
            else
                url = $"{Url(requestParameter)}";

            using HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync<TRequest>(url, body, options);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<TResponse> Delete<TResponse>(RequestParameter requestParameter, string id = null)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            string url = String.Empty;
            if (!String.IsNullOrEmpty(requestParameter.FullEndpoint))
                url = requestParameter.FullEndpoint;
            else
                url = $"{Url(requestParameter)}{(!String.IsNullOrEmpty(id) ? "/" + id : "")}";

            using HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(url);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();

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
