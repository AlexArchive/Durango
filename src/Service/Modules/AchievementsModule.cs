namespace Service.Modules
{
    public class AchievementsModule : ModuleBase
    {
        public AchievementsModule()
        {
            Get["/profile/{gamertag}/games/{gameId}/achievements"] = context => 
                XboxClient.Achievements.GetAchievements(context.gamertag, context.gameId);
        }
    }
}
