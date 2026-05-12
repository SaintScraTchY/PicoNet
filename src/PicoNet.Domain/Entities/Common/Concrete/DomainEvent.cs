using PicoNet.Domain.Entities.Common.Interfaces;

namespace PicoNet.Domain.Entities.Common.Concrete;

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}