namespace Domain;

public class Activity : BaseIdEntity<Guid>
{
    public string Title { get; set; }
    public DateTime DateTime { get; set; }
    public int MyProperty { get; set; }
}
