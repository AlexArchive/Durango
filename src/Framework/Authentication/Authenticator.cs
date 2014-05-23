using Framework.Infrastructure;

namespace Framework.Authentication
{
    public class Authenticator
    {
        private readonly Credentials _credentials;
        public Authenticator(Credentials credentials)
        {
            _credentials = credentials;
        }

        public void Apply(WebAgent webAgent)
        {
            IAuthenticationHandler authenticationHandler = new StandardAuthenticator();
            authenticationHandler.Authenticate(webAgent, _credentials);
        }
    }
}