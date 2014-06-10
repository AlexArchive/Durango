namespace Service.Modules
{
    public class ProfileModule : ModuleBase
    {
        public ProfileModule()
        {
            Get["/profile/{gamertag}"] = context => 
                XboxClient.Profile.GetProfile((string) context.gamertag);
        }
    }
}