using System.Security.Authentication;
using Framework.Infrastructure;

namespace Framework.Clients
{
    public abstract class ClientBase
    {
        protected ClientBase(Connection connection)
        {
            Connection = connection;
        }

        protected Connection Connection { get; private set; }

        protected WebAgent WebAgent
        {
            get { return Connection.WebAgent.Value; }
        }

        protected void EnsureAuthenticated()
        {
            if (!Connection.Authenticated)
                throw new AuthenticationException();
        }
    }
}