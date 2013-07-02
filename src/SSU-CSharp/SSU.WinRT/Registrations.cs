using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using SSU.Model;
using Windows.Foundation;

namespace SSU
{
    public sealed partial class SSURestClient
    {
        public IAsyncOperation<IEnumerable<Registration>> RegistrationsByTeamIdAsync(int teamId)
        {
            return AsyncInfo.Run(ct => RegistrationsByTeamIdInteral(teamId));
        }

        private async Task<IEnumerable<Registration>> RegistrationsByTeamIdInteral(int teamId)
        {
            var url = BaseUrl + "/Registrations/ByTeamId/{Id}".Replace("{Id}", teamId.ToString());
            return await ExecuteAsync(url, typeof(IEnumerable<Registration>)) as IEnumerable<Registration>;
        }

    }
}
