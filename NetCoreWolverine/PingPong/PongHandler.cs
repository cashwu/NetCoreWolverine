using Messages;

namespace NetCoreWolverine.PingPong;

public class PongHandler
{
    public void Handle(Pong pong)
    {
        Console.WriteLine($"{nameof(PongHandler)} - Received Pong #{pong.Number}");
    }
}