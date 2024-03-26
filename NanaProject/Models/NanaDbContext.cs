using Microsoft.EntityFrameworkCore;

namespace NanaProject.Models;

public class NanaDbContext : DbContext
{
    public NanaDbContext(DbContextOptions<NanaDbContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Species> Specieses { get; set;}
}