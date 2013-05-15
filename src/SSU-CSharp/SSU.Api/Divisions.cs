using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        public List<Division> GetBySessionId(int sessionId)
        {
            var request = new RestRequest
                {
                    Resource = "/api/{LeagueSid}/Divisions/BySessionId/{Id}"
                };

            request.AddUrlSegment("Id", sessionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Division>>(request);
        }
    }
}