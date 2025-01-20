using MediatR;

namespace D2ETL.Core.DamageTypeDefinition;

public class DomainTypeViewedEventHandler : INotificationHandler<DamageTypeViewedEvent>
{
    public Task Handle(DamageTypeViewedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"DomainTypeViewedEventHandler: Fired {{notification.Id}}");
        
        return Task.CompletedTask;
    }
}