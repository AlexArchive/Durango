using System;

namespace Framework.Models
{
    public class Friend
    {
        public string GamerTag { get; set; }
        public string GamerTileUrl { get; set; }
        public string LargeGamerTileUrl { get; set; }
        public int GamerScore { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastSeen { get; set; }
        public string Presence { get; set; }
        public TitleInfo TitleInfo { get; set; }
        public string RichPresence { get; set; }
    }

    public class TitleInfo
    {
        public string Name { get; set; }
        public object Id { get; set; }
    }
}