using Microsoft.EntityFrameworkCore;
using Prot.Domain.Entities.Genders;
using Prot.Infrastructure.Configurations;
using Prot.Infrastructure.Configurations.LanguageConfigurations;


namespace Prot.Infrastructure.Contexts;

public class ProtDbContext : DbContext
{
    public ProtDbContext(DbContextOptions<ProtDbContext> options) : base(options)
    {}

    public DbSet<Gender> Genders { get; set; }
    public DbSet<GenderConnectUser> GenderConnectUsers { get; set; }
    public DbSet<Domain.Entities.Users.User> Users { get; set; }

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        modelBuilder.Entity<Gender>()
            .HasMany(x => x.Users)
            .WithOne(y => y.Gender)
            .HasForeignKey(y => y.GenderId);

        modelBuilder.Entity<Domain.Entities.Users.User>()
            .HasMany<GenderConnectUser>()
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);


  


        /*------------------------------Language Configurations--------------------------------*/

        GenderLanguageConfig.Configure(modelBuilder);
    }
}
