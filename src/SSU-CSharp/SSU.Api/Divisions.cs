﻿using System.Collections.Generic;
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
                    Resource = "/api/{LeagueSid}/Divisions/BySessionId/{Id}.json"
                };

            request.AddUrlSegment("Id", sessionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Division>>(request);
        }

        public Team CreateTeamInDivision(int divisionId, string teamName)
        {
            var request = new RestRequest(Method.POST)
                {
                    Resource = "/api/{LeagueSid}/Divisions/CreateTeam/{Id}"
                };

            request.AddUrlSegment("Id", divisionId.ToString());
            request.AddParameter("name", teamName);

            return Execute<Team>(request);
        }
    }
}