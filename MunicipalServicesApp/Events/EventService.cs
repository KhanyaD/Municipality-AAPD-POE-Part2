using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp.Events
{
    // One service per application session preserves searches when the form is reopened.
    public sealed class EventService
    {
        public static readonly EventService Current = new EventService();
        private readonly SortedDictionary<DateTime, List<MunicipalEvent>> eventsByDate =
            new SortedDictionary<DateTime, List<MunicipalEvent>>();
        private readonly Dictionary<int, MunicipalEvent> eventsById = new Dictionary<int, MunicipalEvent>();
        private readonly HashSet<string> categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly Stack<EventSearch> recentSearches = new Stack<EventSearch>();
        private const int HistoryLimit = 20;

        public EventService()
        {
            // Fictional demonstration data, relative to today so the sample remains usable.
            DateTime day = DateTime.Today;
            Add(1, "Community park clean-up", "Environment", day.AddDays(2), "Algoa Park",
                "Join a community clean-up. Bring gloves and drinking water.", false);
            Add(2, "Water maintenance notice", "Utilities", day.AddDays(3), "North End",
                "Demonstration notice: planned maintenance from 09:00 to 12:00.", true);
            Add(3, "Youth football day", "Sport", day.AddDays(4), "Community sports field",
                "A friendly football event for young residents and their families.", false);
            Add(4, "Digital skills workshop", "Education", day.AddDays(5), "Community library",
                "Learn basic computer skills, email and safe internet use.", false);
            Add(5, "Local arts market", "Arts and Culture", day.AddDays(7), "City community hall",
                "Explore local crafts, music and art from community exhibitors.", false);
            Add(6, "Recycling collection notice", "Environment", day.AddDays(7), "Algoa Park",
                "Demonstration announcement: separate paper, glass and plastic for collection.", true);
            Add(7, "Community health day", "Health", day.AddDays(9), "Community clinic",
                "A fictional community health awareness event.", false);
            Add(8, "Road maintenance notice", "Utilities", day.AddDays(10), "CBD",
                "Demonstration notice: allow extra travel time during road maintenance.", true);
            Add(9, "Library reading club", "Education", day.AddDays(12), "Community library",
                "Read and discuss books with fellow community members.", false);
            Add(10, "Community fun run", "Sport", day.AddDays(14), "Local park",
                "A relaxed community run and walk. All fitness levels welcome.", false);
            Add(11, "Heritage storytelling", "Arts and Culture", day.AddDays(18), "City community hall",
                "Share local stories and celebrate the community's cultural heritage.", false);
            Add(12, "Tree planting morning", "Environment", day.AddDays(21), "Community garden",
                "Help plant trees and learn about caring for green spaces.", false);
        }

        private void Add(int id, string title, string category, DateTime date,
            string location, string description, bool announcement)
        {
            var item = new MunicipalEvent { Id = id, Title = title, Category = category,
                Date = date.Date, Location = location, Description = description, IsAnnouncement = announcement };
            eventsById.Add(id, item);
            categories.Add(category);
            List<MunicipalEvent> bucket;
            if (!eventsByDate.TryGetValue(item.Date, out bucket))
            {
                bucket = new List<MunicipalEvent>();
                eventsByDate.Add(item.Date, bucket);
            }
            bucket.Add(item); // Multiple events on one date are retained.
        }

        public List<string> Categories { get { return categories.OrderBy(x => x).ToList(); } }
        public List<EventSearch> History { get { return recentSearches.ToList(); } }
        public MunicipalEvent GetById(int id) { return eventsById[id]; }

        private static bool Contains(string text, string term)
        {
            return text.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public List<MunicipalEvent> Search(EventSearch search, bool remember)
        {
            if (search.From.HasValue != search.To.HasValue ||
                (search.From.HasValue && search.From.Value.Date > search.To.Value.Date))
                throw new ArgumentException("Choose a valid start and end date.");
            var results = new List<MunicipalEvent>();
            string keyword = (search.Keyword ?? "").Trim();
            foreach (var pair in eventsByDate)
            {
                if (pair.Key < DateTime.Today) continue;
                if (search.From.HasValue && pair.Key < search.From.Value.Date) continue;
                if (search.To.HasValue && pair.Key > search.To.Value.Date) break;
                foreach (var item in pair.Value)
                {
                    if (!string.IsNullOrEmpty(search.Category) &&
                        !string.Equals(search.Category, item.Category, StringComparison.OrdinalIgnoreCase)) continue;
                    if (keyword.Length > 0 && !Contains(item.Title, keyword) &&
                        !Contains(item.Description, keyword) && !Contains(item.Location, keyword) &&
                        !Contains(item.Category, keyword)) continue;
                    results.Add(item);
                }
            }
            // Default/reset displays do not create artificial search preferences.
            if (remember && (keyword.Length > 0 || !string.IsNullOrEmpty(search.Category) || search.From.HasValue))
            {
                if (recentSearches.Count == HistoryLimit)
                {
                    var retained = recentSearches.Take(HistoryLimit - 1).Reverse().ToList();
                    recentSearches.Clear();
                    foreach (var entry in retained) recentSearches.Push(entry);
                }
                recentSearches.Push(new EventSearch { Keyword = keyword, Category = search.Category,
                    From = search.From, To = search.To });
            }
            return results;
        }

        public List<EventRecommendation> Recommend(int count)
        {
            var ranked = new List<EventRecommendation>();
            foreach (var item in Search(new EventSearch(), false))
            {
                int score = 0;
                var reasons = new HashSet<string>();
                foreach (var search in recentSearches)
                {
                    if (!string.IsNullOrEmpty(search.Category) &&
                        string.Equals(search.Category, item.Category, StringComparison.OrdinalIgnoreCase))
                    { score += 5; reasons.Add("Matches a searched category"); }
                    if (!string.IsNullOrEmpty(search.Keyword) &&
                        (Contains(item.Title, search.Keyword) || Contains(item.Description, search.Keyword) ||
                         Contains(item.Category, search.Keyword) || Contains(item.Location, search.Keyword)))
                    { score += 3; reasons.Add("Matches a searched keyword"); }
                    if (search.From.HasValue && item.Date >= search.From.Value.Date && item.Date <= search.To.Value.Date)
                    { score += 2; reasons.Add("Within a searched date range"); }
                }
                if (score > 0) ranked.Add(new EventRecommendation { Event = item, Score = score,
                    Reason = string.Join("; ", reasons.OrderBy(x => x)) });
            }
            return ranked.OrderByDescending(x => x.Score).ThenBy(x => x.Event.Date)
                .ThenBy(x => x.Event.Id).Take(count).ToList();
        }

        public void ClearHistory() { recentSearches.Clear(); }
    }
}
