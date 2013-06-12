using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using RestRT;
using SSU.Model;
using Windows.Foundation;

namespace SSU
{
    public sealed partial class SSURestClient
    {
        /// <summary>
        /// Returns a list of all active sessions for the logged in league.
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<IList<Session>> ListActiveSessionsAsync()
        {
            return AsyncInfo.Run(ct => ListActiveSessionsAsyncInternal());
        }
        private async Task<IList<Session>> ListActiveSessionsAsyncInternal()
        {
            var request = new RestRequest
                {
                    Resource = "/{LeagueSid}/Sessions/ActiveSessions"
                };

            var result = await ExecuteAsync(request, typeof(IList<Session>));
            return (IList<Session>) result;

        }
    }
}
