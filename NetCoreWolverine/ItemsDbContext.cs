using Microsoft.EntityFrameworkCore;

namespace NetCoreWolverine;

public class ItemsDbContext : DbContext
{
    public ItemsDbContext(DbContextOptions<ItemsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Your normal EF Core mapping
        modelBuilder.Entity<Item>(map =>
        {
            map.ToTable("items");
            map.HasKey(x => x.Id);
            map.Property(x => x.Name);
        });
    }
}

public class Item
{
    public string Name { get; set; }

    public Guid Id { get; set; }
}