﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reactivities.Utils.AppUser;

namespace Reactivities.Database;

public class DataContext : IdentityDbContext<AppUser, UserRole, Guid>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    }

    public override DbSet<AppUser> Users { get; set; } = default!;
    public override DbSet<UserRole> Roles { get; set; } = default!;
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
}