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
                    Resource = "/api/{LeagueSID}/Registrations/ByTeamId/{Id}"
                };

            request.AddUrlSegment("Id", teamId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Registration>>(request);
        }

        /// <summary>
        /// Gets a list of all of the DataValue mappings of the properties on the registration, including custom fields and object properties.
        /// </summary>
        /// <param name="registrationId">The registration to look up.</param>
        /// <returns></returns>
        public IList<DataValue> GetDetail(int registrationId)
        {
            var request = new RestRequest
                {
                    Resource = "/api/{LeagueSID}/Registrations/Detail/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<DataValue>>(request);
        }

        public DataValue GetDataValue(int registrationId, string name)
        {
            var request = new RestRequest
            {
                Resource = "/api/{LeagueSID}/Registrations/DataValue/{Id}"
            };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            request.AddParameter("name", name);

            return Execute<DataValue>(request);
        }
    }
}