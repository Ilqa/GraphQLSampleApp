using GraphQLSampleApp.Data;
using GraphQLSampleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSampleApp.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([ScopedService] ApiDbContext context)
        {
            return context.Products;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProductCategory> GetProductCategories([ScopedService] ApiDbContext context)
        {
            return context.ProductCategories;
        }
    }
}
