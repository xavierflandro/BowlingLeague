using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class TeamNameVCViewModel
    {
        public List<Team> Teams { get; set; }

        public BowlingLeagueContext context { get; set; }

        public string TeamName { get; set; }
    }
}
