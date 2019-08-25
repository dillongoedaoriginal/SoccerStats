using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;
using Soccer.Client.Models;

namespace Soccer.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] IStatsProvider StatsProvider { get; set; }
        [Inject] ITeamsProvider TeamsProvider { get; set; }

        protected List<Stat> Stats;
        protected List<WinningStat> WinningStats;
        protected Dictionary<string, int> Summary = new Dictionary<string, int>();
        protected bool isLoadingStats = false;
        protected bool isLoadingWinningStats = false;

        protected bool ShowStats => Stats != null;
        protected bool NoStats => ShowStats && !Stats.Any();

        protected TeamFormModel Team1FormModel = new TeamFormModel();
        protected TeamFormModel Team2FormModel = new TeamFormModel();

        protected bool CanSearch => !string.IsNullOrEmpty(Team1FormModel.Team?.Name) && !string.IsNullOrEmpty(Team2FormModel.Team?.Name) && Team1FormModel.Team?.Name != Team2FormModel.Team?.Name;

        protected void GetStats(string team1, string team2)
        {
            isLoadingStats = true;
            isLoadingWinningStats = true;
            var statsTask = StatsProvider.GetStatsAsync(team1, team2).ContinueWith(s =>
            {
                isLoadingStats = false;
                Stats = s.Result;

                Summary = new Dictionary<string, int>
                    ();
                foreach (var stat in Stats)
                {
                    if (Summary.ContainsKey(stat.Winner)) Summary[stat.Winner]++;
                    else Summary[stat.Winner] = 1;
                }

                StateHasChanged();

            }, TaskScheduler.FromCurrentSynchronizationContext());


            var winningStatsTaks = StatsProvider.GetWinningStatsAsync(team1, team2).ContinueWith(ws =>
            {
                isLoadingStats = false;
                WinningStats = ws.Result;

                StateHasChanged();

            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
        
        protected async Task<List<Team>> SearchTeams(string search)
        {
            return await TeamsProvider.GetTeamsAsync(search);
        }
    }
}
