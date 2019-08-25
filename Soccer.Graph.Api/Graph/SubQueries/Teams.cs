using GraphQL.Types;
using Soccer.Api.Graph.Models;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Graph.Api.Graph.SubQueries
{
    public static class Teams
    {
        private static List<Team> _teams;

        public static void Add(ITeamsProvider teamsProvider, ComplexGraphType<object> type)
        {

            type.Field<ListGraphType<TeamType>>("teams",
             arguments: new QueryArguments
             {
                 new QueryArgument(typeof(StringGraphType))
                 {
                     Name = "search",
                     Description = "Search for teams",
                     DefaultValue = "*"

                 }
             },
            resolve: context =>
            {
                if (_teams == null) _teams = teamsProvider.GetTeamsAsync().Result;

                var search = (string)(context as ResolveFieldContext).Arguments["search"];

                return search == "*" ? _teams : _teams.Where(t => t.Name.ToLower().Contains(search.ToLower())).OrderBy(t => t.Name).ToList();
            });
        }
    }
}
