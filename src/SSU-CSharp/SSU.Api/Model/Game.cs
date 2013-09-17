using System;

namespace SSU.Model
{
    public class Game : SSUBase
    {
        public int? Id { get; set; }

        public int? HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public int? AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public GameLocation GameLocation { get; set; }

        public GameField GameField { get; set; }
    }
}
