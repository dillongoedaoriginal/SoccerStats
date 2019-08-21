using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soccer.Contracts.Interfaces
{
    public interface IStatsProvider
    {
        List<Stat> GetStats(string team1, string team2);
        Task<List<Stat>> GetStatsAsync(string team1, string team2);
        Task<List<WinningStat>> GetWinningStatsAsync(string team1, string team2);
    }
}
