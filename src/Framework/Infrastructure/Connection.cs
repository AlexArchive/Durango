using System;
using Framework.Authentication;

namespace Framework.Infrastructure
{
    public class Connection
    {
        public Lazy<WebAgent> WebAgent { get; private set; }
        private readonly Authenticator _authenticator;

        public Connection(string username, string password)
        {
            _authenticator = new Authenticator(username, password);
            WebAgent = new Lazy<WebAgent>(ResolveWebAgent);
        }

        private WebAgent ResolveWebAgent()
        {
            var webAgent = new WebAgent();
            _authenticator.Apply(webAgent);
            return webAgent;
        }
    }
}