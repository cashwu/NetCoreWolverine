namespace NetCoreWolverine.Items;

public class ItemCreatedHandler
{
    public void Handle(ItemCreated itemCreated)
    {
        Console.WriteLine($"{nameof(ItemCreatedHandler)} : You created a new item with id {itemCreated.Id}");
    }
}