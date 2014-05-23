using Framework.Infrastructure;

namespace Framework
{
    public class Connection
    {
        private readonly Authenticator _authenticator;
        public WebAgent WebAgent { get; private set; }

        public Connection(WebAgent webAgent, string username, string password)
        {
            WebAgent = webAgent;
            _authenticator = new Authenticator(username, password);
            _authenticator.Apply(WebAgent);
        }
    }
}