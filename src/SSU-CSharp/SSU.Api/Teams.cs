using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {

        public Team ByTeamId(int id)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Teams/Get/{Id}"
            };

            request.AddUrlSegment("Id", id.ToString(CultureInfo.InvariantCulture));
            return Execute<Team>(request);
        }


        public List<Team> TeamsByDivisionId(int divisionId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Teams/ByDivisionId/{Id}"
            };

            request.AddUrlSegment("Id", divisionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Team>>(request);
        }
    }
}
