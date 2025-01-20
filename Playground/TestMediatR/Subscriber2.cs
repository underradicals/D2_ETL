using MediatR;

namespace Playground.TestMediatR;

public class Subscriber2 : INotificationHandler<Publisher>
{
    public Task Handle(Publisher notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Publisher received: {nameof(Subscriber2)}");
        
        return Task.CompletedTask;
    }
}