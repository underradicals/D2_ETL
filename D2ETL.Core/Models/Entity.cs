using System.Diagnostics;
using MediatR;

namespace D2ETL.Core.Models;

public abstract class Entity
{
    public long Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    private readonly List<DomainEvent> _domainEvents = new();
    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    protected Entity() // Required By ORM
    {
    }

    protected Entity(long id)
    {
        Id = id;
    }

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public override bool Equals(object? obj) => 
        obj is Entity other && 
        ReferenceEquals(this, other) == true &&
        GetUnproxiedType(this) == GetUnproxiedType(other) &&
        (!Id.Equals(0) && !other.Id.Equals(0)) &&
        Id.Equals(other.Id);
    
    public static bool operator ==(Entity? left, Entity? right) =>
        (left is null && right is null) || 
        (left is not null && left.Equals(right)); 

    public static bool operator !=(Entity a, Entity b) => !(a == b);
    
    public override int GetHashCode() => (GetUnproxiedType(this)?.ToString() + Id).GetHashCode();

    private static Type? GetUnproxiedType(object obj) => 
        obj.GetType().ToString().Contains("Castle.Proxies.") || 
        obj.GetType().ToString().EndsWith("Proxy") ? 
            obj.GetType().BaseType : 
            obj.GetType();
}