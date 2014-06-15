using Durango.Infrastructure;

namespace Durango.Authentication
{
    internal interface IAuthenticationHandler
    {
        void Authenticate(WebAgent webAgent, Credentials credentials);
    }
}
