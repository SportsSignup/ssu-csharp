using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        public List<Team> GetByDivisionId(int divisionId)
        {
            var request = new RestRequest
            {
                Resource = "/api/{LeagueSid}/Teams/ByDivisionId/{Id}.json"
            };

            request.AddUrlSegment("Id", divisionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Team>>(request);

        }
    }
}
