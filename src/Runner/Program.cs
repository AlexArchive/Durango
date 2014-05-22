using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;
using Framework.Services;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new FriendsService("twerkteam@yopmail.com", "teamtwerk1");
            service.GetFriendsOf("xMurta");

            Console.ReadKey();

        }
    }
}
