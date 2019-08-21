using GraphQL.Types;
using Soccer.Contracts.Interfaces;
using Soccer.Graph.Api.Graph.SubQueries;

namespace Soccer.Api.Graph
{
    public class SoccerQuery : ObjectGraphType
    {
        public SoccerQuery(ITeamsProvider teamsProvider, IStatsProvider statsProvider)
        {
            Teams.Add(teamsProvider, this);
            Stats.Add(statsProvider, this);
            WinnigStats.Add(statsProvider, this);
        }
    }
}