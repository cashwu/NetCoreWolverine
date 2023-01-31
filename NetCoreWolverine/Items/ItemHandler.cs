using Wolverine.Attributes;

namespace NetCoreWolverine.Items;

public class ItemHandler
{
    [Transactional]
    public static ItemCreated Handle(CreateItemCommand command, ItemsDbContext db)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = command.Name
        };

        db.Items.Add(item);

        return new ItemCreated
        {
            Id = item.Id
        };
    }
}