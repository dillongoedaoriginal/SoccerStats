using GraphQL.Types;
using Soccer.Contracts.Models;

namespace Soccer.Api.Graph.Models
{
    public class WinningStatType : ObjectGraphType<WinningStat>
    {
        public WinningStatType()
        {
            Name = "WinningStat";

            Field(x => x.TeamName);
            Field(x => x.NoOfWins);
            Field(x => x.NoOfGames);
        }
    }
}
