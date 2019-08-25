using Microsoft.EntityFrameworkCore;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class PostgresTeamsProvider : PostgresProvider, ITeamsProvider
    {
        public PostgresTeamsProvider(SoccerContext context) : base(context)
        {
        }

        public async Task<List<Team>> GetTeamsAsync(string name = "*")
        {
            return await SoccerContext.Teams.FromSqlRaw("SELECT DISTINCT \"HomeTeam\" AS \"Name\" FROM public.\"Stats\"").ToListAsync();
        }
    }
}
