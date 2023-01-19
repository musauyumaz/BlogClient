namespace BlogClient.Contracts.Category
{
    public class GetCategoryWithHeadings
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<string> HeadingsName { get; set; }
    }
}
