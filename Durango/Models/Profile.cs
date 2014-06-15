namespace Durango.Models
{
    public sealed class Profile
    {
        public string Gamertag { get; set; }
        public string Tier { get; set; }
        //public string Badges { get; set; }
        public Avatar Avatar { get; set; }
        public string Gamerscore { get; set; }
        public int Reputation { get; set; }
        public string Presence { get; set; }
        public bool Online { get; set; }
        public string Motto { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Biography { get; set; }
        //public string RecentActivity { get; set; }
    }

    public sealed class Avatar
    {
        public string Full { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Tile { get; set; }
    }
}