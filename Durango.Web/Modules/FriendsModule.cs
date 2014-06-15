using System.Collections.Generic;
using System.Linq;
using Durango.Models;
using Nancy;

namespace Durango.Web.Modules
{
    public class FriendsModule : ModuleBase
    {
        public FriendsModule()
        {
            Get["/profile/{gamertag}/friends"] = context =>
            {
                IEnumerable<Friend> friends = XboxClient.Friends.GetFriends(context.gamertag);

                if (friends == null)
                    return this.ErrorMessage(HttpStatusCode.BadRequest, "Profile does not exist.");

                // resource linking
                string baseUri = Request.BaseUri();
                IEnumerable<dynamic> friendsDto = friends.Select(friend =>
                {
                    var friendDto = friend.ToExpandoObject();
                    friendDto.Profile = new { Link = baseUri + "/profile/" + friendDto.GamerTag };
                    friendDto.Friends = new { Link = baseUri + "/profile/" + friendDto.GamerTag + "/friends"};
                    friendDto.Games = new { Link = baseUri + "/profile/" + friendDto.GamerTag + "/games"};
                    return friendDto;
                });
                return friendsDto;
            };
        }
    }
}