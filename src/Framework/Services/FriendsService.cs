﻿using System.Collections.Generic;
using Framework.Common;
using Framework.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Framework.Services
{
    public class FriendsService : ServiceBase
    {
        public FriendsService(string username, string password) 
            : base(username, password)
        {
        }

        private const string BaseAddress = "https://live.xbox.com/en-US/Friends/List?Gamertag=";

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

        private HtmlDocument DownloadDocumentNode(string requestUri)
        {
            var pageData = WebAgent.GetString(requestUri);

            var document = new HtmlDocument();
            document.LoadHtml(pageData);

            return document;
        }
    }
}