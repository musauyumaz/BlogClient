﻿namespace BlogClient.Contracts.Category
{
    public class ListCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class Root
    {
        public List<ListCategory> Categories { get; set; }
        public int TotalCategoryCount { get; set; }
    }
}
