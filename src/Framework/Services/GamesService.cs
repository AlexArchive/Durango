using Framework.Common;
using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Framework.Services
{
    public class GamesService : ServiceBase
    {

        private const string BaseAddress = "https://live.xbox.com/en-US/Activity/Summary?compareTo=";

        public GamesService(string username, string password)
            : base(username, password)
        {

        }

        public IEnumerable<Game> GetGames(string gamertag)
        {
            EnsureAuthenticated();

            var document = DownloadDocumentNode("https://live.xbox.com/en-GB/Friends");
            var docNode = document.DocumentNode;

            var token =
                docNode.SelectSingleNode("//input[@name='__RequestVerificationToken']").Attributes["value"].Value;

            var requestUri = BaseAddress + gamertag + "&lc=1033";
            var response = WebAgent.Post(
                requestUri,
                "__RequestVerificationToken=" + token,
                new WebHeaderCollection { { "X-Requested-With", "XMLHttpRequest" } }
            );

            var content = response.GetResponseStream().ReadAsString();

            dynamic games = JObject.Parse(content)["Data"]["Games"];
            foreach (var game in games)
            {
                // remove any notion of the comparate  
                game.Progress.Replace(
                     JObject.FromObject(new
                     {
                         game.Progress[gamertag].Score,
                         game.Progress[gamertag].Achievements,
                         game.Progress[gamertag].LastPlayed
                     }));
            }

            return games.ToObject<IEnumerable<Achievement>>();
        }
    }
}