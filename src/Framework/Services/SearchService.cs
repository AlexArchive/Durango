using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Framework.Services
{
    public class SearchService : ServiceBase
    {
        private const string BaseAddress = "http://marketplace.xbox.com/en-GB/SiteSearch/xbox/?query=";

        public SearchService(Connection connection) 
            : base(connection)
        {
        }
        
        public IEnumerable<SearchEntry> SearchMarketplace(string query)
        {
            var content = WebAgent.GetString(BaseAddress + query);

            var entries = JObject.Parse(content)["entries"];
            return entries.ToObject<IEnumerable<SearchEntry>>();
        }
    }
}