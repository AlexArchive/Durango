using System.Security.Authentication;
using Durango.Authentication;
using Durango.Infrastructure;
using HtmlAgilityPack;

namespace Durango.Clients
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

        protected HtmlDocument DownloadDocument(string requestUri)
        {
            var pageData = WebAgent.GetString(requestUri);
            var document = new HtmlDocument();
            document.LoadHtml(pageData);
            return document;
        }
    }
}