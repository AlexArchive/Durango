using Nancy;

namespace Service.Modules
{
    public class AchievementsModule : ModuleBase
    {
        public AchievementsModule()
        {
            Get["/profile/{gamertag}/games/{gameId}/achievements"] = context =>
            {
                var achievements = 
                    _xboxClient.Achievements.GetAchievements(
                        (string) context.gamertag, (string) context.gameId);

                return Response.AsJson(achievements);
            };
        }
    }
}

//1414793383