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

        public IAsyncOperation<object> ExecuteAsync(string resource)
        {
            return AsyncInfo.Run(ct => ExecuteAsyncInternal(resource));
        }

        private async Task<object> ExecuteAsyncInternal(string resource)
        {
            var url = BaseUrl + resource;
            var response = await new HttpClient(handler).GetAsync(url);
            
            string responseString = await response.Content.ReadAsStringAsync();
            // parse to json
            var result = JsonConvert.DeserializeObject(responseString);
            return result;
        }


        //public IAsyncOperation<object> ExecuteAsync(IRestRequest request)
        //{
        //    return
        //        AsyncInfo.Run(ct => ExecuteAsyncInternal(request));
        //}

        //private async Task<object> ExecuteAsyncInternal(IRestRequest request)
        //{
        //    var result = await client.ExecuteAsync(request);

        //    return result;
        //}

        ///// <summary>
        ///// Execute a manual REST request
        ///// </summary>
        ///// <param name="request">The RestRequest to execute (will use client credentials)</param>
        ///// <param name="type"></param>
        //public IAsyncOperation<object> ExecuteAsync(IRestRequest request, Type type)
        //{
        //    return
        //        AsyncInfo.Run(ct => ExecuteAsyncInternal(request, type));
        //}

        //private async Task<object> ExecuteAsyncInternal(IRestRequest request, Type type)
        //{
        //    var result = await client.ExecuteAsync(request);

        //    if (result.StatusCode >= 400)
        //    {
        //        // have to read the bytes so .Content doesn't get populated
        //        //var content = result.RawBytes.AsString();
        //        //var json = JObject.Parse(content);
        //        //var newJson = new JObject();
        //        //newJson["RestException"] = json;
        //        //result.Content = null;
        //        //result.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());

        //        // have to read the bytes so .Content doesn't get populated
        //        const string restException = "{{ \"RestException\" : {0} }}";
        //        var content = result.RawBytes.AsString(); //get the response content
        //        var newJson = string.Format(restException, content);

        //        result.Content = null;
        //        result.RawBytes = Encoding.UTF8.GetBytes(newJson);
        //    }

        //    var deserializer = new JsonDeserializer();
        //    return deserializer.Deserialize(result, type);
        //}
    }
}