using System.Collections.Generic;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        /// <summary>
        /// Returns a list of all active sessions for the logged in league - active sessions are those that are visible to admins, and may have closed recently.
        /// </summary>
        /// <returns></returns>
        public List<Session> ListActiveSessions()
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Sessions/ActiveSessions"
                };

            return Execute<List<Session>>(request);
        }

        /// <summary>
        /// Returns a list of all available sessions for the logged in league - available sessions are those that can be registered for.
        /// </summary>
        /// <returns></returns>
        public List<Session> ListAvailableSessions()
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Sessions/AvailableSessions"
            };

            return Execute<List<Session>>(request);
        }

    }
}
