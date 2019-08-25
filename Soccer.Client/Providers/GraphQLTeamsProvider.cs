using GraphQL.Client;
using GraphQL.Common.Request;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soccer.Providers
{

    public class GraphQLTeamsProvider : GraphQLProvider, ITeamsProvider
    {
        public GraphQLTeamsProvider(IGraphQLClient graphQLClient) : base(graphQLClient)
        {
        }

        public async Task<List<Team>> GetTeamsAsync(string search = "*")
        {
            var req = new GraphQLRequest
            {
                Query = @"
query Teams($search : String){
  teams(search : $search){
    name
  }
}",
                Variables = new { search }
            };


            var response = await Client.SendQueryAsync(req);

            return response.GetDataFieldAs<List<Team>>("teams");
        }
    }
}
