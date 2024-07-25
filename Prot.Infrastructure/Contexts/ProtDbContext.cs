using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Genders;
using Prot.Domain.Entities.Users;
using Prot.Infrastructure.Configurations;
using Prot.Infrastructure.Configurations.LanguageConfigurations;

namespace Prot.Infrastructure.Contexts;

public class ProtDbContext : DbContext
{
    public ProtDbContext(DbContextOptions<ProtDbContext> options) : base(options)
    {
    }



    public DbSet<Gender> Genders { get; set; }
    public DbSet<GenderConnectUser> GenderConnectUsers { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        modelBuilder.Entity<Gender>()
            .HasMany(x => x.Users)
            .WithOne(y => y.Gender)
            .HasForeignKey(y => y.GenderId);

        modelBuilder.Entity<User>()
            .HasMany<GenderConnectUser>()
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);



        /*------------------------------Language Configurations--------------------------------*/

        GenderLanguageConfig.Configure(modelBuilder);
    }
}
