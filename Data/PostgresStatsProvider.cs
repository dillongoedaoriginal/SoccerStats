using Microsoft.EntityFrameworkCore;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class PostgresStatsProvider : PostgresProvider, IStatsProvider
    {

        public PostgresStatsProvider(SoccerContext context) : base(context)
        {
        }

        public List<Stat> GetStats(string team1, string team2)
        {
            return GetStatsAsync(team1, team2).Result;
        }

        public async Task<List<Stat>> GetStatsAsync(string team1, string team2)
        {
            return await SoccerContext.Stats.FromSqlRaw($"SELECT * FROM public.GetStats('{team1}', '{team2}')").ToListAsync();
        }

        public async Task<List<WinningStat>> GetWinningStatsAsync(string team1, string team2)
        {
            return await SoccerContext.WinningStats.FromSqlRaw($"SELECT * FROM public.GetWinningStats('{team1}', '{team2}')").ToListAsync();
        }
    }
}
