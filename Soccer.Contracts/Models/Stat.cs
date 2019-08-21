using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Contracts.Models
{
    public class Stat
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Winner { get; set; }
        public int FTHG { get; set; }
        public int FTAG { get; set; }
        public string Ground { get; set; }
    }
}
