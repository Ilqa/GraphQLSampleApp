
using GraphQLSampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleApp.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        { }

        public ApiDbContext()            
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
