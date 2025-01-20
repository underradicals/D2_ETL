using MediatR;

namespace Playground.TestMediatR;

public class Subscriber1 : INotificationHandler<Publisher>
{
    public Task Handle(Publisher notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Publisher received: {nameof(Subscriber1)}");
        
        return Task.CompletedTask;
    }
}