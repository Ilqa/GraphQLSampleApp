using GraphQLSampleApp.Data;
using GraphQLSampleApp.Models;
using System.Collections.Generic;

namespace GraphQLSampleApp.GraphQL.Types;

public class ProductCategoryType : ObjectType<ProductCategory>
{
    // since we are inheriting from objtype we need to override the functionality
    protected override void Configure(IObjectTypeDescriptor<ProductCategory> descriptor)
    {
        descriptor.Description("Used to group the products on the basis of their category");
        descriptor.Field(x => x.Products)
                    .ResolveWith<Resolvers>(p => p.GetProducts(default!, default!))
                    .UseDbContext<ApiDbContext>()
                    .Description("This is the list of products available in this category");
    }

    private class Resolvers
    {
        public IQueryable<Product> GetProducts([Parent] ProductCategory category, [ScopedService] ApiDbContext context)
        {
            return context.Products.Where(x => x.CategoryId == category.Id);
        }

    }
}
