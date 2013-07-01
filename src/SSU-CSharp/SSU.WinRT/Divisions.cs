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
            return AsyncInfo.Run(ct => GetBySessionIdInternal(sessionId));
        }

        public IAsyncOperation<Division> GetDivisionAsync(int divisionId)
        {
            return AsyncInfo.Run(ct => GetDivisionInternal(divisionId));
        }

        private async Task<IEnumerable<Division>> GetBySessionIdInternal(int sessionId)
        {
            var url = BaseUrl + "/Divisions/BySessionId/{Id}".Replace("{Id}", sessionId.ToString());
            return await ExecuteAsync(url, typeof (IEnumerable<Division>)) as IEnumerable<Division>;
        }

        private async Task<Division> GetDivisionInternal(int divisionId)
        {
            var url = BaseUrl + "/Divisions/Get/{Id}".Replace("{Id}", divisionId.ToString());
            return await ExecuteAsync(url, typeof (Division)) as Division;
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