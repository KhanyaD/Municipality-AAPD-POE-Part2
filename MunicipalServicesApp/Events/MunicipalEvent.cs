using System;

namespace MunicipalServicesApp.Events
{
    public sealed class MunicipalEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAnnouncement { get; set; }
        public string Type { get { return IsAnnouncement ? "Announcement" : "Event"; } }
    }

    public sealed class EventSearch
    {
        public string Keyword { get; set; }
        public string Category { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public override string ToString()
        {
            return (string.IsNullOrEmpty(Keyword) ? "Any keyword" : Keyword) + " | " +
                (string.IsNullOrEmpty(Category) ? "All categories" : Category) + " | " +
                (From.HasValue ? From.Value.ToString("dd MMM yyyy") + " – " +
                    To.Value.ToString("dd MMM yyyy") : "All upcoming dates");
        }
    }

    public sealed class EventRecommendation
    {
        public MunicipalEvent Event { get; set; }
        public int Score { get; set; }
        public string Reason { get; set; }
    }
}
