using System.Security.Authentication;
using Framework.Authentication;
using Framework.Infrastructure;

namespace Framework.Clients
{
    public abstract class ClientBase
    {
        protected Connection Connection { get; private set; }

        protected WebAgent WebAgent
        {
            get { return Connection.WebAgent.Value; }
        }

        protected ClientBase(Connection connection)
        {
            Connection = connection;
        }

        protected void EnsureAuthenticated()
        {
            if (Connection.Credentials.AuthenticationType == AuthenticationType.Anonymous)
            {
                throw new AuthenticationException(
                    "you must be authenticated to carry out this operation.");
            }
        }
    }
}