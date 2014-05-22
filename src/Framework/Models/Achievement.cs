namespace Framework.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string TileUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public bool IsHidden { get; set; }
        public string EarnedOn { get; set; }
        public bool IsOffline { get; set; }
    }
}