using System.Diagnostics;
using Framework.Services;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var service = new SearchService("twerkteam@yopmail.com", "teamtwerk1");
            var something = service.Search("COD");
        }
    }
}
