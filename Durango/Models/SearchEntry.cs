namespace Durango.Models
{
    public class SearchEntry
    {
        public string title { get; set; }
        public string parentTitle { get; set; }
        public string detailsUrl { get; set; }
        public string image { get; set; }
        public string downloadTypeClass { get; set; }
        public string downloadTypeText { get; set; }
        public Prices prices { get; set; } 
    }

    public class Prices
    {
        public string silver { get; set; }
        public string gold { get; set; }
    }
}