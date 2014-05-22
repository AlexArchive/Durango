namespace Framework.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string BoxArt { get; set; }
        public string LargeBoxArt { get; set; }
        public int PossibleScore { get; set; }
        public int PossibleAchievements { get; set; }
        public Progress Progress { get; set; }
    }

    public class Progress
    {
        public int Score { get; set; }
        public int Achievements { get; set; }
        public object LastPlayed { get; set; }
    }
}