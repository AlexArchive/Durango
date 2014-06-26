namespace Durango.Models
{
    public sealed class Profile
    {
        public string Gamertag { get; set; }
        public string Gamerscore { get; set; }
        public bool Online { get; set; }
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Location { get; set; }
        public string Biography { get; set; }
        public int Reputation { get; set; }
        public string Presence { get; set; }
        public string Tier { get; set; }
        public Avatar Avatar { get; set; }
        public LaunchTeams LaunchTeams { get; set; }
    }

    public sealed class Avatar
    {
        public string Body { get; set; }
        public string GamerTile { get; set; }
        public string SmallGamerpic { get; set; }
        public string LargeGamerpic { get; set; }
    }

    public sealed class LaunchTeams
    {
        public bool Xbox360 { get; set; }
        public bool NXE { get; set; }
        public bool Kinect { get; set; }
    }
}