using Framework.Infrastructure;
using Framework.Models;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace Framework.Services
{
    public sealed class ProfileService : ServiceBase
    {
        private const string BaseAddress = "http://live.xbox.com/en-US/Profile?gamertag=";

        public ProfileService(string username, string password) 
            : base(username, password)
        {
        }

        public Profile GetProfile(string gamertag)
        {
            var document = DownloadDocumentNode(BaseAddress + gamertag);
            var docNode = document.DocumentNode;

            var profile = new Profile { Gamertag = gamertag };

            profile.Name = docNode.SelectSingleNode("//div[@class='name']/div").InnerText;
            profile.Gamerscore = docNode.SelectSingleNode("//div[@class='gamerscore']").InnerText;
            profile.Presence = docNode.SelectSingleNode("//div[@class='presence']").InnerText;
            profile.Online = profile.Presence.StartsWith("Online") && profile.Presence != "Online Status Unavailable";
            profile.Location = docNode.SelectSingleNode("//div[@class='location']/div").InnerText;
            profile.Biography = docNode.SelectSingleNode("//div[@class='bio']/div").InnerText.Trim();

            var tier = docNode.SelectSingleNode("//div[@class='goldBadge']");
            profile.Tier = tier == null ? "Silver" : "Gold";

            var motto = docNode.SelectSingleNode("//div[@class='motto']");
            profile.Motto = motto != null ? motto.InnerText.Trim() : "None";

            var stars = docNode.SelectNodes("//div[starts-with(@class, 'Star')]");
            foreach (var star in stars)
            {
                var kind = star.GetAttributeValue("class", null);
                profile.Reputation += _starValues[kind];
            }

            profile.Avatar = new Avatar();
            profile.Avatar.Full = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatar-body.png", gamertag);
            profile.Avatar.Small = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatarpic-s.png", gamertag);
            profile.Avatar.Large = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatarpic-l.png", gamertag);

            profile.Avatar.Tile = docNode.SelectSingleNode("//img[@class='gamerpic']").GetAttributeValue("src", null);
            profile.Avatar.Tile = profile.Avatar.Tile.Replace("https://avatar-ssl", "http://avatar");

            return profile;
        }

        private HtmlDocument DownloadDocumentNode(string requestUri)
        {
            var pageData = WebAgent.GetString(requestUri);

            var document = new HtmlDocument();
            document.LoadHtml(pageData);

            return document;
        }

        private static readonly Dictionary<string, int> _starValues
            = new Dictionary<string, int>  {
                {"Star Empty", 0},
                {"Star Quarter", 25},
                {"Star Half", 50},
                {"Star ThreeQuarter", 75},
                {"Star Full", 100}
            };

    }
}