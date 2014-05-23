using System.Collections.Generic;
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
            IAuthenticationHandler authenticator = authenticators[_credentials.AuthenticationType];
            authenticator.Authenticate(webAgent, _credentials);
        }

        private readonly Dictionary<AuthenticationType, IAuthenticationHandler> authenticators =
            new Dictionary<AuthenticationType, IAuthenticationHandler>
                {
                    { AuthenticationType.Anonymous, new AnonymousAuthenticationHandler() },
                    { AuthenticationType.Standard, new StandardAuthenticator() },
                };
    }
}