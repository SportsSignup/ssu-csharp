using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using SSU.Model;
using Windows.Foundation;

namespace SSU
{
    public sealed partial class SSURestClient
    {
        public IAsyncOperation<OrganizationInformation> GetOrganizationInfoAsync()
        {
            return AsyncInfo.Run(ct => GetOrganizationInfoInternal());
        }

        private async Task<OrganizationInformation> GetOrganizationInfoInternal()
        {
            var url = BaseUrl + "/OrganizationInfo/Get";
            return await ExecuteAsync(url, typeof (OrganizationInformation)) as OrganizationInformation;
        }
    }
}