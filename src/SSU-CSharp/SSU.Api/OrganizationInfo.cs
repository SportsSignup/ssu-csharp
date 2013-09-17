using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        /// <summary>
        /// Returns information about the requested organization, such as their site url.
        /// </summary>
        /// <returns></returns>
        public OrganizationInfo GetOrganizationInfo()
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/OrganizationInfo/Get"
                };

            return Execute<OrganizationInfo>(request);
        }
    }
}
