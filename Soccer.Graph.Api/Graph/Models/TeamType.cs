using GraphQL.Types;
using Soccer.Contracts.Models;

namespace Soccer.Api.Graph.Models
{
    public class TeamType : ObjectGraphType<Team>
    {
        public TeamType()
        {
            Name = "Team";
            Field(x => x.Name);
        }
    }
}
