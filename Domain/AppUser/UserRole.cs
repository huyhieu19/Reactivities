using Microsoft.AspNetCore.Identity;

namespace Domain;

public sealed class UserRole : IdentityRole<Guid>
{
    public RoleType RoleType { get; set; }
}
