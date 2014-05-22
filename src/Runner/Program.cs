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
            var service = new ProfileService();
            var profile = service.GetProfile("LagKip");
            Console.WriteLine(profile.ToStringAutomatic());
            Console.ReadKey();
        }
    }
}
