using Framework;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new XboxClient(new Credentials("twerkteam@yopmail.com", "teamtwerk1"));
            var friends = client.Friends.GetFriendsOf("xMurta");
        }
    }
}
