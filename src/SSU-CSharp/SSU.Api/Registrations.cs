using System.Collections.Generic;
using System.Globalization;
using RestSharp;

namespace SSU
{
    public partial class SSURestClient
    {
        /// <summary>
        /// Returns a Registration when queryed by it's Id.
        /// </summary>
        /// <param name="registrationId">The id the registration to query for</param>
        /// <returns></returns>
        public Registration GetByRegistrationId(int registrationId)
        {
            var request = new RestRequest
                {
                    Resource = "/api/{LeagueSid}/Registrations/ById/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            return Execute<Registration>(request);
        }

        /// <summary>
        /// Gets a list of registrations on a team
        /// </summary>
        /// <param name="teamId">The id of the team to query for</param>
        /// <returns></returns>
        public IList<Registration> GetByTeamId(int teamId)
        {
            var request = new RestRequest
                {
                    Resource = "/api/{LeagueSID}/Registrations/ByTeamId/{id}"
                };

            request.AddUrlSegment("Id", teamId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Registration>>(request);
        }
    }
}