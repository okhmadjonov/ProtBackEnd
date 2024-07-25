using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Roles;

namespace Prot.Infrastructure.Configurations;



internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(DefaultUserRoles);
    }

    private UserRole[] DefaultUserRoles =>
        new[]
        {
            new Domain.Entities.Roles.UserRole()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
                CreatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
            }

        };
}
