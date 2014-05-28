using Nancy;

namespace Service.Modules
{
    public class FriendsModule : ModuleBase
    {
        public FriendsModule()
        {
            Get["/profile/{gamertag}/friends"] = context =>
            {
                var friends = _xboxClient.Friends.GetFriends((string) context.gamertag);
                return Response.AsJson(friends);
            };
        }
    }
}