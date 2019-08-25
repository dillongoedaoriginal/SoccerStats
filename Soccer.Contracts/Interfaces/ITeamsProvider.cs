using Soccer.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soccer.Contracts.Interfaces
{
    public interface ITeamsProvider
    {
        Task<List<Team>> GetTeamsAsync(string search = "*");
    }
}
