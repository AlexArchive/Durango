using Framework;
using System.Diagnostics;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new XboxClient("twerkteam@yopmail.com", "teamtwerk1");

            var friends = client.Friends.GetFriendsOf("xMurta");

        }
    }
}
