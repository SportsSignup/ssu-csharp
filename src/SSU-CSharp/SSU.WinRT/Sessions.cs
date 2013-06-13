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
            var response = await new HttpClient(handler).GetAsync(url);

            string responseString = await response.Content.ReadAsStringAsync();
            // parse to json
            var result = JsonConvert.DeserializeObject(responseString, typeof(IEnumerable<Session>)) as IEnumerable<Session>;
            return result;

            //var result = await ExecuteAsync("/Sessions/ActiveSessions") as List<Session>;
            //return result;
        }
    }
}