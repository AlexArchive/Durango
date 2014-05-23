using Framework.Infrastructure;

namespace Framework.Clients
{
    public abstract class ClientBase
    {
        protected ClientBase(Connection connection)
        {
            Connection = connection;
        }

        public Connection Connection { get; private set; }

        public WebAgent WebAgent
        {
            get { return Connection.WebAgent.Value; }
        }
    }
}