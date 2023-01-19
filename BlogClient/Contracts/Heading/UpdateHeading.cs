namespace BlogClient.Contracts.Heading
{
    public class UpdateHeading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
