using GraphQLSampleApp.Models;

namespace GraphQLSampleApp.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Product OnProductAdded([EventMessage] Product product) => product;  //Do some task
}
