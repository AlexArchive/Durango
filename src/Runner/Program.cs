using System;
using Framework.Common;
using Framework.Services;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new GamesService("twerkteam@yopmail.com", "teamtwerk1");
            var games = service.GetGames("xMurta");

            foreach (var game in games)
            {
                Console.WriteLine(game.ToStringAutomatic());
                Console.WriteLine("---");
            }

            Console.ReadKey();
        }
    }
}
