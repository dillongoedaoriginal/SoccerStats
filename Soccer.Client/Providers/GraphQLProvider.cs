using GraphQL.Client;

namespace Soccer.Providers
{
    public class GraphQLProvider
    {
        protected readonly IGraphQLClient Client;

        public GraphQLProvider(IGraphQLClient graphQLClient)
        {
            Client = graphQLClient;
        }
    }
}
