﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
            return await ExecuteAsync(url, typeof(IEnumerable<Team>)) as IEnumerable<Team>;
        }

        public IAsyncOperation<Team> GetTeamAsync(int teamId)
        {
            return AsyncInfo.Run(ct => GetTeamInternal(teamId));
        }

        private async Task<Team> GetTeamInternal(int teamId)
        {
            var url = BaseUrl + "/Teams/Get/{Id}".Replace("{Id}", teamId.ToString());
            return await ExecuteAsync(url, typeof(Team)) as Team;
        }
    }
}