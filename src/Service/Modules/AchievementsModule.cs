using Nancy;

namespace Service.Modules
{
    public class AchievementsModule : ModuleBase
    {
        public AchievementsModule()
        {
            Get["/profile/{gamertag}/games/{gameId}/achievements"] = context =>
            {
                var achievements = XboxClient.Achievements.GetAchievements(context.gamertag, context.gameId);

                if (achievements != null) return achievements;

                return this.ErrorMessage(HttpStatusCode.BadRequest,
                    @"Either the specified profile does not exist or the profile does not have any record of 
                     the specified game.");
            };
        }
    }
}
