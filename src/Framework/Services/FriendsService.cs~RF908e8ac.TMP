using System;
using System.Diagnostics;

namespace Framework.Services
{
    public class FriendsService : ServiceBase
    {
        public FriendsService(string username, string password) 
            : base(username, password)
        {
        }

        public void GetFriendsOf(string gamertag)
        {
            EnsureAuthenticated();
            Console.WriteLine(Authenticated);
        }
    }
}