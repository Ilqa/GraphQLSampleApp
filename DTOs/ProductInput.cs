namespace GraphQLSampleApp.DTOs
{
    public record ProductInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Imported { get; set; }
        public int CategoryId { get; set; }
    }
}
