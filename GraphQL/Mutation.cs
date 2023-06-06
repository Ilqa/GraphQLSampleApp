using GraphQLSampleApp.Data;
using GraphQLSampleApp.DTOs;
using GraphQLSampleApp.Models;
using HotChocolate.Subscriptions;

namespace GraphQLSampleApp.GraphQL;

public class Mutation
{

    [UseDbContext(typeof(ApiDbContext))]
    public async Task<ProductCategory> AddProductCategoryAsync(ProductCategoryInput input, [ScopedService] ApiDbContext context)
    {
        var category = new ProductCategory
        {
            Name = input.Name
        };

        context.ProductCategories.Add(category);
        await context.SaveChangesAsync();

        return category;
    }


    [UseDbContext(typeof(ApiDbContext))]
    public async Task<Product> AddProductAsync(ProductInput input, [ScopedService] ApiDbContext context,
        [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Title = input.Title,
            Description = input.Description,
            Imported = input.Imported,
            CategoryId = input.CategoryId
        };

        context.Products.Add(product);
        await context.SaveChangesAsync();

        await eventSender.SendAsync(nameof(Subscription.OnProductAdded), product, cancellationToken);


        return product;
    }

}

