using MediatR;

namespace D2ETL.Core;

public record DomainEvent(long Id) : INotification;