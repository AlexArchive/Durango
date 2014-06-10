namespace Service.Modules
{
    public class FriendsModule : ModuleBase
    {
        public FriendsModule()
        {
            Get["/profile/{gamertag}/friends"] = context => 
                XboxClient.Friends.GetFriends((string) context.gamertag);
        }
    }
}