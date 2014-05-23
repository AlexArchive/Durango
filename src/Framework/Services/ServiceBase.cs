using Framework.Infrastructure;

namespace Framework.Services
{
    public class ServiceBase
    {
        public ServiceBase(Connection connection)
        {
            Connection = connection;
            WebAgent = connection.WebAgent;
        }

        public Connection Connection { get; private set; }
        public WebAgent WebAgent { get; private set; }
    }
}