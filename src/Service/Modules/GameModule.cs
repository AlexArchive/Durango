using Nancy;

namespace Service.Modules
{
    public class GameModule : ModuleBase
    {
        public GameModule()
        {
            Get["/profile/{gamertag}/games"] = context =>
            {
                var games = _xboxClient.Games.GetGames((string) context.gamertag);
                return Response.AsJson(games);
            };
        }
    }
}