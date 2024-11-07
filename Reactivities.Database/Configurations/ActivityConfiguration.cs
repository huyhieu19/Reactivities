using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reactivities.Entity;

namespace Reactivities.Database.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new List<Activity>
                {
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Past Activity 1",
                        DateTime = DateTime.UtcNow.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Past Activity 2",
                        DateTime = DateTime.UtcNow.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "The Louvre",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 1",
                        DateTime = DateTime.UtcNow.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "music",
                        City = "London",
                        Venue = "Wembly Stadium",

                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 2",
                        DateTime = DateTime.UtcNow.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "food",
                        City = "London",
                        Venue = "Jamies Italian",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 3",
                        DateTime = DateTime.UtcNow.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 4",
                        DateTime = DateTime.UtcNow.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "culture",
                        City = "London",
                        Venue = "British Museum",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 5",
                        DateTime = DateTime.UtcNow.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Punch and Judy",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 6",
                        DateTime = DateTime.UtcNow.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 7",
                        DateTime = DateTime.UtcNow.AddMonths(7),
                        Description = "Activity 7 months in future",
                        Category = "travel",
                        City = "Berlin",
                        Venue = "All",

                    },
                    new Activity
                    {
                        Id = Guid.NewGuid(),
                        Title = "Future Activity 8",
                        DateTime = DateTime.UtcNow.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    }
            });
        }
    }
}