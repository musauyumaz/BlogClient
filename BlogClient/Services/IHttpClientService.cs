namespace BlogClient.Services
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(RequestParameter requestParameter, string id = null);

    }
}
