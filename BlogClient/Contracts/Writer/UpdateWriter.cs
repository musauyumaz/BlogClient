namespace BlogClient.Contracts.Writer
{
    public class UpdateWriter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
    }
}
