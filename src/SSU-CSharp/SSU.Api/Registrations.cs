using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using RestSharp.Validation;
using SSU.Model;

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
                    Resource = "/v1/{LeagueSubdomain}/Registrations/ById/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            return Execute<Registration>(request);
        }

        /// <summary>
        /// Gets a list of all of the DataValue mappings of the properties on the registration, including custom fields and object properties.
        /// </summary>
        /// <param name="registrationId">The registration to look up.</param>
        /// <returns></returns>
        public IList<DataValue> Detail(int registrationId)
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Registrations/Detail/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<DataValue>>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataValue GetDataValue(int registrationId, string name)
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Registrations/DataValue/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            request.AddParameter("name", name);

            return Execute<DataValue>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationId"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataValue SetDataValue(int registrationId, string name, string value)
        {
            Require.Argument("name", name);
            Require.Argument("value", value);

            var request = new RestRequest(Method.POST)
                {
                    Resource = "/v1/{LeagueSubdomain}/Registrations/DataValue/{Id}"
                };

            request.AddUrlSegment("Id", registrationId.ToString(CultureInfo.InvariantCulture));
            request.AddParameter("name", name);
            request.AddParameter("value", value);

            return Execute<DataValue>(request);
        }


        /// <summary>
        /// Gets a list of registrations on a session
        /// </summary>
        /// <param name="sessionId">The id of the session to query for</param>
        /// <returns></returns>
        public IList<Registration> RegistrationsBySessionId(int sessionId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Registrations/BySessionId/{Id}"
            };

            request.AddUrlSegment("Id", sessionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Registration>>(request);            
        }

        /// <summary>
        /// Gets a list of registrations on a division
        /// </summary>
        /// <param name="divisionId">The id of the division to query for</param>
        /// <returns></returns>
        public IList<Registration> RegistrationsByDivisionId(int divisionId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Registrations/ByDivisionId/{Id}"
            };

            request.AddUrlSegment("Id", divisionId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Registration>>(request);
        }

        /// <summary>
        /// Gets a list of registrations on a team
        /// </summary>
        /// <param name="teamId">The id of the team to query for</param>
        /// <returns></returns>
        public IList<Registration> RegistrationsByTeamId(int teamId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Registrations/ByTeamId/{Id}"
            };

            request.AddUrlSegment("Id", teamId.ToString(CultureInfo.InvariantCulture));
            return Execute<List<Registration>>(request);
        }
    }
}