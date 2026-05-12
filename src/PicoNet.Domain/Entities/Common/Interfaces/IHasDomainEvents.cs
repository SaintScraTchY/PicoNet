namespace PicoNet.Domain.Entities.Common.Interfaces;

public interface IHasDomainEvents
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
    void AddDomainEvents(IEnumerable<IDomainEvent> domainEvents);
    void AddDomainEvent(IDomainEvent domainEvent);
}