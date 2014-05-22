using System.Diagnostics;
using Framework.Services;

namespace Runner
{
    class Program
    {
        static void Main()
        {
            var service = new AchievementsService("twerkteam@yopmail.com", "teamtwerk1");
            var achievements = service.GetAchievements("xMurta", "1414793383");

            Debugger.Break();

        }
    }
}
