using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reactivities.Utils.AppUser;

public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    [NotMapped]
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}