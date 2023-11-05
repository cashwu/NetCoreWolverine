using Microsoft.EntityFrameworkCore;

namespace NetCoreWolverine.Entity;

public class ItemsDbContext(DbContextOptions<ItemsDbContext> options)
    : DbContext(options)
{
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wolverine");

        modelBuilder.Entity<Item>(map =>
        {
            map.ToTable("Item");
            map.HasKey(x => x.Id);
            map.Property(x => x.Name);
        });
    }
}