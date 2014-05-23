using Framework;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new XboxClient("twerkteam@yopmail.com", "teamtwerk1");
            var games = client.Achievements.GetAchievements("xMurta", "1096157387");

        }
    }
}