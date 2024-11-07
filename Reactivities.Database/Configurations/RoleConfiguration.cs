using Microsoft.EntityFrameworkCore;
using Reactivities.Utils;
using Reactivities.Utils.AppUser;

namespace Reactivities.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
        {
            builder.HasIndex(r => r.Name).IsUnique();
            builder.HasIndex(r => r.RoleType).IsUnique();
            builder.HasData(new UserRole
            {
                Id = Guid.NewGuid(),
                Name = RoleType.Admin.DescriptionAttribute(),
                NormalizedName = RoleType.Admin.DescriptionAttribute().ToUpper(),
                RoleType = RoleType.Admin
            },
            new UserRole
            {
                Id = Guid.NewGuid(),
                Name = RoleType.Owner.DescriptionAttribute(),
                NormalizedName = RoleType.Owner.DescriptionAttribute().ToUpper(),
                RoleType = RoleType.Owner
            },
            new UserRole
            {
                Id = Guid.NewGuid(),
                Name = RoleType.User.DescriptionAttribute(),
                NormalizedName = RoleType.User.DescriptionAttribute().ToUpper(),
                RoleType = RoleType.User
            },
            new UserRole
            {
                Id = Guid.NewGuid(),
                Name = RoleType.Guest.DescriptionAttribute(),
                NormalizedName = RoleType.Guest.DescriptionAttribute().ToUpper(),
                RoleType = RoleType.Guest
            });
        }
    }
}
