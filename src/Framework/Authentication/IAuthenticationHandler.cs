using Framework.Infrastructure;

namespace Framework.Authentication
{
    public interface IAuthenticationHandler
    {
        void Authenticate(WebAgent webAgent, Credentials credentials);
    }
}
