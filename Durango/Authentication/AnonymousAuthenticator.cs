using Durango.Infrastructure;

namespace Durango.Authentication
{
    internal class AnonymousAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(WebAgent webAgent, Credentials credentials)
        {
        }
    }
}