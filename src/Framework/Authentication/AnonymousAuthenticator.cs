using Framework.Infrastructure;

namespace Framework.Authentication
{
    internal class AnonymousAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(WebAgent webAgent, Credentials credentials)
        {
        }
    }
}