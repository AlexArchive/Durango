using Nancy;

namespace Service.Modules
{
    public class ProfileModule : ModuleBase
    {
        public ProfileModule()
        {
            Get["/profile/{gamertag}"] = context =>
            {
                var profile = _xboxClient.Profile.GetProfile((string) context.gamertag);
                return Response.AsJson(profile);
            };
        }
    }
}