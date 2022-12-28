namespace BlogClient.Contracts.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CategoryResponse
    {
        public Category CategoryDTO { get; set; }
        public int TotalCategoryCount { get; set; }
    }
}
