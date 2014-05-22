using Framework.Common;
using Framework.Models;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Framework.Services
{
    public class FriendsService : ServiceBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Friends/List?Gamertag=";

        public FriendsService(string username, string password) 
            : base(username, password)
        {
        }


        public IEnumerable<Friend> GetFriendsOf(string gamertag)
        {
            EnsureAuthenticated();

            var document = DownloadDocumentNode("https://live.xbox.com/en-GB/Friends");
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