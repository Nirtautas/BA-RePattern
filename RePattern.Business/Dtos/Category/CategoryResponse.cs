namespace RePattern.Business.Dtos.Category
{
    public record CategoryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UniquePathFragment { get; set; }
        public int Order { get; set; }
        public bool OnlyTheory { get; set; }
    }
}
