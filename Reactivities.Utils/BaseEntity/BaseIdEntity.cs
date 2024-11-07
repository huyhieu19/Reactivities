namespace Reactivities.Entity
{
    public class BaseIdEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset TimeDeleted { get; set; }
    }
}