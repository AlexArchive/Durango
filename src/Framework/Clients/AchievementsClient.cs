using System.Collections.Generic;
using System.Linq;
using Framework.Common;
using Framework.Models;
using Newtonsoft.Json.Linq;

namespace Framework.Clients
{
    public class AchievementsClient : ClientBase
    {
        private const string BaseAddress = "https://live.xbox.com/en-US/Activity/Details?titleId=";


        public AchievementsClient(Connection connection) 
            : base(connection)
        {
        }

        public IEnumerable<Achievement> GetAchievements(string gamertag, string gameId)
        {
            var content = WebAgent.GetString(BaseAddress + gameId + "&compareto=" + gamertag);

            var achievementsJson = content.ParseBetween("broker.publish(routes.activity.details.load, ", ");");
            dynamic achievements = JObject.Parse(achievementsJson)["Achievements"];

            foreach (var achievement in achievements)
            {
                if (Enumerable.Any(achievement.EarnDates.Children()))
                {
                    achievement.EarnedOn = achievement.EarnDates["xMurta"].EarnedOn;
                    achievement.IsOffline = achievement.EarnDates["xMurta"].IsOffline;
                }

                ((JObject) achievement.EarnDates).Parent.Remove();
            }

            return achievements.ToObject<IEnumerable<Achievement>>();
        }

    }
}