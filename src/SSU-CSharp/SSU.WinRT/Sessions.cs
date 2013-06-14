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
        /// <summary>
        /// Returns a list of all active sessions for the logged in league.
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<IEnumerable<Session>> ListActiveSessionsAsync()
        {
            return AsyncInfo.Run(ct => ListActiveSessionsAsyncInternal());
        }

        private async Task<IEnumerable<Session>> ListActiveSessionsAsyncInternal()
        {
            var url = BaseUrl + "/Sessions/ActiveSessions";
            return await ExecuteAsync(url, typeof(IEnumerable<Session>)) as IEnumerable<Session>;
        }

        /// <summary>
        /// Returns a list of all active sessions for the logged in league.
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<IEnumerable<Session>> ListAvailableSessionsAsync()
        {
            return AsyncInfo.Run(ct => ListAvailableSessionsAsyncInternal());
        }

        private async Task<IEnumerable<Session>> ListAvailableSessionsAsyncInternal()
        {
            var url = BaseUrl + "/Sessions/AvailableSessions";
            return await ExecuteAsync(url, typeof(IEnumerable<Session>)) as IEnumerable<Session>;
        }

    }
}