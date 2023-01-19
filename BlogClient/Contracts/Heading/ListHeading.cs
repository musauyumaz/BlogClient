namespace BlogClient.Contracts.Heading
{
    public class ListHeading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string WriterFullName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public class ListHeadingRoot
        {
            public List<ListHeading> Headings { get; set; }
            public int TotalHeadingCount { get; set; }
        }
    }
}
