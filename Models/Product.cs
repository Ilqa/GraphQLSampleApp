namespace GraphQLSampleApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Imported { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
