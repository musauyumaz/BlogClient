namespace BlogClient.Contracts.Category
{
    public class CategoryUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class CategoryUpdateRoot
    {
        public CategoryUpdate UpdateCategoryDTO { get; set; }
    }
}
