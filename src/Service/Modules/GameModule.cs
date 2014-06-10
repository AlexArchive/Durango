namespace Service.Modules
{
    public class GameModule : ModuleBase
    {
        public GameModule()
        {
            Get["/profile/{gamertag}/games"] = context => 
                XboxClient.Games.GetGames((string) context.gamertag);
        }
    }
}