namespace BlogClient.Contracts
{
    public class BaseContract<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
    }

}