using Wolverine;

namespace NetCoreWolverine.Items;

// ReSharper disable once ClassNeverInstantiated.Global
public record CreateItemCommand(string Name);

public record CreateItemRequest(CreateItemCommand Command, IMessageBus Bus, CancellationToken CancellationToken);

