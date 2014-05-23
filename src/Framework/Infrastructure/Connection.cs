using Framework.Authentication;

namespace Framework.Infrastructure
{
    public class Connection
    {
        public WebAgent WebAgent { get; private set; }

        public Connection(WebAgent webAgent, string username, string password)
        {
            WebAgent = webAgent;
            Authenticator authenticator = new Authenticator(username, password);
            authenticator.Apply(WebAgent);
        }
    }
}