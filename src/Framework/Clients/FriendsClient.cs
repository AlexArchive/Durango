using System.Diagnostics;
using Framework.Common;
using Framework.Infrastructure;
using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Framework.Clients
{
    public class FriendsClient : ClientBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Friends/List?Gamertag=";

        internal FriendsClient(Connection connection) 
            : base(connection)
        {
        }

        public IEnumerable<Friend> GetFriends(string gamertag)
        {
            EnsureAuthenticated();

            var document = DownloadDocument("https://live.xbox.com/en-GB/Friends");
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

            var root = JObject.Parse(content);

            if (root["Success"].ToObject<bool>() == false)
                return null;

            var friendsNode = root["Data"]["Friends"];
            var friends = friendsNode.ToObject<IEnumerable<Friend>>();

            return friends;
        }
    }
}