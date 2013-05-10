using System.Reflection;
using System.Text;
using RestSharp;
using RestSharp.Extensions;

namespace SSU
{
    /// <summary>
    /// REST API Wrapper
    /// </summary>
    public partial class SSURestClient
    {
        public string BaseUrl { get; private set; }

        public string LeagueSid { get; private set; }

        public string AccountSid { get; set; }

        public string AuthToken { get; set; }

        private readonly RestClient client;

        /// <summary>
        /// Creates a new client with the supplied credentials
        /// </summary>
        /// <param name="leagueSid">The League Sid to authenticate with - on Organization Info Page</param>
        /// <param name="accountSid">The Account Sid of the admin user to authenticate with - on Admin User page.</param>
        /// <param name="authToken">The Auth Token of the admin user to authenticate with - on Admin User page.</param>
        public SSURestClient(string leagueSid, string accountSid, string authToken)
        {
            //BaseUrl = "https://api.sportssignup.com";
            BaseUrl = "http://localhost/lssapp/";
            LeagueSid = leagueSid;
            AccountSid = accountSid;
            AuthToken = authToken;

            // silverlight friendly way to get current version
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            client = new RestClient
                {
                    UserAgent = "ssu-csharp/" + version,
                    Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken),
                    BaseUrl = BaseUrl
                };

            client.AddDefaultUrlSegment("LeagueSid", LeagueSid);
        }

#if FRAMEWORK
        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual T Execute<T>(RestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
                {
                    // for individual resources when there's an error to make
                    // sure that RestException props are populated
                    if (((int) resp.StatusCode) >= 400)
                    {
                        // have to read the bytes so .Content doesn't get populated
                        string restException = "{{ \"RestException\" : {0} }}";
                        var content = resp.RawBytes.AsString(); //get the response content
                        var newJson = string.Format(restException, content);

                        resp.Content = null;
                        resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                    }
                };

            request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            var response = client.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public virtual IRestResponse Execute(IRestRequest request)
        {
            return client.Execute(request);
        }
#endif
    }
}