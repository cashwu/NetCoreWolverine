using Messages;
using Microsoft.EntityFrameworkCore;
using NetCoreWolverine;
using NetCoreWolverine.Issues;
using NetCoreWolverine.Items;
using NetCoreWolverine.PingPong;
using Oakton.Resources;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Postgresql;
using Wolverine.Transports.Tcp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Host.UseWolverine(options =>
{
    options.PersistMessagesWithPostgresql(connectionString);
    options.UseEntityFrameworkCoreTransactions();

    options.ListenAtPort(5580);

    options.PublishMessage<Ping>().ToPort(5581);
    
    options.Services.AddHostedService<Worker>();
});

builder.Services.AddSingleton<DateTimerProvider>();

// Register the EF Core DbContext
builder.Services.AddDbContext<ItemsDbContext>(x => x.UseNpgsql(connectionString),
                                              ServiceLifetime.Singleton);

builder.Host.UseResourceSetupOnStartup();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () =>
{
    return "ok";
});

app.MapGet("/issues/create", (IMessageBus bus) =>
{
    var body = new CreateIssue(1, "title123", "desc");
    bus.InvokeAsync(body);
});

app.MapGet("/items/create", (IMessageBus bus) =>
{
    var body = new CreateItemCommand($"{Guid.NewGuid()}_{DateTime.UtcNow:s}");

    bus.InvokeAsync(body);
});

app.MapGet("/items/create2", (IMessageBus bus) =>
{
    var body = new CreateItemCommand($"{Guid.NewGuid()}_{DateTime.UtcNow:s}");

    return bus.InvokeAsync<ItemCreated>(body);
});

app.Run();