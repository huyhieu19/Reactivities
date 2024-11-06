using Microsoft.AspNetCore.Identity;

namespace Reactivities.Utils.AppUser;

public sealed class UserRole : IdentityRole<Guid>
{
    public RoleType RoleType { get; set; }
}