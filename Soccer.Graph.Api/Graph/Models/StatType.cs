using GraphQL.Types;
using Soccer.Contracts.Models;

namespace Soccer.Api.Graph.Models
{
    public class StatType : ObjectGraphType<Stat>
    {
        public StatType()
        {
            Name = "Stat";

            Field(x => x.AwayTeam);
            Field(x => x.HomeTeam);
            Field(x => x.Ground);
            Field(x => x.FTAG);
            Field(x => x.FTHG);
            Field(x => x.Winner);
        }
    }
}
