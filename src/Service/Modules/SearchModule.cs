using Nancy;

namespace Service.Modules
{
    public class SearchModule : ModuleBase
    {
        public SearchModule()
        {
            Get["/search/{searchQuery}"] = context =>
            {
                var searchEntries = _xboxClient.Search.SearchMarketplace((string) context.searchQuery);
                return Response.AsJson(searchEntries);
            };
        }
    }
}