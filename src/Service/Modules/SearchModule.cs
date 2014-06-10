namespace Service.Modules
{
    public class SearchModule : ModuleBase
    {
        public SearchModule()
        {
            Get["/search/{searchQuery}"] = context => 
                XboxClient.Search.SearchMarketplace((string) context.searchQuery);
        }
    }
}