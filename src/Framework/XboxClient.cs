using Framework.Clients;
using Framework.Infrastructure;

namespace Framework
{
    public class XboxClient
    {
        public XboxClient()
            : this(Credentials.Annonymous)
        {
        }

        public XboxClient(Credentials credentials)
        {
            Connection connection = new Connection(credentials);

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