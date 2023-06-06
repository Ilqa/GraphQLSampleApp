using GraphQLSampleApp.GraphQL;
using GraphQLSampleApp.Data;
using Microsoft.EntityFrameworkCore;
using GraphQLSampleApp.Types;
using GraphQLSampleApp.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

builder.Services.AddGraphQLServer()
        .AddQueryType<Query>()
        .AddType<ProductType>()
        .AddType<ProductCategoryType>()
        .AddFiltering()
        .AddSorting()
        .AddMutationType<Mutation>()
        .AddProjections();

var app = builder.Build();
app.MapGet("/", () => "Hello, the app is working! Please add '/graphql' to the url ");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager");
app.Run();
