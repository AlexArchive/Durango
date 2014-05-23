using Framework;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new XboxClient("x", "2");
            var friends = client.Friends.GetFriendsOf("xMurta");

        }
    }
}