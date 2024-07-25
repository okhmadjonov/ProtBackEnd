using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Roles;
using System.Data;

namespace Prot.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(DefaultRoles);
    }
    private Role[] DefaultRoles = new[]
    {
        new Role("SuperAdmin")
        {
            Id = 1,
            CreatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
            IsActive = true
        },

    };

}
