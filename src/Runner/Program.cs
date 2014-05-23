using Framework;

namespace Runner
{
    public class Program
    {
        private static void Main()
        {
            var client = new XboxClient(new Credentials("twerkteam@yopmail.com", "teamtwerk1"));
            var swag = client.Search.SearchMarketplace("COD");
        }
    }
}
