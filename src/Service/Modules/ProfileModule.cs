using Framework.Models;
using Nancy;

namespace Service.Modules
{
    public class ProfileModule : ModuleBase
    {
        public ProfileModule()
        {
            Get["/profile/{gamertag}"] = context =>
            {
                Profile profile = XboxClient.Profile.GetProfile(context.Gamertag);

                if (profile == null)
                    return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");

                // resource linking
                string baseUri = Request.BaseUri();
                dynamic profileDto = profile.ToExpandoObject();
                profileDto.Friends = new { Link = baseUri + "/profile/" + context.Gamertag + "/friends" };
                profileDto.Games = new { Link = baseUri + "/profile/" + context.Gamertag + "/games" };
                return profileDto;
            };
        }
    }
}