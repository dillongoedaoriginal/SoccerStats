using GraphQL.Client;
using GraphQL.Common.Request;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soccer.Providers
{
    public class GraphQLStatsProvider : GraphQLProvider, IStatsProvider
    {
        public GraphQLStatsProvider(IGraphQLClient graphQLClient) : base(graphQLClient)
        {
        }

        public List<Stat> GetStats(string team1, string team2)
        {
            return GetStatsAsync(team1, team2).Result;
        }

        public async Task<List<Stat>> GetStatsAsync(string team1, string team2)
        {
            var req = new GraphQLRequest
            {
                Query = @"
query Stats($team1: String, $team2: String) {
  stats(team1: $team1, team2: $team2) {
   homeTeam,
    awayTeam,
    winner,
    ground,
    fTAG,
    fTHG
  }
}
",
                Variables = new
                {
                    team1,
                    team2
                }
            };

            var res = await Client.SendQueryAsync(req);

            return res.GetDataFieldAs<List<Stat>>("stats");
        }

        public async Task<List<WinningStat>> GetWinningStatsAsync(string team1, string team2)
        {
            var req = new GraphQLRequest
            {
                Query = @"
query WinningStats($team1: String, $team2: String){
  winningStats(team1: $team1, team2: $team2) {
   teamName,
                noOfGames,
                noOfWins
            }
}
",
                Variables = new
                {
                    team1,
                    team2
                }
            };

            var res = await Client.SendQueryAsync(req);

            return res.GetDataFieldAs<List<WinningStat>>("winningStats");
        }
    }
}
