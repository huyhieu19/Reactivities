using Reactivities.Entity;

namespace Reactivities.Dtos
{
    public class ActivityDto : BaseIdEntity<Guid>
    {
        public string Title { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public bool IsCancelled { get; set; }
    }
}
