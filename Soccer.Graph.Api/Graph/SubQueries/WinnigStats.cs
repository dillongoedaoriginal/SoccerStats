using GraphQL.Types;
using Soccer.Api.Graph.Models;
using Soccer.Contracts.Interfaces;

namespace Soccer.Graph.Api.Graph.SubQueries
{
    public static class WinnigStats
    {
        public static void Add(IStatsProvider statsProvider, ComplexGraphType<object> type)
        {
            type.Field<ListGraphType<WinningStatType>>("winningStats", arguments: new QueryArguments
            {
                 new QueryArgument(typeof(StringGraphType))
                {
                    Name = "team1",
                    Description = "Team 1"
                },

                new QueryArgument(typeof(StringGraphType))
                {
                    Name = "team2",
                    Description = "Team 2"
                }
            },
             resolve: context =>
             {
                 var c = context as ResolveFieldContext;

                 var team1 = c.Arguments["team1"].ToString();
                 var team2 = c.Arguments["team2"].ToString();

                 return statsProvider.GetWinningStatsAsync(team1, team2).Result;
             });
        }
    }
}
