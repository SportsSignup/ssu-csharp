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
            var result = new List<Session>();

            using (
                var handler = new HttpClientHandler
                    {
                        Credentials = new NetworkCredential(AccountSid, AuthToken)
                    })
            {
                var resource = BaseUrl + "/{LeagueSid}/Sessions/ActiveSessions";
                resource = resource.Replace("{LeagueSid}", LeagueSid);
                var response = await new HttpClient(handler).GetAsync(resource).ConfigureAwait(false);

                string responseString = await response.Content.ReadAsStringAsync();
                // parse to json
                result = JsonConvert.DeserializeObject<List<Session>>(responseString);
            }

            return result;

            //var request = new RestRequest
            //    {
            //        Resource = "/{LeagueSid}/Sessions/ActiveSessions"
            //    };

            //var result = await ExecuteAsync(request, typeof(IList<Session>));
            //return (IList<Session>) result;
        }
    }
}