namespace BlogClient.Contracts.Writer
{
    public class ListWriter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public List<string> Photos { get; set; }
    }
    public class ListWriterResponse
    {
        public List<ListWriter> Writers { get; set; }
        public int TotalWriterCount { get; set; }
    }
}
