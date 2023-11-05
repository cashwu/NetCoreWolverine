using Microsoft.EntityFrameworkCore;
using NetCoreWolverine.Entity;
using NetCoreWolverine.Items;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Postgresql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Host.UseWolverine((context, options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");

    options.Services.AddDbContextWithWolverineIntegration<ItemsDbContext>(x =>
    {
        x.UseNpgsql(connectionString);
    }, "wolverine");

    options.PersistMessagesWithPostgresql(connectionString!, "wolverine");
    options.UseEntityFrameworkCoreTransactions();

    options.Policies.AutoApplyTransactions();
    options.Policies.UseDurableInboxOnAllListeners();
    options.Policies.UseDurableOutboxOnAllSendingEndpoints();
});

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "ok");

app.MapPost("/item", ([AsParameters] CreateItemRequest request) =>
            request.Bus.InvokeAsync(request.Command, request.CancellationToken));

app.Run();