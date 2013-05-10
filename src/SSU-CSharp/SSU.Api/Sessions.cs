using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

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
                    Resource = "api/{LeagueSid}/Sessions/ActiveSessions?json=true"
                };

            return Execute<List<Session>>(request);
        }
    }
}
