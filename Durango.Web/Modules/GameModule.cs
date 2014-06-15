using System.Collections.Generic;
using System.Linq;
using Durango.Models;
using Nancy;

namespace Durango.Web.Modules
{
    public class GameModule : ModuleBase
    {
        public GameModule()
        {
            Get["/profile/{gamertag}/games"] = context =>
            {
                IEnumerable<Game> games = XboxClient.Games.GetGames(context.gamertag);

                if (games == null) 
                    return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");

                // resource linking
                string baseUri = Request.BaseUri();
                IEnumerable<dynamic> gamesDto = games.Select(game =>
                {
                    var gameDto = game.ToExpandoObject();
                    gameDto.Achievments = new {
                        Link = baseUri + "/profile/" + context.gamertag + "/games/" + gameDto.Id + "/achievements"
                    };
                    return gameDto;
                });
                return gamesDto;
            };
        }
    }
}