using Nancy;

namespace Service.Modules
{
    public class FriendsModule : ModuleBase
    {
        public FriendsModule()
        {
            Get["/profile/{gamertag}/friends"] = context =>
            {
                var friends = XboxClient.Friends.GetFriends(context.gamertag);

                if (friends != null) return friends;
                
                return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");
            };
        }
    }
}