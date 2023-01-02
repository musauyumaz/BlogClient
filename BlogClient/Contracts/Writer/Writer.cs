namespace BlogClient.Contracts.Writer
{
    public class Writer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }

    public class WriterResponse
    {
        public Writer WriterDTO { get; set; }
    }
}
