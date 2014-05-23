using Framework;
using System;
using System.Diagnostics;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new ServiceClient("twerkteam@yopmail.com", "teamtwerk1");
            //var searchResults = client.Search.SearchMarketplace("COD");

            Console.WriteLine("Authenticated.");

            Console.WriteLine("Press Any Key to get Achievements");
            Console.ReadKey();

            var achievements = client.Achievements.GetAchievements("xMurta", "1414793383");
            Debugger.Break();

            //Console.WriteLine("Press Any Key To Get Friends.");
            //var friends = client.Friends.GetFriendsOf("xMurta");
            //Console.WriteLine("Obtained Friends. Friends Count = {0}", friends.Count());
            //Console.WriteLine("Press Any Key To Get Games.");
            //client.Games.GetGames("xMurta");
            //Console.WriteLine("Obtained Games. Games Count = {0}", friends.Count());
            //Console.WriteLine("Press Any Key To Exit.");
            Console.ReadKey();
        }
    }
}
