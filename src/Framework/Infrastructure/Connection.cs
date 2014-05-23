using System;
using Framework.Authentication;

namespace Framework.Infrastructure
{
    public class Connection
    {
        public Lazy<WebAgent> WebAgent { get; private set; }
        public Credentials Credentials { get; private set; }

        public bool Authenticated { get; private set; }
        private readonly Authenticator _authenticator;

        public Connection(Credentials credentials)
        {
            Credentials = credentials;
            _authenticator = new Authenticator(credentials);
            WebAgent = new Lazy<WebAgent>(ResolveWebAgent);
        }

        private WebAgent ResolveWebAgent()
        {
            var webAgent = new WebAgent();
            _authenticator.Apply(webAgent);
            Authenticated = true;
            return webAgent;
        }
    }
}