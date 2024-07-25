using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Users;
using Prot.Infrastructure.Extentions;

namespace Prot.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(DefaultUserAdmin);

    }

    private User DefaultUserAdmin =>
        new User()
        {
            Id = 1,
            Name ="Alex",
            Surename = "Fergyusson",
            GenderId = 1,
            Age = 100,
            ImageUrl ="",
            Balance =0,
            Phonenumber = "+99898 000 00 00",
            Password = "Admin@123?".Encrypt(),
            City = "Tashkent",
            CreatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
            UpdatedAt = new DateTime(2024, 7, 24, 10, 13, 56, 461, DateTimeKind.Utc),
        };

}
