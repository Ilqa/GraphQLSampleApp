using GraphQLSampleApp.GraphQL;
using GraphQLSampleApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

builder.Services.AddGraphQLServer()
        .AddQueryType<Query>()
        .AddProjections();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager");
app.Run();
