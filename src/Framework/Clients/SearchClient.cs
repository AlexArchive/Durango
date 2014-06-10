using System.Linq;
using System.Xml;
using Framework.Infrastructure;
using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Framework.Clients
{
    public class SearchClient : ClientBase
    {
        private const string BaseAddress = "http://marketplace.xbox.com/en-GB/SiteSearch/xbox/?query=";

        internal SearchClient(Connection connection) 
            : base(connection)
        {
        }
        
        public IEnumerable<SearchEntry> SearchMarketplace(string query)
        {
            var content = WebAgent.GetString(BaseAddress + query);

            var entriesJson = JObject.Parse(content)["entries"];
            var entries = entriesJson.ToObject<IEnumerable<SearchEntry>>();

            if (!entries.Any())
                return null;

            return entries;
        }
    }
}