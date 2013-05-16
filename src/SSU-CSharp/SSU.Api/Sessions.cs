using System.Collections.Generic;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        /// <summary>
        /// Returns a list of all active sessions for the logged in league.
        /// </summary>
        /// <returns></returns>
        public List<Session> ListActiveSessions()
        {
            var request = new RestRequest
                {
                    Resource = "/api/{LeagueSid}/Sessions/ActiveSessions.json"
                };

            return Execute<List<Session>>(request);
        }
    }
}
