using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSU.Model;
using Windows.Foundation;

namespace SSU
{
    public sealed partial class SSURestClient
    {
        public IAsyncOperation<IEnumerable<Division>> DivisionsBySessionIdAsync(int sessionId)
        {
            return AsyncInfo.Run(ct => GetBySessionIdInteral(sessionId));
        }

        private async Task<IEnumerable<Division>> GetBySessionIdInteral(int sessionId)
        {
            var url = BaseUrl + "/Divisions/BySessionId/{Id}".Replace("{Id}", sessionId.ToString());
            var response = await new HttpClient(handler).GetAsync(url);

            string responseString = await response.Content.ReadAsStringAsync();
            // parse to json
            var result =
                JsonConvert.DeserializeObject(responseString, typeof (IEnumerable<Division>)) as IEnumerable<Division>;
            return result;
        }

        //public Team CreateTeamInDivision(int divisionId, string teamName)
        //{
        //    var request = new RestRequest(Method.POST)
        //    {
        //        Resource = "/{LeagueSid}/Divisions/CreateTeam/{Id}"
        //    };

        //    request.AddUrlSegment("Id", divisionId.ToString());
        //    request.AddParameter("name", teamName);

        //    return Execute<Team>(request);
        //}
    }
}