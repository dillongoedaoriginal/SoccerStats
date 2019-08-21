using GraphQL.Types;
using Soccer.Api.Graph.Models;
using Soccer.Contracts.Interfaces;

namespace Soccer.Graph.Api.Graph.SubQueries
{
    public static class Teams
    {
        public static void Add(ITeamsProvider teamsProvider, ComplexGraphType<object> type)
        {
            type.Field<ListGraphType<TeamType>>("teams",
           resolve: context =>
           {
               var teams = teamsProvider.GetTeamsAsync().Result;

               return teams;
           });
        }
    }
}
