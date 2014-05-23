using Framework.Infrastructure;

namespace Framework.Authentication
{
    public class AnonymousAuthenticationHandler : IAuthenticationHandler
    {
        public void Authenticate(WebAgent webAgent, Credentials credentials)
        {
        }
    }
}