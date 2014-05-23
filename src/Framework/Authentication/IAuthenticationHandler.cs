using Framework.Infrastructure;

namespace Framework.Authentication
{
    internal interface IAuthenticationHandler
    {
        void Authenticate(WebAgent webAgent, Credentials credentials);
    }
}
