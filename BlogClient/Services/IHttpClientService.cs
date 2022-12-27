namespace BlogClient.Services
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(RequestParameter requestParameter, string id = null);
        Task<TResponse> Post<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
        Task<TResponse> Put<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
        Task<TResponse> Delete<TResponse>(RequestParameter requestParameter, string id= null);

    }
}
