using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Genders;

namespace Prot.Infrastructure.Configurations.LanguageConfigurations;

public class GenderLanguageConfig
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.OwnsOne(s => s.Title, title =>
            {
                title.Property(t => t.RU).HasColumnName("Title_RU");
                title.Property(t => t.UZ).HasColumnName("Title_UZ");
                title.Property(t => t.EN).HasColumnName("Title_EN");
            });
        });
    }
}
