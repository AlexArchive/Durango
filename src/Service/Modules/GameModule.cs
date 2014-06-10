using Nancy;

namespace Service.Modules
{
    public class GameModule : ModuleBase
    {
        public GameModule()
        {
            Get["/profile/{gamertag}/games"] = context =>
            {
                var games =  XboxClient.Games.GetGames((string) context.gamertag);

                if (games != null) return games;

                return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");
            };
        }
    }
}