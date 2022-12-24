namespace BlogClient.Contracts.Category
{
    public class ListCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Root
    {
        public List<ListCategory> Categories { get; set; }
    }
}
