using System.Collections.Generic;
using System.Linq;
using Durango.Infrastructure;
using Durango.Models;
using Newtonsoft.Json.Linq;

namespace Durango.Clients
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