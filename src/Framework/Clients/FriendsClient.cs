using System.Collections.Generic;
using System.Net;
using Framework.Common;
using Framework.Models;
using Newtonsoft.Json.Linq;

namespace Framework.Clients
{
    public class FriendsClient : ClientBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Friends/List?Gamertag=";


        public FriendsClient(Connection connection) 
            : base(connection)
        {
        }

        public IEnumerable<Friend> GetFriendsOf(string gamertag)
        {
            var document = WebAgent.DownloadDocumentNode("https://live.xbox.com/en-GB/Friends");
            var docNode = document.DocumentNode;

            var token =
                docNode.SelectSingleNode("//input[@name='__RequestVerificationToken']").Attributes["value"].Value;

            var requestUri = BaseAddress + gamertag;
            var response = WebAgent.Post(
                requestUri,
                "__RequestVerificationToken=" + token, 
                new WebHeaderCollection {{"X-Requested-With", "XMLHttpRequest"}}
            );

            var content = response.GetResponseStream().ReadAsString();

            var friendsNode = JObject.Parse(content)["Data"]["Friends"];
            var friends = friendsNode.ToObject<IEnumerable<Friend>>();

            return friends;
        }
    }
}