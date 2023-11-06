using Wolverine;

namespace NetCoreWolverine.Items;

// ReSharper disable once ClassNeverInstantiated.Global
public record CreateItemCommand(Guid Id, string Name);

public record CreateItemRequest(CreateItemCommand Command, IMessageBus Bus, CancellationToken CancellationToken);

public record ItemCreated(Guid Id);