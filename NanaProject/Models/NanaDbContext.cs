using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using NanaProject.Models;

namespace NanaProject.Models;

public class NanaDbContext : IdentityDbContext<IdentityUser>
{
    public NanaDbContext(DbContextOptions<NanaDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Species> Specieses { get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AccountUserEntityConfiguration());
    }

public DbSet<Account> Account { get; set; }
}

public class AccountUserEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(a => a.AccPhoto).HasMaxLength(255).IsRequired();
        builder.Property(a => a.FullName).HasMaxLength(255).IsRequired();
        builder.Property(a => a.DOB).HasMaxLength(255).IsRequired();
        builder.Property(a => a.Address).HasMaxLength(255).IsRequired();
    }
}