using Framework.Infrastructure;

namespace Framework.Authentication
{
    internal class Authenticator
    {
        private readonly Credentials _credentials;
        public Authenticator(Credentials credentials)
        {
            _credentials = credentials;
        }

        public void Apply(WebAgent webAgent)
        {
            IAuthenticationHandler authenticator;

            if (_credentials.AuthenticationType == AuthenticationType.Anonymous)
                authenticator = new AnonymousAuthenticator();
            else
                authenticator = new StandardAuthenticator();

            authenticator.Authenticate(webAgent, _credentials);
        }
    }
}