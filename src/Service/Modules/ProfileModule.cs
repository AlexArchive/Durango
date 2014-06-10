using Nancy;

namespace Service.Modules
{
    public class ProfileModule : ModuleBase
    {
        public ProfileModule()
        {
            Get["/profile/{gamertag}"] = context =>
            {
                var profile = XboxClient.Profile.GetProfile(context.gamertag);
                
                if (profile != null) return profile;
                
                return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");
            };
        }
    }
}