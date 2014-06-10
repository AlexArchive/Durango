using Framework.Common;
using Framework.Infrastructure;
using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Framework.Clients
{
    public class GamesClient : ClientBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Activity/Summary?compareTo=";

        internal GamesClient(Connection connection)
            : base(connection)
        {
        }

        public IEnumerable<Game> GetGames(string gamertag)
        {
            EnsureAuthenticated();

            gamertag = gamertag.ToLower();
            var document = DownloadDocument("https://live.xbox.com/en-GB/Friends");
            var docNode = document.DocumentNode;

            var token =
                docNode.SelectSingleNode("//input[@name='__RequestVerificationToken']").Attributes["value"].Value;

            var requestUri = BaseAddress + gamertag + "&lc=1033";
            var response = WebAgent.Post(
                requestUri,
                "__RequestVerificationToken=" + token,
                new WebHeaderCollection {{"X-Requested-With", "XMLHttpRequest"}}
            );

            var content = response.GetResponseStream().ReadAsString();
            content = content.ToLower();

            dynamic games = JObject.Parse(content)["data"]["games"];
            foreach (var game in games)
            {
                // remove any notion of the comparate  
                game.progress.Replace(
                     JObject.FromObject(new
                     {
                         game.progress[gamertag].score,
                         game.progress[gamertag].achievements,
                         game.progress[gamertag].lastplayed
                     }));
            }

            games = games.ToObject<IEnumerable<Game>>();
            if (games.Count == 0)
            {
                return null;
            }
            return games;
        }
    }
}