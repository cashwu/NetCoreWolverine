using Messages;
using Wolverine;

namespace NetCoreWolverine.PingPong;

public class Worker : BackgroundService
{
    private readonly IMessageBus _bus;

    public Worker(IMessageBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var pingNumber = 1;

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(5000, stoppingToken);
            Console.WriteLine($"{nameof(Worker)} - Sending Ping #{pingNumber}");
            await _bus.PublishAsync(new Ping { Number = pingNumber });
            pingNumber++;
        }
    }
}