using System.Collections.Generic;
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
        public IAsyncOperation<IEnumerable<Team>> TeamsByDivisionIdAsync(int divisionId)
        {
            return AsyncInfo.Run(ct => GetByDivisionIdInteral(divisionId));
        }


        private async Task<IEnumerable<Team>> GetByDivisionIdInteral(int divisionId)
        {
            var url = BaseUrl + "/Teams/ByDivisionId/{Id}".Replace("{Id}", divisionId.ToString());
            var response = await new HttpClient(handler).GetAsync(url);

            string responseString = await response.Content.ReadAsStringAsync();
            // parse to json
            var uncastedResult =
                JsonConvert.DeserializeObject(responseString, typeof(IEnumerable<Team>));
            if (uncastedResult is IEnumerable<Team>)
            {
                return uncastedResult as IEnumerable<Team>;
            } 
            return new List<Team>();
        }
    }
}