using Microsoft.EntityFrameworkCore;
using NetCoreWolverine.Entity;
using Oakton;
using Oakton.Resources;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Http;
using Wolverine.Postgresql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddResourceSetupOnStartup();

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// app.MapControllers();

// app.MapGet("/", () => "ok");

// app.MapPost("/item", ([AsParameters] CreateItemRequest request) =>
//             request.Bus.InvokeAsync<ItemCreated>(request.Command, request.CancellationToken));

// app.MapPostToWolverine<CreateItemCommand, ItemCreated>("/item");

app.UseSwagger();
app.UseSwaggerUI();
app.MapWolverineEndpoints();

// app.Run();

return await app.RunOaktonCommands(args);

// ReSharper disable once UnusedType.Global
public class Endpoint
{
    [WolverineGet("/")]
    public string Get() => "OK ~";
    
    
}

// public partial class Program;