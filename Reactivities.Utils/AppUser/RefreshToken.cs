using Reactivities.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reactivities.Utils.AppUser;

public sealed class RefreshToken : BaseIdEntity<Guid>
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryTime { get; set; }

    /// <summary>
    /// Can use the blacklist table instead
    /// </summary>
    public bool IsRevoked { get; set; }

    public DateTime RevokedDate { get; set; }

    [NotMapped]
    public AppUser User { get; set; }

    public static RefreshToken Update(RefreshToken refreshToken, string token, DateTime expiryTime, bool isRevoked, DateTime revokedDate, Guid userId)
    {
        refreshToken.Token = token;
        refreshToken.ExpiryTime = expiryTime;
        refreshToken.IsRevoked = isRevoked;
        refreshToken.RevokedDate = revokedDate;
        refreshToken.UserId = userId;
        return refreshToken;
    }

    public static RefreshToken Update(RefreshToken refreshToken, string token, DateTime expiryTime, bool isRevoked, DateTime revokedDate)
    {
        refreshToken.Token = token;
        refreshToken.ExpiryTime = expiryTime;
        refreshToken.IsRevoked = isRevoked;
        refreshToken.RevokedDate = revokedDate;
        return refreshToken;
    }

    public static RefreshToken Revoked(RefreshToken token)
    {
        token.IsRevoked = true;
        token.RevokedDate = DateTime.UtcNow;
        return token;
    }
}