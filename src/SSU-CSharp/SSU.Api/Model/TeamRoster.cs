using System.Collections.Generic;

namespace SSU.Model
{
    public class TeamRoster : SSUBase
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public IList<RosteredIndividual> Players { get; set; }

        public IList<RosteredIndividual> Helpers { get; set; }
    }
}