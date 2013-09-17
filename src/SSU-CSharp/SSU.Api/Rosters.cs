using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        public TeamRoster GetRoster(int teamId)
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Rosters/Get/{Id}"
                };
            request.AddUrlSegment("Id", teamId.ToString(CultureInfo.InvariantCulture));

            return Execute<TeamRoster>(request);
        }
    }
}
