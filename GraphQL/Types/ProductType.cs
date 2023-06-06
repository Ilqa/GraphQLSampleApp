using GraphQLSampleApp.Data;
using GraphQLSampleApp.Models;

namespace GraphQLSampleApp.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Used to define Products of a specific ctegory");
            
            descriptor.Field(x => x.Category)
                      .ResolveWith<Resolvers>(p => p.GetCategory(default!, default!))
                      .UseDbContext<ApiDbContext>()
                      .Description("This is the category that the product belongs to");
        }

        private class Resolvers
        {
            public ProductCategory GetCategory([Parent] Product item, [ScopedService] ApiDbContext context)
            {
                return context.ProductCategories.FirstOrDefault(x => x.Id == item.CategoryId);
            }
        }
    }
}
