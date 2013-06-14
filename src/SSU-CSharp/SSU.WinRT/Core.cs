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
    /// <summary>
    /// REST API wrapper.
    /// </summary>
    public sealed partial class SSURestClient
    {
        /// <summary>
        /// The base url of SSU's api service (https://api.sportssignup.com)
        /// </summary>
        public string BaseUrl { get; private set; }


        /// <summary>
        /// The League Sid to authenticate with - on Organization Info Page
        /// </summary>
        public string LeagueSid { get; private set; }


        /// <summary>
        /// The Account Sid of the admin user to authenticate with - on Admin User page.
        /// </summary>
        public string AccountSid { get; set; }


        /// <summary>
        /// The Auth Token of the admin user to authenticate with - on Admin User page.
        /// </summary>
        public string AuthToken { get; set; }

        private readonly HttpClientHandler handler;

        /// <summary>
        /// Creates a new client with the supplied credentials
        /// </summary>
        /// <param name="leagueSid">The League Sid to authenticate with - on Organization Info Page</param>
        /// <param name="accountSid">The Account Sid of the admin user to authenticate with - on Admin User page.</param>
        /// <param name="authToken">The Auth Token of the admin user to authenticate with - on Admin User page.</param>
        public SSURestClient(string leagueSid, string accountSid, string authToken)
        {
            LeagueSid = leagueSid;
            AccountSid = accountSid;
            AuthToken = authToken;
            BaseUrl = "https://api.sportssignup.com" + "/" + leagueSid;

            handler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(AccountSid, AuthToken)
                };
        }

        public IAsyncOperation<object> ExecuteAsync(string resource, Type type)
        {
            return AsyncInfo.Run(ct => ExecuteAsyncInternal(resource, type));
        }

        private async Task<object> ExecuteAsyncInternal(string resource, Type type)
        {
            var response = await new HttpClient(handler).GetAsync(resource).ConfigureAwait(false);
            string responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseString, type);
            return result;
        }
    }
}