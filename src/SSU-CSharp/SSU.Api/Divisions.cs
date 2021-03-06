﻿using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        public Division GetByDivisionId(int id)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Divisions/Get/{Id}"
            };

            request.AddUrlSegment("Id", id.ToString(CultureInfo.InvariantCulture));
            return Execute<Division>(request);            
        }

        public List<Division> DivisionsBySessionId(int sessionId)
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Divisions/BySessionId/{Id}"
                };

            request.AddUrlSegment("Id", sessionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Division>>(request);
        }

        public Team CreateTeamInDivision(int divisionId, string teamName)
        {
            var request = new RestRequest(Method.POST)
                {
                    Resource = "/v1/{LeagueSubdomain}/Divisions/CreateTeam/{Id}"
                };

            request.AddUrlSegment("Id", divisionId.ToString());
            request.AddParameter("name", teamName);

            return Execute<Team>(request);
        }
    }
}