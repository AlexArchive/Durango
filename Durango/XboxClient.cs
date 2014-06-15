using Durango.Clients;
using Durango.Infrastructure;

namespace Durango
{
    public class XboxClient
    {
        public XboxClient() 
            : this (new Connection(Credentials.Annonymous))
        {
        }

        public XboxClient(string username, string password)
            : this (new Connection(new Credentials(username, password)))
        {

        }

        private XboxClient(Connection connection)
        {
            Profile = new ProfileClient(connection);
            Friends = new FriendsClient(connection);
            Games = new GamesClient(connection);
            Achievements = new AchievementsClient(connection);
            Search = new SearchClient(connection);
        }

        public ProfileClient Profile { get; private set; }
        public FriendsClient Friends { get; private set; }
        public GamesClient Games { get; private set; }
        public AchievementsClient Achievements { get; private set; }
        public SearchClient Search { get; private set; }
    }
}