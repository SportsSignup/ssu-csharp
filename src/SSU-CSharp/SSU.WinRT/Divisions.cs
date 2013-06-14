using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
            return await ExecuteAsync(url, typeof (IEnumerable<Division>)) as IEnumerable<Division>;
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