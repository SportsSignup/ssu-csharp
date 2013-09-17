using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        /// <summary>
        /// Returns a list of all active sessions for the requested league - active sessions are those that are visible to admins, and may have closed recently.
        /// </summary>
        /// <returns></returns>
        public List<Session> GetPublicSessions()
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/PublicSessions/Get"
                };

            return Execute<List<Session>>(request);
        }

        /// <summary>
        /// Returns a list of all available sessions for the logged in league - available sessions are those that can be registered for.
        /// </summary>
        /// <returns></returns>
        public List<Team> TeamsBySessionId(int sessionId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Sessions/GetTeamsBySessionId/{Id}"
            };
            request.AddUrlSegment("Id", sessionId.ToString(CultureInfo.InvariantCulture));

            return Execute<List<Team>>(request);
        }

    }
}
