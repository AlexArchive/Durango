using Nancy;

namespace Durango.Web.Modules
{
    public class SearchModule : ModuleBase
    {
        public SearchModule()
        {
            Get["/search/{searchQuery}"] = context =>
            {
                var searchResults = XboxClient.Search.SearchMarketplace(context.searchQuery);

                if (searchResults != null) return searchResults;

                return this.ErrorMessage(HttpStatusCode.OK, "No Results.");
            };
        }
    }
}