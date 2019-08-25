using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccer.Contracts.Interfaces;
using Soccer.Contracts.Models;

namespace Soccer.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] IStatsProvider StatsProvider { get; set; }
        [Inject] ITeamsProvider TeamsProvider { get; set; }

        protected List<string> Teams = new List<string>();
        protected List<Stat> Stats;
        protected List<WinningStat> WinningStats;
        protected Dictionary<string, int> Summary = new Dictionary<string, int>();

        protected bool ShowStats => Stats != null;
        protected bool NoStats => ShowStats && !Stats.Any();

        protected string team1 = "";
        protected string team2 = "";
        protected bool CanSearch => !string.IsNullOrEmpty(team1) && !string.IsNullOrEmpty(team2) && team1 != team2;

        protected async override Task OnInitializedAsync()
        {
            var teams = await TeamsProvider.GetTeamsAsync();
            Teams = teams.OrderBy(t => t.Name).Select(t => t.Name).ToList();
        }

        protected void GetStats(string team1, string team2)
        {
            var statsTask = StatsProvider.GetStatsAsync(team1, team2).ContinueWith(s =>
            {
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
                WinningStats = ws.Result;

                StateHasChanged();

            }, TaskScheduler.FromCurrentSynchronizationContext());

        }


    }
}
