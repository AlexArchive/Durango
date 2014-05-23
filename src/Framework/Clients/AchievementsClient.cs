using Framework.Common;
using Framework.Infrastructure;
using Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Clients
{
    public class AchievementsClient : ClientBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Activity/Details?titleId=";

        internal AchievementsClient(Connection connection) 
            : base(connection)
        {
        }

        public IEnumerable<Achievement> GetAchievements(string gamertag, string gameId)
        {
            var content = WebAgent.GetString(BaseAddress + gameId + "&compareto=" + gamertag);
            var contentJson = content.ParseBetween("broker.publish(routes.activity.details.load, ", ");");
            
            EnsureAuthenticated();
            
            dynamic achievements = JObject.Parse(contentJson)["Achievements"];

            foreach (var achievement in achievements)
            {
                if (Enumerable.Any(achievement.EarnDates.Children()))
                {
                    achievement.EarnedOn = achievement.EarnDates[gamertag].EarnedOn;
                    achievement.IsOffline = achievement.EarnDates[gamertag].IsOffline;
                }

                ((JObject) achievement.EarnDates).Parent.Remove();
            }

            return achievements.ToObject<IEnumerable<Achievement>>();
        }
    }
}