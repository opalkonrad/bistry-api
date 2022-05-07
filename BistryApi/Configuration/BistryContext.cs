using BistryApi.MenuItems;
using Microsoft.EntityFrameworkCore;

namespace BistryApi.Configuration;

public class BistryContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }

    public BistryContext(DbContextOptions<BistryContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>()
            .HasPartitionKey(x => x.Id);
    }
}
