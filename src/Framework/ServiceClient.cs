using Framework.Infrastructure;
using Framework.Services;

namespace Framework
{
    public class ServiceClient
    {
        public ServiceClient(string username, string password)
        {
            Connection connection = new Connection(new WebAgent(), username, password);

            Search = new SearchService(connection);
            Friends = new FriendsService(connection);
            Games = new GamesService(connection);
            Achievements = new AchievementsService(connection);
        }

        public SearchService Search { get; private set; }
        public FriendsService Friends { get; private set; }
        public GamesService Games { get; private set; }
        public AchievementsService Achievements { get; private set; }
    }
}