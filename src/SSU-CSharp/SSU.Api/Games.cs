using System.Collections.Generic;
using System.Globalization;
using RestSharp;
using SSU.Model;

namespace SSU
{
    public partial class SSURestClient
    {
        public List<Game> UpcomingGamesForTeam(int teamId)
        {
            var request = new RestRequest
                {
                    Resource = "/v1/{LeagueSubdomain}/Games/UpcomingGamesForTeam/{Id}"
                };
            request.AddUrlSegment("Id", teamId.ToString(CultureInfo.InvariantCulture));

            return Execute<List<Game>>(request);
        }

        public List<Game> UpcomingGames()
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Games/UpcomingGames"
            };

            return Execute<List<Game>>(request);
        }


        public Game GetGame(int gameId)
        {
            var request = new RestRequest
            {
                Resource = "/v1/{LeagueSubdomain}/Games/Get/{Id}"
            };
            request.AddUrlSegment("Id", gameId.ToString(CultureInfo.InvariantCulture));

            return Execute<Game>(request);
        }
    }
}