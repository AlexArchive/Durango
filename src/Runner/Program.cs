using Framework;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            XboxClient client = new XboxClient("twerkteam@yopmail.com", "teamtwerk1");
            var friends = client.Friends.GetFriendsOf("xMurta");
        }
    }
}
