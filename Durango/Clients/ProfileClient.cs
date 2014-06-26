using System.Collections.Generic;
using Durango.Infrastructure;
using Durango.Models;

namespace Durango.Clients
{
    public sealed class ProfileClient : ClientBase
    {
        private const string BaseAddress = "http://live.xbox.com/en-US/Profile?gamertag=";

        internal ProfileClient(Connection connection) 
            : base(connection)
        {
        }

        public Profile GetProfile(string gamertag)
        {
            var document = DownloadDocument(BaseAddress + gamertag);
            var docNode = document.DocumentNode;

            if (docNode.InnerHtml.Contains("Not found</title>"))
                return null;

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
            profile.Avatar.Body = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatar-body.png", gamertag);
            profile.Avatar.SmallGamerpic = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatarpic-s.png", gamertag);
            profile.Avatar.LargeGamerpic = string.Format("http://avatar.xboxlive.com/avatar/{0}/avatarpic-l.png", gamertag);
            profile.Avatar.SmallGamerTile = docNode.SelectSingleNode("//img[@class='gamerpic']").GetAttributeValue("src", null);
            profile.Avatar.SmallGamerTile = profile.Avatar.SmallGamerTile.Replace("https://avatar-ssl", "http://avatar");

            return profile;
        }

        private static readonly Dictionary<string, int> _starValues =
            new Dictionary<string, int> 
        {
            {"Star Empty", 0},
            {"Star Quarter", 5},
            {"Star Half", 10},
            {"Star ThreeQuarter", 15},
            {"Star Full", 20}
        };
    }
}