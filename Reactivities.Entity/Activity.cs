namespace Reactivities.Entity;

public class Activity : BaseIdEntity<Guid>
{
    public string Title { get; set; }
    public DateTimeOffset DateTime { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string City { get; set; }
    public string Venue { get; set; }
    public bool IsCancelled { get; set; }
}