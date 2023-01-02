namespace BlogClient.Services
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(RequestParameter requestParameter, string id = null);
        Task<TResponse> PostAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
        Task<TResponse> PutAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
        Task<TResponse> DeleteAsync<TResponse>(RequestParameter requestParameter, string id= null);

    }
}
