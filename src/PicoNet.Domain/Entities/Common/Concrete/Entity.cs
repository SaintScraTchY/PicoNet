using PicoNet.Domain.Entities.Common.Interfaces;

namespace PicoNet.Domain.Entities.Common.Concrete;

public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>, IHasDomainEvents 
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public TId Id { get; protected init; } = default!;
    
    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return other.GetType() == GetType() && Id.Equals(other.Id);
    }
    
    public override bool Equals(object? obj)
        => obj is Entity<TId> other && Equals(other);
    
    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);
    
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
        => left.Equals(right);
    
    public static bool operator !=(Entity<TId> left, Entity<TId> right) 
        => !left.Equals(right);
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents 
        => _domainEvents.AsReadOnly();
    
    public void ClearDomainEvents() 
        => _domainEvents.Clear();
    
    public void AddDomainEvents(IEnumerable<IDomainEvent> domainEvents) 
        => _domainEvents.AddRange(domainEvents);
    
    public void AddDomainEvent(IDomainEvent domainEvent) 
        => _domainEvents.Add(domainEvent);
}