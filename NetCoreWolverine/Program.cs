using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Host.UseWolverine();

builder.Services.AddSingleton<DateTimerProvider>();

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

app.Run();