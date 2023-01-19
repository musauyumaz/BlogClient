namespace BlogClient.Contracts.Heading
{
    public class CreateHeading
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }
    }
}
