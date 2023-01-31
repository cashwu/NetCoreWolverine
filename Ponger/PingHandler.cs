using Messages;
using Wolverine;

namespace Ponger;

public class PingHandler
{
    public ValueTask Handle(Ping ping, IMessageContext context)
    {
        Console.WriteLine($"{nameof(PingHandler)} Got Ping #{ping.Number}");

        return context.RespondToSenderAsync(new Pong { Number = ping.Number });
    }
}